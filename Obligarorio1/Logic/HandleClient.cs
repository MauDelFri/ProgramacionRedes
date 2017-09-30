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
            ProtocolItem responseMessage = new ProtocolItem();
            responseMessage.Header = Constants.RESPONSE_HEADER;
            responseMessage.Command = Constants.OK_CODE;

            SocketUtils.SendMessage(this.clientSocket, responseMessage);
        }

        public void ErrorResponse(string errorMessage)
        {
            ProtocolItem responseMessage = new ProtocolItem();
            responseMessage.Header = Constants.RESPONSE_HEADER;
            responseMessage.Command = Constants.ERROR_CODE;
            responseMessage.Data = errorMessage;
            responseMessage.MessageLength = System.Text.Encoding.ASCII.GetBytes(responseMessage.Data).Length;

            SocketUtils.SendMessage(this.clientSocket, responseMessage);
        }
    }
}
