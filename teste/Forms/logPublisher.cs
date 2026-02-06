using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using teste.Logger;


namespace teste.Forms
{
    public partial class logPublisher : Form
    {
        private TcpLpClient _client;

        public logPublisher()
        {
            InitializeComponent();

            _client = new TcpLpClient("127.0.0.1", 44001);
            _client.LineReceived += OnLineReceived;
            Task.Run(() => _client.StartAsync());
        }

        private void OnLineReceived(string line)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(OnLineReceived), line);
                return;
            }

            richTextBox1.AppendText(line + Environment.NewLine);
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }
    }
}
