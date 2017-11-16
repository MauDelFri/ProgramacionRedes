using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Domain
{
    [Serializable]
    public class Log
    {
        public string Event { get; set; }
        public string EventDate { get; set; }

        public Log() { }

        public Log(string eventLog)
        {
            this.Event = eventLog;
            this.EventDate = DateTime.Now.ToString(Constants.DATE_FORMAT);
        }
    }
}
