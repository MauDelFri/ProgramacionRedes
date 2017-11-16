using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;

namespace UserManagementServer
{
    public class UserManagementService : IUserManagementService
    {
        public static RepositoryAccesor RepositoryAccesor;
        public static LogAccesor LogAccesor;

        public UserManagementService()
        {
            RepositoryAccesor = new RepositoryAccesor();
            LogAccesor = new LogAccesor();
        }

        public void AddUser(User user)
        {
            user.TimesConnected = 0;
            user.Friends = new List<User>();
            user.PendingFriendship = new List<User>();
            user.PendingMessages = new List<Message>();
            RepositoryAccesor.AddUser(user);
            LogAccesor.LogMessage(new Log("User " + user.Username + " has been correctly added"));
        }

        public void DeleteUser(User user)
        {
            RepositoryAccesor.DeleteUser(user);
            LogAccesor.LogMessage(new Log("User " + user.Username + " was deleted correctly" ));
        }

        public bool ExistsUser(string username)
        {
            return RepositoryAccesor.ExistsUser(username);
        }

        public List<User> GetUsers()
        {
            LogAccesor.LogMessage(new Log("Requested users by admin management"));
            return RepositoryAccesor.GetRegisteredUsers();
        }

        public bool IsUserConnected(string username)
        {
            return RepositoryAccesor.IsUserConnected(username);
        }

        public void ModifyUser(string username, User newUser)
        {
            RepositoryAccesor.ModifyUser(username, newUser);
            LogAccesor.LogMessage(new Log("User " + username + " has been modified correctly"));
        }
    }
}
