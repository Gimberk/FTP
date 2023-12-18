using System;
using System.Drawing;
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

        private void SendMessage(StreamWriter sw, string msg)
        {
            sw.WriteLine(msg);
            sw.Flush();
        }

        private void BytesToImage(byte[] bytes, string outPath)
        {
            Image img = Image.FromStream(new MemoryStream(bytes));
            img.Save(outPath);
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
                try
                {
                    byte[] buffer = new byte[450000];
                    stream.Read(buffer, 0, buffer.Length);
                    BytesToImage(buffer, Path.Combine("C:", "Users", "james", "idkimg.PNG"));
                }
                catch
                {
                    Console.WriteLine("Something went wrong.");
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