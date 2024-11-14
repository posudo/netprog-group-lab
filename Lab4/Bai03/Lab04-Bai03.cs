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
            webShow.NavigationCompleted += WebShow_NavigationCompleted;
            textBox_url.KeyDown += textBox_url_KeyDown;
        }
        private void textBox_url_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                button_load_Click(sender, e); 
                e.SuppressKeyPress = true;
            }
        }
        private void WebShow_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            
            textBox_url.Text = webShow.CoreWebView2.Source;
            url = webShow.CoreWebView2.Source;
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
            progressBar1.Show();
            string file = "web.html";
            downHTML(url, file);
            progressBar1.Hide();
            MessageBox.Show("Tải file 'web.html' thành công! Bạn có thể kiểm tra file trong thư mục của ứng dụng.");
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
                url = "https://www.google.com/search?q=" + input;
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
            if(url.StartsWith("https://www.google.com/search?"))
            {
                MessageBox.Show("Không thể download hình từ google search! Bạn vui lòng download thủ công nhé.");
                return;
            }    

            string htmlContent = await new WebClient().DownloadStringTaskAsync(url);

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(htmlContent);

            var imageNodes = doc.DocumentNode.SelectNodes("//img");
            if (imageNodes != null)
            {
                progressBar1.Show();
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
                        imgUrl = CleanImageUrl(imgUrl);
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
                progressBar1.Hide();
                MessageBox.Show("Tải tất cả hình từ web thành công! Bạn có thể kiểm tra hình trong thư mục images của ứng dụng.");
            }
        }
        private string CleanImageUrl(string url)
        {
            string pattern = @"(.+\.(jpg|jpeg|png|gif|bmp))";
            var match = System.Text.RegularExpressions.Regex.Match(url, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            return match.Success ? match.Value : url;
        }

        private async void button_view_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(url)) return;
            progressBar1.Show();
             using (WebClient client = new WebClient())
                {
                    string htmlContent = await client.DownloadStringTaskAsync(url);

                    Lab04_Bai03_ViewSource viewerForm = new Lab04_Bai03_ViewSource();
                    viewerForm.SetHtmlContent(htmlContent);
                    progressBar1.Hide();
                    viewerForm.ShowDialog(); 
                }
        }
    }
}
