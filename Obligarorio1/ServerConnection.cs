using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Obligarorio1
{
    public class ServerConnection
    {
        public ServerConnection()
        {
            var serverIPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6000);
            var serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(serverIPEndPoint);
            serverSocket.Listen(100);

            while (true)
            {
                Console.WriteLine("Start waiting for client");
                var clientSocket = serverSocket.Accept();
                Thread thread = new Thread(() => new HandleClient(clientSocket));
                thread.Start();
                Console.WriteLine("Client connected");
            }

            Console.ReadLine();
            serverSocket.Close();
        }
    }
}
