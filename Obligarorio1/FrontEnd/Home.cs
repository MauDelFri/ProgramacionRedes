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

        public Home()
        {
            InitializeComponent();
            this.logic = new ServerLogic();
        }
    }
}
