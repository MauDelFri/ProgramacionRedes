using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace UserManagementServerConnection
{
    public partial class Connection : Form
    {
        public Connection()
        {
            InitializeComponent();
            this.txtServerIp.Text = Constants.DEFAULT_SERVER_IP;
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
                this.lblError.Text = exception.Message;
            }
        }

        private void TryConnect()
        {
            if (!String.IsNullOrEmpty(this.txtServerIp.Text) && this.nudServerPort.Value > 0)
            {
                //ServerLogic logic = new ServerLogic(this.txtServerIp.Text, (int)this.nudServerPort.Value);
                //Home homeForm = new Home(logic);
                //homeForm.Tag = this;
                //homeForm.Show(this);
                //this.Hide();
            }
            else
            {
                this.lblError.Text = "Fill the fields";
            }
        }
    }
}
