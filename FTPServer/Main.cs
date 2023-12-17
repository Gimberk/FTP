using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FTPServer
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void StartServer()
        {
            TcpListener listener = new TcpListener(System.Net.IPAddress.Any, 26950);
            listener.Start();
            while (true)
            {
                Console.WriteLine("Waiting for a connection.");
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Client accepted.");
                NetworkStream stream = client.GetStream();
                StreamWriter sw = new StreamWriter(client.GetStream());
                try
                {
                    byte[] buffer = new byte[1024];
                    stream.Read(buffer, 0, buffer.Length);
                    int recv = 0;
                    foreach (byte b in buffer)
                    {
                        if (b != 0)
                        {
                            recv++;
                        }
                    }
                    string request = Encoding.UTF8.GetString(buffer, 0, recv);
                    Console.WriteLine("request received: " + request);
                    sw.WriteLine("You rock!");
                    sw.Flush();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Something went wrong.");
                    sw.WriteLine(e.ToString());
                }
            }
        }

        private void startServerBtn_Click(object sender, EventArgs e)
        {
            if (portTxt.Texts == string.Empty || !portTxt.Texts.All(char.IsDigit))
            {
                MessageBox.Show("Invalid Port", "Server Start Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Thread server = new Thread(StartServer); server.Start();
        }
    }
}
