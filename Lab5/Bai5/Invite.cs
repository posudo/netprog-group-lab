using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Net.Mime;

namespace Bai5
{
    public partial class Invite : Form
    {

        private string dishName;
        private string dishPrice;
        private string dishAddress;
        private string contributorName;
        private string imageUrl;

        private string smtpServer;
        private int smtpPort;
        private string smtpEmail;
        private string smtpPassword;
        private bool useSSLSMTP;
        public Invite(string name, string price, string address, string contributor, string image)
        {
            InitializeComponent();
            dishName = name;
            dishPrice = price;
            dishAddress = address;
            contributorName = contributor;
            imageUrl = image;
        }
        public Invite()
        {
            InitializeComponent();
        }

        private void Invite_Load(object sender, EventArgs e)
        {
            // Đọc cấu hình từ tệp JSON
            string configPath = "email_config.json";
            if (File.Exists(configPath))
            {
                try
                {
                    var config = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(configPath));
                    smtpServer = config.SMTPServer;
                    smtpPort = int.Parse(config.SMTPPort.ToString());
                    smtpEmail = config.Username;
                    smtpPassword = config.Password;
                    useSSLSMTP = config.UseSSLSMTP;

                    // Kiểm tra nếu cấu hình hợp lệ
                    if (string.IsNullOrEmpty(smtpServer) || string.IsNullOrEmpty(smtpEmail) || string.IsNullOrEmpty(smtpPassword))
                    {
                        MessageBox.Show("Cấu hình email không hợp lệ. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đọc cấu hình email: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy tệp cấu hình email. Vui lòng cấu hình lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Kiểm tra và thiết lập các thông tin về món ăn
            if (lblDishName != null && lblPrice != null && lblAddress != null && lblContributor != null && pictureBoxDish != null)
            {
                lblDishName.Text = dishName;
                lblPrice.Text = dishPrice;
                lblAddress.Text = dishAddress;
                lblContributor.Text = contributorName;
                pictureBoxDish.ImageLocation = imageUrl;
                pictureBoxDish.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private async void btn_Add_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ txb_Email
            string email = txb_Email.Text;

            // Kiểm tra nếu email không trống
            if (!string.IsNullOrEmpty(email))
            {
                // Thêm email vào richTextBox1
                richTextBox1.AppendText(email + Environment.NewLine);  // Thêm vào cuối và xuống dòng mới

                // Xóa nội dung trong txb_Email
                txb_Email.Clear();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập email trước khi thêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private async Task SendEmail(string toEmail)
        {
            try
            {
                string htmlBody = $@"
            <html>
                <head>
                    <style>
                        .email-content {{
                            font-family: Arial, sans-serif;
                            line-height: 1.6;
                        }}
                        .header {{
                            color: #333;
                            font-size: 24px;
                            font-weight: bold;
                            text-align: center;
                        }}
                        .content {{
                            color: #555;
                            font-size: 18px;
                            text-align: center;
                        }}
                        .image {{
                            margin-top: 20px;
                            text-align: center;
                        }}
                        img {{
                            width: 100%;
                            height: auto;
                            max-width: 300px; /* Giới hạn kích thước ảnh nếu cần */
                            display: block;
                            margin: 0 auto;
                        }}
                        .button {{
                            display: block;
                            width: 200px;
                            margin: 20px auto;
                            padding: 10px;
                            background-color: #4CAF50;
                            color: white;
                            text-align: center;
                            border-radius: 5px;
                            text-decoration: none;
                        }}
                        .button:hover {{
                            background-color: #45a049;
                        }}
                    </style>
                </head>
                <body>
                    <div class='email-content'>
                        <div class='header'>!!!!</div>
                        <div class='content'>
                            <p><strong>Chào bạn!</strong></p>
                            <p>Chúng tôi muốn mời bạn tham gia một bữa ăn đặc biệt với món <strong>{dishName}</strong> tại địa chỉ: <strong>{dishAddress}</strong>.</p>
                            <p>Giá món ăn: <strong>{dishPrice}</strong></p>
                            <p>Người đóng góp món ăn này: <strong>{contributorName}</strong></p>
                            <p>Hãy đến và thưởng thức món ăn tuyệt vời này cùng chúng tôi!</p>
                            <p>Chúng tôi hy vọng bạn sẽ tham gia!</p>
                        </div>
                        <div class='image'>
                            <img src='{imageUrl}' alt='Món ăn' />
                        </div>
                        <div class='content'>
                            <a href='https://www.uit.edu.vn' class='button'>Xác Nhận Lời Mời</a>
                        </div>
                    </div>
                </body>
            </html>";

                var smtpClient = new SmtpClient(smtpServer)
                {
                    Port = smtpPort,
                    Credentials = new NetworkCredential(smtpEmail, smtpPassword),
                    EnableSsl = useSSLSMTP,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpEmail),
                    Subject = "Lời mời đi ăn",
                    Body = htmlBody,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(toEmail);

                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi email: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Review_Click(object sender, EventArgs e)
        {
            // Hiển thị thông tin để người dùng kiểm tra lại trước khi gửi
            string reviewContent = $@"
        <strong>Món ăn:</strong> {dishName}<br />
        <strong>Giá:</strong> {dishPrice}<br />
        <strong>Địa chỉ:</strong> {dishAddress}<br />
        <strong>Người đóng góp:</strong> {contributorName}<br />
        <strong>Danh sách email:</strong><br />";

            // Thêm tất cả các email từ richTextBox vào thông báo review
            foreach (var email in richTextBox1.Lines)
            {
                if (!string.IsNullOrEmpty(email))
                {
                    reviewContent += $"{email}<br />";
                }
            }

            // Hiển thị thông báo review
            DialogResult result = MessageBox.Show(reviewContent, "Xem lại thông tin", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            // Nếu người dùng nhấn OK, tiếp tục gửi email
            if (result == DialogResult.OK)
            {
                btn_Send.PerformClick();  // Gửi email sau khi review
            }
        }

        private async void btn_Send_Click(object sender, EventArgs e)
        {
            // Lấy các email từ richTextBox1
            string[] emailList = richTextBox1.Lines;

            // Gửi email tới mỗi địa chỉ trong danh sách
            foreach (var email in emailList)
            {
                if (!string.IsNullOrEmpty(email))
                {
                    await SendEmail(email);
                }
            }
        }
    }
}
