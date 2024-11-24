using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai5
{
    public partial class AddDish : Form
    {
        private string accessToken; // Biến để lưu access tok
        public AddDish(string token)
        {
            InitializeComponent();
            accessToken = token;
        }
        private static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://nt106.uitiot.vn")
        };
        private async void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các TextBox
                string monAn = txbMonan.Text;
                string diaChi = txbDiachi.Text;
                string hinhAnh = txbHinhanh.Text;
                int gia = int.Parse(txbGia.Text);
                string moTa = txbMota.Text;

                // Kiểm tra xem tất cả các trường đã được điền
                if (string.IsNullOrWhiteSpace(monAn) || string.IsNullOrWhiteSpace(diaChi) ||
                    string.IsNullOrWhiteSpace(hinhAnh) || string.IsNullOrWhiteSpace(moTa))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin món ăn.");
                    return;
                }

                // Gọi API để thêm món ăn
                var newDish = new
                {
                    ten_mon_an = monAn,
                    dia_chi = diaChi,
                    hinh_anh = hinhAnh,
                    gia = gia,
                    mo_ta = moTa
                };

                // Chuyển đổi nội dung yêu cầu thành JSON
                var json = JsonConvert.SerializeObject(newDish);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Thêm token vào header của yêu cầu
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                // Gửi yêu cầu POST tới đường dẫn chính xác
                HttpResponseMessage response = await httpClient.PostAsync("api/v1/monan/add", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm món ăn thành công!");
                    this.Close(); // Đóng form sau khi thêm thành công
                }
                else
                {
                    // Đọc phản hồi để lấy chi tiết lỗi
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    JObject jsonDoc = JObject.Parse(jsonResponse);
                    MessageBox.Show("Thêm món ăn không thành công: " + jsonDoc["detail"]?.ToString() ?? response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
    }
}
