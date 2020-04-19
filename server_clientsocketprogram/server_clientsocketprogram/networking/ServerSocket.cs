using System;
using System.Net;
using System.Net.Sockets;

namespace server_clientsocketprogram.networking
{
    public class ServerSocket
    {

        private Socket _socket;
        private byte[] _buffer = new byte[1024];

        public ServerSocket()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


        }


        public void Bind(int port)
        {
            _socket.Bind(new IPEndPoint(IPAddress.Any, port));
        }

        public void Listener(int backlog)
        {
            _socket.Listen(5000);

        }


        public void Accept()
        {
            _socket.BeginAccept(AcceptedCallback, null);

        }

        private void AcceptedCallback(IAsyncResult result)
        {

            Socket clientSocket = _socket.EndAccept(result);

            if (clientSocket != null)
          _buffer = new byte[1024];
           
            clientSocket.BeginReceive(_buffer,0,_buffer.Length,SocketFlags.None,RecaiveCallback,clientSocket);

            Accept();
        }

        private void RecaiveCallback(IAsyncResult result)
        {
            Socket clientSocket = result.AsyncState as Socket;
           

          int bufferSize=  clientSocket.EndReceive(result);
         
            byte[] packet = new byte[bufferSize];
            Array.Copy(_buffer,packet,packet.Length);



            //gelen verileri tutma

            PacketHandler.Handle(packet, clientSocket);
            _buffer = new byte[1024];
            clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, RecaiveCallback, clientSocket);

        }
    }
}
