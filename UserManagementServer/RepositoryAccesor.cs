using System;
using System.Collections.Generic;
using Domain;
using System.Configuration;
using HostRepository;

namespace UserManagementServer
{
    public class RepositoryAccesor
    {
        private Repository repository;

        public RepositoryAccesor()
        {
            Configuration configurationManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection configurationCollection = configurationManager.AppSettings.Settings;
            this.repository = (Repository)Activator.GetObject((typeof(Repository)), "tcp://" + configurationCollection["repositoryIp"].Value + ":6100/Repository");
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
