using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using HtmlAgilityPack;
using AngleSharp;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Newtonsoft.Json;
using System.Threading.Tasks;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Wpf;
using WebView2 = Microsoft.Web.WebView2.WinForms.WebView2;

namespace Bai4
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            LoadMovieData();
        }
        // Hold movie data
        public class Movie
        {
            public string Title { get; set; }
            public string Url { get; set; }
            public string ImageUrl { get; set; }
            public string Summary { get; set; }
        }

        private List<Movie> movies = new List<Movie>();

        private async void Form1_Load_1(object sender, EventArgs e)
        {
        }
        private async void LoadMovieData()
        {
            string url = "https://betacinemas.vn/phim.htm";
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(url);

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(response);

            // Parse the HTML to find movie data
            var movieNodes = doc.DocumentNode.SelectNodes("//div[contains(@class, \"col-lg-4 col-md-4 col-sm-8 col-xs-16 padding-right-30 padding-left-30 padding-bottom-30\")]");
            int movieCount = movieNodes.Count;
            progressBar1.Maximum = movieCount;

            foreach (var node in movieNodes)
            {
                var title = node.SelectSingleNode(".//h3")?.InnerText.Trim();
                var movieUrl = node.SelectSingleNode(".//a")?.GetAttributeValue("href", string.Empty);
                var imageUrl = node.SelectSingleNode(".//img")?.GetAttributeValue("src", string.Empty);
                Console.WriteLine($"Title: {title}");
                Console.WriteLine($"URL: {movieUrl}");

                if (!string.IsNullOrEmpty(movieUrl))
                {
                    Movie movie = new Movie
                    {
                        Title = title,
                        Url = "https://betacinemas.vn" + movieUrl,
                        ImageUrl = imageUrl
                    };
                    movies.Add(movie);
                }

                progressBar1.Value += 1; // Update progress bar
                await Task.Delay(100);   // Simulate delay for demo purposes
            }
            string filepath = "C:\\Users\\tung\\Downloads\\LTMCP\\Lab3\\23521744_23521782_23521650\\Lab4\\Bai4\\movies.json";
            // Save to JSON
            //File.WriteAllText(filepath, JsonConvert.SerializeObject(movies));

            // Load movies into ListBox
            foreach (var movie in movies)
            {
                listBox1.Items.Add(movie.Title);
            }

            progressBar1.Visible = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                var selectedMovie = movies[listBox1.SelectedIndex];
                Browser browser = new Browser(selectedMovie.Url);
            }
        }
    }
    

}
