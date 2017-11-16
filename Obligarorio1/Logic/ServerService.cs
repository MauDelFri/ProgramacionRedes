using Domain;
using Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Exceptions;
using System.IO;

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

        public User GetCurrentUser()
        {
            return this.handleClient.CurrentSession.User;
        }

        public void LoginService(string data)
        {
            try
            {
                this.TryLogin(data);
                ServerConnection.LogAccesor.LogMessage(new Log("Login successful user " + this.GetCurrentUser().Username));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.LOGIN_CODE, Constants.ERROR_RESPONSE + e.Message);
                ServerConnection.LogAccesor.LogMessage(new Log("Login failed"));
            }
        }

        private void TryLogin(string data)
        {
            string[] userProperties = this.Parser.GetUser(data);
            User user = new User(userProperties[0], userProperties[1]);

            if (ServerConnection.RepositoryAccesor.ExistsUser(user.Username))
            {
                this.UserExistsAtLogin(user);
            }
            else
            {
                ServerConnection.RepositoryAccesor.AddUser(user);
                this.LoginSuccess(user);
            }
        }

        private void UserExistsAtLogin(User user)
        {
            if (ServerConnection.RepositoryAccesor.AreUsersCredentialsCorrect(user))
            {
                if (ServerConnection.RepositoryAccesor.IsUserConnected(user.Username))
                {
                    throw new UserAlreadyConnectedException();
                }
                else
                {
                    user = ServerConnection.RepositoryAccesor.GetUserFromUsername(user.Username);
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
            ServerConnection.ConnectedClients.Add(this.handleClient);
            ServerConnection.RepositoryAccesor.ConnectUserSession(this.handleClient.CurrentSession);
            this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.LOGIN_CODE, Constants.SUCCESS_RESPONSE);
        }
        
        public void LogoutService(string data)
        {
            try
            {
                this.TryLogout(data);
                ServerConnection.LogAccesor.LogMessage(new Log("Logout successful user " + this.GetCurrentUser().Username));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.LOGOUT_CODE, Constants.ERROR_RESPONSE + e.Message);
                ServerConnection.LogAccesor.LogMessage(new Log("Logout failed. User " + this.GetCurrentUser().Username));
            }
        }

        private void TryLogout(string data)
        {
            string username = this.Parser.GetString(data);
            User user = ServerConnection.RepositoryAccesor.GetUserFromUsername(username);
            if (ServerConnection.RepositoryAccesor.IsUserConnected(user.Username))
            {
                ServerConnection.RepositoryAccesor.DisconnectUser(user);
                ServerConnection.DisconnectUser(user);
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
                ServerConnection.LogAccesor.LogMessage(new Log("Requested connected users by user " + this.GetCurrentUser().Username));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.CONNECTED_USERS, Constants.ERROR_RESPONSE + e.Message);
                ServerConnection.LogAccesor.LogMessage(new Log("Connected users request failed. User " + this.GetCurrentUser().Username));
            }
        }

        private void TryGetConnectedUsers(string data)
        {
            List<string> connectedUsernames = ServerConnection.RepositoryAccesor.GetConnectedSessions().Select(s => s.User.Username).ToList();
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
                ServerConnection.LogAccesor.LogMessage(new Log("Requested friends by user " + this.GetCurrentUser().Username));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.GET_FRIENDS, Constants.ERROR_RESPONSE + e.Message);
                ServerConnection.LogAccesor.LogMessage(new Log("Fiends request failed. User " + this.GetCurrentUser().Username));
            }
        }

        private void TryGetFriends()
        {
            string friends = "";
            foreach (var item in ServerConnection.RepositoryAccesor.GetUserFromUsername(this.GetCurrentUser().Username).Friends)
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
                string username = this.Parser.GetString(data);
                this.TrySendFriendshipRequest(username);
                ServerConnection.LogAccesor.LogMessage(new Log("Send friendship request by user " + 
                    this.GetCurrentUser().Username + " to " + username));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.SEND_FRIENDSHIP_REQUEST, Constants.ERROR_RESPONSE + e.Message);
                ServerConnection.LogAccesor.LogMessage(new Log("Send friendship request failed. User " + this.GetCurrentUser().Username));
            }
        }

        private void TrySendFriendshipRequest(string username)
        {
            if (ServerConnection.RepositoryAccesor.ExistsUser(username))
            {
                User user = ServerConnection.RepositoryAccesor.GetUserFromUsername(username);
                User currentUser = ServerConnection.RepositoryAccesor.GetUserFromUsername(this.handleClient.CurrentSession.User.Username);
                if (user.PendingFriendship.Contains(currentUser))
                {
                    throw new UserAlreadyRequestException();
                }
                
                if (currentUser.Friends.Contains(user))
                {
                    throw new UsersAlreadyFriendsException();
                }

                if (currentUser.PendingFriendship.Contains(user))
                {
                    currentUser.Friends.Add(user);
                    user.Friends.Add(currentUser);
                    currentUser.RemovePendingFriendship(user);
                    this.handleClient.SendMessage(Constants.REQUEST_HEADER, Constants.FRIENDSHIP_ACCEPTED, user.Username + Constants.ATTRIBUTE_SEPARATOR + user.Friends.Count);
                    HandleClient userSession = ServerConnection.GetUserSession(user);
                    userSession.SendMessage(Constants.REQUEST_HEADER, Constants.FRIENDSHIP_ACCEPTED,
                        currentUser.Username + Constants.ATTRIBUTE_SEPARATOR +
                        currentUser.Friends.Count);
                }
                else
                {
                    user.PendingFriendship.Add(currentUser);
                    this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.SEND_FRIENDSHIP_REQUEST, Constants.SUCCESS_RESPONSE);
                    if (ServerConnection.RepositoryAccesor.IsUserConnected(user.Username))
                    {
                        HandleClient userSession = ServerConnection.GetUserSession(user);
                        userSession.SendMessage(Constants.REQUEST_HEADER, Constants.SEND_FRIENDSHIP_REQUEST, currentUser.Username);
                    }
                }

                ServerConnection.RepositoryAccesor.SaveUser(currentUser);
                ServerConnection.RepositoryAccesor.SaveUser(user);
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
                ServerConnection.LogAccesor.LogMessage(new Log("Friendship request responded by user " + this.GetCurrentUser().Username));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.RESPOND_FRIENDSHIP_REQUEST, Constants.ERROR_RESPONSE + e.Message);
                ServerConnection.LogAccesor.LogMessage(new Log("Friendship request response failed. User " + this.GetCurrentUser().Username));
            }
        }

        private void TryRespondFriendshipRequest(string data)
        {
            string[] dataArray = this.Parser.GetListAttribute(data);
            if (ServerConnection.RepositoryAccesor.ExistsUser(dataArray[0]))
            {
                User user = ServerConnection.RepositoryAccesor.GetUserFromUsername(dataArray[0]);
                User currentUser = ServerConnection.RepositoryAccesor.GetUserFromUsername(this.GetCurrentUser().Username);
                currentUser.RemovePendingFriendship(user);
                this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.RESPOND_FRIENDSHIP_REQUEST, Constants.SUCCESS_RESPONSE);
                this.ProcessFriendshipResponseAction(dataArray, user, currentUser);
            }
            else
            {
                throw new UserNotExistsException();
            }
        }

        private void ProcessFriendshipResponseAction(string[] dataArray, User user, User currentUser)
        {
            user.Friends.Add(currentUser);
            currentUser.Friends.Add(user);
            if (ServerConnection.RepositoryAccesor.IsUserConnected(user.Username))
            {
                HandleClient userSession = ServerConnection.GetUserSession(user);
                userSession.SendMessage(Constants.REQUEST_HEADER, Constants.FRIENDSHIP_ACCEPTED,
                    currentUser.Username + Constants.ATTRIBUTE_SEPARATOR +
                    currentUser.Friends.Count);
            }

            ServerConnection.RepositoryAccesor.SaveUser(currentUser);
            ServerConnection.RepositoryAccesor.SaveUser(user);
        }

        public void SendMessage(string data)
        {
            try
            {
                string[] dataArray = this.Parser.GetStringArray(data, 2);
                this.TrySendMessage(data, dataArray);
                ServerConnection.LogAccesor.LogMessage(new Log("Message delivered from user " + this.GetCurrentUser().Username + " to user " + dataArray[0]));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.SEND_MESSAGE, Constants.ERROR_RESPONSE + e.Message);
                ServerConnection.LogAccesor.LogMessage(new Log("Send message failed. User " + this.GetCurrentUser().Username));
            }
        }

        private void TrySendMessage(string data, string[] dataArray)
        {
            if (ServerConnection.RepositoryAccesor.ExistsUser(dataArray[0]))
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
            User user = ServerConnection.RepositoryAccesor.GetUserFromUsername(dataArray[0]);
            User currentUser = ServerConnection.RepositoryAccesor.GetUserFromUsername(this.GetCurrentUser().Username);
            Message message = new Message(dataArray[1], currentUser, user);
            user.PendingMessages.Add(message);
            ServerConnection.RepositoryAccesor.SaveUser(user);
            if (ServerConnection.RepositoryAccesor.IsUserConnected(user.Username))
            {
                HandleClient userSession = ServerConnection.GetUserSession(user);
                userSession.SendMessage(Constants.REQUEST_HEADER, Constants.SEND_MESSAGE, message.FormatToSend());
            }
        }

        public void GetPendingMessages(string data)
        {
            try
            {
                this.TryGetPendingMessages(data);
                ServerConnection.LogAccesor.LogMessage(new Log("Requested pending messages by user " + this.GetCurrentUser().Username));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.GET_PENDING_MESSAGES, Constants.ERROR_RESPONSE + e.Message);
                ServerConnection.LogAccesor.LogMessage(new Log("Request pending messages failed. User " + this.GetCurrentUser().Username));
            }
        }

        private void TryGetPendingMessages(string data)
        {
            string username = this.Parser.GetString(data);
            if (ServerConnection.RepositoryAccesor.ExistsUser(username))
            {
                User user = ServerConnection.RepositoryAccesor.GetUserFromUsername(username);
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
                ServerConnection.LogAccesor.LogMessage(new Log("Requested pending friendship requests by user " + this.GetCurrentUser().Username));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.GET_PENDING_FRIENDSHIPS, Constants.ERROR_RESPONSE + e.Message);
                ServerConnection.LogAccesor.LogMessage(new Log("Request pending friendships failed. User " + this.GetCurrentUser().Username));
            }
        }

        private void TryGetPendingFriendships(string data)
        {
            string username = this.Parser.GetString(data);
            if (ServerConnection.RepositoryAccesor.ExistsUser(username))
            {
                User user = ServerConnection.RepositoryAccesor.GetUserFromUsername(username);
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
                ServerConnection.LogAccesor.LogMessage(new Log("Message read by username " + this.GetCurrentUser().Username));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.MESSAGE_READ, Constants.ERROR_RESPONSE + e.Message);
                ServerConnection.LogAccesor.LogMessage(new Log("Message read failed. User " + this.GetCurrentUser().Username));
            }
        }

        private void TryMessageRead(string data)
        {
            string[] messageData = this.Parser.GetStringArray(data, 2);
            User currentUser = ServerConnection.RepositoryAccesor.GetUserFromUsername(this.GetCurrentUser().Username);
            Message messageRead = currentUser.PendingMessages.
                Find(m => m.Sender.Username.Equals(messageData[0]) && m.Date.ToString(Constants.DATE_FORMAT).Equals(messageData[1]));
            if (messageRead != null)
            {
                currentUser.PendingMessages.Remove(messageRead);
                ServerConnection.RepositoryAccesor.SaveUser(currentUser);
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
                ServerConnection.LogAccesor.LogMessage(new Log("File received, sended by user " + this.GetCurrentUser().Username));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                this.handleClient.SendMessage(Constants.RESPONSE_HEADER, Constants.MESSAGE_READ, Constants.ERROR_RESPONSE + e.Message);
                ServerConnection.LogAccesor.LogMessage(new Log("File receive failed. User " + this.GetCurrentUser().Username));
            }
        }

        private void TryReceiveFile(string data)
        {
            string[] messageData = this.Parser.GetStringArray(data, 3);
            string filepath = this.handleClient.ReceiveFile(long.Parse(messageData[0]), messageData[1]);
            User user = ServerConnection.RepositoryAccesor.GetUserFromUsername(messageData[2]);
            if (ServerConnection.RepositoryAccesor.IsUserConnected(user.Username))
            {
                HandleClient userSession = ServerConnection.GetUserSession(user);
                userSession.SendFileToUser(filepath, this.handleClient.CurrentSession.User.Username);
            }
        }
    }
}
