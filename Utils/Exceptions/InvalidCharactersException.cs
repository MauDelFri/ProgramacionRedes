using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Exceptions
{
    public class InvalidCharactersException : Exception 
    {
        public InvalidCharactersException()
        {

        }

        public InvalidCharactersException(string message) : base(message) { }
    }
}
