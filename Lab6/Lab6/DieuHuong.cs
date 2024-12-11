using Lab6;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class DieuHuong: Form
    {
        public DieuHuong()
        {
            InitializeComponent();
        }

        private void Client_Click(object sender, EventArgs e)
        {
            PhongVe quay1 = new PhongVe("1");
            quay1.Show();
        }

        private void server_Click(object sender, EventArgs e)
        {
            server bai4 = new server();
            bai4.Show();
        }

        private void Quay2_Click(object sender, EventArgs e)
        {
            PhongVe quay2 = new PhongVe("2");
            quay2.Show();
        }

        private void Quay3_Click(object sender, EventArgs e)
        {
            PhongVe quay3 = new PhongVe("3");
            quay3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(btn_ID.Text == "admin" && btnPasWord.Text == "123")
            {
                SuperUser superUser = new SuperUser();
                superUser.Show();
            }
        }
    }
}