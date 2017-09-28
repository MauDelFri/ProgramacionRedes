using Domain;
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
                this.handleClient.ErrorResponse(e.Message);
            }
        }

        private void TryLogin(string data)
        {
            User user = this.Parser.GetUser(data);
            user = Repository.GetCompleteUser(user);
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
            Repository.ConnectedUsers.Add(user);
            //TODO
            // Como devolvemos error para que se envie al cliente???? (acordarse que la responsabilidad de enviar es el handler)
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
    }
}
