using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace HostRepository
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpChannel serverChannel = new TcpChannel(6100);
            try
            {
                ChannelServices.RegisterChannel(serverChannel, false);
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(Repository), "Repository", WellKnownObjectMode.Singleton);
                Console.WriteLine("Remoting service started ...\n\n");
                Console.ReadLine();
            }
            catch (Exception)
            {
                ChannelServices.UnregisterChannel(serverChannel);
            }
        }
    }
}
