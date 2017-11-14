using Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utils;

namespace Obligarorio1
{
    public class HandleClient
    {
        private FunctionalityMapper mapper;
        private Socket clientSocket;
        public Session CurrentSession { get; set; }
        public ReplaySubject<ProtocolItem> PendingMessage { get; set; }

        public HandleClient(Socket clientSocket)
        {
            this.clientSocket = clientSocket;
            this.mapper = new FunctionalityMapper();
            this.PendingMessage = new ReplaySubject<ProtocolItem>();
            this.PendingMessage.Subscribe(message => this.OnPendingMessageSend(message));

            while (true)
            {
                if (!SocketExtensions.IsConnected(this.clientSocket))
                {
                    break;
                }
                ProtocolItem message;
                try
                {
                    message = SocketUtils.RecieveMessage(this.clientSocket);
                }
                catch (SocketException e)
                {
                    break;
                }

                if (message.Command == Constants.DISCONNECT_CLIENT)
                {
                    ServerConnection.DisconnectUser(this.CurrentSession.User);
                    break;
                }

                Console.WriteLine(message);
                this.mapper.MapCommandToService(message, this);
            }

            Console.WriteLine("El cliente se desconecto");
            clientSocket.Close();
        }

        public void SendMessage(string header, int command, string data)
        {
            ProtocolItem responseMessage = this.CreateProtocolItem(header, command, data);
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

        private void OnPendingMessageSend(ProtocolItem message)
        {
            SocketUtils.SendMessage(this.clientSocket, message);
        }

        public string ReceiveFile(long fileLength, string filename)
        {
            return SocketUtils.ReceiveFile(this.clientSocket, fileLength, filename);
        }

        public void SendFileToUser(String filePath, String friendUsername)
        {
            FileStream filestream = new FileStream(filePath, FileMode.Open);
            ProtocolItem message = new ProtocolItem(Constants.REQUEST_HEADER, Constants.RECEIVE_FILE,
                filestream.Length + Constants.ATTRIBUTE_SEPARATOR + filePath.Split('/').Last() + Constants.ATTRIBUTE_SEPARATOR + friendUsername);
            filestream.Close();
            SocketUtils.SendMessage(this.clientSocket, message);
            Thread.Sleep(1000);
            SocketUtils.SendFile(this.clientSocket, filePath);
        }
    }
}
