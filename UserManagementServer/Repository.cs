using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class Repository : MarshalByRefObject
    {
        public static List<User> Users { get; set; }

        public void Initialize()
        {
            Users = new List<User>();
        }

        public bool ExistsUser(string username)
        {
            return Users.Where(u => u.Username.Equals(username)).ToList().Count() > 0;
        }

        public bool AreUsersCredentialsCorrect(User user)
        {
            return Users.Find(u => u.Username.Equals(user.Username)).Password.Equals(user.Password);
        }

        public User GetCompleteUser(User user)
        {
            return Users.Find(u => u.Equals(user));
        }

        public User GetUserFromUsername(string username)
        {
            return Users.Find(u => u.Username.Equals(username));
        }

        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public List<User> GetRegisteredUsers()
        {
            return Users;
        }
    }
}
