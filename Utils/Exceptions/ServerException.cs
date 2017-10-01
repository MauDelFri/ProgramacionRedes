using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Exceptions
{
    public class ServerException : Exception 
    {
        public ServerException() : base("An error ocurr on the server") { }

        public ServerException(string message) : base(message) { }
    }
}
