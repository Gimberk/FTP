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
        private void SendMessage(StreamWriter sw, byte[] data)
        {
            sw.WriteLine(data);
            sw.Flush();
        }

        private void BytesToFile(byte[] bytes, string outPath)
        {
            File.WriteAllBytes(outPath, bytes);
        }

        private void StartServer()
        {
            TcpListener listener = new TcpListener(System.Net.IPAddress.Any, 26950);
            listener.Start();

            Console.WriteLine("Waiting for a connection.");
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Client accepted.");
            NetworkStream stream = client.GetStream();
            try
            {
                byte[] fileDataBuffer = new byte[3000];
                stream.Read(fileDataBuffer, 0, fileDataBuffer.Length);
                int recv = 0;
                foreach (byte b in fileDataBuffer)
                {
                    if (b != 0)
                    {
                        recv++;
                    }
                }
                string[] fileData = Encoding.UTF8.GetString(fileDataBuffer, 0, recv).Split(',');
                // +10 probably not necessary, just to be safe
                byte[] fileBuffer = new byte[Convert.ToInt32(fileData[2])+10];
                stream.Read(fileBuffer, 0, fileBuffer.Length);
                BytesToFile(fileBuffer, Path.Combine("C:", "Users", "james", 
                    $"{fileData[0]}{fileData[1]}"));
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong: " + e.Message);
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