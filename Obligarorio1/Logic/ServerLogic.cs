using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
    }
}
