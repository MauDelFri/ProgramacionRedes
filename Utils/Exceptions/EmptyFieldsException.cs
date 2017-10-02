using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Exceptions
{
    public class EmptyFieldsException : ServerException 
    {
        public EmptyFieldsException() : base("Complete all fileds") { }

        public EmptyFieldsException(string message) : base(message) { }
    }
}
