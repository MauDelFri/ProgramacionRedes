using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligarorio1
{
    public class ServerService
    {
        public ProtocolObjectsParser Parser;

        public ServerService()
        {
            this.Parser = new ProtocolObjectsParser();
        }

        public void LoginService(string data)
        {
            User user = this.Parser.GetUser(data);
            //TODO
            // Como devolvemos error para que se envie al cliente???? (acordarse que la responsabilidad de enviar es el handler)
        }
    }
}
