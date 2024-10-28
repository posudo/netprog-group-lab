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
using System.Security.Cryptography;

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
        bool check_username(ClientInfo sus_client)
        {
            foreach(var client_info in connectedClients)
            {
                if(client_info.Username == sus_client.Username && client_info.ClientSocket!=sus_client.ClientSocket)
                {
                    return true;
                }
            }
            return false;
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
            byte[] recv = new byte[1024*5000];
            int bytesReceived;
            string username = "Unknown";
            bool remove_username = true;
            ClientInfo clientInfo = null;

            while (true)
            {
                try
                {
                    bytesReceived = clientSocket.Receive(recv);
                    if (bytesReceived > 0)
                    {
                        byte header = recv[0];
                        if (header == 3)
                        {
                            username = Encoding.UTF8.GetString(recv, 1, bytesReceived - 1);
                            Array.Clear(recv, 0, recv.Length);
                            if (check_username(clientInfo))
                            {
                                remove_username = false;
                                break;
                            }
                            BroadcastMessage("", $"\n{username} has left the chat.");
                            break; 
                        }
                        else if (header == 2)
                        {
                            username = Encoding.UTF8.GetString(recv, 1, bytesReceived - 1);
                            clientInfo = new ClientInfo(clientSocket, username);
                            connectedClients.Add(clientInfo);
                            if (check_username(clientInfo))
                            {
                                UsernameError("Username already be used.\n", clientInfo);
                                continue;
                            }
                            listBox_participants.Items.Add(username);
                            UpdateParticipantList();
                            BroadcastMessage("", $"\n{username} has joined the chat.");
                           
                            Array.Clear(recv, 0, recv.Length);
                        }
                        else if (header == 7)
                        {
                            string text = Encoding.UTF8.GetString(recv, 1, bytesReceived - 1);
                            string[] parts = text.Split(new char[] { ';' }, 2, StringSplitOptions.RemoveEmptyEntries);

                            if (parts.Length == 2)
                            {
                                string targetUsername = parts[0];
                                string privateMessage = parts[1];
                                SendPrivateChat(targetUsername, privateMessage);
                            }

                            Array.Clear(recv, 0, recv.Length);
                        }
                        else if (header == 6)
                        {
                            string text = Encoding.UTF8.GetString(recv, 1, bytesReceived - 1);
                            string[] parts = text.Split(new char[] { ';' }, 2, StringSplitOptions.RemoveEmptyEntries);

                            if (parts.Length == 2)
                            {
                                string targetUsername = parts[0];
                                string privateMessage = parts[1];
                                SendPrivateChat(targetUsername, privateMessage);
                            }

                            Array.Clear(recv, 0, recv.Length);
                        }    
                        else if (header == 0)
                        {
                            string text = Encoding.UTF8.GetString(recv, 1, bytesReceived - 1);
                            BroadcastMessage("",text);
                            Array.Clear(recv, 0, recv.Length);
                        }
                        else
                        { 
                            BroadcastImage(username, recv);
                            Array.Clear(recv, 0, recv.Length);
                        }
                    }
                }
                catch (SocketException ex)
                {
                    MessageBox.Show($"Error: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            if (clientInfo != null)
            {
                if(remove_username)
                { listBox_participants.Items.Remove(clientInfo.Username); }
                connectedClients.Remove(clientInfo);
                UpdateParticipantList();
                clientSocket.Close();
            }
        }  
        private void UsernameError(string message,ClientInfo error_client)
        {

            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            byte[] messageToSend = new byte[messageBytes.Length + 1];
            messageToSend[0] = 4;
            Array.Copy(messageBytes, 0, messageToSend, 1, messageBytes.Length);
            error_client.ClientSocket.Send(messageToSend);
        }
        private void BroadcastMessage(string username, string message)
{
            string formattedMessage;
            if (username == "Server"||message=="")
            {
                string timestamp = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
                formattedMessage = $"\n{timestamp} {username}:\n{message}";
            }
            else formattedMessage = $"{message}"; 
    byte[] messageBytes = Encoding.UTF8.GetBytes(formattedMessage);
    byte[] messageToSend = new byte[messageBytes.Length + 1];
    messageToSend[0] = 0; 
    Array.Copy(messageBytes, 0, messageToSend, 1, messageBytes.Length);

    
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
       
    richTextBox_chat.AppendText(formattedMessage);
}
        private void BroadcastImage(string username, byte[] imageBytes)
        {
           
            foreach (var clientInfo in connectedClients)
                {
                    if (clientInfo.ClientSocket.Connected)
                    {
                        try
                        {
                            clientInfo.ClientSocket.Send(imageBytes);
                        }
                        catch (SocketException ex)
                        {
                            MessageBox.Show($"Error sending image to client: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }



            richTextBox_chat.AppendText("\n");
            InsertImageToChatBox(imageBytes);
      BroadcastMessage(username, "");
        }
        private void button_send_Click(object sender, EventArgs e)
        {
            if (textBox_send_chat.Text != "")
            {
                try
                {
                    string chat_text = textBox_send_chat.Text;
                    BroadcastMessage("Server", chat_text);
                    textBox_send_chat.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error sending chat: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_send_files_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|Image files (*.jpeg;*.jpg;*.png;*.gif)|*.jpeg;*.jpg;*.png;*.gif";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string filePath in openFileDialog.FileNames)
                    {
                        string fileExtension = Path.GetExtension(filePath).ToLower();

                        if (fileExtension == ".txt")
                        {
                            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                            using (StreamReader reader = new StreamReader(fs))
                            {
                                string textContent = reader.ReadToEnd();
                                BroadcastMessage("Server", textContent);
                            }
                        }
                        else if (fileExtension == ".png" || fileExtension == ".jpeg" || fileExtension == ".jpg" || fileExtension == ".gif")
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
            if (richTextBox_chat.InvokeRequired)
            {

                richTextBox_chat.Invoke(new Action<byte[]>(InsertImageToChatBox), imageBytes);
                return;
            }
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                Image image = Image.FromStream(ms);
                Clipboard.SetImage(image);

                richTextBox_chat.SelectionStart = richTextBox_chat.TextLength;
                richTextBox_chat.SelectionLength = 0;

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

        private void UpdateParticipantList()
        {
            StringBuilder participants = new StringBuilder();
            foreach (var clientInfo in connectedClients)
            {
                participants.AppendLine(clientInfo.Username);
            }

            byte[] messageBytes = Encoding.UTF8.GetBytes(participants.ToString());
            byte[] messageToSend = new byte[messageBytes.Length + 1];
            messageToSend[0] = 5;
            Array.Copy(messageBytes, 0, messageToSend, 1, messageBytes.Length);

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
                        MessageBox.Show($"Error sending participant list to client: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Lab03_Bai05_Client client = new Lab03_Bai05_Client();
            client.Show();

        }
        private void SendPrivateChat(string target, string message)
        {
            target = target.Trim();
            foreach (var client in connectedClients)
            {
           

                if (string.Equals(client.Username, target, StringComparison.OrdinalIgnoreCase))
                {
                    byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                    byte[] messageToSend = new byte[messageBytes.Length + 1];
                    messageToSend[0] = 6;
                    Array.Copy(messageBytes, 0, messageToSend, 1, messageBytes.Length);

                    client.ClientSocket.Send(messageToSend);

         
                    return;
                }
            }
        }

    }
}
