using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FTPClient
{
    public partial class Client : Form
    {
        struct FileData
        {
            public string fName, fExt;
            public int fSize;
            public FileData(string name, string extension, int fSize)
            {
                fName = name; fExt = extension; this.fSize = fSize;
            }
        }

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
            FileInfo fi = new FileInfo(ofd.FileName);
            FileData fileData = new FileData(fi.Name, fi.Extension, sendData.Length);
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", Convert.ToInt32(portTxt.Texts));

                NetworkStream stream = client.GetStream();

                string sendFileData = $"{fileData.fName},{fileData.fExt},{fileData.fSize}";
                byte[] sendFileBytes = Encoding.ASCII.GetBytes(sendFileData);
                stream.Write(sendFileBytes, 0, sendFileBytes.Length);
                Thread.Sleep(1000);
                stream.Write(sendData, 0, sendData.Length);

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
