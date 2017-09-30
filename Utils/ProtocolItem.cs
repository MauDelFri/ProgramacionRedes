using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class ProtocolItem
    {
        public String Header { get; set; }
        public int Command { get; set; }
        public int MessageLength { get; set; }
        public String Data { get; set; }

        public ProtocolItem()
        {
            this.Data = "";
            this.MessageLength = 0;
        }

        public ProtocolItem(string header, int command, string data)
        {
            this.Header = header;
            this.Command = command;
            this.Data = data;
            this.MessageLength = System.Text.Encoding.ASCII.GetBytes(this.Data).Length;
        }

        public byte[] GetAsByteArray()
        {
            List<byte> protocolItemByteArray = System.Text.Encoding.ASCII.GetBytes(this.Header.ToCharArray()).ToList();
            protocolItemByteArray.AddRange(BitConverter.GetBytes(this.Command).Take(2));
            protocolItemByteArray.AddRange(BitConverter.GetBytes(this.MessageLength));
            protocolItemByteArray.AddRange(System.Text.Encoding.ASCII.GetBytes(this.Data));

            return protocolItemByteArray.ToArray();
        }
    }
}
