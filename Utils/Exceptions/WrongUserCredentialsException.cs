using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Exceptions
{
    public class WrongUserCredentialsException : Exception 
    {
        public WrongUserCredentialsException()
        {

        }

        public WrongUserCredentialsException(string message) : base(message) { }
    }
}
