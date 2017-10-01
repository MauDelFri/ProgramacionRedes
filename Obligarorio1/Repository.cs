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
        public static List<HandleClient> ConnectedClients { get; set; }

        public static void Initialize()
        {
            Users = new List<User>();
            ConnectedClients = new List<HandleClient>();
        }

        public static bool ExistsUser(string username)
        {
            return Users.Where(u => u.Username.Equals(username)).ToList().Count() > 0;
        }

        public static bool AreUsersCredentialsCorrect(User user)
        {
            return Users.Find(u => u.Username.Equals(user.Username)).Password.Equals(user.Password);
        }

        public static bool IsUserConnected(User user)
        {
            return ConnectedClients.Where(s => s.CurrentSession.User.Equals(user)).ToList().Count() > 0;
        }

        public static User GetCompleteUser(User user)
        {
            return Users.Find(u => u.Equals(user));
        }

        public static User GetUserFromUsername(string username)
        {
            return Users.Find(u => u.Username.Equals(username));
        }

        public static HandleClient GetUserSession(User user)
        {
            return ConnectedClients.Find(s => s.CurrentSession.User.Equals(user));
        }

        public static void DisconnectUser(User user)
        {
            ConnectedClients.Remove(GetUserSession(user));
        }
    }
}
