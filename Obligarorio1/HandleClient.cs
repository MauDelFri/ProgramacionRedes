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
        public FunctionalityMapper Mapper;

        public HandleClient(Socket clientSocket)
        {
            this.Mapper = new FunctionalityMapper();

            while (true)
            {
                if (!SocketExtensions.IsConnected(clientSocket))
                {
                    break;
                }

                ProtocolItem message = SocketUtils.RecieveMessage(clientSocket);
                Console.WriteLine(message);
                this.Mapper.MapCommandToService(message);
            }

            Console.WriteLine("El cliente se desconecto");
            clientSocket.Close();
        }
    }
}
