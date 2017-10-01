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
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                this.service.Logout();
                var loginForm = (Login)Tag;
                loginForm.Show();
                Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void btnConnectedUsers_Click(object sender, EventArgs e)
        {
            string[] data = this.service.GetConnectedUsers();
            for(int i=0; i< data.Length; i++)
            {
                this.listBoxConnectedUsers.Items.Add(data[i]);
            }
            
        }

        private void buttonMyFriends_Click(object sender, EventArgs e)
        {

        }
    }
}
