using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class Constants
    {
        public static string REQUEST_HEADER = "REQ";
        public static string RESPONSE_HEADER = "RES";
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

        public static char ATTRIBUTE_SEPARATOR = '-';
        public static char OBJECT_SEPARATOR = '|';
    }
}
