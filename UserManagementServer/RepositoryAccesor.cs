using System;
using System.Collections.Generic;
using Domain;
using DataAccess;

namespace UserManagementServer
{
    public class RepositoryAccesor
    {
        private Repository repository;

        public RepositoryAccesor()
        {
            this.repository = (Repository)Activator.GetObject((typeof(Repository)), "tcp://localhost:6100/Repository");
        }

        public void Initialize()
        {
            this.repository.Initialize();
        }

        public List<User> GetRegisteredUsers()
        {
            return this.repository.GetRegisteredUsers();
        }

        public bool ExistsUser(string username)
        {
            return this.repository.ExistsUser(username);
        }

        public void AddUser(User user)
        {
            this.repository.AddUser(user);
        }

        public void ModifyUser(string username, User newUser)
        {
            this.repository.ModifyUser(username, newUser);
        }

        public void DeleteUser(User user)
        {
            this.repository.DeleteUser(user);
        }

        public bool IsUserConnected(string username)
        {
            return this.repository.IsUserConnected(username);
        }
    }
}
