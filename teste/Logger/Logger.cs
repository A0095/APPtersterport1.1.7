using System;
using System.Drawing;
using System.Windows.Forms;

namespace teste.Logger
{
    public static class Log
    {
        public static event Action<string> OnLog;

        public static void Info(string message) => Write(LogLevel.Info, message);
        public static void Error(string message) => Write(LogLevel.Error, message);
        public static void Debug(string message) => Write(LogLevel.Debug, message);
        public static void Fatal(string message) => Write(LogLevel.Fatal, message);
        public static void Debug2(string message) => Write(LogLevel.Debug2, message);
        public static void Debug3(string message) => Write(LogLevel.Debug3, message);

        private static void Write(LogLevel level, string message)
        {
            string line = $"[{DateTime.Now:HH:mm:ss.fff}] [{level}] {message}";
            OnLog?.Invoke(line);
        }

    }

    public static class ConsoleLogger
    {
        private static RichTextBox _txtLog;

        public static void Initialize(RichTextBox richTextBox)
        {
            _txtLog = richTextBox;
        }

        public static void Info(string msg) => AppendLog(msg, Color.Black);
        public static void Error(string msg) => AppendLog(msg, Color.Red);

        private static void AppendLog(string msg, Color color)
        {
            if (_txtLog == null) return;

            if (_txtLog.InvokeRequired)
            {
                _txtLog.BeginInvoke(new Action(() => AppendLog(msg, color)));
                return;
            }

            _txtLog.SelectionStart = _txtLog.TextLength;
            _txtLog.SelectionLength = 0;
            _txtLog.SelectionColor = color;          
            _txtLog.AppendText($"[{DateTime.Now:HH:mm:ss.fff}] {msg}{Environment.NewLine}");
            _txtLog.SelectionColor = _txtLog.ForeColor;
            _txtLog.ScrollToCaret();
        }
    }
}
