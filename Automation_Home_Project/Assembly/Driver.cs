using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Automation_Home_Project
{
    public class Driver
    {
        private static IWebDriver webDriver=null;
        private static string baseURL = "https://www.bbc.com";

        public static IWebDriver WebDriver
        {
            get 
            {
                if (webDriver == null)
                {
                    webDriver = new ChromeDriver();
                    webDriver.Manage().Window.Maximize();
                    webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    webDriver.Navigate().GoToUrl(baseURL);
                }
                return webDriver;
            }
            set
            {
                webDriver = value;
            }
        }
        //public static void Initialize()
        //{
        //    if (webDriver == null)
        //    {
        //        webDriver = new ChromeDriver();
        //        webDriver.Manage().Window.Maximize();
        //        webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        //        webDriver.Navigate().GoToUrl(baseURL);
        //    }
        //}

        public static void StopDriver()
        {
            WebDriver.Quit();
            WebDriver = null;
            //BrowserWait = null;
        }

        public static void ImplicitWait(int sec)
        {
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(sec);
        }

        public static void ExplicitWait(int sec, By element)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(sec));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }
    }
}
