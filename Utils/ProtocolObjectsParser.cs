using System.Linq;
using Utils.Exceptions;

namespace Utils
{
    public class ProtocolObjectsParser
    {
        public string[] GetUser(string data)
        {
            //Posiblemente tendriamos verificacion del formato de data 
            //(que realmente esta compuesta por 2 propiedades separadas por '-') antes de realizar el parseo?
            // hasta se podria llamar TryGetUser y tirar excepcion en caso de que no este bien el formato
            if (this.isMessageFormatValid(data, 2, 1))
            {
                string[] user = data.Split('-');
                return user;
            }
            else
            {
                throw new InvalidMessageFormatException("El formato del mensaje es incorrecto");
            }
        }

        private bool isMessageFormatValid(string message, int attributesAmount, int objectsAmount)
        {
            string[] objects = message.Split(Constants.OBJECT_SEPARATOR);
            return objects.Where(o => o.Split(Constants.ATTRIBUTE_SEPARATOR).Count() == attributesAmount).Count() == objectsAmount;
        }

        public string GetString(string data)
        {
            if (this.isMessageFormatValid(data, 1, 1))
            {
                return data;
            }
            else
            {
                throw new InvalidMessageFormatException("El formato del mensaje es incorrecto");
            }
        }

        public string[] GetListAttribute(string data)
        {
            string[] propertiesSplitted = data.Split(Constants.ATTRIBUTE_SEPARATOR);
            return propertiesSplitted;
        }

        public string[] GetListObject(string data)
        {
            string[] objectSplitted = data.Split(Constants.OBJECT_SEPARATOR);
            return objectSplitted;
        }

        public string[] GetStringArray(string data, int attributesCount)
        {
            if (this.isMessageFormatValid(data, attributesCount, 1))
            {
                return data.Split(Constants.ATTRIBUTE_SEPARATOR);
            }
            else
            {
                throw new InvalidMessageFormatException();
            }
        }
    }
}
