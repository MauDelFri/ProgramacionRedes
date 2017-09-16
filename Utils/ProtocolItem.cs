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

        public ProtocolItem() { }

        public byte[] GetAsByteArray()
        {
            byte[] protocolItemByteArray = System.Text.Encoding.ASCII.GetBytes(this.Header.ToCharArray(), 0, 3);
            protocolItemByteArray.Concat(BitConverter.GetBytes(this.Command).Skip(6));
            protocolItemByteArray.Concat(BitConverter.GetBytes(this.MessageLength));
            protocolItemByteArray.Concat(System.Text.Encoding.ASCII.GetBytes(this.Data));

            return protocolItemByteArray;
        }
    }
}
