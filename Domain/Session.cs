using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Session
    {
        public User User { get; set; }
        public DateTime ConnectedFrom { get; set; }
        public DateTime ConnectedTo { get; set; }

        public Session() { }
    }
}
