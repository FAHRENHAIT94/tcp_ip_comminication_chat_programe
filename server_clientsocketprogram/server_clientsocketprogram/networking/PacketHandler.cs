using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace server_clientsocketprogram.networking
{
   public static class PacketHandler
    {

        public static void Handle(byte[] packet,Socket clientsocket)
        {

            ushort packetLength = BitConverter.ToUInt16(packet, 0);
            ushort packetType = BitConverter.ToUInt16(packet, 2) ;
            Console.WriteLine("PAKET ALINDI boyut:{0} | tip:{1}",packetLength,packetType);


        }
    }
}
