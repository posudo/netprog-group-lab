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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Bai6
{
    public partial class Main : Form
    {
        private ImapClient client_imap;
        public Main()
        {
            InitializeComponent();
            lvMails.View = View.Details;
            lvMails.Columns.Add("#", 50);
            lvMails.Columns.Add("Subject", 200);
            lvMails.Columns.Add("From", 150);
            lvMails.Columns.Add("Date", 120);
            this.FormClosing += Bai6_FormClosing;
            lvMails.MouseDoubleClick += lvMails_DoubleClick;
            lvMails.FullRowSelect = true;
        }

        private void Bai6_FormClosing(object sender, FormClosingEventArgs e)
        {
            btDangXuat.PerformClick();
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

                    lvMails.Items.Add(item);
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
                progressBar1.Visible = false;
            }
        }
        private void btDangXuat_Click(object sender, EventArgs e)
        {
            try
            {
                if (client_imap != null)
                {

                    client_imap.Disconnect(true);
                    client_imap.Dispose();
                    client_imap = null;

                    MessageBox.Show("Đăng xuất thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to log out: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lvMails.Items.Clear();
            btDangNhap.Visible = true;
            btGuiMail.Visible = false;
            btRefresh.Visible = false;
            tbTaiKhoan.ReadOnly = false;
            tbMatKhau.ReadOnly = false;
            tbIMAP.ReadOnly = false;
            tbSMTP.ReadOnly = false;
            nudPort1.ReadOnly = false;
            nudPort2.ReadOnly = false;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            lvMails.Items.Clear();

            int limit_message = 40;
            int count = 1;

            var inbox = client_imap.Inbox;
            inbox.Open(FolderAccess.ReadOnly);

            for (int i = inbox.Count - 1; i >= Math.Max(0, inbox.Count - limit_message); i--)
            {
                var message = inbox.GetMessage(i);

                var item = new ListViewItem((count).ToString());
                item.SubItems.Add(message.Subject);
                item.SubItems.Add(message.From.ToString());
                item.SubItems.Add(message.Date.ToString("dd/MM/yyyy HH:mm:ss"));

                lvMails.Items.Add(item);
                count++;
            }
            MessageBox.Show("Refresh thành công!");

        }

        private void btGuiMail_Click(object sender, EventArgs e)
        {
            SendEmail send_form = new SendEmail();

            send_form.Authenticate(tbTaiKhoan.Text,tbMatKhau.Text,tbSMTP.Text,(int)nudPort2.Value);
            send_form.ShowDialog();
        }

        private void lvMails_DoubleClick(object sender, EventArgs e)
        {
            if (lvMails.SelectedItems.Count > 0)
            {
                int selectedIndex = lvMails.SelectedItems[0].Index;

                try
                {
                    var inbox = client_imap.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);

                    // Lấy email tương ứng
                    var message = inbox.GetMessage(inbox.Count - 1 - selectedIndex);

                    // Mở form chi tiết
                    DisplayEmail detailForm = new DisplayEmail();
                    detailForm.display_email(
                        message.From.ToString(),
                        message.To.ToString(),
                        message.Subject,
                        message.HtmlBody ?? message.TextBody // Hiển thị HTML hoặc text
                    );

                    detailForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể mở email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
