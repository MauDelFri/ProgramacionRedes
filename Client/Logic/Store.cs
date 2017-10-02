using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace Client.Logic
{
    public class Store
    {
        private static Store instance;
        public Socket socket;
        public User user { get; set; }

        public ReplaySubject<string> LoginState { get; set; }
        public ReplaySubject<string> LogoutState { get; set; }
        public ReplaySubject<string[]> ConnectedUsersState { get; set; }
        public ReplaySubject<string[]> FriendsState { get; set; }
        public ReplaySubject<string> RespondFriendshipRequestState { get; set; }
        public ReplaySubject<string> SendMessageState { get; set; }
        public ReplaySubject<string> SendFriendshipRequestState { get; set; }
        public ReplaySubject<string> MessageReadState { get; set; }
        public ReplaySubject<string> FriendshipAcceptedState { get; set; }
        public ReplaySubject<string[]> PendingFriendshipsState { get; set; }
        public ReplaySubject<List<Message>> PendingMessagesState { get; set; }
        public ReplaySubject<string> ReceiveFriendshipRequestsState { get; set; }
        public ReplaySubject<Message> ReceiveMessagesState{ get; set; }

        private Store()
        {
            this.LoginState = new ReplaySubject<string>();
            this.LogoutState = new ReplaySubject<string>();
            this.ConnectedUsersState = new ReplaySubject<string[]>();
            this.FriendsState = new ReplaySubject<string[]>();
            this.RespondFriendshipRequestState = new ReplaySubject<string>();
            this.SendMessageState = new ReplaySubject<string>();
            this.SendFriendshipRequestState = new ReplaySubject<string>();
            this.MessageReadState = new ReplaySubject<string>();
            this.PendingFriendshipsState = new ReplaySubject<string[]>();
            this.PendingMessagesState = new ReplaySubject<List<Message>>();
            this.ReceiveMessagesState = new ReplaySubject<Message>();
            this.ReceiveFriendshipRequestsState = new ReplaySubject<string>();
            this.FriendshipAcceptedState = new ReplaySubject<string>();
        }

        public static Store GetInstance()
        {
            if (instance == null)
            {
                instance = new Store();
            }

            return instance;
        }
    }
}
