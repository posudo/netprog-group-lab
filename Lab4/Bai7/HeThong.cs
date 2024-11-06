using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
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

namespace Bai7
{
    public partial class HeThong : Form
    {
        private string accessToken;
        private List<Dish> myDishes; // Danh sách các món ăn do người dùng đóng góp
        private int currentPage = 1; // Trang hiện tại
        private int pageSize = 10; // Kích thước trang mặc định
        public HeThong(string token)
        {
            InitializeComponent();
            accessToken = token; // Lưu access token
            myDishes = new List<Dish>(); // Khởi tạo danh sách
            InitializeComboBox();
            // Đăng ký sự kiện MouseClick
            tableLayoutPanel1.MouseClick += tableLayoutPanel1_MouseClick;
        }
        private void InitializeComboBox()
        {
            // Giả sử có tối đa 20 trang
            for (int i = 1; i <= 20; i++)
            {
                comboBox1.Items.Add(i);
            }
            comboBox1.SelectedIndex = 0; // Chọn trang đầu tiên
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged; // Đăng ký sự kiện
        }


        private  async void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đang gọi API để lấy tất cả các món ăn...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await LoadAllDishes(currentPage, pageSize); // Tải món ăn theo trang hiện tại và kích thước trang
            isMyDishesLoaded = false; // Đặt lại trạng thái là chưa bấm "Tôi đóng góp"
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy trang được chọn
            currentPage = (int)comboBox1.SelectedItem;


            // Tải lại danh sách món ăn
            await LoadAllDishes(currentPage, pageSize);
        }
        private static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://nt106.uitiot.vn")
        };
        private bool isMyDishesLoaded = false;
        private async void tôiĐóngGópToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            await LoadMyDishes(1, 10); // Tải 10 món ăn mà người dùng đã đóng góp
            isMyDishesLoaded = true; // Đánh dấu đã tải món ăn của người dùng
        }
        private async Task LoadRandomDish(List<Dish> dishList)
        {
            try
            {
                // Kiểm tra nếu danh sách món ăn không có món nào
                if (dishList.Count == 0)
                {
                    MessageBox.Show("Danh sách món ăn trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Random món ăn từ danh sách được truyền vào
                Random random = new Random();
                int randomIndex = random.Next(dishList.Count);
                Dish randomDish = dishList[randomIndex];

                // Hiển thị thông tin món ăn ngẫu nhiên
                Form dishForm = new Form
                {
                    Text = "Ăn gì đây ta?",
                    Size = new Size(300, 280)
                };

                TableLayoutPanel layout = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    AutoSize = true,
                    ColumnCount = 1,
                    RowCount = 2,
                    Padding = new Padding(10)
                };

                PictureBox pictureBox = new PictureBox
                {
                    ImageLocation = randomDish.hinh_anh,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Height = 150,
                    Width = 150,
                    Dock = DockStyle.Fill
                };

                Label lblDishInfo = new Label
                {
                    Text = $"Món ăn: {randomDish.ten_mon_an}\nGiá: {randomDish.gia} VND\nĐịa chỉ: {randomDish.dia_chi}\nNgười đóng góp: {randomDish.nguoi_dong_gop}",
                    AutoSize = true,
                    Dock = DockStyle.Fill,
                    Padding = new Padding(10)
                };

                layout.Controls.Add(pictureBox, 0, 0);
                layout.Controls.Add(lblDishInfo, 0, 1);

                dishForm.Controls.Add(layout);
                dishForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<Dish> allDishes = new List<Dish>();
        private async Task LoadAllDishes(int pageNumber, int pageSize)
        {
            try
            {
                var jsonBody = new JObject
        {
            { "current", pageNumber },
            { "pageSize", pageSize }
        };

                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                HttpResponseMessage response = await httpClient.PostAsync("api/v1/monan/all", new StringContent(jsonBody.ToString(), Encoding.UTF8, "application/json"));

                string jsonResponse = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    JObject jsonObject = JObject.Parse(jsonResponse);
                    JArray dishes = (JArray)jsonObject["data"];

                    // Đặt lại danh sách allDishes để làm mới
                    allDishes.Clear();
                    tableLayoutPanel1.Controls.Clear();
                    tableLayoutPanel1.RowCount = 0;

                    foreach (var dish in dishes)
                    {
                        // Chuyển đổi JSON thành đối tượng Dish và thêm vào allDishes
                        Dish dishItem = JsonConvert.DeserializeObject<Dish>(dish.ToString());
                        allDishes.Add(dishItem);

                        tableLayoutPanel1.RowCount++;

                        PictureBox pictureBox = new PictureBox
                        {
                            ImageLocation = dishItem.hinh_anh,
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Height = 100,
                            Width = 100,
                            Dock = DockStyle.Fill
                        };

                        Label lblTenMonAn = new Label { Text = dishItem.ten_mon_an, AutoSize = true };
                        Label lblGia = new Label { Text = $"Giá: {dishItem.gia} VND", AutoSize = true };
                        Label lblDiaChi = new Label { Text = $"Địa chỉ: {dishItem.dia_chi}", AutoSize = true };

                        string nguoiThem = dishItem.nguoi_dong_gop ?? "N/A";
                        Label lblNguoiThem = new Label { Text = $"Người thêm: {nguoiThem}", AutoSize = true };

                        FlowLayoutPanel infoPanel = new FlowLayoutPanel
                        {
                            FlowDirection = FlowDirection.TopDown,
                            AutoSize = true
                        };
                        infoPanel.Controls.Add(lblTenMonAn);
                        infoPanel.Controls.Add(lblGia);
                        infoPanel.Controls.Add(lblDiaChi);
                        infoPanel.Controls.Add(lblNguoiThem);

                        tableLayoutPanel1.Controls.Add(pictureBox, 0, tableLayoutPanel1.RowCount - 1);
                        tableLayoutPanel1.Controls.Add(infoPanel, 1, tableLayoutPanel1.RowCount - 1);
                    }

                    
                }
                else
                {
                    MessageBox.Show("Lỗi khi tải danh sách món ăn: " + jsonResponse, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async Task LoadMyDishes(int pageNumber, int pageSize)
        {
            try
            {
                var jsonBody = new JObject
        {
            { "current", pageNumber },
            { "pageSize", pageSize }
        };

                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                HttpResponseMessage response = await httpClient.PostAsync("api/v1/monan/my-dishes", new StringContent(jsonBody.ToString(), Encoding.UTF8, "application/json"));

                string jsonResponse = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    JObject jsonObject = JObject.Parse(jsonResponse);
                    JArray dishes = (JArray)jsonObject["data"];

                    myDishes.Clear();
                    tableLayoutPanel1.Controls.Clear();
                    tableLayoutPanel1.RowCount = 0;

                    foreach (var dish in dishes)
                    {
                        Dish myDish = JsonConvert.DeserializeObject<Dish>(dish.ToString());
                        myDishes.Add(myDish);

                        tableLayoutPanel1.RowCount++;
                        PictureBox pictureBox = new PictureBox
                        {
                            ImageLocation = myDish.hinh_anh,
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Height = 100,
                            Width = 100,
                            Dock = DockStyle.Fill
                        };

                        Label lblTenMonAn = new Label { Text = myDish.ten_mon_an, AutoSize = true };
                        Label lblGia = new Label { Text = $"Giá: {myDish.gia} VND", AutoSize = true };
                        Label lblDiaChi = new Label { Text = $"Địa chỉ: {myDish.dia_chi}", AutoSize = true };
                        Label lblNguoiThem = new Label { Text = $"Người thêm: {myDish.nguoi_dong_gop}", AutoSize = true };

                        FlowLayoutPanel infoPanel = new FlowLayoutPanel
                        {
                            FlowDirection = FlowDirection.TopDown,
                            AutoSize = true
                        };
                        infoPanel.Controls.Add(lblTenMonAn);
                        infoPanel.Controls.Add(lblGia);
                        infoPanel.Controls.Add(lblDiaChi);
                        infoPanel.Controls.Add(lblNguoiThem);

                        tableLayoutPanel1.Controls.Add(pictureBox, 0, tableLayoutPanel1.RowCount - 1);
                        tableLayoutPanel1.Controls.Add(infoPanel, 1, tableLayoutPanel1.RowCount - 1);
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi khi tải danh sách món ăn của bạn: " + jsonResponse, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private Dish selectedDish; // Món ăn được chọn để xóa

        private void btnThemmon_Click(object sender, EventArgs e)
        {
            AddDish themon = new AddDish(accessToken);
            themon.Show();
        }

        private void btnXoamon_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có món nào được chọn hay không
            if (selectedDish == null) // Giả sử bạn có biến selectedDish để lưu món ăn được chọn
            {
                MessageBox.Show("Vui lòng chọn món ăn cần xoá.", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            // Hiển thị hộp thoại xác nhận
            var result = MessageBox.Show("Bạn có chắc chắn muốn xoá món này không?", "Xác nhận", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                // Gọi API để xoá món ăn
                DeleteDish(selectedDish.id);
            }
        }
        private async Task DeleteDish(string dishId)
        {
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                HttpResponseMessage response = await httpClient.DeleteAsync($"api/v1/monan/{dishId}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Đã xóa món ăn thành công!", "Thông báo", MessageBoxButtons.OK);
                    await LoadMyDishes(currentPage, pageSize); // Tải lại danh sách món ăn
                }
                else
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Lỗi khi xóa món ăn: " + jsonResponse, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public class Dish
        {
            public string id { get; set; } // Thêm thuộc tính ID
            public string ten_mon_an { get; set; }
            public float gia { get; set; }
            public string mo_ta { get; set; }
            public string hinh_anh { get; set; }
            public string dia_chi { get; set; }
            public string nguoi_dong_gop { get; set; } // Thêm trường người thêm nếu cần
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void tableLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            // Lấy tọa độ nhấp chuột và chuyển đổi nó thành tọa độ của TableLayoutPanel
            Point clickPoint = tableLayoutPanel1.PointToClient(MousePosition);

            // Tính toán chỉ số hàng mà người dùng đã nhấp chuột
            int clickedRow = clickPoint.Y / tableLayoutPanel1.GetRowHeights().Max(); // Nếu hàng có chiều cao khác nhau, bạn có thể cần tính toán lại

            // Kiểm tra xem hàng đã nhấp có nằm trong danh sách món ăn không
            if (clickedRow >= 0 && clickedRow < myDishes.Count)
            {
                // Lưu món ăn được chọn
                selectedDish = myDishes[clickedRow];
                MessageBox.Show($"Đã chọn món ăn: {selectedDish.ten_mon_an}", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private async void btnRandomDish_Click(object sender, EventArgs e)
        {
            if (isMyDishesLoaded && myDishes.Count > 0)
            {
                // Nếu đã bấm "Tôi đóng góp" và có món ăn trong danh sách myDishes
                await LoadRandomDish(myDishes); // Random từ các món đã đóng góp
            }
            else
            {
                // Nếu chưa bấm "Tôi đóng góp" hoặc không có món ăn trong danh sách myDishes
                await LoadRandomDish(allDishes); // Random từ tất cả các món ăn
            }
        }

        private void linkLabellogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignIn logout = new SignIn();
            logout.Show();
            this.Close();
        }
    }
}
