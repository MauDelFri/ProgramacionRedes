using Domain;
using Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.LOGIN_CODE, Constants.ERROR_RESPONSE + e.Message);
            }
        }

        private void TryLogin(string data)
        {
            string[] userProperties = this.Parser.GetUser(data);
            User user = new User(userProperties[0], userProperties[1]);

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
                    throw new UserAlreadyConnectedException();
                }
                else
                {
                    user = Repository.GetUserFromUsername(user.Username);
                    this.LoginSuccess(user);
                }
            }
            else
            {
                throw new WrongUserCredentialsException();
            }
        }

        private void LoginSuccess(User user)
        {
            user.TimesConnected++;
            this.handleClient.CurrentSession = new Session(user);
            Repository.ConnectedClients.Add(this.handleClient);
            this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.LOGIN_CODE, Constants.SUCCESS_RESPONSE);
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
                this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.LOGOUT_CODE, Constants.ERROR_RESPONSE + e.Message);
            }
        }

        private void TryLogout(string data)
        {
            string username = this.Parser.GetString(data);
            User user = Repository.GetUserFromUsername(username);
            if (Repository.IsUserConnected(user))
            {
                Repository.DisconnectUser(user);
                this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.LOGOUT_CODE, Constants.SUCCESS_RESPONSE);
            }
            else
            {
                throw new UserNotConnectedException();
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
                this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.CONNECTED_USERS, Constants.ERROR_RESPONSE + e.Message);
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
            this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.CONNECTED_USERS, connectedUsernamesMessage);
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
                this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.GET_FRIENDS, Constants.ERROR_RESPONSE + e.Message);
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
                friends = friends.Substring(0, friends.Length - 1);
            }

            this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.GET_FRIENDS, friends);
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
                this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.SEND_FRIENDSHIP_REQUEST, Constants.ERROR_RESPONSE + e.Message);
            }
        }

        private void TrySendFriendshipRequest(string data)
        {
            string username = this.Parser.GetString(data);
            if (Repository.ExistsUser(username))
            {
                User user = Repository.GetUserFromUsername(username);
                if (user.PendingFriendship.Contains(this.handleClient.CurrentSession.User))
                {
                    throw new UserAlreadyRequestException();
                }
                
                if (handleClient.CurrentSession.User.Friends.Contains(user))
                {
                    throw new UsersAlreadyFriendsException();
                }

                if (this.handleClient.CurrentSession.User.PendingFriendship.Contains(user))
                {
                    this.handleClient.CurrentSession.User.Friends.Add(user);
                    user.Friends.Add(this.handleClient.CurrentSession.User);
                    this.handleClient.CurrentSession.User.RemovePendingFriendship(user);
                    this.handleClient.SendMessage(Constants.REQUEST_HEADER, Constants.FRIENDSHIP_ACCEPTED, user.Username + Constants.ATTRIBUTE_SEPARATOR + user.Friends.Count);
                    HandleClient userSession = Repository.GetUserSession(user);
                    userSession.SendMessage(Constants.REQUEST_HEADER, Constants.FRIENDSHIP_ACCEPTED,
                        this.handleClient.CurrentSession.User.Username + Constants.ATTRIBUTE_SEPARATOR +
                        this.handleClient.CurrentSession.User.Friends.Count);
                }
                else
                {
                    user.PendingFriendship.Add(this.handleClient.CurrentSession.User);
                    this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.SEND_FRIENDSHIP_REQUEST, Constants.SUCCESS_RESPONSE);
                    if (Repository.IsUserConnected(user))
                    {
                        HandleClient userSession = Repository.GetUserSession(user);
                        userSession.SendMessage(Constants.REQUEST_HEADER, Constants.SEND_FRIENDSHIP_REQUEST, this.handleClient.CurrentSession.User.Username);
                    }
                }   
            }
            else
            {
                throw new UserNotExistsException();
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
                this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.RESPOND_FRIENDSHIP_REQUEST, Constants.ERROR_RESPONSE + e.Message);
            }
        }

        private void TryRespondFriendshipRequest(string data)
        {
            string[] dataArray = this.Parser.GetListAttribute(data);
            if (Repository.ExistsUser(dataArray[0]))
            {
                User user = Repository.GetUserFromUsername(dataArray[0]);
                this.handleClient.CurrentSession.User.RemovePendingFriendship(user);
                this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.RESPOND_FRIENDSHIP_REQUEST, Constants.SUCCESS_RESPONSE);
                this.ProcessFriendshipResponseAction(dataArray, user);
            }
            else
            {
                throw new UserNotExistsException();
            }
        }

        private void ProcessFriendshipResponseAction(string[] dataArray, User user)
        {
            user.Friends.Add(this.handleClient.CurrentSession.User);
            this.handleClient.CurrentSession.User.Friends.Add(user);
            if (Repository.IsUserConnected(user))
            {
                HandleClient userSession = Repository.GetUserSession(user);
                userSession.SendMessage(Constants.REQUEST_HEADER, Constants.FRIENDSHIP_ACCEPTED, 
                    this.handleClient.CurrentSession.User.Username + Constants.ATTRIBUTE_SEPARATOR + 
                    this.handleClient.CurrentSession.User.Friends.Count);
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
                this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.SEND_MESSAGE, Constants.ERROR_RESPONSE + e.Message);
            }
        }

        private void TrySendMessage(string data)
        {
            string[] dataArray = this.Parser.GetStringArray(data, 2);
            if (Repository.ExistsUser(dataArray[0]))
            {
                this.ProcessMessageToSend(dataArray);
                this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.SEND_MESSAGE, data);
            }
            else
            {
                throw new UserNotExistsException();
            }
        }

        private void ProcessMessageToSend(string[] dataArray)
        {
            User user = Repository.GetUserFromUsername(dataArray[0]);
            Message message = new Message(dataArray[1], this.handleClient.CurrentSession.User, user);
            user.PendingMessages.Add(message);
            if (Repository.IsUserConnected(user))
            {
                HandleClient userSession = Repository.GetUserSession(user);
                userSession.SendMessage(Constants.REQUEST_HEADER, Constants.SEND_MESSAGE, message.FormatToSend());
            }
        }

        public void GetPendingMessages(string data)
        {
            try
            {
                this.TryGetPendingMessages(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.GET_PENDING_MESSAGES, Constants.ERROR_RESPONSE + e.Message);
            }
        }

        private void TryGetPendingMessages(string data)
        {
            string username = this.Parser.GetString(data);
            if (Repository.ExistsUser(username))
            {
                User user = Repository.GetUserFromUsername(username);
                List<Message> pendingMessages = user.PendingMessages;
                string pendingMessagesData = this.GetPendingMessagesToSend(pendingMessages);
                this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.GET_PENDING_MESSAGES, pendingMessagesData);
            }
            else
            {
                throw new UserNotExistsException();
            }
        }

        private string GetPendingMessagesToSend(List<Message> pendingMessages)
        {
            string pendingMessagesData = "";
            foreach (var item in pendingMessages)
            {
                pendingMessagesData += item.FormatToSend() + Constants.OBJECT_SEPARATOR;
            }

            if (pendingMessagesData.EndsWith(Constants.OBJECT_SEPARATOR + ""))
            {
                pendingMessagesData = pendingMessagesData.Substring(0, pendingMessagesData.Length - 1);
            }

            return pendingMessagesData;
        }

        public void GetPendingFriendships(string data)
        {
            try
            {
                this.TryGetPendingFriendships(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.GET_PENDING_FRIENDSHIPS, Constants.ERROR_RESPONSE + e.Message);
            }
        }

        private void TryGetPendingFriendships(string data)
        {
            string username = this.Parser.GetString(data);
            if (Repository.ExistsUser(username))
            {
                User user = Repository.GetUserFromUsername(username);
                List<User> pendingFriendships = user.PendingFriendship;
                string pendingFriendshipsData = this.GetPendingFriendshipsToSend(pendingFriendships);
                this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.GET_PENDING_FRIENDSHIPS, pendingFriendshipsData);
            }
            else
            {
                throw new UserNotExistsException();
            }
        }

        private string GetPendingFriendshipsToSend(List<User> pendingFriendships)
        {
            string pendingFriendshipsData = "";
            foreach (var item in pendingFriendships)
            {
                pendingFriendshipsData += item.Username + Constants.OBJECT_SEPARATOR;
            }

            if (pendingFriendshipsData.EndsWith(Constants.OBJECT_SEPARATOR + ""))
            {
                pendingFriendshipsData = pendingFriendshipsData.Substring(0, pendingFriendshipsData.Length);
            }

            return pendingFriendshipsData;
        }

        public void MessageRead(string data)
        {
            try
            {
                this.TryMessageRead(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.MESSAGE_READ, Constants.ERROR_RESPONSE + e.Message);
            }
        }

        private void TryMessageRead(string data)
        {
            string[] messageData = this.Parser.GetStringArray(data, 2);
            Message messageRead = this.handleClient.CurrentSession.User.PendingMessages.
                Find(m => m.Sender.Username.Equals(messageData[0]) && m.Date.ToString(Constants.DATE_FORMAT).Equals(messageData[1]));
            if (messageRead != null)
            {
                this.handleClient.CurrentSession.User.PendingMessages.Remove(messageRead);
                this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.MESSAGE_READ, Constants.SUCCESS_RESPONSE);
            }
            else
            {
                throw new MessageNotPendingException();
            }
        }

        public void ReceiveFile(string data)
        {
            try
            {
                this.TryReceiveFile(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.MESSAGE_READ, Constants.ERROR_RESPONSE + e.Message);
            }
        }

        private void TryReceiveFile(string data)
        {
            string[] messageData = this.Parser.GetStringArray(data, 2);
            string filepath = this.handleClient.ReceiveFile(long.Parse(messageData[0]), messageData[1]);
        }
    }
}
