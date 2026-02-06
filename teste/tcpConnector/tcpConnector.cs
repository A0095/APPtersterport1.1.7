using System;
using System.Net.Sockets;
using System.Text;
using System.Xml.Linq;

 

   public class tcpConnector

    {

        static void LogPublisher()

        {

            string serverIp = "127.0.0.1";

            int port = 44001;
            TcpClient client = new TcpClient();

            client.Connect(serverIp, port);
            NetworkStream stream = client.GetStream();
            while (true)

            {


                string message = Console.ReadLine();

                if (string.IsNullOrEmpty(message))

                    break;
                byte[] data = Encoding.UTF8.GetBytes(message);

                stream.Write(data, 0, data.Length);
                byte[] buffer = new byte[1024];

                int bytesRead = stream.Read(buffer, 0, buffer.Length);

                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);


            }
            stream.Close();

            client.Close();

        }
    }
}


