using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Bai06
{
    public partial class Bai06 : Form
    {
        public Bai06()
        {
            InitializeComponent();
        }
        private static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://nt106.uitiot.vn")
        };

        private void btShow_Click(object sender, EventArgs e)
        {
            GetUserInfo();
        }
        private async void GetUserInfo()
        {
            string jwt = tbToken.Text;
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", jwt);
            using HttpResponseMessage response = await httpClient.GetAsync("api/v1/user/me");
            if(response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                JObject userInfo = JObject.Parse(res);
                rtbShow.Text = userInfo.ToString();
            }
            else
            {
                MessageBox.Show("Error: " + response.ReasonPhrase);
            }
        }
    }
}
