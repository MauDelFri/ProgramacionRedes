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
        public int TimesConnected { get; set; }

        public User()
        {
            this.Initialize();
        }

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
            this.Initialize();
        }

        public User(string username)
        {
            this.Username = username;
            this.Initialize();
        }

        private void Initialize()
        {
            this.TimesConnected = 0;
            this.Friends = new List<User>();
            this.PendingFriendship = new List<User>();
            this.PendingMessages = new List<Message>();
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

        public void RemovePendingFriendship(User user)
        {
            this.PendingFriendship.Remove(user);
        }
    }
}
