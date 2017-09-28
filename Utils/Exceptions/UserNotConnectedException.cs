using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Exceptions
{
    public class UserNotConnectedException : Exception 
    {
        public UserNotConnectedException()
        {

        }

        public UserNotConnectedException(string message) : base(message) { }
    }
}
