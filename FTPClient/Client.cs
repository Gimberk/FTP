using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace FTPClient
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK) return;

            if (MessageBox.Show($"File: \"{ofd.FileName}\"?", 
                "Upload File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == 
                DialogResult.No) return;

            byte[] sendData = File.ReadAllBytes(ofd.FileName);
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", Convert.ToInt32(portTxt.Texts));

                NetworkStream stream = client.GetStream();
                stream.Write(sendData, 0, sendData.Length);
                Console.WriteLine("sending data to server...");

                stream.Close();
                client.Close();
            }
            catch
            {
                Console.WriteLine("failed to connect...");
            }
        }
    }
}
