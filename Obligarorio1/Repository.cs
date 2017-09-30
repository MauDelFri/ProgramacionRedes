using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligarorio1
{
    public static class Repository
    {
        public static List<User> Users { get; set; }
        public static List<User> ConnectedUsers { get; set; }

        public static void Initialize()
        {
            Users = new List<User>();
            ConnectedUsers = new List<User>();
        }

        public static bool ExistsUser(User user)
        {
            return Users.Where(u => u.Equals(user)).ToList().Count() > 0;
        }

        public static bool AreUsersCredentialsCorrect(User user)
        {
            return Users.Find(u => u.Username.Equals(user.Username)).Password.Equals(user.Password);
        }

        public static bool IsUserAlreadyConnected(User user)
        {
            return ConnectedUsers.Where(u => u.Equals(user)).ToList().Count() > 0;
        }

        public static User GetCompleteUser(User user)
        {
            return Users.Find(u => u.Equals(user));
        }

        public static User GetUserFromUsername(string username)
        {
            return Users.Find(u => u.Username.Equals(username));
        }

        public static void DisconnectUser(User user)
        {
            ConnectedUsers.Remove(user);
        }
    }
}
