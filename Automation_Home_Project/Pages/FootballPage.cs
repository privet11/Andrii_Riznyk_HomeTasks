using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Home_Project.PageObject
{
    public class FootballPage:Driver
    {
        private readonly IWebElement scoresAndFixtButt = WebDriver.FindElement(By.XPath("//a[@data-stat-title='Scores & Fixtures']"));
        private IList<IWebElement> leagues = WebDriver.FindElements(By.XPath("//button[contains(@class,'list-link')]"));
        private IWebElement moreLink = WebDriver.FindElement(By.XPath("//span[contains(@data-reactid,'1.0.0.0.1') and contains(@data-reactid,'0.1.0.0')]"));
        private readonly IWebElement viewAllLink = WebDriver.FindElement(By.XPath("//span[contains(@data-reactid,'0.1.0.0') and contains(@data-reactid,'fixtures.2.2.0.0')]"));


        public void ClickOnLeague(string league)
        {
            //leagues = WebDriver.FindElements(By.XPath("//button[contains(@class,'list-link')]"));
            leagues.Where(el => el.Text == league).FirstOrDefault().Click();    
        }

        public void ViewAllClick()
        {
            viewAllLink.Click();
        }

        public void MoreClick()
        {
            //moreLink = WebDriver.FindElement(By.XPath("//span[contains(@data-reactid,'1.0.0.0.1') and contains(@data-reactid,'0.1.0.0')]"));
            moreLink.Click();
        }

        public void ScoresAndFixtClick() => scoresAndFixtButt.Click(); 
    }
}
