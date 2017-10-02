using Domain;
using Obligarorio1.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Obligarorio1
{
    public partial class Home : Form
    {
        ServerLogic logic;

        public Home(ServerLogic logic)
        {
            this.logic = logic;
            InitializeComponent();
            this.listRegisteredClients.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.listConnectedClients.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void btnUpdateClients_Click(object sender, EventArgs e)
        {
            List<User> users = this.logic.GetRegisteredUsers();
            List<ListViewItem> items = users.Select(u => new ListViewItem(new string[] { u.Username, u.Friends.Count().ToString(), u.TimesConnected.ToString() })).ToList();
            this.listRegisteredClients.Items.Clear();
            this.listRegisteredClients.Items.AddRange(items.ToArray());
        }

        private void btnUpdateConnected_Click(object sender, EventArgs e)
        {
            List<Session> sessions = this.logic.GetConnectedSessions();
            List<ListViewItem> items = sessions.Select(s => new ListViewItem(
                new string[] { s.User.Username, s.User.Friends.Count().ToString(),
                    s.User.TimesConnected.ToString(), s.GetElapsedTime() })).ToList();
            this.listConnectedClients.Items.Clear();
            this.listConnectedClients.Items.AddRange(items.ToArray());
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
            Environment.Exit(0);
        }
    }
}
