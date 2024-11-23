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
using MimeKit;

namespace Bai6
{
    public partial class SendEmail : Form
    {
        private string password;
        private string smtp;
        private int port;
        public SendEmail()
        {
            InitializeComponent();
        }
        public void Authenticate(string tk, string pass, string smtp_address, int smtp_port)
        {
            tbFrom.Text = tk;
            password = pass;
            smtp = smtp_address;
            port = smtp_port;
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            string fromEmail = tbFrom.Text;
            string toEmail = tbTo.Text;
            string subject = tbSubject.Text;
            string body = rtbBody.Text;
            string attachmentPath = tbAttachment.Text;
            string displayName = tbName.Text;
            bool isHtml = cbHTML.Checked;
            
            try
            {
                using (var smtpClient = new SmtpClient(smtp, port))
                {
                    smtpClient.Credentials = new NetworkCredential(fromEmail, password);
                    smtpClient.EnableSsl = true;

                    var fromAddress = new MailAddress(fromEmail, displayName);

                    var mailMessage = new MailMessage
                    {
                        From = fromAddress, 
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = isHtml
                    };
                    mailMessage.To.Add(toEmail);

                    if (!string.IsNullOrEmpty(attachmentPath) && File.Exists(attachmentPath))
                    {
                        mailMessage.Attachments.Add(new Attachment(attachmentPath));
                        FileInfo fileInfo = new FileInfo(attachmentPath);
                        const long maxFileSizeInBytes = 20 * 1024 * 1024; 

                        if (fileInfo.Length > maxFileSizeInBytes)
                        {
                            MessageBox.Show("Vui lòng chọn file không lớn hơn 20MB");
                            return; 
                        }

                        mailMessage.Attachments.Add(new Attachment(attachmentPath));
                    }

                    smtpClient.Send(mailMessage);
                    MessageBox.Show("Gửi email thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All Files (*.*)|*.*";
                openFileDialog.Title = "Select a File to Attach";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    FileInfo fileInfo = new FileInfo(filePath);

                    tbAttachment.Text = filePath; 
                    
                }
            }
        }
    }
}
