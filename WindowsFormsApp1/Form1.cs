using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void BtnStart_Click(object sender, EventArgs e)
        {
            Thread start = new Thread(new ThreadStart(Worker));
            start.IsBackground = false;
            start.Start();

        }
        private void Worker()
        {
            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                Chrome();
            }
        }
        private void Chrome()
        {
            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.PageLoadStrategy = PageLoadStrategy.Default;
            chromeOptions.AddAdditionalCapability("useAutomationExtension", false);
            chromeOptions.AddArguments(new string[]
            {
                "--disable-notifications",
                "--ignore-certificate-errors",
                "--disable-popup-blocking",
                "--incognito",
                "--disable-hang-monitor",
                "--test-type",
                "--new-window",
                "--no-sandbox",
                "--lang=EN"
            });
            IWebDriver driver = new ChromeDriver(chromeDriverService, chromeOptions, TimeSpan.FromHours(1.0));
            IJavaScriptExecutor javaScriptExecutor = driver as IJavaScriptExecutor;
            driver.Navigate().GoToUrl("https://popcat.click/");
            javaScriptExecutor.ExecuteScript("var event = new KeyboardEvent('keydown', {key: 'g',ctrlKey: true});setInterval(function(){for (i = 0; i < 100; i++) {document.dispatchEvent(event);}}, 0);", Array.Empty<object>());
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.facebook.com/mostafakamelomarrslan/");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Developed By MOstafa Kamel \n دعوة 40 غريب مستجابة دعوة \nدعوة بالنجاح والتوفيق ","Wish");
        }
    }
}
