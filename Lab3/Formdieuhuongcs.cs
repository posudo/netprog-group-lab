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
    public partial class Formdieuhuongcs : Form
    {
        public Formdieuhuongcs()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBai3_Click(object sender, EventArgs e)
        {
            Bai3 bai3 = new Bai3();
            bai3.Show();
        }

        private void btnBai4_Click(object sender, EventArgs e)
        {
            DieuHuong_Bai4 bai4 = new DieuHuong_Bai4();
            bai4.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lab03_Bai05_Server bai5 = new Lab03_Bai05_Server();
            bai5.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Formdieuhuongcs_Load(object sender, EventArgs e)
        {

        }
    }
}
