using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class SocketUtils
    {
        private static int FixedMessageLengthSize = 9;
        public static ProtocolItem RecieveMessage(Socket socket)
        {
            ProtocolItem item = RecieveHeader(socket);
            item = RecieveSpecificSizedMessage(socket, item);
            return item;
        }

        private static ProtocolItem RecieveHeader(Socket socket)
        {
            int received = 0;
            var headerBytes = new Byte[FixedMessageLengthSize];
            while (received < FixedMessageLengthSize)
            {
                received += socket.Receive(headerBytes, received, FixedMessageLengthSize - received, SocketFlags.None);
            }

            ProtocolItem item = new ProtocolItem();
            item.Header = Encoding.ASCII.GetString(headerBytes.Take(3).ToArray());
            byte[] commandBytes = new byte[] {0, 0};
            commandBytes.Concat(headerBytes.Skip(3).Take(2).ToArray());
            item.Command = BitConverter.ToInt16(commandBytes, 0);
            item.MessageLength = BitConverter.ToInt16(headerBytes, 5);

            return item;
        }

        private static ProtocolItem RecieveSpecificSizedMessage(Socket socket, ProtocolItem item)
        {
            int received = 0;
            var data = new Byte[item.MessageLength];
            while (received < data.Length)
            {
                received += socket.Receive(data, received, data.Length, SocketFlags.None);
            }

            item.Data = Encoding.ASCII.GetString(data);
            return item;
        }

        public static ProtocolItem SendMessage(Socket socket, ProtocolItem item)
        {
            SendMessageAsProtocolItem(socket, item);
            return RecieveMessage(socket);
        }

        private static void SendMessageAsProtocolItem(Socket socket, ProtocolItem item)
        {
            var data = item.GetAsByteArray();
            int sent = 0;
            while (sent < data.Length)
            {
                sent += socket.Send(data, sent, data.Length - sent, SocketFlags.None);
            }
        }
    }

    public static class SocketExtensions
    {
        public static bool IsConnected(this Socket socket)
        {
            try
            {
                return !(socket.Poll(1, SelectMode.SelectRead) && socket.Available == 0);
            }
            catch (SocketException) { return false; }
        }
    }
}
