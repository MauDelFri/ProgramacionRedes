using Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Obligarorio1
{
    public class LogAccesor
    {
        private MessageQueue messageQueue;

        public LogAccesor()
        {
            Configuration configurationManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection configurationCollection = configurationManager.AppSettings.Settings;
            //MessageQueue[] queues = MessageQueue.GetPrivateQueuesByMachine(configurationCollection["messageQueueIp"].Value);
            this.messageQueue = new MessageQueue(configurationCollection["messageQueueIp"].Value);// queues.First(q => q.QueueName.Equals(configurationCollection["messageQueueName"].Value));
            this.messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(Log) });
        }

        public void LogMessage(Log message)
        {
            this.messageQueue.Send(message);
        }
    }
}
