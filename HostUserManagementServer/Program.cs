using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using UserManagementServer;

namespace HostUserManagementServer
{
    static class Program
    {
        static void Main(string[] args)
        {
            var serviceHost = new ServiceHost(typeof(UserManagementService));
            Console.WriteLine("Starting service...");
            serviceHost.Open();
            Console.ReadLine();
        }
    }
}
