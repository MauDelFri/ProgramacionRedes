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

namespace Client
{
    public class ClientService
    {
        private Thread thread;
        private ClientConnection connection;
        public User user;
        public ProtocolObjectsParser Parser;

        public ClientService()
        {
            this.Parser = new ProtocolObjectsParser();
            this.connection = new ClientConnection();
            this.thread = new Thread(() => this.connection.Connect());
            this.thread.Start();
        }

        public User GetUser()
        {
            return user;
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
            SocketUtils.SendMessage(this.connection.GetClientSocket(), message);
            ProtocolItem response = SocketUtils.RecieveMessage(this.connection.GetClientSocket());
            this.ProcessResponse(response);
            this.user = new User(username, password);
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
            ProtocolItem message = new ProtocolItem(Constants.REQUEST_HEADER, Constants.LOGOUT_CODE, this.user.Username);
            SocketUtils.SendMessage(this.connection.GetClientSocket(), message);
            ProtocolItem response = SocketUtils.RecieveMessage(this.connection.GetClientSocket());
            this.ProcessResponse(response);
            this.user = null;
        }

        public string[] GetConnectedUsers()
        {
            ProtocolItem message = new ProtocolItem(Constants.REQUEST_HEADER, Constants.CONNECTED_USERS, "");
            SocketUtils.SendMessage(this.connection.GetClientSocket(), message);
            ProtocolItem response = SocketUtils.RecieveMessage(this.connection.GetClientSocket());
            this.ProcessResponse(response);
            return Parser.GetListAttribute(response.Data);
        }

        public string[] GetMyFriends()
        {
            ProtocolItem message = new ProtocolItem(Constants.REQUEST_HEADER, Constants.GET_FRIENDS, "");
            SocketUtils.SendMessage(this.connection.GetClientSocket(), message);
            ProtocolItem response = SocketUtils.RecieveMessage(this.connection.GetClientSocket());
            this.ProcessResponse(response);
            return Parser.GetListObject(response.Data);
        }

        public void AddFriend(string username)
        {
            ProtocolItem message = new ProtocolItem(Constants.REQUEST_HEADER, Constants.SEND_FRIENDSHIP_REQUEST, username);
            SocketUtils.SendMessage(this.connection.GetClientSocket(), message);
            ProtocolItem response = SocketUtils.RecieveMessage(this.connection.GetClientSocket());
            this.ProcessResponse(response);
        }

        public string[] GetFriendshipRequests()
        {
            ProtocolItem message = new ProtocolItem(Constants.REQUEST_HEADER, Constants.GET_PENDING_FRIENDSHIPS, this.user.Username);
            SocketUtils.SendMessage(this.connection.GetClientSocket(), message);
            ProtocolItem response = SocketUtils.RecieveMessage(this.connection.GetClientSocket());
            this.ProcessResponse(response);
            return Parser.GetListObject(response.Data);
        }

        public void AcceptRequest(string username)
        {
            ProtocolItem message = new ProtocolItem(Constants.REQUEST_HEADER, Constants.RESPOND_FRIENDSHIP_REQUEST, username);
            SocketUtils.SendMessage(this.connection.GetClientSocket(), message);
            ProtocolItem response = SocketUtils.RecieveMessage(this.connection.GetClientSocket());
            this.ProcessResponse(response);
        }
    }
}
