using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Exceptions
{
    public class UserAlreadyRequestException : ServerException
    {
        public UserAlreadyRequestException() : base("The user already send request") { }

        public UserAlreadyRequestException(string message) : base(message) { }
    }
}
