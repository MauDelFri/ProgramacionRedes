using Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Obligarorio1
{
    public class ResponseMapper
    {
        public ClientService service { get; set; }

        public ResponseMapper()
        {
            service = new ClientService();
        }

        public void MapHeaderToAction(ProtocolItem message)
        {
            switch (message.Header)
            {
                case Constants.REQUEST_HEADER:
                    this.MapRequestCommandToService(message);
                    break;
                case Constants.RESPONSE_HEADER:
                    this.MapResponseCommandToService(message);
                    break;
            }
        }

        public void MapResponseCommandToService(ProtocolItem message)
        {
            switch (message.Command)
            {
                case Constants.LOGIN_CODE:
                    service.LoginResponse(message.Data);
                    break;
                case Constants.LOGOUT_CODE:
                    service.LogoutResponse(message.Data);
                    break;
                case Constants.CONNECTED_USERS:
                    service.ConnectedUsersResponse(message.Data);
                    break;
                case Constants.GET_FRIENDS:
                    service.GetFriendsResponse(message.Data);
                    break;
                case Constants.RESPOND_FRIENDSHIP_REQUEST:
                    service.RespondFriendshipRequestResponse(message.Data);
                    break;
                case Constants.MESSAGE_READ:
                    service.MessageReadResponse(message.Data);
                    break;
                case Constants.GET_PENDING_FRIENDSHIPS:
                    service.GetPendingFriendshipsResponse(message.Data);
                    break;
                case Constants.GET_PENDING_MESSAGES:
                    service.GetPendingMessagesResponse(message.Data);
                    break;
                case Constants.SEND_FRIENDSHIP_REQUEST:
                    service.SendFriendshipRequestResponse(message.Data);
                    break;
                case Constants.SEND_MESSAGE:
                    service.SendMessageResponse(message.Data);
                    break;
                default:
                    break;
            }
        }

        public void MapRequestCommandToService(ProtocolItem message)
        {
            switch (message.Command)
            {
                case Constants.SEND_FRIENDSHIP_REQUEST:
                    service.ReceiveFriendshipRequest(message.Data);
                    break;
                case Constants.SEND_MESSAGE:
                    service.ReceiveMessage(message.Data);
                    break;
                case Constants.FRIENDSHIP_ACCEPTED:
                    service.FriendshipAccepted(message.Data);
                    break;
                default:
                    break;
            }
        }
    }
}
