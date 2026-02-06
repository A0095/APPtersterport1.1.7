using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace teste
{
    public class TcpLpClient
    {
        public event Action<string> LineReceived;

        private readonly string _ipAddress;
        private readonly int _port;
        private readonly int _reconnectDelayMs = 3000;

        private CancellationTokenSource _cts;

        // Synchronisation
        private string _lastLine = null;
        private bool _syncFound = false;

        public TcpLpClient(string ipAddress, int port)
        {
            _ipAddress = ipAddress;
            _port = port;
        }

        public async Task StartAsync()
        {
            _cts = new CancellationTokenSource();

            while (!_cts.IsCancellationRequested)
            {
                try
                {
                    using (TcpClient client = new TcpClient())
                    {
                        LineReceived?.Invoke(WithTimestamp("Connecting..."));
                        await client.ConnectAsync(_ipAddress, _port);

                        LineReceived?.Invoke(WithTimestamp("Connected"));

                        using (StreamReader reader =
                               new StreamReader(client.GetStream()))
                        {
                            string line;

                            //  À chaque reconnexion, on repart en mode synchro
                            _syncFound = _lastLine == null;

                            while (!_cts.IsCancellationRequested &&
                                   (line = await reader.ReadLineAsync()) != null)
                            {
                                //  Phase d’alignement (ignorer l’historique)
                                if (!_syncFound)
                                {
                                    if (line == _lastLine)
                                    {
                                        _syncFound = true;
                                    }
                                    continue;
                                }

                                //  Lecture normale
                                LineReceived?.Invoke(WithTimestamp(line));
                                _lastLine = line;
                            }
                        }
                    }

                    LineReceived?.Invoke(WithTimestamp("Connection closed"));
                }
                catch (Exception ex)
                {
                    LineReceived?.Invoke(WithTimestamp("ERROR: " + ex.Message));
                }

                if (!_cts.IsCancellationRequested)
                {
                    LineReceived?.Invoke(WithTimestamp("Reconnecting..."));
                    await Task.Delay(_reconnectDelayMs);
                }
            }
        }

        public void Stop()
        {
            _cts?.Cancel();
        }

        private string WithTimestamp(string message)
        {
            return $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] {message}";
        }

    }
}
