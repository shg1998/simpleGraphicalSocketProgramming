using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class Form1 : Form
    {

        string serverIP = "localhost";
        int port = 1080;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TcpClient client = new TcpClient(serverIP, port);

            int byteCount = Encoding.ASCII.GetByteCount(message.Text +1);

            byte[] sendBfr = new byte[byteCount];
            sendBfr = Encoding.ASCII.GetBytes(message.Text +";");

            NetworkStream stream = client.GetStream();
            stream.Write(sendBfr,0,sendBfr.Length);

            stream.Close();
            client.Close();

        }
    }
}
