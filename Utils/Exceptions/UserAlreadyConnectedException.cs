using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Exceptions
{
    public class UserAlreadyConnectedException : Exception 
    {
        public UserAlreadyConnectedException()
        {

        }

        public UserAlreadyConnectedException(string message) : base(message) { }
    }
}
