using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Obligarorio1
{
    public class FunctionalityMapper
    {
        public FunctionalityMapper() { }

        public void MapCommandToService(ProtocolItem message, HandleClient handleClient)
        {
            ServerService service = new ServerService(handleClient);
            switch (message.Command)
            {
                case Constants.LOGIN_CODE:
                    service.LoginService(message.Data);
                    break;
                case Constants.LOGOUT_CODE:
                    service.LogoutService(message.Data);
                    break;
                case Constants.CONNECTED_USERS:
                    service.ConnectedUsers(message.Data);
                    break;
                case Constants.GET_FRIENDS:
                    service.GetFriends(message.Data);
                    break;
                case Constants.SEND_FRIENDSHIP_REQUEST:
                    service.SendFriendshipRequest(message.Data);
                    break;
                case Constants.RESPOND_FRIENDSHIP_REQUEST:
                    service.RespondFriendshipRequest(message.Data);
                    break;
                case Constants.SEND_MESSAGE:
                    service.SendMessage(message.Data);
                    break;
                default:
                    break;
            }
        }
    }
}
