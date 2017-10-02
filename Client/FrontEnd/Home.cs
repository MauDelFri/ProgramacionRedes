using Client.Logic;
using Obligarorio1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Utils;
using Domain;

namespace Client
{
    public partial class Home : Form
    {
        private ClientService service;
        private List<TabPage> chats;

        public object Parser { get; private set; }

        public Home(ClientService service)
        {
            InitializeComponent();
            this.chats = new List<TabPage>();
            this.service = service;
            this.buttonAddFriend.Enabled = false;
            this.buttonAccept.Enabled = false;
            Store.GetInstance().LogoutState.Subscribe(data => this.OnLogoutSuccess());
            Store.GetInstance().ConnectedUsersState.Subscribe(data => this.OnConnectedUsersSuccess(data), error => this.OnServiceCallError(error.Message));
            Store.GetInstance().FriendsState.Subscribe(data => this.OnFriendsSuccess(data), error => this.OnServiceCallError(error.Message));
            Store.GetInstance().PendingFriendshipsState.Subscribe(data => this.OnPendingFriendshipsSuccess(data), error => this.OnServiceCallError(error.Message));
            Store.GetInstance().PendingMessagesState.Subscribe(data => this.OnPendingMessagesSuccess(data), error => this.OnServiceCallError(error.Message));
            Store.GetInstance().SendFriendshipRequestState.Subscribe(data => this.OnSendFriendshipRequestSuccess(), error => this.OnServiceCallError(error.Message));
            Store.GetInstance().SendMessageState.Subscribe(data => this.OnSendMessageSuccess(data), error => this.OnServiceCallError(error.Message));
            Store.GetInstance().ReceiveFriendshipRequestsState.Subscribe(data => this.OnReceiveFriendshipRequestSuccess(data), error => this.OnServiceCallError(error.Message));
            Store.GetInstance().ReceiveMessagesState.Subscribe(data => this.OnReceiveMessageSuccess(data), error => this.OnServiceCallError(error.Message));
            Store.GetInstance().FriendshipAcceptedState.Subscribe(data => this.OnFriendshipAcceptedSuccess(data), error => this.OnServiceCallError(error.Message));
            this.service.GetPendingMessages();
        }

        #region Observables server response

        private void OnFriendshipAcceptedSuccess(string data)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    this.listBoxMyFriends.Items.Clear();
                    this.listBoxMyFriends.Items.Add(data);
                }));
            }
        }

        private void OnReceiveFriendshipRequestSuccess(string data)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    Store.GetInstance().user.PendingFriendship.Add(new User(data));
                    this.listBoxFriendshipRequests.Items.Clear();
                    this.listBoxFriendshipRequests.Items.AddRange(Store.GetInstance().user.PendingFriendship.ToArray());
                }));
            }
        }

        private void OnReceiveMessageSuccess(Domain.Message message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    this.ShowMessageOnChat(message);
                    this.service.MessageRead(message);
                }));
            }
        }

        private void OnPendingMessagesSuccess(List<Domain.Message> pendingMessages)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    foreach (var message in pendingMessages)
                    {
                        this.ShowMessageOnChat(message);
                        this.service.MessageRead(message);
                    }
                }));
            }
        }

        private void ShowMessageOnChat(Domain.Message message)
        {
            if (!this.chats.Exists(t => t.Text.Equals(message.Sender.Username)))
            {
                this.AddChatTab(message.Sender.Username);
            }

            IEnumerator enumerator = this.chats.Find(t => t.Text.Equals(message.Sender.Username)).Controls.GetEnumerator();
            enumerator.MoveNext();
            ((ListBox)enumerator.Current).Items.Add(message.Sender.Username + " - " +
                message.Date.ToString(Constants.DATE_FORMAT) + " - " + message.Text);
        }

        private void OnSendMessageSuccess(string data)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    ProtocolObjectsParser parser = new ProtocolObjectsParser();
                    string[] dataArray = parser.GetStringArray(data, 2);
                    IEnumerator enumerator = this.chats.Find(t => t.Text.Equals(dataArray[0])).Controls.GetEnumerator();
                    enumerator.MoveNext();
                    ((ListBox)enumerator.Current).Items.Add("Yo - " + DateTime.Now.ToString(Constants.DATE_FORMAT) + " - " + dataArray[1]);
                    this.txtMessage.Text = "";
                }));
            }
        }

        private void OnSendFriendshipRequestSuccess()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    this.labelMessage.Text = "Friend added";
                }));
            }
        }

        private void OnPendingFriendshipsSuccess(string[] data)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    this.listBoxFriendshipRequests.Items.Clear();
                    for (int i = 0; i < data.Length; i++)
                    {
                        this.listBoxFriendshipRequests.Items.Add(data[i]);
                    }
                    this.labelMessage.Text = "";
                }));
            }
        }

        private void OnFriendsSuccess(string[] data)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    this.listBoxMyFriends.Items.Clear();
                    for (int i = 0; i < data.Length; i++)
                    {
                        this.listBoxMyFriends.Items.Add(data[i]);
                    }
                    this.labelMessage.Text = "";
                }));
            }
        }

        private void OnServiceCallError(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    this.labelMessage.Text = message;
                }));
            }
        }

        private void OnConnectedUsersSuccess(string[] data)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => {
                    this.listBoxConnectedUsers.Items.Clear();
                    for (int i = 0; i < data.Length; i++)
                    {
                        if (service.GetUser().Username != data[i])
                        {
                            this.listBoxConnectedUsers.Items.Add(data[i]);
                        }
                    }
                    this.labelMessage.Text = "";
                }));
            }
        }

        private void OnLogoutSuccess()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    var loginForm = (Login)Tag;
                    loginForm.Show();
                    Close();
                    this.labelMessage.Text = "";
                }));
            }
        }

        #endregion

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.service.Logout();
        }

        private void btnConnectedUsers_Click(object sender, EventArgs e)
        {
            this.service.GetConnectedUsers();
        }

        private void buttonMyFriends_Click(object sender, EventArgs e)
        {
            this.service.GetMyFriends();
        }

        private void listBoxConnectedUsers_SelectedValueChanged(object sender, EventArgs e)
        {
            this.buttonAddFriend.Enabled = true;
        }

        private void buttonAddFriend_Click(object sender, EventArgs e)
        {
            if (this.listBoxConnectedUsers.SelectedItem != null)
            {
                object username = this.listBoxConnectedUsers.SelectedItem;
                this.service.AddFriend((string)username);
            }
        }

        private void buttonFriendshipRequests_Click(object sender, EventArgs e)
        {
            this.service.GetFriendshipRequests();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (this.listBoxFriendshipRequests.SelectedItem != null)
            {
                object username = this.listBoxFriendshipRequests.SelectedItem;
                try
                {
                    this.service.AcceptRequest((string)username);
                    this.labelMessage.Text = "Friend accepted";
                    this.listBoxFriendshipRequests.Items.Remove(username);
                    this.buttonAccept.Enabled = false;
                }
                catch (Exception ex)
                {
                    this.labelMessage.Text = ex.Message;
                }
            }
        }

        private void listBoxFriendshipRequests_SelectedValueChanged(object sender, EventArgs e)
        {
            this.buttonAccept.Enabled = true;
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            if (this.listBoxMyFriends.SelectedItem != null)
            {
                string friend = ((string)this.listBoxMyFriends.SelectedItem).Split('-')[0];
                if (this.chats.Exists(t => t.Text.Equals(friend)))
                {
                    this.tabControlChat.SelectedTab = this.chats.Find(t => t.Text.Equals(friend));
                }
                else
                {
                    this.AddChatTab(friend);
                }
            }
        }

        private void AddChatTab(string friend)
        {
            ListBox chatMessages = new ListBox();
            chatMessages.Name = friend + "-chat";
            chatMessages.Dock = DockStyle.Fill;
            TabPage chat = new TabPage(friend);
            chat.Controls.Add(chatMessages);
            this.chats.Add(chat);
            this.tabControlChat.TabPages.Add(chat);
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtMessage.Text.Trim()) && this.chats.Count() > 0 && e.KeyCode == Keys.Enter)
            {
                string friendUsername = this.tabControlChat.SelectedTab.Text;
                string message = this.txtMessage.Text;
                this.service.SendMessage(friendUsername + Constants.ATTRIBUTE_SEPARATOR + message);
            }
        }
    }
}
