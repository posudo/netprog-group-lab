using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai4
{
    public partial class Browser : Form
    {
        public Browser(string url)
        {
            InitializeComponent();
            webBrowser1.Navigate(url);
        }

        private void Browser_Load(object sender, EventArgs e)
        {
            // Set the size and location of the browser window
            this.Size = new System.Drawing.Size(800, 600);
            this.CenterToScreen();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
