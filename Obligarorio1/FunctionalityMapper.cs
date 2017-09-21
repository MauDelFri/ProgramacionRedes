using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Obligarorio1
{
    public class FunctionalityMapper
    {
        public void MapCommandToService(ProtocolItem message)
        {
            ServerService service = new ServerService();
            switch (message.Command)
            {
                case 1:
                    service.LoginService(message.Data);
                    break;
                default:
                    break;
            }
        }
    }
}
