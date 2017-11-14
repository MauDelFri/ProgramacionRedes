using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LogServer
{
    public class LogMessageReveiver
    {
        public LogMessageReveiver()
        {
            MessageQueue messageQueue = new MessageQueue(@".\Private$\myqueue");
            messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(Log) });

            while (true)
            {
                Log message = (Log)messageQueue.Receive().Body;
                Store.GetInstance().AddLog(message);
            }
        }
    }
}
