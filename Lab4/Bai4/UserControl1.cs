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

namespace Bai4
{
    public partial class MovieItemControl : UserControl
    {
        public MovieItemControl()
        {
            InitializeComponent();
        }

        private void MovieItemControl_Load(object sender, EventArgs e)
        {
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
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = Link,
                UseShellExecute = true
            });
        }
    }
}
