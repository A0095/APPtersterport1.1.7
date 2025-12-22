using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace teste
{
    public partial class Form1 : Form
    {
        // ===============================
        // CHAMPS GLOBAUX
        // ===============================
        private CancellationTokenSource _cts;
        private static readonly HttpClient _http = new HttpClient();
        private bool DEBUG_MODE = false;

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
        public Form1()
        {
            InitializeComponent();

            this.AcceptButton = null;
            btnstop.Enabled = false;

            txtip.KeyDown += txtip_KeyDown;

            _http.Timeout = TimeSpan.FromSeconds(20);
        }

        private void txtip_Enter(object sender, EventArgs e)
        {
            // volontairement vide
        }

        // ===============================
        // DEBUG MODE (MENU)
        // ===============================
        private void btnDebug_Click(object sender, EventArgs e)
        {
            DEBUG_MODE = !DEBUG_MODE;

            if (DEBUG_MODE)
            {
                debugToolStripMenuItem.Text = "DEBUG : ON";
                LogInfo("DEBUG MODE ACTIVÉ (simulation)");
            }
            else
            {
                debugToolStripMenuItem.Text = "DEBUG : OFF";
                LogInfo("DEBUG MODE DÉSACTIVÉ (mode réel)");
            }
        }

        // ===============================
        // LOGS (NOIR / ROUGE)
        // ===============================
        private void LogInfo(string msg) => AppendLog(msg, Color.Black);
        private void LogError(string msg) => AppendLog(msg, Color.Red);

        private void AppendLog(string msg, Color color)
        {
            if (txtlog.InvokeRequired)
            {
                txtlog.BeginInvoke(new Action(() => AppendLog(msg, color)));
                return;
            }

            txtlog.SelectionStart = txtlog.TextLength;
            txtlog.SelectionLength = 0;
            txtlog.SelectionColor = color;
            txtlog.AppendText($"[{DateTime.Now:HH:mm:ss}] {msg}{Environment.NewLine}");
            txtlog.SelectionColor = txtlog.ForeColor;
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
                LogError("IP / serveur non renseigné");
                return;
            }

            if (DEBUG_MODE)
            {
                SimulateDebugPing(server, portId);
                return;
            }

            string endpoint = $"http://{server}:44000/api/v2/task";
            LogInfo("TEST CONNEXION AUTOSTORE");
            LogInfo("Endpoint : " + endpoint);

            Stopwatch sw = Stopwatch.StartNew();

            try
            {
                using (HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Head, endpoint))
                {
                    HttpResponseMessage resp = await _http.SendAsync(req);
                    sw.Stop();

                    double sec = sw.Elapsed.TotalSeconds;
                    txtResponseTime.Text = sec.ToString("0.00") + " s";

                    LogInfo("Connexion OK");
                    LogInfo("HTTP " + (int)resp.StatusCode);

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
                LogError(ex.Message);

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
        // DEBUG SIMULATIONS
        // ===============================
        private void SimulateDebugPing(string server, int portId)
        {
            double fakeTime = 0.35;
            txtResponseTime.Text = fakeTime.ToString("0.00") + " s";

            LogInfo("[DEBUG] Ping simulé OK");

            _portTestHistory.Add(new PortTestResult
            {
                DateTest = DateTime.Now,
                ServerIp = server,
                PortId = portId,
                Success = true,
                ResponseTimeSeconds = fakeTime,
                Message = "DEBUG MODE"
            });
        }

        private void SimulateDebugProcess()
        {
            LogInfo("[DEBUG] Process AutoStore simulé");

            for (int i = 1; i <= 10; i++)
                LogInfo("[DEBUG] Cycle " + i + " OK");

            _portTestHistory.Add(new PortTestResult
            {
                DateTest = DateTime.Now,
                ServerIp = txtip.Text,
                PortId = int.TryParse(txtPort.Text, out int p) ? p : -1,
                Success = true,
                ResponseTimeSeconds = 3.5,
                Message = "DEBUG Process"
            });
        }

        // ===============================
        // START / STOP
        // ===============================
        private async void btnstart_Click(object sender, EventArgs e)
        {
            if (DEBUG_MODE)
            {
                SimulateDebugProcess();
                return;
            }

            LogInfo("START réel non implémenté ici (debug conseillé)");
        }

        private void btnstop_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            btnstop.Enabled = false;
        }

        // ===============================
        // RAPPORT TXT
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
            LogInfo("Rapport TXT généré");
            LogInfo("Chemin : " + filePath);
        }

        private void generateReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_portTestHistory.Count == 0)
            {
                MessageBox.Show("Aucun test enregistré");
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
    }
}
