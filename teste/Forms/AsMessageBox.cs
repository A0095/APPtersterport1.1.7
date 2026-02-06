using System;
using System.Drawing;

using System.Windows.Forms;

namespace teste.Forms
{
    public partial class AsMessageBoxDialog : Form
    {

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message
        {
            get { return lblMessage__NT.Text; }
            set { lblMessage__NT.Text = value; }
        }


        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get { return Text; }
            set { Text = value; }
        }

        /// <summary>
        /// Gets or sets the icon for the form.
        /// </summary>
        public Image MessageIcon
        {
            get { return picIcon.Image; }
            set { picIcon.Image = value; }
        }

        public AsMessageBoxDialog()
        {
            InitializeComponent();
            lblMessage__NT.TextAlign = ContentAlignment.MiddleCenter;
        }

        /// <summary>
        /// Initializes the buttons.
        /// </summary>
        /// <param name="buttons">The buttons.</param>
        public void InitializeButtons(MessageBoxButtons buttons)
        {
            buttonBar.Buttons = buttons;
        }

        public void InitializeIcon(MessageBoxIcon icon)
        {
            picIcon.Image = ASIcon.ForMessageBox(icon);
        }

    }

    public static class ASMessageBox
    {

        public static DialogResult Show(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            AsMessageBoxDialog box = Instance;
            box.Message = message;
            box.Title = title;
            box.InitializeButtons(buttons);
            box.InitializeIcon(icon);

            return box.ShowDialog();
        }



        private static AsMessageBoxDialog Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AsMessageBoxDialog();
                return _instance;
            }
        }

        private static AsMessageBoxDialog _instance = null;
    }


    public static class ASIcon
    {
        public static readonly Image Question = Properties.Resources.dialog_question;
        public static readonly Image Warning = Properties.Resources.dialog_warning;
        public static readonly Image Info = Properties.Resources.dialog_information;
        public static readonly Image Password = Properties.Resources.dialog_password;
        public static readonly Image Error = Properties.Resources.dialog_error;
        public static readonly Image None = null;

        public static Image ForMessageBox(MessageBoxIcon icon)
        {
            switch (icon)
            {
                case MessageBoxIcon.Information:
                    return Info;
                case MessageBoxIcon.None:
                    return None;
                case MessageBoxIcon.Question:
                    return Question;
                case MessageBoxIcon.Error:
                    return Error;
                case MessageBoxIcon.Warning:
                    return Warning;
                default:
                    throw new NotSupportedException("Icon " + icon + " not supported, sorry.");
            }
        }


    }
}
