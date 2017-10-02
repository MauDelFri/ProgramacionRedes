using Client.Logic;
using Obligarorio1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    public class ClientConnection
    {
        private Socket socket;

        public ClientConnection() { }

        public void Connect(string serverIp, int serverPort, string clientIp, int clientPort)
        {
            var serverIPEndPoint = new IPEndPoint(IPAddress.Parse(serverIp), serverPort);
            var clientIPEndPoint = new IPEndPoint(IPAddress.Parse(clientIp), clientPort);
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.socket.Bind(clientIPEndPoint);
            this.socket.Connect(serverIPEndPoint);
            Store.GetInstance().socket = this.socket;
            Thread thread = new Thread(() => new HandleServer(this.socket));
            thread.IsBackground = true;
            thread.Start();
        }

        public Socket GetClientSocket()
        {
            return this.socket;
        }
    }
}
