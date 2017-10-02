using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client;
using Client.Logic;
using Utils;

namespace Obligarorio1
{
    public partial class Connection : Form
    {
        public Connection()
        {
            InitializeComponent();
            this.txtServerIp.Text = Constants.DEFAULT_SERVER_IP;
            this.txtClientIp.Text = Constants.DEFAULT_CLIENT_IP;
            this.nudClientPort.Value = Constants.DEFAULT_CLIENT_PORT;
            this.nudServerPort.Value = Constants.DEFAULT_SERVER_PORT;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                this.TryConnect();
            }
            catch (Exception exception)
            {
                this.lblError.Text = "Connection to the server failed";
            }
        }

        private void TryConnect()
        {
            if (!String.IsNullOrEmpty(this.txtServerIp.Text) && this.nudServerPort.Value > 0 && 
                this.nudClientPort.Value >= 0 && !String.IsNullOrEmpty(this.txtClientIp.Text))
            {
                ClientConnection connection = new ClientConnection();
                connection.Connect(this.txtServerIp.Text, (int)this.nudServerPort.Value, 
                    this.txtClientIp.Text, (int)this.nudClientPort.Value);

                Login loginForm = new Login();
                loginForm.Tag = this;
                loginForm.Show(this);
                this.Hide();
            }
            else
            {
                this.lblError.Text = "Fill the fields";
            }
        }
    }
}
