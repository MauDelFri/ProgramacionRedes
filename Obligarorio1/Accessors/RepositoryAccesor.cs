using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Domain;
using HostRepository;
using System.Configuration;

namespace Obligarorio1
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

        public List<Session> GetConnectedSessions()
        {
            return this.repository.GetConnectedSessions();
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

        public bool AreUsersCredentialsCorrect(User user)
        {
            return this.repository.AreUsersCredentialsCorrect(user);
        }

        public User GetCompleteUser(User user)
        {
            return this.repository.GetCompleteUser(user);
        }

        public User GetUserFromUsername(string username)
        {
            return this.repository.GetUserFromUsername(username);
        }

        public void AddUser(User user)
        {
            this.repository.AddUser(user);
        }

        public bool IsUserConnected(string username)
        {
            return this.repository.IsUserConnected(username);
        }

        public void DisconnectUser(User user)
        {
            this.repository.DisconnectUser(user);
        }

        public void ConnectUserSession(Session currentSession)
        {
            this.repository.ConnectUserSession(currentSession);
        }

        public void SaveUser(User user)
        {
            this.repository.SaveUser(user);
        }
    }
}
