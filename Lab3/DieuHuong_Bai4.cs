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
    public partial class DieuHuong_Bai4 : Form
    {
        public DieuHuong_Bai4()
        {
            InitializeComponent();
        }

        private void Client_Click(object sender, EventArgs e)
        {
            Bai4 bai4 = new Bai4();
            bai4.Show();
        }

        private void server_Click(object sender, EventArgs e)
        {
            server bai4 = new server();
            bai4.Show();
        }
    }
}
