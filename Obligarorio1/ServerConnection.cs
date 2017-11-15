using Domain;
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
        public static List<HandleClient> ConnectedClients { get; set; }
        public static RepositoryAccesor RepositoryAccesor { get; set; }
        public static LogAccesor LogAccesor { get; set; }

        public ServerConnection(string serverIp, int serverPort)
        {
            ConnectedClients = new List<HandleClient>();
            LogAccesor = new LogAccesor();
            RepositoryAccesor = new RepositoryAccesor();
            RepositoryAccesor.Initialize();
            var serverIPEndPoint = new IPEndPoint(IPAddress.Parse(serverIp), serverPort);
            var serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(serverIPEndPoint);
            serverSocket.Listen(100);

            while (true)
            {
                Console.WriteLine("Start waiting for client");
                var clientSocket = serverSocket.Accept();
                Thread thread = new Thread(() => new HandleClient(clientSocket));
                thread.IsBackground = true;
                thread.Start();
                Console.WriteLine("Client connected");
            }

            Console.ReadLine();
            serverSocket.Close();
        }

        public static HandleClient GetUserSession(User user)
        {
            return ConnectedClients.Find(s => s.CurrentSession.User.Equals(user));
        }

        public static void DisconnectUser(User user)
        {
            ConnectedClients.Remove(GetUserSession(user));
        }
    }
}
