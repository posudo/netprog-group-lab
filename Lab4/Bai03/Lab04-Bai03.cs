using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using Microsoft.Web.WebView2.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Web.WebView2.Core;
using System.Security.Policy;
using System.Text.RegularExpressions;

namespace web_server
{
    public partial class Form3 : Form
    {
        private string url;
        public Form3()
        {
            InitializeComponent();
            this.Resize += Form3_Resize;
        }
        private void Form3_Resize(object sender, EventArgs e)
        {
            webShow.Size = this.ClientSize;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            webShow.EnsureCoreWebView2Async(null);
        }

        private void downHTML(string szURL, string fileurl)
        {
            WebClient client = new WebClient();
            Stream response = client.OpenRead(szURL);
            client.DownloadFile(szURL, fileurl);
        }
        private void button_files_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(url)) return;
            string file = "web.html";
            downHTML(url, file);
        }
        private void button_load_Click(object sender, EventArgs e)
        {
            string input = textBox_url.Text.Trim();
            if (string.IsNullOrWhiteSpace(input)) return;

            string pattern = @"^[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$";
            if (Regex.IsMatch(input, pattern))
            {
                url = "http://" + input;
            }
            else if (input.StartsWith("http"))
            { url = input; }
            else
            {
                if (input.StartsWith("http")) url = input;
                url = "https://www.google.com/search?q=" + Uri.EscapeDataString(input);
            }
            webShow.CoreWebView2.Navigate(url);
        }
        private void button_reload_Click(object sender, EventArgs e)
        {
            if (webShow != null && webShow.CoreWebView2 != null)
            {
                webShow.CoreWebView2.Reload();
            }
        }
        private async void button_resources_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(url)) return;

            string htmlContent = await new WebClient().DownloadStringTaskAsync(url);

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(htmlContent);

            var imageNodes = doc.DocumentNode.SelectNodes("//img");
            if (imageNodes != null)
            {
                string directoryPath = Path.Combine(Environment.CurrentDirectory, "images");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                foreach (var img in imageNodes)
                {
                    string imgUrl = img.GetAttributeValue("src", null);
                    if (imgUrl != null)
                    {
                        if (!imgUrl.StartsWith("http"))
                        {
                            Uri baseUri = new Uri(url);
                            imgUrl = new Uri(baseUri, imgUrl).ToString();
                        }
                        string fileName = Path.GetFileName(imgUrl);
                        if (!string.IsNullOrEmpty(fileName))
                        {
                            string filePath = Path.Combine(directoryPath, fileName);
                            try
                            {
                                using (WebClient client = new WebClient())
                                {
                                    await client.DownloadFileTaskAsync(imgUrl, filePath);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error downloading {imgUrl}: {ex.Message}");
                            }
                        }
                    }
                }
            }
        }

        private async void button_view_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(url)) return;

            try
            {
                using (WebClient client = new WebClient())
                {
                    string htmlContent = await client.DownloadStringTaskAsync(url);

                    Lab04_Bai03_ViewSource viewerForm = new Lab04_Bai03_ViewSource();
                    viewerForm.SetHtmlContent(htmlContent); 
                    viewerForm.ShowDialog(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading HTML: {ex.Message}");
            }
        }
    }
}
