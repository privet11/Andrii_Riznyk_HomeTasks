using Automation_Home_Project.Assembly;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Home_Project.PageObject
{
    public class HomePage: Driver
    {
        private readonly IWebElement newsButt = WebDriver.FindElement(By.XPath("//a[text()='News']"));
        private readonly IWebElement sportButt = WebDriver.FindElement(By.XPath("//a[text()='Sport']"));


        public void NewsClick() => newsButt.Click();
        public void SportClick() => sportButt.Click();

    }
}
