using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Exceptions
{
    public class WrongUserCredentialsException : ServerException 
    {
        public WrongUserCredentialsException() : base("Username is already taken") { }

        public WrongUserCredentialsException(string message) : base(message) { }
    }
}
