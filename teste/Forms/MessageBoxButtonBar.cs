using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teste.Forms
{
    public partial class MessageBoxButtonBar : UserControl
    {

        public MessageBoxButtonBar()
        {
            InitializeComponent();
        }

        private MessageBoxButtons _buttons = MessageBoxButtons.OKCancel;

        [DefaultValue(MessageBoxButtons.OKCancel)]
        public MessageBoxButtons Buttons
        {
            get { return _buttons; }
            set
            {
                if (_buttons != value)
                {
                    _buttons = value;
                    InitializeButtons(value);
                }
            }
        }

        public DialogResult DialogResult { get; private set; }

        private void InitializeButtons(MessageBoxButtons buttons)
        {
            btnOk.Visible = false;
            btnCancel.Visible = false;
            btnYes.Visible = false;
            btnNo.Visible = false;

            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    btnOk.Visible = true;
                    break;
                case MessageBoxButtons.OKCancel:
                    btnOk.Visible = true;
                    btnCancel.Visible = true;
                    break;
                case MessageBoxButtons.YesNo:
                    btnYes.Visible = true;
                    btnNo.Visible = true;
                    break;
                case MessageBoxButtons.YesNoCancel:
                    btnYes.Visible = true;
                    btnNo.Visible = true;
                    btnCancel.Visible = true;
                    break;
                default:
                    throw new NotSupportedException("Buttons " + buttons + " not supported, sorry.");
            }
        }

        private void PressButton(DialogResult result)
        {
            Form parent = this.FindForm();
            if (parent != null)
            {
                parent.DialogResult = result;
                parent.Close(); 
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            PressButton(DialogResult.OK);
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            PressButton(DialogResult.No);
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            PressButton(DialogResult.Yes);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            PressButton(DialogResult.Cancel);
        }

    }
}
