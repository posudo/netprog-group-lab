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
using System.Collections.Concurrent;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Net.Mail;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices.ComTypes;
using static Bai4.Bai4;
namespace Bai4
{
    public partial class Bai4 : Form
    {


        public Bai4()
        {
            InitializeComponent();
            LoadMovieData();
        }
        public class Movie
        {
            public string TenPhim { get; set; }
            public string Url { get; set; }
            public string Poster { get; set; }
        }

        private List<Movie> movies = new List<Movie>();
        string localPath = "C:\\Users\\tung\\Downloads\\LTMCP";

        private async void LoadMovieData()
        {
            string url = "https://betacinemas.vn/phim.htm";
            var web = new HtmlWeb();
            var doc = await Task.Run(() => web.Load(url));

            // Parse the HTML to find movie data
            var movieNodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'col-lg-4')]");
            int movieCount = movieNodes.Count;

            foreach (var movieNode in movieNodes)
            {
                var movie = new Movie();

                // Extract the title and URL
                var titleNode = movieNode.SelectSingleNode(".//h3/a");
                if (titleNode != null)
                {
                    movie.TenPhim = titleNode.InnerText.Trim();
                    movie.Url = "https://betacinemas.vn" + titleNode.GetAttributeValue("href", string.Empty);  // Combine relative URL with base URL
                }

                // Extract the image URL
                var imageNode = movieNode.SelectSingleNode(".//div[@class='pi-img-wrapper']//img");
                if (imageNode != null)
                {
                    movie.Url = imageNode.GetAttributeValue("src", string.Empty);
                }

                movies.Add(movie);

            }

            // Load movies into ListBox
            foreach (var movie in movies)
            {
                phimSelection_cb.Items.Add(movie.TenPhim);
                var movieItem = new UserControl1
                {
                    Title = movie.TenPhim,
                    Link = movie.Url
                };

                if (!string.IsNullOrEmpty(movie.Url))
                {
                    string sanitizedTitle = Regex.Replace(movie.TenPhim, @"[^A-Za-z0-9]", "_");
                    string fileName = Path.Combine(localPath, $"posterImage_{sanitizedTitle}.jpg");

                    // Check if the image file already exists
                    if (!File.Exists(fileName))
                    {
                        using (WebClient client = new WebClient())
                        {
                            try
                            {
                                // Download the file
                                await client.DownloadFileTaskAsync(new Uri(movie.Url), fileName);

                                // Load the image into the movie item
                                movieItem.PosterImage = Image.FromFile(fileName);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"An error occurred while downloading image for '{movie.TenPhim}': " + ex.Message);
                            }
                        }
                    }
                    else
                    {
                        // Load the existing image file
                        movieItem.PosterImage = Image.FromFile(fileName);
                    }
                }

                flowLayoutPanel1.Controls.Add(movieItem);
            }

        }



        private void phimSelection_cb_SelectedIndexChanged(object sender, EventArgs e)
        {

            seatSelect_clb.ClearSelected();


            for (int i = 0; i < seatSelect_clb.Items.Count; i++)
            {
                seatSelect_clb.SetItemChecked(i, false);
            }

        }


        public class MovieStatistics
        {
            public string MovieName { get; set; } = null;
            public Dictionary<string, bool> my_seat = new Dictionary<string, bool>()
            {
                { "A1", false }, {"A2",false}, {"A3",false}, {"A4",false}, {"A5",false},
                { "B1", false }, {"B2",false}, {"B3",false}, {"B4",false}, {"B5",false},
                { "C1", false }, {"C2",false}, {"C3",false}, {"C4",false}, {"C5",false},
            };
            public string image { get; set; }
            public int Revenue { get; set; } = 0;
        }
        private Dictionary<string, MovieStatistics> movieStatistics = new Dictionary<string, MovieStatistics>();

        List<string> selectedSeats = new List<string>();
        private void datVe_Click(object sender, EventArgs e)
        {
            string selectedMovie = phimSelection_cb.SelectedItem.ToString();

            string sanitizedTitle = Regex.Replace(phimSelection_cb.SelectedItem.ToString(), @"[^A-Za-z0-9]", "_");
            string fileName = Path.Combine(localPath, $"posterImage_{sanitizedTitle}.jpg");

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
            if (!movieStatistics.ContainsKey(selectedMovie))
            {
                movieStatistics[selectedMovie] = new MovieStatistics
                {
                    MovieName = selectedMovie,
                    image = fileName
                };
            }
            selectedSeats.Clear();
            foreach (var item in seatSelect_clb.CheckedItems)
            {
                selectedSeats.Add(item.ToString());
                movieStatistics[phimSelection_cb.SelectedItem.ToString()].my_seat[item.ToString()] = true;
            }

            if (selectedSeats.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một ghế.");
                return;
            }

            int totalPrice = 0;
            movieStatistics[selectedMovie].Revenue = 0;

            // Tính toán giá vé
            // Giả sử giá vé là 100,000 VND
            foreach (string seat in selectedSeats)
            {
                if (seat == "A1" || seat == "B1" || seat == "C1" || seat == "A5" || seat == "B5" || seat == "C5")
                {
                    totalPrice += 100000 * 1 / 4;
                }
                else if (seat == "B2" || seat == "B3" || seat == "B4")
                {
                    totalPrice += 100000 * 2;
                }
                else
                {
                    totalPrice += 100000;
                }
            }

            movieStatistics[selectedMovie].Revenue += totalPrice;

            string bookingInfo = $"Xác nhận đặt vé:\n\n" +
                                 $"Tên: {yourName.Text}\n" +
                                 $"Phim: {movieStatistics[selectedMovie].MovieName}\n" +
                                 $"Ghế đã chọn: {string.Join(", ", selectedSeats)}\n" +
                                 $"Tổng tiền: {totalPrice:N0} VND";

            MessageBox.Show(bookingInfo, "Xác nhận đặt vé", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo đối tượng MailMessage
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("23521744@gm.uit.edu.vn");
                mail.To.Add(textBox1.Text);
                mail.Subject = "Xác nhận đặt mua vé xem phim";

                // Tạo nội dung email HTML
                string htmlBody = @"
                <html>
                <body>
                    <h2 style='color:blue;'>Xác nhận đặt mua vé xem phim</h2>
                    <p>Cảm ơn bạn đã đặt vé! Dưới đây là thông tin chi tiết:</p>";

                foreach (var item in movieStatistics.Values.ToList())
                {
                    // Lấy danh sách ghế đã chọn
                    List<string> seats = new List<string>();
                    foreach (var seat in item.my_seat)
                    {
                        if (seat.Value)
                        {
                            seats.Add(seat.Key);
                        }
                    }

                    // Thêm thông tin từng bộ phim vào email
                    htmlBody += $@"
                    <hr>
                    <p><b>Tên phim:</b> {item.MovieName}</p>
                    <p><b>Ghế đã chọn:</b> {string.Join(", ", seats)}</p>
                    <p><b>Tổng tiền:</b> {item.Revenue:N0} VND</p>";


                    // Đính kèm file ảnh
                    string imagePath = item.image; // Đường dẫn ảnh
                    Attachment inlineImage = new Attachment(imagePath);
                    inlineImage.ContentDisposition.Inline = true;
                    mail.Attachments.Add(inlineImage);
                }

                // Kết thúc nội dung email
                htmlBody += @"
                    <hr>
                    <p style='color:green;'>Chúc bạn có ngày tốt lành!</p>
                </body>
                </html>";

                mail.IsBodyHtml = true;
                mail.Body = htmlBody;

                // Cấu hình SMTP client
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("23521744@gm.uit.edu.vn", "dccm vgcu vjfv oips"),
                    EnableSsl = true
                };

                // Gửi email
                smtp.Send(mail);

                // Thông báo thành công
                MessageBox.Show("Email đã gửi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi nếu gửi thất bại
                MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}