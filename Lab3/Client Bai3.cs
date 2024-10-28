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

namespace Lab3
{
    public partial class Client_Bai3 : Form
    {
        public Client_Bai3()
        {
            InitializeComponent();
            tcpClient = new TcpClient();
        }
        private TcpClient tcpClient;
        private NetworkStream networkStream;
        private void txtClientMessages_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // Kết nối tới server (127.0.0.1:8080)
                if (!tcpClient.Connected)
                {
                    tcpClient.Connect("127.0.0.1", 8080);
                    networkStream = tcpClient.GetStream();
                    MessageBox.Show("Đã kết nối đến server.");
                }
                else
                {
                    MessageBox.Show("Đã kết nối rồi.");
                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Không thể kết nối tới Server. " + ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (tcpClient.Connected)
            {
                try
                {
                    // Gửi tin nhắn từ TextBox
                    byte[] data = Encoding.ASCII.GetBytes(txtClientMessages.Text);
                    networkStream.Write(data, 0, data.Length);
                    MessageBox.Show("Tin nhắn đã được gửi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi gửi tin nhắn. " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Chưa kết nối tới server. Vui lòng kết nối trước.");
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            networkStream?.Close();
            tcpClient?.Close();
            MessageBox.Show("Ngắt kết nối.");
        }
    }
}
