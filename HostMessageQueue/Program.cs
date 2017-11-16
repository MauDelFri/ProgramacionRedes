using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace HostMessageQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing Message Queue ...");
            MessageQueue messageQueue;
            string queueName = @".\private$\queue";
            if (MessageQueue.Exists(queueName))
            {
                messageQueue = new MessageQueue(queueName);
            }
            else
            {
                messageQueue = MessageQueue.Create(queueName);
            }

            messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(Log) });
            Console.WriteLine("Message Queue Initialized");
            Console.ReadLine();
        }
    }
}
