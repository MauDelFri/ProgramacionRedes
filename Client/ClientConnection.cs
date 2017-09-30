using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ClientConnection
    {
        private Socket socket;

        public ClientConnection() { }

        public void Connect()
        {
            var serverIPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6000);
            var clientIPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 0);
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.socket.Bind(clientIPEndPoint);
            this.socket.Connect(serverIPEndPoint);
        }

        public Socket GetClientSocket()
        {
            return this.socket;
        }
    }
}
