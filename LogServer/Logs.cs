using Domain;
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
using Utils;

namespace LogServer
{
    public partial class Logs : Form
    {
        private Thread thread;

        public Logs()
        {
            InitializeComponent();
            this.thread = new Thread(() => new LogMessageReveiver());
            this.thread.Start();
            Store.GetInstance().LogsPublish.Subscribe(data => this.OnLogPublished(data));
        }

        private void OnLogPublished(List<Log> logs)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    logs = logs.OrderByDescending(l => l.EventDate).ToList();
                    List<ListViewItem> items = logs.Select(l => new ListViewItem(new string[] { l.Event, l.EventDate.ToString(Constants.DATE_FORMAT) })).ToList();
                    this.listLogs.Clear();
                    this.listLogs.Items.AddRange(items.ToArray());
                }));
            }
        }
    }
}
