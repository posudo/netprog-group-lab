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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using static Lab3.Bai4;

namespace Lab3
{
    public partial class server : Form
    {
        private Socket serverSocket;
        private List<Socket> clientList;
        private Thread listenThread;
        private CancellationTokenSource cancellationTokenSource;

        private void SetUp_listView()
        {
            screen.View = View.Details;
            screen.Columns.Add("Name", 100);
            screen.Columns.Add("Movie", 150);
            screen.Columns.Add("Hall", 50);
            screen.Columns.Add("Seats ", 200);
        }
        public server()
        {
            InitializeComponent();
            clientList = new List<Socket>();
            cancellationTokenSource = new CancellationTokenSource();
            listenThread = new Thread(() => StartServer(cancellationTokenSource.Token));
            listenThread.IsBackground = true;
            listenThread.Start();
            SetUp_listView();
        }

        private void StartServer(CancellationToken token)
        {
            IPEndPoint IP = new IPEndPoint(IPAddress.Any, 9999);
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            serverSocket.Bind(IP);

            Thread listen = new Thread(() =>
            {
                try
                {
                    while (!token.IsCancellationRequested)
                    {
                        serverSocket.Listen(100);
                        Socket client = serverSocket.Accept();
                        clientList.Add(client);
                        Thread receiveThread = new Thread(() => Receive(client, token));
                        receiveThread.IsBackground = true;
                        receiveThread.Start();
                    }
                }
                catch (Exception ex)
                {
                    if (!token.IsCancellationRequested)
                    {
                        MessageBox.Show("Server error: " + ex.Message);
                        IP = new IPEndPoint(IPAddress.Any, 9999);
                        serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                    }
                }
            });
            listen.IsBackground = true;
            listen.Start();
        }

        private void Receive(Socket client, CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    byte[] data = new byte[1024 * 5000];
                    int receivedBytes = client.Receive(data);
                    if (receivedBytes > 0)
                    {
                        // Deserialize the data to a MovieTicket object to void casting exception
                        var ticketInfo = Deserialize(data) as MovieTicket;

                        if (ticketInfo != null)
                        {
                            // Construct a message string based on the MovieTicket properties
                            string message = $"{ticketInfo.Name}|{ticketInfo.Movie}|{ticketInfo.Hall}|{string.Join(",", ticketInfo.Seats)}|{ticketInfo.TotalPrice}";

                            // Create a ListViewItem for the ListView control
                            ListViewItem item = new ListViewItem(message.Split('|'));

                            // Update the ListView on the UI thread
                            screen.Invoke((MethodInvoker)(() =>
                            {
                                screen.Items.Add(item);
                            }));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested)
                {
                    clientList.Remove(client);
                    client.Close();
                    MessageBox.Show("Client disconnected: " + ex.Message);
                }
            }
        }



        private void ProcessClientMessage(string message, Socket client)
        {
            // Process the received message
            // Example: Broadcast the message to other clients
            foreach (Socket item in clientList)
            {
                if (item != null && item != client)
                {
                    item.Send(Serialize(message));
                }
            }
        }

        private byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            return stream.ToArray();
        }

        private object Deserialize(byte[] data)
        {
            try
            {
                string json = Encoding.UTF8.GetString(data).TrimEnd('\0'); // Convert byte array to JSON string
                return JsonConvert.DeserializeObject<MovieTicket>(json);   // Deserialize JSON to MovieTicket object
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Deserialization error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        // Close connection when form is closed
        private void server_FormClosed(object sender, FormClosedEventArgs e)
        {
            cancellationTokenSource.Cancel();

            foreach (Socket client in clientList)
            {
                client.Close();
            }
            serverSocket.Close();

            listenThread.Join(); // Wait for the listen thread to complete
        }
    }
}
