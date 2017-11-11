using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain;

namespace Obligarorio1.Logic
{
    public class ServerLogic
    {
        private Thread thread;

        public ServerLogic(string serverIp, int serverPort)
        {
            this.thread = new Thread(() => new ServerConnection(serverIp, serverPort));
            this.thread.Start();
        }

        public List<User> GetRegisteredUsers()
        {
            return ServerConnection.RepositoryAccesor.GetRegisteredUsers();
        }

        public List<Session> GetConnectedSessions()
        {
            return ServerConnection.ConnectedClients.Select(h => h.CurrentSession).ToList();
        }
    }
}
