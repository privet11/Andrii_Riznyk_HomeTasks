using Automation_Home_Project.Assembly;
using Automation_Home_Project.PageObject;
using Automation_Home_Project.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace Automation_Home_Project.Tests
{
    [Binding]
    public class TeamScoresTest : PagesGet
    {
        string firstTeam;
        string secondTeam;
        byte firstScore;
        byte secondScore;
        string league;
        string month;
        Score score;


        [Given(@"the Home page is open")]
        public void GivenTheHomePageIsOpen()
        {
            GetPages<HomePage>();
        }

        [Given(@"the team names is (.*)  (.*)")]
        public void GivenTheTeamNamesIs(string team1, string team2)
        {
            firstTeam = team1;
            secondTeam = team2;
        }

        [Given(@"the team scores is (.*)  (.*)")]
        public void GivenTheTeamScoresIs(string score1, string score2)
        {
            firstScore = Convert.ToByte(score1);
            secondScore = Convert.ToByte(score2);
        }

        [Given(@"the league is (.*)")]
        public void GivenTheLeagueIs(string league)
        {
            this.league = league;
        }

        [Given(@"the month is (.*)")]
        public void GivenTheMonthIs(string month)
        {
            this.month = month;
        }

        [When(@"user is navigate to the sport page")]
        public void WhenUserIsNavigateToTheSportPage()
        {
            GetPages<HomePage>().SportClick();
        }

        [When(@"user is'nt logining in")]
        public void WhenUserIsNtLoginingIn()
        {
            GetPages<SportPage>().SignInExitClick();
        }

        [When(@"user is navigate to the football page")]
        public void WhenUserIsNavigateToTheFootballPage()
        {
            GetPages<SportPage>().FootballClick();
        }

        [When(@"user selecting league")]
        public void WhenUserSelectingLeague()
        {
            GetPages<FootballPage>().MoreClick();
            GetPages<FootballPage>().ClickOnLeague(league);
            GetPages<FootballPage>().ViewAllClick();
        }

        [When(@"user selecting month")]
        public void WhenUserSelectingMonth()
        {
            GetPages<ScoresFixturesPage>().ClickOnMonth(month);
        }

        [When(@"user navigating to the match page")]
        public void WhenUserNavigatingToTheMatchPage()
        {
            GetPages<ScoresFixturesPage>().ClickOnTeam(firstTeam, secondTeam);
        }

        [Then(@"there must be specified teams with the specified scores")]
        public void ThenThereMustBeSpecifiedTeamsWithTheSpecifiedScores()
        {
            score = new Score { Score1 = firstScore, Score2 = secondScore };
            Assert.IsTrue(GetPages<ScoresFixturesPage>().GetScore(firstTeam, secondTeam) == score);
        }

        [Then(@"there must be same teams with the same scores")]
        public void ThenThereMustBeSameTeamsWithTheSameScores()
        {
            Assert.IsTrue(GetPages<FootballMatchPage>().GetScore(firstTeam, secondTeam) == score);
            Driver.StopDriver();
        }


    }
}