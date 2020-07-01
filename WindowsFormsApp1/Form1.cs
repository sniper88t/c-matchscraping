using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.ObjectModel;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // navigate to URL  
            List<string> list = new List<string>();

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://za.soccerway.com/matches/2020/01/26/");
            Thread.Sleep(5000);

            ReadOnlyCollection<IWebElement> iniScores = driver.FindElements(By.ClassName("score-time"));
            ReadOnlyCollection<IWebElement> groupCounts = driver.FindElements(By.XPath("//span[contains(text(), 'South Africa')]" +
                ""));

            ReadOnlyCollection<IWebElement> itemclicks = driver.FindElements(By.XPath("//span[contains(text(), 'South Africa')]" +
                ""));
            IJavaScriptExecutor javascriptExecutor = (IJavaScriptExecutor)driver;

            for (int i = 0; i < groupCounts.Count; i++)
            {
                Thread.Sleep(1000);
                javascriptExecutor.ExecuteScript("arguments[0].click();", itemclicks[i]);
            }

            //ReadOnlyCollection<IWebElement> nextScores = driver.FindElements(By.ClassName("score-time"));
            Thread.Sleep(1000);
            ReadOnlyCollection<IWebElement> alinks = driver.FindElements(By.XPath("//td[@class ='score-time score']//a[@href]"));

            List<string> tmp = new List<string>();
            for (int i = 0; i < alinks.Count; i++)
            {
                tmp.Add(alinks[i].GetAttribute("href"));
                Console.WriteLine(alinks[i].GetAttribute("href"));
            }
            Thread.Sleep(1000);

            for (int j=iniScores.Count; j < alinks.Count; j++)
            {
                list.Add(tmp[j]);
            }
            Console.WriteLine(list);
            driver.Quit();
            Thread.Sleep(3000);
        }
    }
}
