using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Exceptions
{
    public class InvalidMessageFormatException : ServerException 
    {
        public InvalidMessageFormatException() : base("El formato del mensaje es incorrecto") { }

        public InvalidMessageFormatException(string message) : base(message) { }
    }
}
