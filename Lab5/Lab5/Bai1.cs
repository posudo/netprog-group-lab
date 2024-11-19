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

namespace Lab5
{
    public partial class Bai1 : Form
    {
        public Bai1()
        {
            InitializeComponent();
        }

        private void send_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a new MailMessage object
                MailMessage mail = new MailMessage();

                // Set the sender, recipient, subject, and body of the email
                mail.From = new MailAddress(from_email.Text);
                mail.To.Add(to_email.Text);
                mail.Subject = subject.Text;
                mail.Body = body.Text;

                // Set up the SMTP client with your email provider's settings
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587); // Change if not using Gmail
                smtp.Credentials = new NetworkCredential("23521744@gm.uit.edu.vn", "...");
                smtp.EnableSsl = true;

                // Send the email
                smtp.Send(mail);
                MessageBox.Show("Email sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send email. Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}