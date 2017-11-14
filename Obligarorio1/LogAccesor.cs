using Domain;
using System;
using System.Collections.Generic;
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
            string queueName = @".\private$\myqueue";
            if (MessageQueue.Exists(queueName))
            {
                this.messageQueue = new MessageQueue(queueName);
            }
            else
            {
                this.messageQueue = MessageQueue.Create(queueName);
            }

            this.messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(Log) });
        }

        public void LogMessage(Log message)
        {
            this.messageQueue.Send(message);
        }
    }
}
