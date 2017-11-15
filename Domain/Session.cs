using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class Session
    {
        public User User { get; set; }
        public DateTime ConnectedFrom { get; set; }

        public Session(User user)
        {
            this.User = user;
            this.ConnectedFrom = DateTime.Now;
        }

        public string GetElapsedTime()
        {
            TimeSpan span = DateTime.Now.Subtract(this.ConnectedFrom);
            return span.Hours + ":" + span.Minutes + ":" + span.Seconds;   
        }
    }
}
