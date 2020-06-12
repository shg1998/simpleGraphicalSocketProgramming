using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace socketProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = Dns.GetHostEntry("localhost").AddressList[0];
            TcpListener server = new TcpListener(ip, 1080);
            TcpClient client = default(TcpClient);
            try
            {
                server.Start();
                Console.WriteLine("server started ...");
                Console.Read();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Read();
            }

            while (true)
            {
                client = server.AcceptTcpClient();
                byte[] recivedBfr = new byte[100];
                NetworkStream stream = client.GetStream();

                stream.Read(recivedBfr, 0, recivedBfr.Length);

                StringBuilder ms = new StringBuilder();
                foreach (byte b in recivedBfr)
                {
                    if (b.Equals(00))
                    {
                        break;
                    }
                    else
                    {
                        ms.Append(Convert.ToChar(b).ToString());
                    }
                }
                Console.WriteLine(ms.ToString() + ms.Length);
                Console.Read();
            }
        }
    }
}
