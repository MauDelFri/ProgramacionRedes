using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Obligarorio1
{
    public class HandleClient
    {
        private FunctionalityMapper mapper;
        private Socket clientSocket;
        public Session CurrentSession { get; set; }

        public HandleClient(Socket clientSocket)
        {
            this.clientSocket = clientSocket;
            this.mapper = new FunctionalityMapper();

            while (true)
            {
                if (!SocketExtensions.IsConnected(this.clientSocket))
                {
                    break;
                }

                ProtocolItem message = SocketUtils.RecieveMessage(this.clientSocket);
                Console.WriteLine(message);
                this.mapper.MapCommandToService(message, this);
            }

            Console.WriteLine("El cliente se desconecto");
            clientSocket.Close();
        }

        public void AcknowledgeResponse()
        {
            ProtocolItem responseMessage = this.CreateProtocolItem(Constants.RESPONSE_HEADER, Constants.OK_CODE, "");
            SocketUtils.SendMessage(this.clientSocket, responseMessage);
        }

        public void ErrorResponse(string errorMessage)
        {
            ProtocolItem responseMessage = this.CreateProtocolItem(Constants.RESPONSE_HEADER, Constants.ERROR_CODE, errorMessage);
            SocketUtils.SendMessage(this.clientSocket, responseMessage);
        }

        public void MessageResponse(string data)
        {
            ProtocolItem responseMessage = this.CreateProtocolItem(Constants.RESPONSE_HEADER, Constants.OK_CODE, data);
            SocketUtils.SendMessage(this.clientSocket, responseMessage);
        }

        public void SendMessage(string data, int command)
        {
            ProtocolItem responseMessage = this.CreateProtocolItem(Constants.REQUEST_HEADER, command, data);
            SocketUtils.SendMessage(this.clientSocket, responseMessage);
        }

        private ProtocolItem CreateProtocolItem(string header, int command, string data)
        {
            ProtocolItem responseMessage = new ProtocolItem();
            responseMessage.Header = header;
            responseMessage.Command = command;
            responseMessage.Data = data;
            responseMessage.MessageLength = System.Text.Encoding.ASCII.GetBytes(responseMessage.Data).Length;

            return responseMessage;
        }
    }
}
