using MailKit.Net.Imap;
using MailKit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MailKit.Net.Smtp;

namespace Bai6
{
    public partial class Main : Form
    {
        private ImapClient client_imap;
        private SmtpClient client_smtp;
        public Main()
        {
            InitializeComponent();
            lvMails.View = View.Details;
            lvMails.Columns.Add("#", 50);
            lvMails.Columns.Add("Subject", 200);
            lvMails.Columns.Add("From", 150);
            lvMails.Columns.Add("Date", 120);
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            string email = tbTaiKhoan.Text;
            string password = tbMatKhau.Text;
            int limit_message = 40;
            string imap = tbIMAP.Text;
            int port = (int)nudPort1.Value;
            int count = 1;

            try
            {
                client_imap = new ImapClient();
                client_imap.Connect(imap, port, true);
                client_imap.Authenticate(email, password);

                var inbox = client_imap.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                for (int i = inbox.Count - 1; i >= Math.Max(0, inbox.Count - limit_message); i--)
                {
                    var message = inbox.GetMessage(i);

                    var item = new ListViewItem((count).ToString());
                    item.SubItems.Add(message.Subject);
                    item.SubItems.Add(message.From.ToString());
                    item.SubItems.Add(message.Date.ToString("dd/MM/yyyy HH:mm:ss"));

                    lvMails.Invoke((MethodInvoker)delegate
                    {
                        lvMails.Items.Add(item);
                    });

                    count++;
                }

                progressBar1.Visible = false;
                btDangNhap.Visible = false;
                btGuiMail.Visible = true;
                btRefresh.Visible = true;
                tbTaiKhoan.ReadOnly = true;
                tbMatKhau.ReadOnly = true;
                tbIMAP.ReadOnly = true;
                tbSMTP.ReadOnly = true;
                nudPort1.ReadOnly = true;
                nudPort2.ReadOnly = true;

                MessageBox.Show("Đăng nhập thành công");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to retrieve emails: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btDangXuat_Click(object sender, EventArgs e)
        {

        }
    }
}
