using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Domain;

namespace Obligarorio1
{
    public class RepositoryAccesor
    {
        private Repository.Repository repository;

        public RepositoryAccesor()
        {
            TcpChannel serverChannel = new TcpChannel(6200);
            try
            {
                ChannelServices.RegisterChannel(serverChannel, false);
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(Repository.Repository), "Repository", WellKnownObjectMode.Singleton);
                Console.WriteLine("Remoting service started ...\n\n");
                this.repository = (Repository.Repository)Activator.GetObject((typeof(Repository.Repository)), "tcp://localhost:6200/Repository");
            }
            catch (Exception)
            {
                ChannelServices.UnregisterChannel(serverChannel);
            }
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
    }
}
