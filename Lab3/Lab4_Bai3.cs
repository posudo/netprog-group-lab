using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Lab4_Bai3 : Form
    {
        public Lab4_Bai3()
        {
            InitializeComponent();
        }

        private void client_Click(object sender, EventArgs e)
        {
            Bai4 bai4 = new Bai4();
            bai4.Show();
        }

        private void server_Click(object sender, EventArgs e)
        {
            server my_server = new server();
            my_server.Show();
        }
    }
}
