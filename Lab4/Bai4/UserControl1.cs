using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Bai4
{
    public partial class MovieItemControl : UserControl
    {
        public MovieItemControl()
        {
            InitializeComponent();
        }


        public string Title
        {
            get => MovieTitle.Text;
            set => MovieTitle.Text = value;
        }

        public string Link
        {
            get => MovieURI.Text;
            set => MovieURI.Text = value;
        }

        public Image PosterImage
        {
            get => Poster.Image;
            set => Poster.Image = value;
        }

        private void MovieURI_Click(object sender, EventArgs e)
        {
            using (var browser = new Browser(Link))
            {
                browser.ShowDialog();
            }
        }
    }
}
