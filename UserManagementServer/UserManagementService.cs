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

        public UserManagementService()
        {
            RepositoryAccesor = new RepositoryAccesor();
        }

        public void AddUser(User user)
        {
            user.TimesConnected = 0;
            user.Friends = new List<User>();
            user.PendingFriendship = new List<User>();
            user.PendingMessages = new List<Message>();
            RepositoryAccesor.AddUser(user);
        }

        public void DeleteUser(User user)
        {
            RepositoryAccesor.DeleteUser(user);
        }

        public bool ExistsUser(string username)
        {
            return RepositoryAccesor.ExistsUser(username);
        }

        public List<User> GetUsers()
        {
            return RepositoryAccesor.GetRegisteredUsers();
        }

        public bool IsUserConnected(string username)
        {
            return RepositoryAccesor.IsUserConnected(username);
        }

        public void ModifyUser(string username, User newUser)
        {
            RepositoryAccesor.ModifyUser(username, newUser);
        }
    }
}
