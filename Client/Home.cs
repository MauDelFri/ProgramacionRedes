using Client.Logic;
using Obligarorio1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Home : Form
    {
        private ClientService service;

        public Home(ClientService service)
        {
            InitializeComponent();
            this.service = service;
            this.buttonAddFriend.Enabled = false;
            this.buttonAccept.Enabled = false;
            Store.GetInstance().LogoutState.Subscribe(data => this.OnLogoutSuccess());
            Store.GetInstance().ConnectedUsersState.Subscribe(data => this.OnConnectedUsersSuccess(data), error => this.OnServiceCallError(error.Message));
            Store.GetInstance().FriendsState.Subscribe(data => this.OnFriendsSuccess(data), error => this.OnServiceCallError(error.Message));
            Store.GetInstance().PendingFriendshipsState.Subscribe(data => this.OnPendingFriendshipsSuccess(data), error => this.OnServiceCallError(error.Message));
            //Store.GetInstance().PendingMessagesState.Subscribe(data => this.OnPendingMessagesSuccess(), error => this.OnServiceCallError(error.Message));
            Store.GetInstance().SendFriendshipRequestState.Subscribe(data => this.OnSendFriendshipRequestSuccess(), error => this.OnServiceCallError(error.Message));
            //Store.GetInstance().ReceiveFriendshipRequestsState.Subscribe(data => this.OnReceiveFriendshipRequestSuccess(), error => this.OnServiceCallError(error.Message));
            //Store.GetInstance().ReceiveMessagesState.Subscribe(data => this.OnReceiveMessageSuccess(), error => this.OnServiceCallError(error.Message));
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
            object username = this.listBoxConnectedUsers.SelectedItem;
            this.service.AddFriend((string)username);
        }

        private void buttonFriendshipRequests_Click(object sender, EventArgs e)
        {
            this.service.GetFriendshipRequests();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
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

        private void listBoxFriendshipRequests_SelectedValueChanged(object sender, EventArgs e)
        {
            this.buttonAccept.Enabled = true;
        }
    }
}
