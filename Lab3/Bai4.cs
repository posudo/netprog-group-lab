using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Lab3
{
    public partial class Bai4 : Form
    {
        [Serializable]
        public class MovieTicket
        {
            public string Name { get; set; }
            public string Movie { get; set; }
            public string Hall { get; set; }
            public List<string> Seats { get; set; }
            public int TotalPrice { get; set; }
            public bool IsInitialInfo { get; set; }
            public bool IsOccupied { get; set; }
        }

        private List<Thread> threads = new List<Thread>();
        private CancellationTokenSource cancellationTokenSource;
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

            Thread listen = new Thread(() => Receive(cancellationTokenSource.Token));
            listen.IsBackground = true;
            listen.Start();
            threads.Add(listen);
        }
        void CloseConnection()
        {
            client.Close();
        }

        private void Send_ThongTin()
        {
            if (chonRap_cb.InvokeRequired)
            {
                chonRap_cb.Invoke(new Action(Send_ThongTin));
            }
            else
            {
                var AddInfo = new MovieTicket
                {
                    Name = "null",
                    Movie = "null",
                    Hall = chonRap_cb.SelectedItem.ToString(),
                    Seats = new List<string> { "A1", "A2", "A3", "A4", "A5", "B1", "B2", 
                        "B3", "B4", "B5", "C1", "C2", "C3", "C4", "C5" },
                    IsInitialInfo = true,
                    IsOccupied = false,
                    TotalPrice = 0
                };
                string json = JsonConvert.SerializeObject(AddInfo);
                client.Send(Encoding.UTF8.GetBytes(json));
            }
        }

        void Send_datVe()
        {
            var bookingInfo = new MovieTicket
            {
                Name = yourName.Text,
                Movie = phimSelection_cb.SelectedItem?.ToString(),
                Hall = chonRap_cb.SelectedItem?.ToString(),
                Seats = selectedSeats,
                IsInitialInfo = false,
                IsOccupied = true,
                TotalPrice = selectedSeats.Sum(seat =>
                {
                    int basePrice = Int32.Parse(giaVeChuan_out.Text);
                    if (seat == "A1" || seat == "B1" || seat == "C1" || seat == "A5" || seat == "B5" || seat == "C5")
                        return basePrice / 4;
                    else if (seat == "B2" || seat == "B3" || seat == "B4")
                        return basePrice * 2;
                    else
                        return basePrice;
                })
            };


            string json = JsonConvert.SerializeObject(bookingInfo);
            client.Send(Encoding.UTF8.GetBytes(json));
        }

        object Deserialize(byte[] data)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream(data))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    return formatter.Deserialize(stream);
                }
            }
            catch (SerializationException ex)
            {
                MessageBox.Show($"Deserialization error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        void Receive(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    byte[] data = new byte[1024];
                    int receivedBytes = client.Receive(data);

                    if (receivedBytes > 0)
                    {
                        var response = Deserialize(data.Take(receivedBytes).ToArray());
                    }
                }
            }
            // SocketException: Client disconnected
            catch (SocketException ex)
            {
                MessageBox.Show($"Socket error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => this.Close()));
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => this.Close()));
                }
                else
                {
                    this.Close();
                }
            }
        }

        public Bai4()
        {
            InitializeComponent();
            ConnectToServer();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            seatSelect_clb.ItemCheck += SeatSelect_clb_ItemCheck;
            cancellationTokenSource = new CancellationTokenSource();
        }

        public class MovieStatistics
        {
            public string MovieName { get; set; }
            public int TicketsSold { get; set; }
            public int TotalTickets { get; set; }
            public int Revenue { get; set; }

            public int TicketsRemaining => TotalTickets - TicketsSold;
            public double SoldPercentage => (double)TicketsSold / TotalTickets * 100;
        }

        [Serializable]
        public class ThongTin
        {
            
            public string TenPhim { get; set; }
            public string RapChieu { get; set; }
            public string GiaVe { get; set; }
        }

        public class Hall
        {
            public Dictionary<string, bool> my_seat = new Dictionary<string, bool>
            {
                { "A1", false }, {"A2",false}, {"A3",false}, {"A4",false}, {"A5",false},
                { "B1", false }, {"B2",false}, {"B3",false}, {"B4",false}, {"B5",false},
                { "C1", false }, {"C2",false}, {"C3",false}, {"C4",false}, {"C5",false},
            };
        }
        List<ThongTin> my_list = new List<ThongTin>();
        Dictionary<string, Hall> my_hall = new Dictionary<string, Hall>();

        public void Luu(ThongTin[] thongtin)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();

                    bf.Serialize(fs, thongtin);
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Luu(my_list.ToArray());
        }

        public ThongTin[] DeserializeFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();

                ThongTin[] thongtins = (ThongTin[])bf.Deserialize(fs);
                fs.Close();
                return thongtins;
            }
            return null;
        }
        private bool IsCommaSeparated(string input)
        {
            string[] parts = input.Split(',');

            return parts.Length > 1 && parts.All(part => !string.IsNullOrWhiteSpace(part));
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (!IsCommaSeparated(rapChieu_box.Text) && rapChieu_box.Text.Length > 1)
            {
                MessageBox.Show("Rạp chiếu là một chuỗi được ngăn bởi dấu phẩy!");
                giaVe_box.Text = string.Empty;
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(giaVe_box.Text, @"^[1-9]\d*$"))
            {
                MessageBox.Show("Giá vé phải là một số không bắt đầu bằng 0 và không chứa ký tự.");
                giaVe_box.Text = string.Empty;
                return;
            }

            string[] rap_phim = rapChieu_box.Text.Replace(" ", "").Split(',');
            string ten_phim = tenPhim_box.Text.Replace(" ", "");
            string gia_ve = giaVe_box.Text.Replace(" ", "");

            foreach (ThongTin t in my_list)
            {
                if (ten_phim == t.TenPhim.Replace(" ", ""))
                {
                    MessageBox.Show("Tên phim đã tồn tại!");
                    tenPhim_box.Text = string.Empty;
                    giaVe_box.Text = string.Empty;
                    rapChieu_box.Text = string.Empty;
                    return;
                }

                if (rap_phim.SequenceEqual(t.RapChieu.Replace(" ", "").Split(',')))
                {
                    MessageBox.Show("Rạp chiếu đã tồn tại!");
                    tenPhim_box.Text = string.Empty;
                    giaVe_box.Text = string.Empty;
                    rapChieu_box.Text = string.Empty;
                    return;
                }
            }

            string[] a = { tenPhim_box.Text, rapChieu_box.Text, giaVe_box.Text };
            ThongTin b = new ThongTin();

            for (int i = 0; i < a.Length; i++)
            {
                if (string.IsNullOrEmpty(a[i]))
                {
                    screen.Items.Clear();
                    MessageBox.Show("Bạn nhập không đủ thông tin!");
                    tenPhim_box.Text = string.Empty;
                    rapChieu_box.Text = string.Empty;
                    giaVe_box.Text = string.Empty;
                    return;
                }
                else
                {
                    b.TenPhim = tenPhim_box.Text;
                    b.RapChieu = rapChieu_box.Text;
                    b.GiaVe = giaVe_box.Text;
                    screen.Items.Add(a[i]);
                }
            }
            screen.Items.Add('\n');
            my_list.Add(b);
        }

        ThongTin[] global;
        private void layInfo_dki_Click(object sender, EventArgs e)
        {
            ThongTin[] tt = DeserializeFile();
            phimSelection_cb.Items.Clear();
            global = tt;
            foreach (ThongTin t in global)
            {
                phimSelection_cb.Items.Add(t.TenPhim);
            }

        }

        private void phimSelection_cb_SelectedIndexChanged(object sender, EventArgs e)
        {

            seatSelect_clb.ClearSelected();


            for (int i = 0; i < seatSelect_clb.Items.Count; i++)
            {
                seatSelect_clb.SetItemChecked(i, false);
            }

            giaVeChuan_out.ReadOnly = true;
            if (phimSelection_cb.SelectedIndex >= 0 && phimSelection_cb.SelectedIndex < global.Length)
            {
                giaVeChuan_out.Text = global[phimSelection_cb.SelectedIndex].GiaVe;
                giaVeChuan_out.Refresh();
            }
            string[] rapChieu = global[phimSelection_cb.SelectedIndex].RapChieu.Replace(" ", "").Split(',');
            chonRap_cb.Items.Clear();
            foreach (string s in rapChieu)
            {
                my_hall[s] = new Hall();
                chonRap_cb.Items.Add(s);
            }
        }

        private async void chonRap_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chonRap_cb.SelectedItem == null) return;

            string selectedHall = chonRap_cb.SelectedItem.ToString();

            // Xóa ghế đã chọn trước đó
            for (int i = 0; i < seatSelect_clb.Items.Count; i++)
            {
                seatSelect_clb.SetItemChecked(i, false);
            }

            await Task.Run(() => Send_ThongTin());
        }


        // Event xử lý chọn ghế đã được đặt
        private void SeatSelect_clb_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string selectedHall = chonRap_cb.SelectedItem?.ToString();
            if (selectedHall == null) return;

            string seat = seatSelect_clb.Items[e.Index].ToString();
            bool isSeatOccupied = IsSeatOccupiedInDatabase(selectedHall, seat);

            if (isSeatOccupied)
            {
                MessageBox.Show("This ticket has already been purchased.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.NewValue = CheckState.Unchecked; // Cancle thay đổi
            }
        }

        // Check xem ghế đã được đặt chưa
        private bool IsSeatOccupiedInDatabase(string hall, string seat)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Database=QUANLYRAP;Integrated Security=True";
            string query = "SELECT IsOccupied FROM SeatAvailability WHERE TheaterID = @TheaterID AND Seats = @Seats";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TheaterID", Int32.Parse(hall));
                        cmd.Parameters.AddWithValue("@Seats", seat);

                        object result = cmd.ExecuteScalar();
                        if (result != null && Convert.ToBoolean(result))
                        {
                            return true;
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
            return false;
        }


        private Dictionary<string, MovieStatistics> movieStatistics = new Dictionary<string, MovieStatistics>();


        List<string> selectedSeats = new List<string>();

        private void datVe_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(yourName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên của bạn.");
                return;
            }

            if (phimSelection_cb.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một bộ phim.");
                return;
            }

            if (chonRap_cb.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một rạp.");
                return;
            }

            selectedSeats.Clear();
            foreach (var item in seatSelect_clb.CheckedItems)
            {
                selectedSeats.Add(item.ToString());

                if (seatSelect_clb.CheckedItems.Contains(item) && 
                    my_hall[chonRap_cb.SelectedItem.ToString()].my_seat.ContainsKey(item.ToString()))
                {
                    my_hall[chonRap_cb.SelectedItem.ToString()].my_seat[item.ToString()] = true;
                }
            }


            if (selectedSeats.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một ghế.");
                return;
            }

            string selectedHall = chonRap_cb.SelectedItem.ToString();
            string selectedMovie = phimSelection_cb.SelectedItem.ToString();
            int basePrice = Int32.Parse(giaVeChuan_out.Text);
            int totalPrice = 0;

            // Tính toán giá vé
            foreach (string seat in selectedSeats)
            {
                if (seat == "A1" || seat == "B1" || seat == "C1" || seat == "A5" || seat == "B5" || seat == "C5")
                {
                    totalPrice += basePrice * 1 / 4;
                }
                else if (seat == "B2" || seat == "B3" || seat == "B4")
                {
                    totalPrice += basePrice * 2;
                }
                else
                {
                    totalPrice += basePrice;
                }
            }
            if (!movieStatistics.ContainsKey(selectedMovie))
            {
                movieStatistics[selectedMovie] = new MovieStatistics
                {
                    MovieName = selectedMovie,
                    TotalTickets = 15 * global[phimSelection_cb.SelectedIndex].RapChieu.Replace(" ", "").Split(',').Length
                };
            }

            movieStatistics[selectedMovie].TicketsSold += selectedSeats.Count;
            movieStatistics[selectedMovie].Revenue += totalPrice;

            string bookingInfo = $"Xác nhận đặt vé:\n\n" +
                                 $"Tên: {yourName.Text}\n" +
                                 $"Phim: {selectedMovie}\n" +
                                 $"Ghế đã chọn: {string.Join(", ", selectedSeats)}\n" +
                                 $"Tổng tiền: {totalPrice:N0} VND";
            Send_datVe();
            MessageBox.Show(bookingInfo, "Xác nhận đặt vé", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private async void XuatThongTin_Click(object sender, EventArgs e)
        {
            var sortedStatistics = movieStatistics.Values.OrderByDescending(ms => ms.Revenue).ToList();
            int totalMovies = sortedStatistics.Count;

            SaveFileDialog sfd = new SaveFileDialog();

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false))
                    {
                        await sw.WriteLineAsync("Tên phim, Số lượng vé bán ra, Số lượng vé tồn," +
                            " Tỉ lệ vé bán ra, Doanh thu, Xếp hạng doanh thu phòng vé");

                        for (int i = 0; i < sortedStatistics.Count; i++)
                        {
                            var stats = sortedStatistics[i];
                            await sw.WriteLineAsync($"{stats.MovieName}, {stats.TicketsSold}," +
                                $" {stats.TicketsRemaining}, {stats.SoldPercentage:F2}%, {stats.Revenue:N0} VND, {i + 1}");

                            // Update ProgressBar on UI thread
                            int progress = (i + 1) * 100 / totalMovies;
                            this.Invoke((MethodInvoker)delegate {
                                progressBar1.Value = progress;
                            });
                        }
                    }

                    MessageBox.Show("Thông tin thống kê đã được xuất ra file thành công.",
                        "Xuất thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Reset ProgressBar khi hoàn thành
                    this.Invoke((MethodInvoker)delegate {
                        progressBar1.Value = 0;
                    });
                }
            }
        }

        // Đóng kết nối khi form đóng
        private void Bai4_FormClosed(object sender, FormClosedEventArgs e)
        {
            cancellationTokenSource.Cancel();
            CloseConnection();

            // Kiểm tra nếu có threads chạy nền

            foreach (var thread in threads)
            {
                if (thread.IsAlive)
                {
                    MessageBox.Show($"Thread {thread.ManagedThreadId} is still running.");
                }
            }
        }
    }

}
