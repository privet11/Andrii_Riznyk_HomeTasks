using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Home_Project.PageObject
{
    public class SpecificNewsPage : Driver
    {
        //[FindsBy(How = How.XPath, Using = "//a[contains(@class,'share-button')]")]
        private readonly IWebElement shareButton = WebDriver.FindElement(By.XPath("//a[contains(@class,'share-button')]"));
        private readonly IWebElement shareLink = WebDriver.FindElement(By.XPath("//a[contains(@class,'share-link')]"));
        private readonly IWebElement article = WebDriver.FindElement(By.XPath("//h1[contains(@class,'story-body__h1')]"));

        public void ShareClick()
        {
            ExplicitWait(10, By.XPath("//a[contains(@class,'share-button')]"));
            shareButton.Click(); 
        }
        public string Article() => article.Text;
        public string ShareLink() => shareLink.Text;





    }
}