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
namespace Bai5
{
    public partial class Email_Setting : Form
    {
        public Email_Setting()
        {
            InitializeComponent();
        }

        private void btn_TestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ giao diện
                string smtpServer = txb_SMTP.Text;
                int smtpPort = int.Parse(cmb_SMTPPort.SelectedItem.ToString());
                string username = txb_Username.Text;
                string password = txb_Password.Text;
                string recipientEmail = txb_Username.Text; // Email nhận sẽ là chính email người gửi
                bool useSSLSMTP = cb_SSLSMTP.Checked;

                // Tạo đối tượng SmtpClient
                using (SmtpClient smtp = new SmtpClient(smtpServer, smtpPort))
                {
                    smtp.Credentials = new NetworkCredential(username, password);
                    smtp.EnableSsl = useSSLSMTP;

                    // Tạo nội dung email
                    MailMessage mail = new MailMessage
                    {
                        From = new MailAddress(username),
                        Subject = "SMTP Connection Test",
                        Body = "This email confirms that the SMTP connection is successful.",
                        IsBodyHtml = false
                    };

                    mail.To.Add(recipientEmail); // Gửi tới chính email nhập vào

                    // Gửi email
                    smtp.Send(mail);
                }

                // Hiển thị thông báo thành công
                MessageBox.Show($"Kết nối SMTP thành công! Email test đã được gửi tới {recipientEmail}.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SmtpException smtpEx)
            {
                // Lỗi liên quan đến SMTP
                MessageBox.Show($"Lỗi SMTP: {smtpEx.Message}", "Lỗi SMTP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException formatEx)
            {
                // Lỗi định dạng (ví dụ: port không hợp lệ)
                MessageBox.Show($"Lỗi định dạng: {formatEx.Message}", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Các lỗi khác
                MessageBox.Show($"Không thể kết nối. Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_SaveExit_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ giao diện
                var config = new
                {
                    IMAPServer = txb_IMAP.Text,
                    IMAPPort = cmb_IMAPPort.SelectedItem.ToString(),
                    SMTPServer = txb_SMTP.Text,
                    SMTPPort = cmb_SMTPPort.SelectedItem.ToString(),
                    Username = txb_Username.Text,
                    Nickname = txb_Nickname.Text,
                    Password = txb_Password.Text,
                    UseSSLIMAP = cb_SSLIMAP.Checked, // Lưu trạng thái SSL cho IMAP
                    UseSSLSMTP = cb_SSLSMTP.Checked  // Lưu trạng thái SSL cho SMTP
                };

                // Lưu thông tin cấu hình vào tệp JSON
                string configPath = "email_config.json";
                System.IO.File.WriteAllText(configPath, Newtonsoft.Json.JsonConvert.SerializeObject(config, Newtonsoft.Json.Formatting.Indented));

                MessageBox.Show("Cấu hình đã được lưu!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể lưu cấu hình. Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }
        private void Email_Setting_Load(object sender, EventArgs e)
        {
            // Các cổng IMAP phổ biến
            cmb_IMAPPort.Items.Add("143");  // IMAP không SSL
            cmb_IMAPPort.Items.Add("993");  // IMAP SSL

            // Các cổng SMTP phổ biến
            cmb_SMTPPort.Items.Add("25");   // SMTP không SSL/TLS
            cmb_SMTPPort.Items.Add("465");  // SMTP SSL
            cmb_SMTPPort.Items.Add("587");  // SMTP TLS

            // Mặc định chọn cổng đầu tiên
            cmb_IMAPPort.SelectedIndex = 0;
            cmb_SMTPPort.SelectedIndex = 0;
        }
    }
}
