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
    public partial class Server_Bai3 : Form
    {
        public Server_Bai3()
        {
            InitializeComponent();
        }
        private TcpListener tcpListener;
        private Thread serverThread;
        private void btnListen_Click(object sender, EventArgs e)
        {
            serverThread = new Thread(StartServer);
            serverThread.IsBackground = true;
            serverThread.Start();
            btnListen.Enabled = false;
            txtServerMessages.AppendText("Server started!\n");
        }
        private void StartServer()
        {
            tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
            tcpListener.Start();

            while (true)
            {
                try
                {
                    TcpClient client = tcpListener.AcceptTcpClient();
                    IPEndPoint clientEndPoint = (IPEndPoint)client.Client.RemoteEndPoint;
                    Invoke(new Action(() => txtServerMessages.AppendText($"Connection accepted from {clientEndPoint.Address}:{clientEndPoint.Port}\n")));

                    Thread clientThread = new Thread(() => HandleClient(client));
                    clientThread.Start();
                }
                catch (SocketException)
                {
                    break;
                }
            }
        }

        private void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Invoke(new Action(() => txtServerMessages.AppendText($"From client: {message}\n")));
            }

            client.Close();
            Invoke(new Action(() => txtServerMessages.AppendText("Client disconnected.\n")));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            tcpListener?.Stop();
            serverThread?.Join();
            base.OnFormClosing(e);
        }
    }
}
