using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UserManagementClient.UserManagementService;

namespace UserManagementClient
{
    public partial class Home : Form
    {
        private UserManagementServiceClient service;
        private List<User> users = new List<User>();
        private bool isAddingNew = true;

        public Home()
        {
            InitializeComponent();
            this.service = new UserManagementServiceClient();
            this.AddUsersToListView(this.service.GetUsers());
        }

        private void AddUsersToListView(List<User> users)
        {
            this.users = users;
            List<ListViewItem> items = this.users.Select(u => new ListViewItem(
                new string[] { u.Username, u.Password })).ToList();
            this.listRegisteredClients.Items.Clear();
            this.listRegisteredClients.Items.AddRange(items.ToArray());
        }

        private void btnUpdateClients_Click(object sender, EventArgs e)
        {
            this.AddUsersToListView(this.service.GetUsers());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.listRegisteredClients.SelectedItems.Count > 0)
            {
                int selectedIndex = this.listRegisteredClients.Items.IndexOf(this.listRegisteredClients.SelectedItems[0]);
                this.service.DeleteUser(this.users.ElementAt(selectedIndex));
                this.AddUsersToListView(this.service.GetUsers());
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.listRegisteredClients.SelectedItems.Count > 0)
            {
                int selectedIndex = this.listRegisteredClients.Items.IndexOf(this.listRegisteredClients.SelectedItems[0]);
                this.txtUsername.Text = this.users.ElementAt(selectedIndex).Username;
                this.txtPassword.Text = this.users.ElementAt(selectedIndex).Password;
                this.isAddingNew = false;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            this.txtUsername.Text = "";
            this.txtPassword.Text = "";
            this.isAddingNew = true;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            User newUser = new User();
            newUser.Username = this.txtUsername.Text;
            newUser.Password = this.txtPassword.Text;
            if (this.isAddingNew)
            {
                this.service.AddUser(newUser);
            }
            else
            {
                if (this.listRegisteredClients.SelectedItems.Count > 0)
                {
                    int selectedIndex = this.listRegisteredClients.Items.IndexOf(this.listRegisteredClients.SelectedItems[0]);
                    this.service.ModifyUser(this.users.ElementAt(selectedIndex).Username, newUser);
                }
            }

            this.AddUsersToListView(this.service.GetUsers());
        }

        private void listRegisteredClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.isAddingNew)
            {
                this.txtUsername.Text = "";
                this.txtPassword.Text = "";
            }
            if (this.listRegisteredClients.SelectedItems.Count > 0)
            {
                this.btnEdit.Enabled = true;
                this.btnDelete.Enabled = true;
                this.isAddingNew = false;
            }
            else
            {
                this.btnEdit.Enabled = false;
                this.btnDelete.Enabled = false;
                this.isAddingNew = true;
            }
        }
    }
}
