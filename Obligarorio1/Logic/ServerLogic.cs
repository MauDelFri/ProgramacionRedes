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

        public ServerLogic()
        {
            Repository.Initialize();
            this.thread = new Thread(() => new ServerConnection());
            this.thread.Start();
        }

        public List<User> GetRegisteredUsers()
        {
            return Repository.Users;
        }

        public List<Session> GetConnectedSessions()
        {
            return Repository.ConnectedSessions;
        }
    }
}
