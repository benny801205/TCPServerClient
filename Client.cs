using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net.Sockets;
using System.IO;

namespace Scoket
{
    class Program
    {
        static void Main(string[] args)
        {
            string serverIP = "192.168.1.196";
            int port = 8080;
            TCPClient(port, serverIP);

        }

        public static void TCPClient(int port, string serverIP)
        {
            string msg = "hello";
            TcpClient client = new TcpClient(serverIP, port);
            int bytecount = Encoding.ASCII.GetByteCount(msg);
            byte[] senddata = new byte[bytecount];
            senddata = Encoding.ASCII.GetBytes(msg);
            NetworkStream stream = client.GetStream();
            stream.Write(senddata, 0, senddata.Length);
            stream.Close();
            client.Close();
        }





        public static void sendUserInfoToServer(int port, string serverIP )
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Connect(serverIP, port);
            byte[] buffer = Encoding.ASCII.GetBytes("I'm from C#dedededededdefefefefefefefefggggggggggggggggggggggggggggggggggggggggg");
            s.Send(buffer);
            Console.WriteLine("snet");

            //receive
            byte[] rcvLenBytes = new byte[4];
            s.Receive(rcvLenBytes);
            int rcvLen = System.BitConverter.ToInt32(rcvLenBytes, 0);
            byte[] rcvBytes = new byte[rcvLen];
            s.Receive(rcvBytes);
            String rcv = System.Text.Encoding.ASCII.GetString(rcvBytes);

            Console.WriteLine("Client received: " + rcv);


        }



    }


}
