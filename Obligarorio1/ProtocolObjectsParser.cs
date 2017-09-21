using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligarorio1
{
    public class ProtocolObjectsParser
    {
        public User GetUser(string data)
        {
            //Posiblemente tendriamos verificacion del formato de data 
            //(que realmente esta compuesta por 2 propiedades separadas por '-') antes de realizar el parseo?
            // hasta se podria llamar TryGetUser y tirar excepcion en caso de que no este bien el formato
            string[] propertiesSplitted = data.Split('-');
            User user = new User(propertiesSplitted[0], propertiesSplitted[1]);
            return user;
        }
    }
}
