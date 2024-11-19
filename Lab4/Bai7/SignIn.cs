using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Bai7
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }
        private static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://nt106.uitiot.vn") // Đặt địa chỉ cơ sở cho HttpClient
        };

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txbUsername.Text; // Lấy tên đăng nhập
            string password = txbPassword.Text; // Lấy mật khẩu

            // Gọi hàm đăng nhập
            await LoginAsync(username, password);
        }
        private string accessToken; // Khai báo biến để lưu token
        private async Task LoginAsync(string username, string password)
        {
            try
            {
                var formData = new MultipartFormDataContent
                {
                    { new StringContent(""), "grant_type" },
                    { new StringContent(username), "username" },
                    { new StringContent(password), "password" },
                    { new StringContent(""), "scope" },
                    { new StringContent(""), "client_id" },
                    { new StringContent(""), "client_secret" },
                };

                HttpResponseMessage response = await httpClient.PostAsync("auth/token", formData);
                string jsonResponse = await response.Content.ReadAsStringAsync();
                JObject jsonDoc = JObject.Parse(jsonResponse);

                if (response.IsSuccessStatusCode)
                {
                    string tokenType = jsonDoc["token_type"]?.ToString();
                    accessToken = jsonDoc["access_token"]?.ToString(); // Gán giá trị cho biến accessToken

                    MessageBox.Show("Đăng nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở form HeThong và truyền token
                    var heThongForm = new HeThong(accessToken); // Thêm constructor cho HeThong nhận accessToken
                    heThongForm.Show();

                    // Đóng form đăng nhập
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(jsonDoc["detail"]?.ToString() ?? "Đã xảy ra lỗi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show($"Lỗi HTTP: {httpEx.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string GetAccessToken()
        {
            return accessToken; // Trả về access token
        }

        private void linkLabelSignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp dangky = new SignUp();
            dangky.Show();
            this.Hide();
        }
    }
}
