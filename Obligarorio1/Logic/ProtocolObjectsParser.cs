﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Utils.Exceptions;

namespace Obligarorio1
{
    public class ProtocolObjectsParser
    {
        public User GetUser(string data)
        {
            //Posiblemente tendriamos verificacion del formato de data 
            //(que realmente esta compuesta por 2 propiedades separadas por '-') antes de realizar el parseo?
            // hasta se podria llamar TryGetUser y tirar excepcion en caso de que no este bien el formato
            if (this.isMessageFormatValid(data, 2, 1))
            {
                string[] propertiesSplitted = data.Split('-');
                User user = new User(propertiesSplitted[0], propertiesSplitted[1]);
                return user;
            }
            else
            {
                throw new InvalidMessageFormatException("El formato del mensaje es incorrecto");
            }
        }

        private bool isMessageFormatValid(string message, int attributesAmount, int objectsAmount)
        {
            string[] objects = message.Split(Constants.objectSeparator);
            return objects.Where(o => o.Split(Constants.attributeSeparator).Count() == attributesAmount).Count() == objectsAmount;
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
    }
}