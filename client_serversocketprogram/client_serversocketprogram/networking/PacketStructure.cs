using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client_serversocketprogram.networking
{
    public abstract class PacketStructure
    {

        private byte[] _buffer;

        public PacketStructure(ushort length, ushort type)
        {
            _buffer = new byte[length];
            WriteUshort(length, 0);
            WriteUshort(type, 2);
        }

        public void WriteUshort(ushort value,ushort offset)
        {
            byte[] tempbuf = new byte[2];
            tempbuf = BitConverter.GetBytes(value);
            Buffer.BlockCopy(tempbuf,0,_buffer,offset,2);
        }

        public void WriteUInt(uint value, int offset)
        {
            byte[] tempbuf = new byte[4];
            tempbuf = BitConverter.GetBytes(value);
            Buffer.BlockCopy(tempbuf, 0, _buffer, offset, 4);
        }

        public void WriteString(string value, int offset)
        {
            byte[] tempbuf = new byte[value.Length];
            tempbuf = Encoding.UTF8.GetBytes(value);
            Buffer.BlockCopy(tempbuf, 0, _buffer, offset, value.Length);
        }
    }
}
