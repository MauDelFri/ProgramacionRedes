using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class Constants
    {
        public const string REQUEST_HEADER = "REQ";
        public const string RESPONSE_HEADER = "RES";
        public const int ERROR_CODE = 99;
        public const int OK_CODE = 0;
        public const int LOGIN_CODE = 1;
        public const int LOGOUT_CODE = 2;
        public const int CONNECTED_USERS = 3;
        public const int GET_FRIENDS = 4;
        public const int SEND_FRIENDSHIP_REQUEST = 5;
        public const int RESPOND_FRIENDSHIP_REQUEST = 6;
        public const int FRIENDSHIP_ACCEPTED = 7;
        public const int SEND_MESSAGE = 8;
        public const int MESSAGE_READ = 9;
        public const int GET_PENDING_FRIENDSHIPS = 10;
        public const int GET_PENDING_MESSAGES = 11;

        public const char ATTRIBUTE_SEPARATOR = '-';
        public const char OBJECT_SEPARATOR = '|';
        public const string DATE_FORMAT = "dd/MM/yyyy HH:mm:ss";
        public const string ACCEPT_FRIENDSHIP_ACTION = "accept";
        public const string REJECT_FRIENDSHIP_ACTION = "reject";
        public const string SUCCESS_RESPONSE = "OK";
        public const string ERROR_RESPONSE = "ERROR:";
        public const string DEFAULT_SERVER_IP = "127.0.0.1";
        public const int DEFAULT_SERVER_PORT = 6000;
        public const int DEFAULT_CLIENT_PORT = 0;
    }
}
