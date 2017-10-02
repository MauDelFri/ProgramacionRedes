using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Exceptions;
using Utils;
using System.Net.Sockets;
using System.Net;
using Domain;
using System.Threading;
using Client.Logic;

namespace Client
{
    public class ClientService
    {
        private Thread thread;
        public ProtocolObjectsParser Parser;

        public ClientService()
        {
            this.Parser = new ProtocolObjectsParser();
        }

        public User GetUser()
        {
            return Store.GetInstance().user;
        }

        public void TryLogin(string username, string password)
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                throw new EmptyFieldsException();
            }

            if (username.Contains("-") || password.Contains("-"))
            {
                throw new InvalidCharactersException();
            }

            String dataToSend = username + "-" + password;
            ProtocolItem message = new ProtocolItem(Constants.REQUEST_HEADER, Constants.LOGIN_CODE, dataToSend);
            SocketUtils.SendMessage(Store.GetInstance().socket, message);
            Store.GetInstance().user = new User(username, password);
        }

        private void ProcessResponse(ProtocolItem response)
        {
            if (response.Command == Constants.ERROR_CODE)
            {
                throw new ServerException(response.Data);
            }
        }

        public void Logout()
        {
            ProtocolItem message = new ProtocolItem(Constants.REQUEST_HEADER, Constants.LOGOUT_CODE, this.GetUser().Username);
            SocketUtils.SendMessage(Store.GetInstance().socket, message);
        }

        public void GetConnectedUsers()
        {
            ProtocolItem message = new ProtocolItem(Constants.REQUEST_HEADER, Constants.CONNECTED_USERS, "");
            SocketUtils.SendMessage(Store.GetInstance().socket, message);
        }

        public void GetMyFriends()
        {
            ProtocolItem message = new ProtocolItem(Constants.REQUEST_HEADER, Constants.GET_FRIENDS, "");
            SocketUtils.SendMessage(Store.GetInstance().socket, message);
        }

        public void AddFriend(string username)
        {
            ProtocolItem message = new ProtocolItem(Constants.REQUEST_HEADER, Constants.SEND_FRIENDSHIP_REQUEST, username);
            SocketUtils.SendMessage(Store.GetInstance().socket, message);
        }

        public void GetFriendshipRequests()
        {
            ProtocolItem message = new ProtocolItem(Constants.REQUEST_HEADER, Constants.GET_PENDING_FRIENDSHIPS, this.GetUser().Username);
            SocketUtils.SendMessage(Store.GetInstance().socket, message);
        }

        public void AcceptRequest(string username)
        {
            ProtocolItem message = new ProtocolItem(Constants.REQUEST_HEADER, Constants.RESPOND_FRIENDSHIP_REQUEST, username);
            SocketUtils.SendMessage(Store.GetInstance().socket, message);
        }

        #region Observable server response
        public void RespondFriendshipRequestResponse(string data)
        {
            if (data.Equals(Constants.SUCCESS_RESPONSE))
            {
                Store.GetInstance().RespondFriendshipRequestState.OnNext("");
            }
            else
            {
                Store.GetInstance().RespondFriendshipRequestState.OnError(new ServerException(data.Replace(Constants.ERROR_RESPONSE, "")));
            }
        }

        public void MessageReadResponse(string data)
        {
            if (data.Equals(Constants.SUCCESS_RESPONSE))
            {
                Store.GetInstance().MessageReadState.OnNext("");
            }
            else
            {
                Store.GetInstance().MessageReadState.OnError(new ServerException(data.Replace(Constants.ERROR_RESPONSE, "")));
            }
        }

        public void GetPendingFriendshipsResponse(string data)
        {
            if (data.StartsWith(Constants.ERROR_RESPONSE))
            {
                Store.GetInstance().PendingFriendshipsState.OnError(new ServerException(data.Replace(Constants.ERROR_RESPONSE, "")));
            }
            else
            {
                Store.GetInstance().PendingFriendshipsState.OnNext(Parser.GetListObject(data));
            }
        }

        public void GetPendingMessagesResponse(string data)
        {
            if (data.StartsWith(Constants.ERROR_RESPONSE))
            {
                Store.GetInstance().PendingMessagesState.OnError(new ServerException(data.Replace(Constants.ERROR_RESPONSE, "")));
            }
            else
            {
                List<Message> messages = Parser.GetMessages(data).Select(m => new Message(new User(m[0]), m[1], m[2])).ToList();
                Store.GetInstance().PendingMessagesState.OnNext(messages);
            }
        }

        public void SendFriendshipRequestResponse(string data)
        {
            if (data.Equals(Constants.SUCCESS_RESPONSE))
            {
                Store.GetInstance().SendFriendshipRequestState.OnNext("");
            }
            else
            {
                Store.GetInstance().SendFriendshipRequestState.OnError(new ServerException(data.Replace(Constants.ERROR_RESPONSE, "")));
            }
        }

        public void SendMessageResponse(string data)
        {
            if (data.Equals(Constants.SUCCESS_RESPONSE))
            {
                Store.GetInstance().SendMessageState.OnNext("");
            }
            else
            {
                Store.GetInstance().SendMessageState.OnError(new ServerException(data.Replace(Constants.ERROR_RESPONSE, "")));
            }
        }

        public void GetFriendsResponse(string data)
        {
            if (data.StartsWith(Constants.ERROR_RESPONSE))
            {
                Store.GetInstance().FriendsState.OnError(new ServerException(data.Replace(Constants.ERROR_RESPONSE, "")));
            }
            else
            {
                Store.GetInstance().FriendsState.OnNext(Parser.GetListObject(data));
            }
        }

        public void ConnectedUsersResponse(string data)
        {
            if (data.StartsWith(Constants.ERROR_RESPONSE))
            {
                Store.GetInstance().ConnectedUsersState.OnError(new ServerException(data.Replace(Constants.ERROR_RESPONSE, "")));
            }
            else
            {
                Store.GetInstance().ConnectedUsersState.OnNext(Parser.GetListAttribute(data));
            }
        }

        public void ReceiveFriendshipRequest(string data)
        {
            if (data.StartsWith(Constants.ERROR_RESPONSE))
            {
                Store.GetInstance().ReceiveFriendshipRequestsState.OnError(new ServerException(data.Replace(Constants.ERROR_RESPONSE, "")));
            }
            else
            {
                Store.GetInstance().ReceiveFriendshipRequestsState.OnNext(Parser.GetString(data));
            }
        }

        public void ReceiveMessage(string data)
        {
            if (data.StartsWith(Constants.ERROR_RESPONSE))
            {
                Store.GetInstance().ReceiveMessagesState.OnError(new ServerException(data.Replace(Constants.ERROR_RESPONSE, "")));
            }
            else
            {
                string[] messageArray = Parser.GetListAttribute(data);
                Message message = new Message(new User(messageArray[0]), messageArray[1], messageArray[2]);
                Store.GetInstance().ReceiveMessagesState.OnNext(message);
            }
        }

        public void LogoutResponse(string data)
        {
            if (data.Equals(Constants.SUCCESS_RESPONSE))
            {
                Store.GetInstance().LogoutState.OnNext("");
            }
            else
            {
                Store.GetInstance().LogoutState.OnError(new ServerException(data.Replace(Constants.ERROR_RESPONSE, "")));
            }
        }

        public void LoginResponse(string data)
        {
            if (data.Equals(Constants.SUCCESS_RESPONSE))
            {
                Store.GetInstance().LoginState.OnNext("");
            }
            else
            {
                Store.GetInstance().LoginState.OnError(new ServerException(data.Replace(Constants.ERROR_RESPONSE, "")));
            }
        }
        #endregion
    }
}
