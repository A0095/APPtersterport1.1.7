using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teste
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void commissioningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string password = AskCommissioningPassword();

            if (password != "1234") // mot de passe commissioning
            {
                MessageBox.Show(
                    "Mot de passe incorrect",
                    "Accès refusé",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Accès autorisé → ouvrir Form1
            this.DialogResult = DialogResult.OK;
            this.Close();
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

                Label lbl = new Label()
                {
                    Text = "Mot de passe :",
                    Left = 20,
                    Top = 20
                };

                TextBox txt = new TextBox()
                {
                    Left = 20,
                    Top = 45,
                    Width = 240,
                    PasswordChar = '*'
                };

                Button btnOk = new Button()
                {
                    Text = "OK",
                    Left = 160,
                    Width = 100,
                    Top = 80,
                    DialogResult = DialogResult.OK
                };

                prompt.Controls.Add(lbl);
                prompt.Controls.Add(txt);
                prompt.Controls.Add(btnOk);
                prompt.AcceptButton = btnOk;

                return prompt.ShowDialog() == DialogResult.OK
                    ? txt.Text
                    : null;
            }
        }



    }

    //
    //
    //

}
