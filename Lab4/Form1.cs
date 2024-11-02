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
using Microsoft.Web.WebView2.Core;
using HtmlAgilityPack;
using System.Net.Http;

namespace Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            try
            {
                await webView21.EnsureCoreWebView2Async(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"WebView2 initialization failed: {ex.Message}");
            }
        }

        private async void Load_Click(object sender, EventArgs e)
        {
            if (webView21.CoreWebView2 == null)
            {
                try
                {
                    await webView21.EnsureCoreWebView2Async(null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"WebView2 initialization failed: {ex.Message}");
                    return;
                }
            }

            if (webView21.CoreWebView2 != null)
            {
                string html = getHTML(URL.Text);
                if (!string.IsNullOrEmpty(html))
                {
                    webView21.CoreWebView2.NavigateToString(html);
                }
            }
            else
            {
                MessageBox.Show("WebView2 is not initialized.");
            }
        }

        private string getHTML(string szURL)
        {
            if (!szURL.StartsWith("http://") && !szURL.StartsWith("https://"))
            {
                szURL = "http://" + szURL;
            }

            WebRequest request = WebRequest.Create(szURL);
            WebResponse response = null;
            Stream dataStream = null;
            StreamReader reader = null;
            string responseFromServer = string.Empty;

            try
            {
                response = request.GetResponse();
                dataStream = response.GetResponseStream();
                reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                reader?.Close();
                dataStream?.Close();
                response?.Close();
            }

            return responseFromServer;
        }

        private void webView21_Click(object sender, EventArgs e)
        {
        }

        string savepath = "C:\\Users\\tung\\Downloads\\LTMCP";
        private async void Down_File_Click(object sender, EventArgs e)
        {
            string url = URL.Text;
            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                string htmlContent = await httpClient.GetStringAsync(url);
                File.WriteAllText("download.html", htmlContent);
                MessageBox.Show("Download completed!");
            }
            else
            {
                MessageBox.Show("Invalid URL");
            }
        }

        private void Reload_Click(object sender, EventArgs e)
        {
            if (webView21.CoreWebView2 == null)
            {
                MessageBox.Show("WebView2 is not initialized.");
                return;
            }

            if (string.IsNullOrEmpty(getHTML(URL.Text)))
            {
                MessageBox.Show("No page has been loaded yet.");
                return;
            }

            string html = getHTML(getHTML(URL.Text));
            if (!string.IsNullOrEmpty(html))
            {
                webView21.CoreWebView2.NavigateToString(html);
            }
        }

        private string GetUniqueFileName(string path, string fileName)
        {
            string fileNameOnly = Path.GetFileNameWithoutExtension(fileName);
            string extension = Path.GetExtension(fileName);
            string fullPath = Path.Combine(path, fileName);
            int count = 1;

            while (File.Exists(fullPath))
            {
                string tempFileName = $"{fileNameOnly}({count++}){extension}";
                fullPath = Path.Combine(path, tempFileName);
            }

            return Path.GetFileName(fullPath);
        }

        private readonly HttpClient httpClient = new HttpClient();

        private async Task DownloadImages(string url, string savePath)
        {
            try
            {
                // Create HtmlDocument and load the HTML
                var web = new HtmlWeb();
                var doc = web.Load(url);

                // Find all img tags
                var imgNodes = doc.DocumentNode.SelectNodes("//img");

                if (imgNodes == null || !imgNodes.Any())
                {
                    MessageBox.Show("No images found on this page.");
                    return;
                }

                int totalImages = imgNodes.Count;
                int downloadedImages = 0;
                int failedDownloads = 0;

                foreach (var imgNode in imgNodes)
                {
                    string imgUrl = imgNode.GetAttributeValue("src", "");

                    if (string.IsNullOrEmpty(imgUrl))
                        continue;

                    // Handle relative URLs
                    if (imgUrl.StartsWith("//"))
                        imgUrl = "https:" + imgUrl;
                    else if (imgUrl.StartsWith("/"))
                        imgUrl = new Uri(new Uri(url), imgUrl).ToString();
                    else if (!imgUrl.StartsWith("http"))
                        imgUrl = new Uri(new Uri(url), imgUrl).ToString();

                    try
                    {
                        // Generate a unique filename
                        string fileName = Path.GetFileName(new Uri(imgUrl).LocalPath);
                        if (string.IsNullOrEmpty(Path.GetExtension(fileName)))
                            fileName += ".jpg";

                        // Ensure filename is unique
                        string fullPath = Path.Combine(savePath, GetUniqueFileName(savePath, fileName));

                        // Download the image
                        byte[] imageBytes = await httpClient.GetByteArrayAsync(imgUrl);
                        // Use synchronous WriteAllBytes instead of WriteAllBytesAsync
                        File.WriteAllBytes(fullPath, imageBytes);
                        downloadedImages++;

                        // Update progress in status strip if you have one
                        // Or you could add a progress bar to show download progress
                    }
                    catch (Exception ex)
                    {
                        failedDownloads++;
                        Console.WriteLine($"Failed to download image: {imgUrl}. Error: {ex.Message}");
                    }
                }

                MessageBox.Show($"Download completed!\nSuccessfully downloaded: {downloadedImages} images\nFailed: {failedDownloads} images");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error downloading images: {ex.Message}");
            }
        }
        private async void Down_Resources_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(getHTML(URL.Text)))
            {
                MessageBox.Show("Please load a webpage first.");
                return;
            }

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select folder to save images";
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string savePath = folderDialog.SelectedPath;
                    await DownloadImages(getHTML(URL.Text), savePath);
                }
            }
        }
    }
}