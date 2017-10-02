using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Exceptions
{
    public class UserNotConnectedException : ServerException 
    {
        public UserNotConnectedException() : base("User is not connected") { }

        public UserNotConnectedException(string message) : base(message) { }
    }
}
