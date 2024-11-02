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
using System.Data.SqlClient;

namespace Lab3
{
    public partial class server : Form
    {
        Socket serverSocket;
        List<Socket> clientList;
        private Thread listenThread;
        private CancellationTokenSource cancellationTokenSource;

        private void SetUp_listView()
        {
            screen.View = View.Details;
            screen.Columns.Add("Name", 100);
            screen.Columns.Add("Movie", 150);
            screen.Columns.Add("Hall", 50);
            screen.Columns.Add("Seats ", 200);
            screen.Columns.Add("Total Price", 150);
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
                        // Deserialize the data to a MovieTicket object to avoid casting exception
                        var ticketInfo = Deserialize(data) as MovieTicket;

                        if (ticketInfo != null)
                        {
                            if (ticketInfo.Sign == 1)
                            {
                                if (!IsHallInDatabase(ticketInfo))
                                    InsertSeatAvailability(ticketInfo);
                            }
                            
                            if (ticketInfo.Sign == 2)
                            {
                                UpdateSeatAvailability(ticketInfo);

                                string message = $"{ticketInfo.Name}|{ticketInfo.Movie}|{ticketInfo.Hall}|" +
                                    $"{string.Join(", ", ticketInfo.Seats)}|{ticketInfo.TotalPrice}";
                                // Create a ListViewItem for the ListView control
                                ListViewItem item = new ListViewItem(message.Split('|'));

                                // Update the ListView on the UI thread
                                screen.Invoke((MethodInvoker)(() =>
                                {
                                    screen.Items.Add(item);
                                }));
                            }

                            if(ticketInfo.Sign == 3)
                            {
                                if (ticketInfo.Sign == 3) // Sign 3 means seat selection update
                                {
                                    // Broadcast the seat selection to all clients except the sender
                                    foreach (Socket otherClient in clientList)
                                    {
                                        if (otherClient != client) // Don't send back to the sender
                                        {
                                            string json = JsonConvert.SerializeObject(ticketInfo);
                                            otherClient.Send(Encoding.UTF8.GetBytes(json));
                                        }
                                    }
                                }
                            }

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
        

        private bool IsHallInDatabase(MovieTicket data)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Database=QUANLYRAP;Integrated Security=True";
            string query = "SELECT COUNT(*) FROM SeatAvailability WHERE TheaterID = @TheaterID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Assuming you have a method to get TheaterID from hall name
                        //int theaterID = GetTheaterIDFromHallName(hall);
                        cmd.Parameters.AddWithValue("@TheaterID", data.Hall);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                    // Log the error
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    // Log the error
                    return false;
                }
            }
        }

        private async void InsertSeatAvailability(MovieTicket data)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Database=QUANLYRAP;Integrated Security=True";
            string query = "INSERT INTO SeatAvailability (Seats, TheaterID, IsOccupied) VALUES (@Seats, @TheaterID, @IsOccupied)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync();
                    foreach (string seat in data.Seats)
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Seats", seat);
                            cmd.Parameters.AddWithValue("@TheaterID", Int32.Parse(data.Hall));
                            cmd.Parameters.AddWithValue("@IsOccupied", 0);

                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private async void UpdateSeatAvailability(MovieTicket data)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Database=QUANLYRAP;Integrated Security=True";
            string query = "UPDATE SeatAvailability SET IsOccupied = 1 WHERE Seats = @Seats AND TheaterID = @TheaterID AND IsOccupied = 0";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync();

                    foreach (string seat in data.Seats)
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Seats", seat);
                            cmd.Parameters.AddWithValue("@TheaterID", Int32.Parse(data.Hall));
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
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
