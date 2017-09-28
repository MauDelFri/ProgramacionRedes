using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public String Name { get; set; }
        public List<User> Friends { get; set; }
        public List<User> PendingFriendship { get; set; }
        public List<Message> PendingMessages { get; set; }

        public User() { }

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public override bool Equals(object other)
        {
            if (other != null && other.GetType().Equals(this.GetType()))
            {
                return this.Username.Equals(((User)other).Username) && 
                    this.Password.Equals(((User)other).Password);
            }

            return false;
        }
    }
}
