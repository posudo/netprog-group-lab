using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using static Lab6.PhongVe;
using Newtonsoft.Json;

namespace Lab6
{
    public partial class SuperUser : Form
    {

        public SuperUser()
        {
            InitializeComponent();
        }

        private List<Thread> threads = new List<Thread>();
        private CancellationTokenSource cancellationTokenSource; // This field is declared but never used
        IPEndPoint IP;
        Socket client;

        void ConnectToServer()
        {
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            try
            {
                client.Connect(IP);
            }
            catch (SocketException ex)
            {
                MessageBox.Show($"Không thể kết nối với server! Lỗi: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        [Serializable]
        public class ThongTinDongMo
        {
            public string ID { get; set; }
            public string Header { get; set; }
        }

        void SendToSV(string header)
        {
            var thongTinDongMo = new ThongTinDongMo
            {
                ID = btn_ID_quay.Text,
                Header = header
            };
            string userData = $"DONGMO;{JsonConvert.SerializeObject(thongTinDongMo)}";
            client.Send(Encoding.UTF8.GetBytes(userData));
        }


        private void SuperUser_Load(object sender, EventArgs e)
        {
            Thread connect = new Thread(ConnectToServer);
            connect.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendToSV("MO");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SendToSV("DONG");
        }
    }
}
