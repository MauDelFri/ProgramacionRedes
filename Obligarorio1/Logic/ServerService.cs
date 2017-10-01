using Domain;
using Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Utils.Exceptions;

namespace Obligarorio1
{
    public class ServerService
    {
        private User loggedUser;
        public ProtocolObjectsParser Parser;
        private HandleClient handleClient;

        public ServerService(HandleClient handleClient)
        {
            this.handleClient = handleClient;
            this.Parser = new ProtocolObjectsParser();
        }

        public void LoginService(string data)
        {
            try
            {
                this.TryLogin(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                this.handleClient.ErrorResponse(e.Message);
            }
        }

        private void TryLogin(string data)
        {
            User user = this.Parser.GetUser(data);
            if (Repository.ExistsUser(user))
            {
                this.UserExistsAtLogin(user);
            }
            else
            {
                Repository.Users.Add(user);
                this.LoginSuccess(user);
            }
        }

        private void UserExistsAtLogin(User user)
        {
            if (Repository.AreUsersCredentialsCorrect(user))
            {
                if (Repository.IsUserAlreadyConnected(user))
                {
                    throw new UserAlreadyConnectedException("User is already connected");
                }
                else
                {
                    user = Repository.GetUserFromUsername(user.Username);
                    this.LoginSuccess(user);
                }
            }
            else
            {
                throw new WrongUserCredentialsException("Username is already taken");
            }
        }

        private void LoginSuccess(User user)
        {
            user.TimesConnected++;
            this.loggedUser = user;
            Repository.ConnectedSessions.Add(new Session(user));
            this.handleClient.AcknowledgeResponse();
        }

        public void LogoutService(string data)
        {
            try
            {
                this.TryLogout(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                this.handleClient.ErrorResponse(e.Message);
            }
        }

        private void TryLogout(string data)
        {
            string username = this.Parser.GetString(data);
            User user = Repository.GetUserFromUsername(username);
            if (Repository.IsUserAlreadyConnected(user))
            {
                Repository.DisconnectUser(user);
                this.handleClient.AcknowledgeResponse();
            }
            else
            {
                throw new UserNotConnectedException("User is not connected");
            }
        }

        public void ConnectedUsers(string data)
        {
            try
            {
                this.TryGetConnectedUsers(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                this.handleClient.ErrorResponse(e.Message);
            }
        }

        private void TryGetConnectedUsers(string data)
        {
            List<string> connectedUsernames = Repository.ConnectedSessions.Select(s => s.User.Username).ToList();
            string connectedUsernamesMessage = connectedUsernames.First();
            foreach (var item in connectedUsernames.Skip(1))
            {
                connectedUsernamesMessage += Constants.ATTRIBUTE_SEPARATOR + item;
            }
            this.handleClient.MessageResponse(connectedUsernamesMessage);
        }

        public void GetFriends(string data)
        {
            try
            {
                this.TryGetFriends();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                this.handleClient.ErrorResponse(e.Message);
            }
        }

        private void TryGetFriends()
        {
            string friends = "";
            foreach (var item in this.loggedUser.Friends)
            {
                friends += item.Username + Constants.ATTRIBUTE_SEPARATOR + item.Friends.Count + Constants.OBJECT_SEPARATOR;
            }

            if (!String.IsNullOrEmpty(friends) && friends.EndsWith(Constants.OBJECT_SEPARATOR + ""))
            {
                friends = friends.Substring(0, friends.Count() - 1);
            }

            this.handleClient.MessageResponse(friends);
        }
    }
}
