using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai4
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
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
    }
}
