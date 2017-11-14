using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class Log
    {
        public String Event { get; set; }
        public DateTime EventDate { get; set; }

        public Log(String eventLog, DateTime eventDate)
        {
            this.Event = eventLog;
            this.EventDate = EventDate;
        }
    }
}
