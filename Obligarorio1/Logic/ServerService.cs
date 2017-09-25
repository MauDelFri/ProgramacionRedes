using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Exceptions;

namespace Obligarorio1
{
    public class ServerService
    {
        public ProtocolObjectsParser Parser;
        private HandleClient handleClient;

        public ServerService(HandleClient handleClient)
        {
            this.handleClient = handleClient;
            this.Parser = new ProtocolObjectsParser();
        }

        public void LoginService(string data)
        {
            try
            {
                User user = this.Parser.GetUser(data);
                //TODO
                // Como devolvemos error para que se envie al cliente???? (acordarse que la responsabilidad de enviar es el handler)
                this.handleClient.AcknowledgeResponse();
            }
            catch (InvalidMessageFormatException e)
            {
                Console.WriteLine(e.Message);
                this.handleClient.ErrorResponse(e.Message);
            }
        }
    }
}
