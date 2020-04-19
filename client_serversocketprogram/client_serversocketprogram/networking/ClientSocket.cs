using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace client_serversocketprogram.networking
{
    public class ClientSocket
    {

        private Socket _socket;
        private byte[] _buffer;




        public ClientSocket()

        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        }


        public void Connect(string ipAdress,int port)
        {
            _socket.BeginConnect(new IPEndPoint(IPAddress.Parse(ipAdress),port),ConnectCallback,null);


        }
        public void ConnectCallback(IAsyncResult result)
        {
            if (_socket.Connected)
            {
                Console.WriteLine("bağlantı yapıldı");
                _buffer = new byte[1024];
                _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, RecaivedCallback, null);


        

            }
            else
            {

                Console.WriteLine("bağlantı yapılamadı");
            }
           

        }
        private void RecaivedCallback(IAsyncResult result)
        {
            int buflength = _socket.EndReceive(result);
            byte[] packet = new byte[buflength];
            Array.Copy(_buffer,packet,packet.Length);


            //veri tutma

            _buffer = new byte[1024];
            _socket.BeginReceive(_buffer,0,_buffer.Length,SocketFlags.None,RecaivedCallback,null);


        }


    }
}
