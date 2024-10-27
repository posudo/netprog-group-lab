using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Lab3
{
    public partial class Lab03_Bai05_Server : Form
    {
        private List<ClientInfo> connectedClients = new List<ClientInfo>();
        public Lab03_Bai05_Server()
        {
            InitializeComponent();
        }

        private void Lab03_Bai05_Server_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread serverThread = new Thread(new ThreadStart(StartUnsafeThread));
            serverThread.Start();
            this.textBox_send_chat.KeyDown += new KeyEventHandler(textBox_send_chat_KeyDown);
        }
        public class ClientInfo
        {
            public Socket ClientSocket { get; set; }
            public string Username { get; set; }

            public ClientInfo(Socket socket, string username)
            {
                ClientSocket = socket;
                Username = username;
            }
        }
        void StartUnsafeThread()
        {
            Socket listenerSocket = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp
            );

            IPEndPoint ipepServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            listenerSocket.Bind(ipepServer);
            listenerSocket.Listen(-1);

            while (true)
            {
                Socket clientSocket = listenerSocket.Accept();
                Thread clientThread = new Thread(() => HandleClient(clientSocket));
                clientThread.Start();
            }
        }
        private void HandleClient(Socket clientSocket)
        {
            byte[] recv = new byte[1024];
            int bytesReceived;
            string username = "Unknown";
            ClientInfo clientInfo = null;

            while (clientSocket.Connected)
            {
                try
                {

                    bytesReceived = clientSocket.Receive(recv);
                    if (bytesReceived > 0)
                    {
                        byte header = recv[0];
                        if (header == 2)
                        {
                            username = Encoding.UTF8.GetString(recv, 1, bytesReceived - 1);
                            clientInfo = new ClientInfo(clientSocket, username);
                            connectedClients.Add(clientInfo);
                            listBox_participants.Items.Add(username);
                            BroadcastMessage("Server", $"{username} has joined the chat.");
                        }
                        if (header == 0)
                        {
                            string text = Encoding.UTF8.GetString(recv, 1, bytesReceived - 1);
                            BroadcastMessage(username, text);
                        }
                        else if (header == 1)
                        {
                            byte[] imageBytes = new byte[bytesReceived - 1];
                            Array.Copy(recv, 1, imageBytes, 0, bytesReceived - 1);
                            BroadcastImage(username,imageBytes);
                        }
                    }
                }
                catch (SocketException ex)
                {
                    MessageBox.Show($"Error: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
                lock (connectedClients)
                {
                    connectedClients.Remove(clientInfo);
                }
                clientSocket.Close();
        }  
private void BroadcastMessage(string username, string message)
{
            string timestamp = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            string formattedMessage = $"{timestamp} {username}:\n{message}\n";
    byte[] messageBytes = Encoding.UTF8.GetBytes(formattedMessage);
    byte[] messageToSend = new byte[messageBytes.Length + 1];
    messageToSend[0] = 0; 
    Array.Copy(messageBytes, 0, messageToSend, 1, messageBytes.Length);

    lock (connectedClients)
    {
        foreach (var clientInfo in connectedClients)
        {
            if (clientInfo.ClientSocket.Connected)
            {
                try
                {
                    clientInfo.ClientSocket.Send(messageToSend); 
                }
                catch (SocketException ex)
                {
                    MessageBox.Show($"Error sending message to client: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }    
    richTextBox_chat.AppendText(formattedMessage);
}
        private void BroadcastImage(string username, byte[] imageBytes)
        {
            string timestamp = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            lock (connectedClients)
            {
                foreach (var clientInfo in connectedClients)
                {
                    if (clientInfo.ClientSocket.Connected)
                    {
                        try
                        {
                            byte[] usernameBytes = Encoding.UTF8.GetBytes(username);
                            byte[] timestampBytes = Encoding.UTF8.GetBytes(timestamp);

                            int totalLength = 2 + usernameBytes.Length + timestampBytes.Length + imageBytes.Length;
                            byte[] messageToSend = new byte[totalLength];

                            messageToSend[0] = 1; 
                            messageToSend[1] = (byte)usernameBytes.Length; 

                            Array.Copy(usernameBytes, 0, messageToSend, 2, usernameBytes.Length);                   
                            Array.Copy(timestampBytes, 0, messageToSend, 2 + usernameBytes.Length, timestampBytes.Length);
                            Array.Copy(imageBytes, 0, messageToSend, 2 + usernameBytes.Length + timestampBytes.Length, imageBytes.Length);

                            clientInfo.ClientSocket.Send(messageToSend);
                        }
                        catch (SocketException ex)
                        {
                            MessageBox.Show($"Error sending image to client: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            richTextBox_chat.AppendText($"{timestamp} {username}:\n");
            InsertImageToChatBox(imageBytes);
            richTextBox_chat.AppendText("\n");
        }
        private void button_send_Click(object sender, EventArgs e)
        {
            try
            {
                string chat_text = textBox_send_chat.Text;
                BroadcastMessage("Server", chat_text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending chat: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_send_files_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|Image files (*.png;*.jpeg)|*.png;*.jpeg";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string filePath in openFileDialog.FileNames)
                    {
                        string fileExtension = Path.GetExtension(filePath);

                        if (fileExtension == ".txt")
                        {
                            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                            using (StreamReader reader = new StreamReader(fs))
                            {
                                string textContent = reader.ReadToEnd();
                                BroadcastMessage("Server", textContent);
                            }
                        }
                        else if (fileExtension == ".png" || fileExtension == ".jpeg")
                        {
                            byte[] imageBytes;
                            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                            {
                                imageBytes = new byte[fs.Length];
                                fs.Read(imageBytes, 0, imageBytes.Length);
                            }
                            BroadcastImage("Server", imageBytes);
                        }
                    }
                }
            }
        }
        private void InsertImageToChatBox(byte[] imageBytes)
        {
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                Image image = Image.FromStream(ms);
                Clipboard.SetImage(image);
                richTextBox_chat.ReadOnly = false;
                richTextBox_chat.Paste();
                richTextBox_chat.ReadOnly = true;
            }
        }
        private void textBox_send_chat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(e.Shift)
                {
                    return;
                }    
                e.SuppressKeyPress = true;
                button_send.PerformClick();
                textBox_send_chat.Text = "";
            }
        }
    }
}
