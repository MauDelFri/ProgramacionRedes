using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Exceptions
{
    public class InvalidMessageFormatException : Exception 
    {
        public InvalidMessageFormatException()
        {

        }

        public InvalidMessageFormatException(string message) : base(message) { }
    }
}
