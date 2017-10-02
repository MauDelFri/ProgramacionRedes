using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Obligarorio1
{
    public class HandleServer
    {
        private ResponseMapper mapper;
        private Socket serverSocket;

        public HandleServer(Socket serverSocket)
        {
            this.serverSocket = serverSocket;
            this.mapper = new ResponseMapper();

            while (true)
            {
                if (!SocketExtensions.IsConnected(this.serverSocket))
                {
                    break;
                }

                ProtocolItem message = SocketUtils.RecieveMessage(this.serverSocket);
                Console.WriteLine(message);
                this.mapper.MapHeaderToAction(message);
            }

            Console.WriteLine("El cliente se desconecto");
            serverSocket.Close();
        }

        public void SendMessage(string header, int command, string data)
        {
            ProtocolItem responseMessage = this.CreateProtocolItem(header, command, data);
            SocketUtils.SendMessage(this.serverSocket, responseMessage);
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
