using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using teste.Forms;
using teste.Logger;

namespace teste.forms
{
    public partial class TestLoop : Form
    {
        // ===============================
        // CHAMPS GLOBAUX
        // ===============================
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private static readonly HttpClient _http = new HttpClient();

        // ===============================
        // HISTORIQUE DES TESTS
        // ===============================
        private readonly List<PortTestResult> _portTestHistory = new List<PortTestResult>();

        private class PortTestResult
        {
            public DateTime DateTest { get; set; }
            public string ServerIp { get; set; }
            public int PortId { get; set; }
            public bool Success { get; set; }
            public double ResponseTimeSeconds { get; set; }
            public string Message { get; set; }
        }

        // ===============================
        // CONSTRUCTEUR
        // ===============================
        public TestLoop()
        {
            InitializeComponent();

            ConsoleLogger.Initialize(txtlog); 
            this.AcceptButton = null;
            btnstop.Enabled = false;

            txtip.KeyDown += txtip_KeyDown;

            _http.Timeout = TimeSpan.FromSeconds(20);

            _cts = new CancellationTokenSource();

            Log.OnLog += AddLog;
            Log.Info("TEST AUTOSTORE : message au démarrage");
        }


        //partage des log 
        private void AddLog(string message)
        {
            if (txtlog.InvokeRequired)
            {
                txtlog.Invoke(new Action(() => AddLog(message)));
                return;
            }

            txtlog.AppendText(message + Environment.NewLine);
        }


        private void txtip_Enter(object sender, EventArgs e)
        {
            // volontairement vide
        }
        private async Task<int> CreateTaskGroupAsync(string endpoint, int numberOfTasks)
        {
            int taskGroupId = (int)(DateTime.UtcNow.Ticks % int.MaxValue);

            StringBuilder tasksXml = new StringBuilder();

            for (int i = 1; i <= numberOfTasks; i++)
            {
                tasksXml.Append(
                    "<task>" +
                    $"<task_id>{taskGroupId + i}</task_id>" +
                    "</task>"
                );
            }

            string xml =
                "<?xml version=\"1.0\"?>" +
                "<methodcall>" +
                "<name>create_taskgroup</name>" +
                "<params>" +
                $"<taskgroup_id>{taskGroupId}</taskgroup_id>" +
                "<category>1</category>" +
                "<priority>10</priority>" +
                $"<req_time>{DateTime.UtcNow:yyyy-MM-ddTHH:mm:ssZ}</req_time>" +
                "<tasks>" +
                tasksXml +
                "</tasks>" +
                "</params>" +
                "</methodcall>";

            await PostXmlAsync(endpoint, xml, CancellationToken.None);

            ConsoleLogger.Info($"TASKGROUP CRÉÉE : ID={taskGroupId} ({numberOfTasks} tâches)");

            return taskGroupId;
        }

        private async Task RunV1_TaskGroupTestAsync(string server, int portId)
        {
            string endpoint = $"http://{server}:44000/api/v2/task";

            try
            {
                ConsoleLogger.Info("=== TEST V1 AVEC TASKGROUP ===");

                // 1️⃣ Création taskgroup (10 tâches)
                int taskGroupId = await CreateTaskGroupAsync(endpoint, 10);

                // 2️⃣ OPENPORT
                await PostXmlAsync(endpoint,
                    BuildXml("openport",
                        $"<port_id>{portId}</port_id>"),
                    CancellationToken.None);

                ConsoleLogger.Info("OPENPORT OK");

                // 3️⃣ Consommation des 10 tâches par le port
                for (int i = 1; i <= 10; i++)
                {
                    ConsoleLogger.Info($"OPENBIN (task {i}/10)");

                    string openResp = await PostXmlAsync(endpoint,
                        BuildXml("openbin",
                            $"<port_id>{portId}</port_id>" +
                            $"<taskgroup_id>{taskGroupId}</taskgroup_id>"),
                        CancellationToken.None);

                    int binId, taskId;
                    ParseOpenBin(openResp, out binId, out taskId);

                    // CLOSEBIN (attente prêt)
                    while (true)
                    {
                        string closeResp = await PostXmlAsync(endpoint,
                            BuildXml("closebin",
                                $"<port_id>{portId}</port_id>" +
                                $"<bin_id>{binId}</bin_id>" +
                                $"<task_id>{taskId}</task_id>"),
                            CancellationToken.None);

                        if (TryParseFault(closeResp, out int fault))
                        {
                            if (fault == 1027)
                            {
                                await Task.Delay(500);
                                continue;
                            }
                            throw new Exception("CLOSEBIN fault=" + fault);
                        }
                        break;
                    }

                    // FLUSH
                    await PostXmlAsync(endpoint,
                        BuildXml("flushportbin",
                            $"<port_id>{portId}</port_id>" +
                            $"<bin_id>{binId}</bin_id>"),
                        CancellationToken.None);

                    ConsoleLogger.Info($"TASK {i} TERMINÉE");
                }

                // 4️⃣ CLOSEPORT
                await PostXmlAsync(endpoint,
                    BuildXml("closeport",
                        $"<port_id>{portId}</port_id>"),
                    CancellationToken.None);

                ConsoleLogger.Info("CLOSEPORT OK");
                ConsoleLogger.Info("=== TEST V1 TERMINÉ ===");
            }
            catch (Exception ex)
            {
                ConsoleLogger.Error("ERREUR V1 : " + ex.Message);
            }
        }

        // ===============================
        // AFFICHAGE DES TRAMES
        // ===============================
        private void ShowSend(string xml)
        {
            txtSend.Clear();
            txtSend.AppendText(xml);
        }

        private void ShowReceive(string xml)
        {
            txtReceive.Clear();
            txtReceive.AppendText(xml);
        }
        private async Task<string> PostXmlAsync(string url, string xml, CancellationToken ct)
        {
            ShowSend(xml);

            using (var content = new StringContent(xml, Encoding.UTF8, "application/xml"))
            using (HttpResponseMessage resp = await _http.PostAsync(url, content, ct))
            {
                string responseXml = await resp.Content.ReadAsStringAsync();
                ShowReceive(responseXml);
                return responseXml;
            }
        }
        //
        //METHODE
        //
        private void ParseOpenBin(string xml, out int binId, out int taskId)
        {
            binId = 0;
            taskId = 0;

            if (TryParseFault(xml, out int fault))
                throw new Exception("AutoStore fault openbin=" + fault);

            XDocument doc = XDocument.Parse(xml);
            XElement p = doc.Root.Element("params");

            if (p == null)
                throw new Exception("Réponse invalide : <params> manquant");

            binId = int.Parse(p.Element("bin_id").Value);
            taskId = int.Parse(p.Element("task_id").Value);
        }

        private bool TryParseFault(string xml, out int code)
        {
            code = 0;

            try
            {
                XDocument d = XDocument.Parse(xml);
                XElement fault = d.Root.Element("fault");
                if (fault == null) return false;

                code = int.Parse(fault.Element("code").Value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string BuildXml(string method, string innerParams)
        {
            return
                "<?xml version=\"1.0\"?>" +
                "<methodcall>" +
                "<name>" + method + "</name>" +
                "<params>" +
                innerParams +
                "</params>" +
                "</methodcall>";
        }



        // ===============================
        // TEST CONNEXION (ENTER)
        // ===============================
        private async void txtip_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await PingEndpointAsync();
            }
        }

        private async Task PingEndpointAsync()
        {
            txtlog.Clear();
            txtSend.Clear();
            txtReceive.Clear();
            txtResponseTime.Text = "";

            string server = txtip.Text.Trim();
            int portId = int.TryParse(txtPort.Text, out int p) ? p : -1;

            if (string.IsNullOrEmpty(server))
            {
                ConsoleLogger.Error("IP / serveur non renseigné");
                return;
            }

            string endpoint = $"http://{server}:44000/api/v2/task";
            ConsoleLogger.Info("TEST CONNEXION AUTOSTORE");
            ConsoleLogger.Info("Endpoint : " + endpoint);

            Stopwatch sw = Stopwatch.StartNew();

            try
            {
                using (HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Head, endpoint))
                {
                    HttpResponseMessage resp = await _http.SendAsync(req);
                    sw.Stop();

                    double sec = sw.Elapsed.TotalSeconds;
                    txtResponseTime.Text = sec.ToString("0.00") + " s";

                    ConsoleLogger.Info("Connexion OK");
                    ConsoleLogger.Info("HTTP " + (int)resp.StatusCode);

                    _portTestHistory.Add(new PortTestResult
                    {
                        DateTest = DateTime.Now,
                        ServerIp = server,
                        PortId = portId,
                        Success = true,
                        ResponseTimeSeconds = sec,
                        Message = "HTTP OK"
                    });
                }
            }
            catch (Exception ex)
            {
                sw.Stop();
                txtResponseTime.Text = "Erreur";
                ConsoleLogger.Error(ex.Message);

                _portTestHistory.Add(new PortTestResult
                {
                    DateTest = DateTime.Now,
                    ServerIp = server,
                    PortId = portId,
                    Success = false,
                    ResponseTimeSeconds = 0,
                    Message = ex.Message
                });
            }
        }

        // ===============================
        // START / STOP
        // ===============================
    private async void btnstart_Click(object sender, EventArgs e)
    {

        // Si le port est invalide, on force 0 (ou ton port par défaut)
        int.TryParse(txtPort.Text, out int port);

        try
        {
            await RunV1_TaskGroupTestAsync(txtip.Text.Trim(), port);

                ConsoleLogger.Info("VALIDATION : Trame envoyée et task terminée");
        }
        catch (Exception ex)
        {
                ConsoleLogger.Error("ERREUR : Trame non envoyée - " + ex.Message);
        }
    }


        private void btnstop_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            btnstop.Enabled = false;
        }

        // ===============================
        // RAPORT LOG
        // ===============================
        private string BuildReportText()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("RAPPORT TEST AUTOSTORE");
            sb.AppendLine("Généré le : " + DateTime.Now);
            sb.AppendLine();

            foreach (var r in _portTestHistory)
            {
                sb.AppendLine($"Test port {r.PortId}");
                sb.AppendLine($"IP        : {r.ServerIp}");
                sb.AppendLine($"Résultat  : {(r.Success ? "OK" : "ECHEC")}");
                sb.AppendLine($"Temps rep.: {r.ResponseTimeSeconds:0.00} s");
                sb.AppendLine("----------------------------------");
            }

            sb.AppendLine();
            sb.AppendLine("TEMPS MOYEN PAR PORT");

            foreach (var g in _portTestHistory.Where(x => x.Success).GroupBy(x => x.PortId))
            {
                sb.AppendLine($"Port {g.Key} : {g.Average(x => x.ResponseTimeSeconds):0.00} s");
            }

            return sb.ToString();
        }

        private void GenerateTxtReport(string filePath)
        {
            File.WriteAllText(filePath, BuildReportText(), Encoding.UTF8);
            ConsoleLogger.Info("Rapport TXT généré");
            ConsoleLogger.Info("Chemin : " + filePath);
        }

        private void generateReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_portTestHistory.Count == 0)
            {
                informationLoggin();
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Rapport TXT (*.txt)|*.txt";
                sfd.FileName = "Rapport_AutoStore_" +
                    DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
                sfd.InitialDirectory =
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (sfd.ShowDialog() == DialogResult.OK)
                    GenerateTxtReport(sfd.FileName);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            Log.OnLog -= AddLog;
            base.OnFormClosed(e);
        }

        private bool informationLoggin()
        {
            string title = "Export Log";
            string message = "Aucun test enregistré";


            DialogResult res = ASMessageBox.Show(
                message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return (res == DialogResult.OK);
        }
    }
}
