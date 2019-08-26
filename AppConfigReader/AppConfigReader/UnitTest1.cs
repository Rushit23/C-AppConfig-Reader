using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Threading;
using AppConfigReading.Configuration;
using AppConfigReading.interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace AppConfigReading
{
    [TestClass]
    // public class UnitTest1 : IDisposable
    public class UnitTest1
    {
        public IWebDriver driver;


        public void Driver(string browser)
        {
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    break;
                case "Firefox":
                    driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    break;
                case "IE":
                    driver = new InternetExplorerDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    break;
                default:
                    driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    break;
            }
        }



        public void InitalizeDriver()
        {

            // driver = new ChromeDriver();

            Driver("Chrome");
            string url = "https://www.cricbuzz.com";
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();

        }





        [TestMethod]
        public void ReadingDataFromAppConfig()
        {
            // Will help to read the files from Configuration Manager

            Console.WriteLine(ConfigurationManager.AppSettings.Get("BrowserType"));
            Console.WriteLine(ConfigurationManager.AppSettings.Get("Username"));
            Console.WriteLine(ConfigurationManager.AppSettings.Get("Password"));
            Console.WriteLine((int)BrowserType.Chrome);
        }




        [TestMethod]
        public void ReadingDataFromAppConfig_02()
        {
            IConfig config = new AppConfigReader();
            Console.WriteLine("Browser : {0}", config.GetBrowser());
            Console.WriteLine("Username : {0}", config.GetUsername());
            Console.WriteLine("Password : {0}", config.GetPassword());

        }







        
        [TestMethod]
        public void Test1()
        {
            InitalizeDriver();
            string title = driver.Title;
            Thread.Sleep(3000);

            Assert.AreEqual("World Cup 2019, Cricket Score, Schedule, Latest News, Stats & Videos | Cricbuzz.com", title);
            driver.Quit();
        }


/*
        public void Dispose()
        {
            driver.Quit();
        }

*/

    }

    
}
