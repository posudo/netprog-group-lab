using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai5
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }
        private static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://nt106.uitiot.vn")
        };

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = txbUsername.Text; // Tên đăng nhập
            string email = txbEmail.Text; // Email
            string password = txbPassword.Text; // Mật khẩu
            string firstName = txbFirstname.Text; // Họ
            string lastName = txbLastname.Text; // Tên
            int sex = rbtnMale.Checked ? 0 : 1; // Giới tính: 0 cho Nam, 1 cho Nữ
            string birthday = dtpBirthday.Value.ToString("yyyy-MM-dd"); // Ngày sinh
            string language = txbLanguage.Text; // Ngôn ngữ
            string phone = txbPhone.Text; // Số điện thoại

            // Kiểm tra mật khẩu có khớp hay không
            if (password != txbConfirmPassword.Text)
            {
                MessageBox.Show("Mật khẩu và xác nhận mật khẩu không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo đối tượng requestData để gửi đi
            var requestData = new
            {
                username = username,
                email = email,
                password = password,
                first_name = firstName,
                last_name = lastName,
                sex = sex,
                birthday = birthday,
                language = language,
                phone = phone
            };

            // Chuyển đổi đối tượng requestData thành JSON
            string jsonToSend = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);



            // Gọi hàm đăng ký
            await RegisterUser(jsonToSend);
            SignIn dangnhapmoi = new SignIn();
            dangnhapmoi.Show();
            this.Hide();
        }
        private async Task RegisterUser(string jsonContent)
        {
            try
            {
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Gửi yêu cầu POST
                HttpResponseMessage response = await httpClient.PostAsync("api/v1/user/signup", content);

                // Đọc phản hồi
                string jsonResponse = await response.Content.ReadAsStringAsync();
                JObject jsonDoc = JObject.Parse(jsonResponse);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Đăng ký thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Hiển thị nội dung phản hồi lỗi từ API
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Xóa nội dung các TextBox
            txbUsername.Clear();
            txbEmail.Clear();
            txbPassword.Clear();
            txbConfirmPassword.Clear();
            txbFirstname.Clear();
            txbLastname.Clear();
            txbLanguage.Clear();
            txbPhone.Clear();
            // Đặt lại giá trị của DateTimePicker về ngày hiện tại
            dtpBirthday.Value = DateTime.Now;

            // Đặt lại các RadioButton về trạng thái chưa chọn
            rbtnMale.Checked = false;
            rbtnFemale.Checked = false;
        }
    }
}
