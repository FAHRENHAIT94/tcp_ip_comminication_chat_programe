using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client_serversocketprogram.networking.packet
{
   public  class Message :PacketStructure
    {
        private string _message;
        public Message()
            :base(4+(ushort)message.Length,2000)
        {

            _message = message;
        }


        public string Text
        {
            get { return _message; }
            set { WriteString(value, 4); }
        }
    }
}
