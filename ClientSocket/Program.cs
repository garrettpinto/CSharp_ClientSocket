using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace ClientSocket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int BUFFER_SIZE = 20248;
            IPAddress server_ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipe = new IPEndPoint(server_ip, 1234);


            Socket cs = new Socket(server_ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            cs.Connect(ipe);

            string msg;
            byte[] b = new byte[BUFFER_SIZE];

            // abcdefgh (first message)
            // BB (second message)
            // BBcdefgh

            Array.Clear(b, 0, b.Length);

            cs.Receive(b);

            msg = Encoding.ASCII.GetString(b).TrimEnd('\0');
            Console.WriteLine("[+] Received from server; {0}",msg);

            cs.Close();

            Console.ReadKey();
        }
    }
}
