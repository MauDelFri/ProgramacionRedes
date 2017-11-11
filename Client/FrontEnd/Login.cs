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
    public partial class Login : Form
    {
        private ClientService service;

        public Login()
        {
            InitializeComponent();
            this.service = new ClientService();
            Store.GetInstance().LoginState.Subscribe(data => this.OnLoginSuccess(), error => this.OnLoginError(error.Message));
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                this.service.TryLogin(this.txtUsername.Text, this.txtPassword.Text);
            }
            catch (Exception exception)
            {
                this.lblError.Text = exception.Message;
            }
        }

        private void OnLoginError(string message)
        {
            this.lblError.Text = message;
        }

        private void OnLoginSuccess()
        {   
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => {
                    Home homeForm = new Home(this.service);
                    homeForm.Tag = this;
                    homeForm.Show(this);
                    Hide();
                }));
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
            Environment.Exit(0);
        }
    }
}
