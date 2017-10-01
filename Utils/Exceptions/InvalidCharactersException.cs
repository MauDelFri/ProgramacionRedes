using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Exceptions
{
    public class InvalidCharactersException : ServerException 
    {
        public InvalidCharactersException() : base("The fields can not contain '-'") { }

        public InvalidCharactersException(string message) : base(message) { }
    }
}
