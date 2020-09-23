using Automation_Home_Project.Assembly;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Home_Project.PageObject
{
    public class SearchResultPage: Driver
    {
        private readonly IList<IWebElement> searchItemsList = WebDriver.FindElements(By.XPath("//a[contains(@class,'PromoLink')]"));


        public IList<IWebElement> SearchItemsList() => searchItemsList;
    }
}
