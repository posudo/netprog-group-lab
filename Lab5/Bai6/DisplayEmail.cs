using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai6
{
    public partial class DisplayEmail : Form
    {
        public DisplayEmail()
        {
            InitializeComponent();
            this.Resize += DisplayEmail_Resize;
        }

        private void DisplayEmail_Resize(object sender, EventArgs e)
        {
            webBrowserEmail.Size = this.Size;
        }

        public void display_email(string from, string to, string subject, string htmlBody)
        {
            lbFrom.Text = $"From: {from}";
            lbTo.Text = $"To: {to}";
            lbSubject.Text = subject;
            this.Text = subject;

            webBrowserEmail.DocumentText = htmlBody;
        }
    }
}
