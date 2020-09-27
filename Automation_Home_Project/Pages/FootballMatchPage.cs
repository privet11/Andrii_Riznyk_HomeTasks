using Automation_Home_Project.Assembly;
using Automation_Home_Project.HomeTask2Patterns;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Home_Project.Pages
{
    public class FootballMatchPage : Driver
    {
        private readonly IWebElement firstTeam = WebDriver.FindElement(By.XPath("//span[contains(@class,'team-name--home')]"));
        private readonly IWebElement secondTeam = WebDriver.FindElement(By.XPath("//span[contains(@class,'team-name--away')]"));
        private readonly IWebElement firstTeamScore = WebDriver.FindElement(By.XPath("//span[contains(@class,'number--home')]"));
        private readonly IWebElement secondTeamScore = WebDriver.FindElement(By.XPath("//span[contains(@class,'number--away')]"));

        public Score GetScore(string team1, string team2)
        {
            //if (team1 == firstTeam.Text && team2 == secondTeam.Text)
            //{
            //    return new Score { Score1 =Convert.ToByte(firstTeamScore.Text), Score2 = Convert.ToByte(secondTeamScore.Text) };
            //}
            //return null;
            if (team1 == firstTeam.Text && team2 == secondTeam.Text)
            {
                Builder builder = new ConcreteBuilder();
                Director director = new Director(builder);
                director.BuildFullFeaturedProduct(Convert.ToByte(firstTeamScore.Text), Convert.ToByte(secondTeamScore.Text));
                return builder.GetScores();
            }
            return null;
        }
    }
}
