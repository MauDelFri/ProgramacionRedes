using Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LogServer
{
    public class LogMessageReceiver
    {
        MessageQueue messageQueue;
        public LogMessageReceiver()
        {
            Configuration configurationManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection configurationCollection = configurationManager.AppSettings.Settings;
            MessageQueue[] queues = MessageQueue.GetPrivateQueuesByMachine(configurationCollection["messageQueueIp"].Value);
            this.messageQueue = queues.First(q => q.QueueName.Equals(configurationCollection["messageQueueName"].Value));
            this.messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(Log) });


            while (true)
            {
                try
                {
                    Log log = (Log)this.messageQueue.Receive().Body;
                    Store.GetInstance().AddLog(log);
                }
                catch (MessageQueueException e)
                {
                    Store.GetInstance().AddLog(new Log(e.Message));
                }
            }
        }

    }
}
