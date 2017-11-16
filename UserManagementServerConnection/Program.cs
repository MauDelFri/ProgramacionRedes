using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserManagementServer;

namespace UserManagementServerConnection
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var serviceHost = new ServiceHost(typeof(UserManagementService)))
            {
                Console.WriteLine("Starting service...");
                serviceHost.Open();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Connection());
        }
    }
}
