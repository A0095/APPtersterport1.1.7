using System;
using System.Linq;
using System.Windows.Forms;
using teste.Forms;

namespace teste.forms
{
    public partial class FormLogin : Form
    {
        private readonly string[] languages = { "fr", "en", "de", "es" };

        public FormLogin()
        {
            InitializeComponent();

            // Charger la langue par défaut
            ApplyLanguage("fr");

            // Sauvegarde automatique à la fermeture
            this.FormClosing += MainForm_FormClosing;
        }

        // --- Boutons de langue ---
        private void frecnhToolStripMenuItem_Click(object sender, EventArgs e) => ApplyLanguage("fr");
        private void englishToolStripMenuItem_Click(object sender, EventArgs e) => ApplyLanguage("en");
        private void germanToolStripMenuItem_Click(object sender, EventArgs e) => ApplyLanguage("de");
        private void spanishToolStripMenuItem_Click(object sender, EventArgs e) => ApplyLanguage("es");

        // --- Appliquer une langue ---
        private void ApplyLanguage(string lang)
        {
            LanguageManager.SetLanguage(lang); // si tu as un LanguageManager
            AutoTranslationManager.LoadLanguage(lang); // charge le dictionnaire de cette langue
            AutoTranslationManager.TranslateAllOpenForms(); // applique la traduction partout
        }

        // --- Sauvegarde JSON ---
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var lang in languages)
                AutoTranslationManager.SaveCurrentLanguage(lang);
        }

        // --- Exemple Commissioning ---
        private void commissioningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string password = AskCommissioningPassword();
            if (password != "1234") { informationPassword(); return; }

            btnTestLoop.Visible = true;
            btnLog.Visible = true;
            btnClosed.Visible = true;
        }

        private string AskCommissioningPassword()
        {
            using (Form prompt = new Form())
            {
                prompt.Width = 300;
                prompt.Height = 150;
                prompt.Text = "Accès Commissioning";
                prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                prompt.StartPosition = FormStartPosition.CenterParent;

                Label lbl = new Label() { Text = "Mot de passe :", Left = 20, Top = 20 };
                TextBox txt = new TextBox() { Left = 20, Top = 45, Width = 240, PasswordChar = '*' };
                Button btnOk = new Button() { Text = "OK", Left = 160, Width = 100, Top = 80, DialogResult = DialogResult.OK };

                prompt.Controls.Add(lbl);
                prompt.Controls.Add(txt);
                prompt.Controls.Add(btnOk);
                prompt.AcceptButton = btnOk;

                return prompt.ShowDialog() == DialogResult.OK ? txt.Text : null;
            }
        }

        // --- Boutons ---
        private void btnLog_Click(object sender, EventArgs e)
        {
            btnLog.Enabled = false;
            logPublisher lp = new logPublisher();

            // 1️⃣ Traduire le form avant de l'afficher
            AutoTranslationManager.Translate(lp);

            // 2️⃣ Réactiver le bouton à la fermeture
            lp.FormClosed += (s, args) => btnLog.Enabled = true;
            lp.Show();
        }

        private void btnTestLoop_Click(object sender, EventArgs e)
        {
            btnTestLoop.Enabled = false;
            TestLoop testLoop = new TestLoop();

            // Traduire le form avant Show
            AutoTranslationManager.Translate(testLoop);

            testLoop.FormClosed += (s, args) => btnTestLoop.Enabled = true;
            testLoop.Show();
        }

        private void btnClosed_Click(object sender, EventArgs e) => Application.Exit();

        private void versionToolStripMenuItem_Click(object sender, EventArgs e) => informationWindows();

        private bool informationWindows()
        {
            string title = "About Page";
            string message = "AutoStore template \n\r\nVersion :  " + Application.ProductVersion;
            DialogResult res = ASMessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return res == DialogResult.OK;
        }

        private bool informationPassword()
        {
            string title = "Mot de passe incorrect";
            string message = "Accès refusé";
            DialogResult res = ASMessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return res == DialogResult.Cancel;
        }
    }
}
