using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Exceptions
{
    public class UsersAlreadyFriendsException : ServerException
    {
        public UsersAlreadyFriendsException() : base("Already friends") { }

        public UsersAlreadyFriendsException(string message) : base(message) { }
    }
}
