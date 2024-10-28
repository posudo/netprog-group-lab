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
    public partial class Lab03_Bai05_Client : Form
    {
        private List<ClientInfo> connectedClients = new List<ClientInfo>();
        private Socket clientSocket;
        Thread receiveThread;
        private string privateChatTarget = null;

        public Lab03_Bai05_Client()
        {
            InitializeComponent();
        }

        private void Lab03_Bai05_Client_Load(object sender, EventArgs e)
        {
            
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

        private void SendMessage(string username, string message)
        {
            string formattedMessage;
            byte[] messageBytes;
            byte[] messageToSend;

            if (message == "0") // Disconnect message
            {
                formattedMessage = $"{username}";
                messageBytes = Encoding.UTF8.GetBytes(formattedMessage);
                messageToSend = new byte[messageBytes.Length + 1];
                messageToSend[0] = 3; // Header for disconnect
       
            }
            else if (message == "1") // Other specific message if needed
            {
                formattedMessage = $"{username}";
                messageBytes = Encoding.UTF8.GetBytes(formattedMessage);
                messageToSend = new byte[messageBytes.Length + 1];
                messageToSend[0] = 2;
            }
            else
            {
                string timestamp = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
                 formattedMessage = $"\n{timestamp} {username}:\n{message}";
                messageBytes = Encoding.UTF8.GetBytes(formattedMessage);
                messageToSend = new byte[messageBytes.Length + 1];
                messageToSend[0] = 0; 
            }
            Array.Copy(messageBytes, 0, messageToSend, 1, messageBytes.Length);
            try
            {
                clientSocket.Send(messageToSend);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending chat: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SendImage(string username, byte[] imageBytes)
        {

                if (clientSocket.Connected)
                {
                    try
                    {
                        clientSocket.Send(imageBytes);
                    }
                    catch (SocketException ex)
                    {
                        MessageBox.Show($"Error sending image to client: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
           
        }
        private void button_send_Click(object sender, EventArgs e)
        {
            if (textBox_send_chat.Text != "")
            {
                SendMessage(textBox_username.Text, textBox_send_chat.Text);
                textBox_send_chat.Text = "";
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
                                //clientSocket.Send(textContent);
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
                            SendImage(textBox_username.Text, imageBytes);
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
                richTextBox_chat.ReadOnly = false;
                richTextBox_chat.Paste();
                richTextBox_chat.ReadOnly = true;
            }
        }
        private void textBox_send_chat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (e.Shift)
                {
                    return;
                }
                e.SuppressKeyPress = true;
                button_send.PerformClick();
                textBox_send_chat.Text = "";
            }
        }

        private void ReceiveData()
        {
      
            byte[] recvBuffer = new byte[1024 * 5000];
            bool check_connect = true;
            while (clientSocket!=null)
            {
                try
                {
                    int bytesReceived = clientSocket.Receive(recvBuffer);
            

                    if (bytesReceived > 0)
                    {

                        byte header = recvBuffer[0];
                        if (header == 4)
                        {
                            check_connect = false;
                            string message = Encoding.UTF8.GetString(recvBuffer, 1, bytesReceived - 1);
                            richTextBox_chat.Invoke(new Action(() =>
                            {
                                richTextBox_chat.AppendText(message);
                                button_disconnect.PerformClick();
                            }));
                        }
                        if (check_connect)
                       {     check_connect = false;
                            MessageBox.Show("Connected to server!", "Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        if (header == 5)
                        {
                            string participants = Encoding.UTF8.GetString(recvBuffer, 1, bytesReceived - 1);
                            UpdateParticipantList(participants);
                        }
                        else if (header == 0) 
                        {
                           string message = Encoding.UTF8.GetString(recvBuffer, 1, bytesReceived - 1);
                         richTextBox_chat.AppendText(message);
                        }
                        else 
                        {
                            richTextBox_chat.AppendText("\n");
                            InsertImageToChatBox(recvBuffer);
                           
                        }
                        
                    }
                   


                }
                catch (SocketException ex)
                {
                    MessageBox.Show($"Connection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                
            }
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect("127.0.0.1", 8080);

                
                receiveThread = new Thread(ReceiveData);
                receiveThread.Start();
               
                if (textBox_username.Text == "") textBox_username.Text = "Unknown";
                SendMessage(textBox_username.Text, "1");


                
                button_connect.Enabled = false;
                textBox_username.ReadOnly = true;
                button_disconnect.Enabled = true;
                button_send.Enabled = true;
                button_send_files.Enabled = true;
                button_private_chat.Enabled = true;
                textBox_send_chat.ReadOnly = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to server: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_disconnect_Click(object sender, EventArgs e)
        {
            if (clientSocket != null && clientSocket.Connected)
            {
                receiveThread.Abort();
        SendMessage(textBox_username.Text, "0");
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
                
                clientSocket = null; 
                MessageBox.Show("Disconnected from server.", "Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Update UI
                button_connect.Enabled = true;
                textBox_username.ReadOnly = false;
                button_disconnect.Enabled = false;
                button_send.Enabled = false;
                button_send_files.Enabled = false;
                button_private_chat.Enabled = false;
                textBox_send_chat.ReadOnly = true;

          
            }
        }

        private void UpdateParticipantList(string participants)
        {
            if (listBox_participants.InvokeRequired)
            {
                listBox_participants.Invoke(new Action<string>(UpdateParticipantList), participants);
                return;
            }

            listBox_participants.Items.Clear();
            string[] usernames = participants.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string username in usernames)
            {
                listBox_participants.Items.Add(username);
            }
        }

        private void button_private_chat_Click(object sender, EventArgs e)
        {
            if (listBox_participants.SelectedItem != null)
            {
                privateChatTarget = listBox_participants.SelectedItem.ToString();
                richTextBox_chat.AppendText($"Private chat with {privateChatTarget} starts now, send >exit to exit:\n");
                SendMessage(privateChatTarget, "private");
            }
            else
            {
                MessageBox.Show("Please select a participant to chat with.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
