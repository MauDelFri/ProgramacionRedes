using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Exceptions
{
    public class UserAlreadyConnectedException : ServerException 
    {
        public UserAlreadyConnectedException() : base("User is already connected") { }

        public UserAlreadyConnectedException(string message) : base(message) { }
    }
}
