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
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace Bai4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load_1(object sender, EventArgs e)
        {
            // Initialize HttpClient
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://betacinemas.vn/phim.htm");

            // Load the HTML document
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(response);

            // Use XPath or LINQ to parse the HTML
            var movieNodes = document.DocumentNode.SelectNodes("//div[@class='movie']");
            foreach (var node in movieNodes)
            {
                var title = node.SelectSingleNode(".//h2").InnerText;
                var showtimes = node.SelectNodes(".//span[@class='showtime']").Select(n => n.InnerText);

                Console.WriteLine($"Title: {title}");
                Console.WriteLine("Showtimes:");
                foreach (var time in showtimes)
                {
                    Console.WriteLine(time);
                }
            }
        }
    }
    

}
