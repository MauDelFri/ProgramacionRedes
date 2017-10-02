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
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                this.service.Logout();
                var loginForm = (Login)Tag;
                loginForm.Show();
                Close();
                this.labelMessage.Text = "";
            }
            catch (Exception ex)
            {
                this.labelMessage.Text = ex.Message;
            } 
        }

        private void btnConnectedUsers_Click(object sender, EventArgs e)
        {
            this.listBoxConnectedUsers.Items.Clear();
            string[] data = this.service.GetConnectedUsers();
            for(int i=0; i< data.Length; i++)
            {
                if (service.GetUser().Username != data[i])
                {
                    this.listBoxConnectedUsers.Items.Add(data[i]);
                }
            }
            this.labelMessage.Text = "";

        }

        private void buttonMyFriends_Click(object sender, EventArgs e)
        {
            this.listBoxMyFriends.Items.Clear();
            string[] data = this.service.GetMyFriends();
            for (int i = 0; i < data.Length; i++)
            {
               this.listBoxMyFriends.Items.Add(data[i]); 
            }
            this.labelMessage.Text = "";
        }

        private void listBoxConnectedUsers_SelectedValueChanged(object sender, EventArgs e)
        {
            this.buttonAddFriend.Enabled = true;
        }

        private void buttonAddFriend_Click(object sender, EventArgs e)
        {
            object username = this.listBoxConnectedUsers.SelectedItem;
            try
            {
                this.service.AddFriend((string)username);
                this.labelMessage.Text = "Friend added";
            }
            catch (Exception ex)
            {
                this.labelMessage.Text = ex.Message;
            }
        }

        private void buttonFriendshipRequests_Click(object sender, EventArgs e)
        {
            this.listBoxFriendshipRequests.Items.Clear();
            string[] data = this.service.GetFriendshipRequests();
            for (int i = 0; i < data.Length; i++)
            {
                this.listBoxFriendshipRequests.Items.Add(data[i]);
            }
            this.labelMessage.Text = "";
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
