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
            this.listRegisteredClients.FullRowSelect = true;
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
                User user = this.users.ElementAt(selectedIndex);
                if (this.service.IsUserConnected(user.Username))
                {
                    this.lblError.Text = "No se puede editar porque el usuario se encuentra conectado";
                }
                else
                {
                    this.lblError.Text = "";
                    this.service.DeleteUser(user);
                    this.AddUsersToListView(this.service.GetUsers());
                }
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
                if (this.IsValidAddUser(newUser))
                {
                    this.service.AddUser(newUser);
                    this.AddUsersToListView(this.service.GetUsers());
                }
            }
            else
            {
                if (this.listRegisteredClients.SelectedItems.Count > 0)
                {
                    int selectedIndex = this.listRegisteredClients.Items.IndexOf(this.listRegisteredClients.SelectedItems[0]);
                    User selectedUser = this.users.ElementAt(selectedIndex);
                    if (this.IsValidModifyUser(selectedUser.Username, newUser))
                    {
                        this.service.ModifyUser(selectedUser.Username, newUser);
                        this.AddUsersToListView(this.service.GetUsers());
                    }
                }
            }

        }

        private bool IsValidAddUser(User newUser)
        {
            if (this.txtUsername.Text == "" || this.txtPassword.Text == "")
            {
                this.lblError.Text = "Complete todos los campos";
            }
            else if (this.service.ExistsUser(newUser.Username))
            {
                this.lblError.Text = "El nombre de usuario ya existe";
            }
            else
            {
                this.lblError.Text = "";
            }

            return this.lblError.Text == "";
        }

        private bool IsValidModifyUser(string oldUsername, User newUser)
        {
            if (this.txtUsername.Text == "" || this.txtPassword.Text == "")
            {
                this.lblError.Text = "Complete todos los campos";
            }
            else if (this.service.ExistsUser(newUser.Username) && !newUser.Username.Equals(oldUsername))
            {
                this.lblError.Text = "El nombre de usuario ya existe";
            }
            else if (this.service.IsUserConnected(oldUsername))
            {
                this.lblError.Text = "No se puede editar porque el usuario se encuentra conectado";
            }
            else
            {
                this.lblError.Text = "";
            }

            return this.lblError.Text == "";
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
