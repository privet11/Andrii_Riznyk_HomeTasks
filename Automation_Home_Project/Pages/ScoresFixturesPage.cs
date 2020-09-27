using Automation_Home_Project.Assembly;
using Automation_Home_Project.HomeTask2Patterns;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Home_Project.PageObject
{
    public class ScoresFixturesPage: Driver
    {
        //private readonly IList<IWebElement> championshipMonths = WebDriver.FindElements(By.XPath("//span[contains(@class,'primer-bold')]"));
        private readonly IList<IWebElement> scores = WebDriver.FindElements(By.XPath("//div[contains(@class,'fixture__wrapper')]"));
        private IWebElement score;
        private readonly IWebElement months;

        private readonly By firstTeam = By.XPath(".//span[contains(@class,'team-name--home')]");
        private readonly By secondTeam = By.XPath(".//span[contains(@class,'team-name--away')]");
        private readonly By firstTeamScore = By.XPath(".//span[contains(@class,'number--home')]");
        private readonly By secondTeamScore = By.XPath(".//span[contains(@class,'number--away')]");

        //span[contains(text(),'AUG')]
        public void ClickOnMonth(string month)
        {
            //championshipMonths = WebDriver.FindElements(By.XPath("//span[contains(@class,'primer-bold')]"));
            //championshipMonths.Where(x => x.Text == month).FirstOrDefault().Click();
            //ExplicitWait(10, By.XPath($"//span[contains(text(),'{month}')]"));
            //WebDriver.FindElement(By.XPath($"//span[contains(text(),'{month}')]")).Click();
            //WebDriver.Navigate().Back();
            try
            {
                WebDriver.FindElement(By.XPath($"//span[contains(text(),'{month}')]")).Click();

            }
            catch (StaleElementReferenceException)
            {
                WebDriver.FindElement(By.XPath($"//span[contains(text(),'{month}')]")).Click();
            }
        }

        public IEnumerable<string> Scores()
        {
            return scores.Select(x => x.Text);
        }

        public void ClickOnTeam(string team1, string team2)
        {
            scores.Where(x => x.FindElement(firstTeam).Text == team1 && x.FindElement(secondTeam).Text == team2).
                          Select(x=>x.FindElement(firstTeam)).FirstOrDefault().Click();
        }

        public Score GetScore(string team1, string team2)
        {
            score = scores.Where(x => x.FindElement(firstTeam).Text == team1 && x.FindElement(secondTeam).Text == team2).FirstOrDefault();
            Builder builder = new ConcreteBuilder();
            Director director = new Director(builder);
            director.BuildFullFeaturedProduct(Convert.ToByte(score.FindElement(firstTeamScore).Text), 
                                              Convert.ToByte(score.FindElement(secondTeamScore).Text));

            return builder.GetScores();
        }
    }













    //private readonly IWebElement searchChampionshipInput = Driver.webDriver.FindElement(By.XPath("//input[@name='search']"));
    //private readonly IList<IWebElement> championshipMonths = Driver.webDriver.FindElements(By.XPath("//span[contains(@class,'primer-bold')]"));
    //private readonly IWebElement scores = Driver.webDriver.FindElement(By.XPath("//div[contains(@class,'fixture__wrapper')]"));
    //private readonly IWebElement team = Driver.webDriver.FindElement(By.XPath("//span[contains(@class,'team sp')]"));
    //private readonly IWebElement firstTeam = Driver.webDriver.FindElement(By.XPath("//div[contains(@class,'fixture__wrapper')]")).FindElement(By.XPath(".//span[contains(@class,'team-name sp')]"));
    //private readonly IWebElement secondTeam = Driver.webDriver.FindElement(By.XPath("//span[contains(@class,'team sp')]"));
}
