﻿using System;
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
            Repository.Initialize();
            this.thread = new Thread(() => new ServerConnection(serverIp, serverPort));
            this.thread.Start();
        }

        public List<User> GetRegisteredUsers()
        {
            return Repository.Users;
        }

        public List<Session> GetConnectedSessions()
        {
            return Repository.ConnectedClients.Select(h => h.CurrentSession).ToList();
        }
    }
}
