using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Exceptions
{
    public class EmptyFieldsException : Exception 
    {
        public EmptyFieldsException()
        {

        }

        public EmptyFieldsException(string message) : base(message) { }
    }
}
