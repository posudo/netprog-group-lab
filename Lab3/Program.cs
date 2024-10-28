using Lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Lab03_Bai05_Client client = new Lab03_Bai05_Client();
            //Lab03_Bai05_Server server = new Lab03_Bai05_Server();

            //server.Show();
            //client.Show();
            

            Application.Run(new Lab03_Bai05_Server());


           
        }
    }
}
