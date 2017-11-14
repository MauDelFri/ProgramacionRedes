using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace LogServer
{
    public class Store
    {
        private static Store instance;
        public Socket socket;
        public List<Log> Logs { get; set; }
        public ReplaySubject<List<Log>> LogsPublish { get; set; }

        private Store()
        {
            this.LogsPublish = new ReplaySubject<List<Log>>();
        }

        public static Store GetInstance()
        {
            if (instance == null)
            {
                instance = new Store();
            }

            return instance;
        }

        public void AddLog(Log log)
        {
            this.Logs.Add(log);
            this.LogsPublish.OnNext(this.Logs);
        }
    }
}
