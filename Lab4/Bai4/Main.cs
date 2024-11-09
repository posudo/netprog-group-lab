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
using System.Net;
using System.Text.RegularExpressions;

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
            var web = new HtmlWeb();
            var doc = web.Load(url);

            // Parse the HTML to find movie data
            var movieNodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'col-lg-4')]");
            int movieCount = movieNodes.Count;
            progressBar1.Maximum = movieCount;
            progressBar1.Visible = true;

            int progress = 0;
            foreach (var movieNode in movieNodes)
            {
                var movie = new Movie();

                // Extract the title and URL
                var titleNode = movieNode.SelectSingleNode(".//h3/a");
                if (titleNode != null)
                {
                    movie.Title = titleNode.InnerText.Trim();
                    movie.Url = "https://betacinemas.vn" + titleNode.GetAttributeValue("href", string.Empty);  // Combine relative URL with base URL
                }

                // Extract the image URL
                var imageNode = movieNode.SelectSingleNode(".//div[@class='pi-img-wrapper']//img");
                if (imageNode != null)
                {
                    movie.ImageUrl = imageNode.GetAttributeValue("src", string.Empty);
                }

                movies.Add(movie);

                // Update progress bar
                progress++;
                progressBar1.Value = progress;
            }
            string filepath = "C:\\Users\\tung\\Downloads\\LTMCP\\Lab3\\23521744_23521782_23521650\\Lab4\\Bai4\\movies.json";
            string localPath = "C:\\Users\\tung\\Downloads\\LTMCP";
            // Save to JSON
            //File.WriteAllText(filepath, JsonConvert.SerializeObject(movies));

            // Load movies into ListBox
            foreach (var movie in movies)
            {
                var movieItem = new MovieItemControl
                {
                    Title = movie.Title,
                    Link = movie.Url
                };

                if (!string.IsNullOrEmpty(movie.ImageUrl))
                {
                    string sanitizedTitle = Regex.Replace(movie.Title, @"[^A-Za-z0-9]", "_");
                    string fileName = Path.Combine(localPath, $"posterImage_{sanitizedTitle}.jpg");

                    // Check if the image file already exists
                    if (!File.Exists(fileName))
                    {
                        using (WebClient client = new WebClient())
                        {
                            try
                            {
                                // Download the file
                                client.DownloadFile(movie.ImageUrl, fileName);

                                // Load the image into the movie item
                                movieItem.PosterImage = Image.FromFile(fileName);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"An error occurred while downloading image for '{movie.Title}': " + ex.Message);
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

            progressBar1.Visible = true;
        }

    }
    

}
