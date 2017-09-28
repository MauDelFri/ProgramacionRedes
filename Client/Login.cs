﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client;

namespace Obligarorio1
{
    public partial class Login : Form
    {
        private ClientService service;

        public Login()
        {
            InitializeComponent();
            this.service = new ClientService();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                this.service.TryLogin(this.txtUsername.Text, this.txtPassword.Text);
                Home homeForm= new Home();
                homeForm.Tag = this;
                homeForm.Show(this);
                Hide();
            }
            catch (Exception exception)
            {
                this.lblError.Text = exception.Message;
            }
        }
    }
}
