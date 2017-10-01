using Domain;
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
            if (Repository.ExistsUser(user.Username))
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
                if (Repository.IsUserConnected(user))
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
            this.handleClient.CurrentSession = new Session(user);
            Repository.ConnectedClients.Add(this.handleClient);
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
            if (Repository.IsUserConnected(user))
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
            List<string> connectedUsernames = Repository.ConnectedClients.Select(s => s.CurrentSession.User.Username).ToList();
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
            foreach (var item in this.handleClient.CurrentSession.User.Friends)
            {
                friends += item.Username + Constants.ATTRIBUTE_SEPARATOR + item.Friends.Count + Constants.OBJECT_SEPARATOR;
            }

            if (!String.IsNullOrEmpty(friends) && friends.EndsWith(Constants.OBJECT_SEPARATOR + ""))
            {
                friends = friends.Substring(0, friends.Count() - 1);
            }

            this.handleClient.MessageResponse(friends);
        }

        public void SendFriendshipRequest(string data)
        {
            try
            {
                this.TrySendFriendshipRequest(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                this.handleClient.ErrorResponse(e.Message);
            }
        }

        private void TrySendFriendshipRequest(string data)
        {
            string username = this.Parser.GetString(data);
            if (Repository.ExistsUser(username))
            {
                User user = Repository.GetUserFromUsername(username);
                user.PendingFriendship.Add(this.handleClient.CurrentSession.User);
                this.handleClient.AcknowledgeResponse();
                if (Repository.IsUserConnected(user))
                {
                    HandleClient userSession = Repository.GetUserSession(user);
                    userSession.SendMessage(this.handleClient.CurrentSession.User.Username, Constants.SEND_FRIENDSHIP_REQUEST);
                }
            }
            else
            {
                throw new UserNotExistsException("The user does not exist");
            }
        }

        public void RespondFriendshipRequest(string data)
        {
            try
            {
                this.TryRespondFriendshipRequest(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                this.handleClient.ErrorResponse(e.Message);
            }
        }

        private void TryRespondFriendshipRequest(string data)
        {
            string username = this.Parser.GetString(data);
            if (Repository.ExistsUser(username))
            {
                User user = Repository.GetUserFromUsername(username);
                user.Friends.Add(this.handleClient.CurrentSession.User);
                this.handleClient.CurrentSession.User.Friends.Add(user);
                this.handleClient.CurrentSession.User.RemovePendingFriendship(user);
                this.handleClient.AcknowledgeResponse();
                if (Repository.IsUserConnected(user))
                {
                    HandleClient userSession = Repository.GetUserSession(user);
                    userSession.SendMessage(this.handleClient.CurrentSession.User.Username, Constants.FRIENDSHIP_ACCEPTED);
                }
            }
            else
            {
                throw new UserNotExistsException("The user does not exist");
            }
        }

        public void SendMessage(string data)
        {
            try
            {
                this.TrySendMessage(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                this.handleClient.ErrorResponse(e.Message);
            }
        }

        private void TrySendMessage(string data)
        {
            string[] dataArray = this.Parser.GetStringArray(data, 2);
            if (Repository.ExistsUser(dataArray[0]))
            {
                this.ProcessMessage(dataArray);
                this.handleClient.AcknowledgeResponse();
            }
            else
            {
                throw new UserNotExistsException("The user does not exist");
            }
        }

        private void ProcessMessage(string[] dataArray)
        {
            User user = Repository.GetUserFromUsername(dataArray[0]);
            Message message = new Message(dataArray[1], this.handleClient.CurrentSession.User, user);
            if (Repository.IsUserConnected(user))
            {
                HandleClient userSession = Repository.GetUserSession(user);
                userSession.SendMessage(message.FormatToSend(), Constants.SEND_MESSAGE);
            }
            else
            {
                user.PendingMessages.Add(message);
            }
        }
    }
}
