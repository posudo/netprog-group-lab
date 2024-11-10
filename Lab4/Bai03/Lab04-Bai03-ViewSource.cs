using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace web_server
{
    public partial class Lab04_Bai03_ViewSource : Form
    {
        public Lab04_Bai03_ViewSource()
        {
            InitializeComponent();
        }
        public void SetHtmlContent(string htmlContent)
        {
            rtbShow.Text = htmlContent;
        }
    }
}
