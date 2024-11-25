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
namespace Bai4
{
    public partial class Bai4 : Form
    {


        public Bai4()
        {
            InitializeComponent();
            seatSelect_clb.ItemCheck += SeatSelect_clb_ItemCheck;
            LoadMovieData();
        }
        public class Movie
        {
            public string TenPhim { get; set; }
            public string Url { get; set; }
            public string Poster { get; set; }
        }

        private List<Movie> movies = new List<Movie>();

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
            string localPath = "C:\\Users\\tung\\Downloads\\LTMCP";

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


        // Event xử lý chọn ghế đã được đặt
        private void SeatSelect_clb_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ////string selectedHall = chonRap_cb.SelectedItem?.ToString();
            //if (selectedHall == null) return;

            //string seat = seatSelect_clb.Items[e.Index].ToString();
            ////bool isSeatOccupied = IsSeatOccupiedInDatabase(selectedHall, seat);

            //if (isSeatOccupied)
            //{
            //    MessageBox.Show("This ticket has already been purchased.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    e.NewValue = CheckState.Unchecked; // Cancle thay đổi
            //}
        }


        List<string> selectedSeats = new List<string>();

        private void datVe_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(yourName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên của bạn.");
                return;
            }

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Vui lòng nhập email của bạn.");
                return;
            }
            if (phimSelection_cb.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một bộ phim.");
                return;
            }

            selectedSeats.Clear();


            if (selectedSeats.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một ghế.");
                return;
            }

            string selectedMovie = phimSelection_cb.SelectedItem.ToString();
            int totalPrice = 0;

            // Tính toán giá vé
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
            //if (!movieStatistics.ContainsKey(selectedMovie))
            //{
            //    movieStatistics[selectedMovie] = new MovieStatistics
            //    {
            //        MovieName = selectedMovie,
            //        TotalTickets = 15 * global[phimSelection_cb.SelectedIndex].RapChieu.Replace(" ", "").Split(',').Length
            //    };
            //}

            //movieStatistics[selectedMovie].TicketsSold += selectedSeats.Count;
            //movieStatistics[selectedMovie].Revenue += totalPrice;

            string bookingInfo = $"Xác nhận đặt vé:\n\n" +
                                 $"Tên: {yourName.Text}\n" +
                                 $"Phim: {selectedMovie}\n" +
                                 $"Ghế đã chọn: {string.Join(", ", selectedSeats)}\n" +
                                 $"Tổng tiền: {totalPrice:N0} VND";
            //Send_datVe();

            MessageBox.Show(bookingInfo, "Xác nhận đặt vé", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private List<string> strings = new List<string>();

        private async void seatSelect_clb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in seatSelect_clb.Items)
                {
                    string seat = item.ToString();
                    if (seatSelect_clb.CheckedItems.Contains(item))
                    {
                        if (!strings.Contains(seat))
                        {
                            strings.Add(seat);
                        }
                    }
                    else
                    {
                        if (strings.Contains(seat))
                        {
                            strings.Remove(seat);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating seat selection: {ex.Message}");
            }
        }

    }

}