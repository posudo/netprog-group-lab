using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using HtmlAgilityPack;
using AngleSharp;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
namespace Bai4
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
            Application.Run(new Form1());
        }
    }
}
