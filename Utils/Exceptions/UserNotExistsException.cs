using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Exceptions
{
    public class UserNotExistsException : ServerException 
    {
        public UserNotExistsException() : base("The user does not exist") { }

        public UserNotExistsException(string message) : base(message) { }
    }
}
