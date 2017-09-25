using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Exceptions;
using Utils;
using System.Net.Sockets;
using System.Net;

namespace Client
{
    public class ClientService
    {
        private Socket socket;

        public ClientService()
        {
            var serverIPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6000);
            var clientIPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 0);
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.socket.Bind(clientIPEndPoint);
            this.socket.Connect(serverIPEndPoint);
        }

        public void TryLogin(string username, string password)
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                throw new EmptyFieldsException("Complete all fileds");
            }

            if (username.Contains("-") || password.Contains("-"))
            {
                throw new InvalidCharactersException("The fields can not contain '-'");
            }

            String dataToSend = username + "-" + password;
            ProtocolItem message = new ProtocolItem(Constants.REQUEST_HEADER, Constants.LOGIN_CODE, dataToSend);
            SocketUtils.SendMessage(this.socket, message);
            ProtocolItem response = SocketUtils.RecieveMessage(this.socket);
            this.OnLoginResponse(response);
        }

        private void OnLoginResponse(ProtocolItem response)
        {
            if (response.Command == Constants.ERROR_CODE)
            {
                throw new ServerException(response.Data);
            }
        }
    }
}
