using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit.Net.Smtp;

namespace Bai6
{
    public partial class SendEmail : Form
    {
        private SmtpClient client;
        public SendEmail()
        {
            InitializeComponent();
        }
    }
}
