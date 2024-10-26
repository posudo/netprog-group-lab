using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class server : Form
    {
        private Socket serverSocket;
        private Socket clientSocket;
        private Thread listenThread;
        public server()
        {
            InitializeComponent();
            listenThread = new Thread(StartServer);
            listenThread.IsBackground = true;
            listenThread.Start();
        }
        private void StartServer()
        {
            try
            {
                // Tạo socket server
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Gán địa chỉ và cổng cho socket
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 8080);
                serverSocket.Bind(endPoint);

                // Chuyển socket vào chế độ lắng nghe
                serverSocket.Listen(10); // Chờ tối đa 10 client cùng lúc

                // Cập nhật UI để thông báo server đã sẵn sàng
                Invoke(new Action(() =>
                {
                    screen.AppendText("Server đang lắng nghe trên cổng 8080...\n");
                }));

                // Chấp nhận kết nối từ client
                clientSocket = serverSocket.Accept();

                // Cập nhật UI để thông báo đã kết nối với client
                Invoke(new Action(() =>
                {
                    screen.AppendText("Kết nối với client thành công!\n");
                }));

                // Xử lý dữ liệu từ client
                while (true)
                {
                    byte[] buffer = new byte[1024];
                    int received = clientSocket.Receive(buffer);
                    string text = Encoding.ASCII.GetString(buffer, 0, received);


                }
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi nếu có
                Invoke(new Action(() =>
                {
                    screen.AppendText("Lỗi: " + ex.Message + "\n");
                }));
            }
        }
    }
}
