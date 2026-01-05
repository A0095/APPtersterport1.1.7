using System;

namespace teste
{
    public static class AppLogger
    {
        public static event Action<string> OnLog;

        public static void Info(string message)
        {
            Write("INFO", message);
        }

        public static void Error(string message)
        {
            Write("ERROR", message);
        }

        private static void Write(string level, string message)
        {
            string line = $"[{DateTime.Now:HH:mm:ss}] [{level}] {message}";
            OnLog?.Invoke(line);
        }
    }
}
