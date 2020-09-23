using Automation_Home_Project.Assembly;
using Automation_Home_Project.PageObject;
using Automation_Home_Project.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Automation_Home_Project.Tests.Sport_tests
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


        [Given(@"the names of teams is (.*)  (.*)")]
        public void GivenTheTeamNamesIs(string team1, string team2)
        {
            firstTeam = team1;
            secondTeam = team2;
        }

        [Given(@"the match scores is (.*)  (.*)")]
        public void GivenTheTeamScoresIs(string score1, string score2)
        {
            firstScore = Convert.ToByte(score1);
            secondScore = Convert.ToByte(score2);
        }

        [Given(@"the test league is (.*)")]
        public void GivenTheLeagueIs(string league)
        {
            this.league = league;
        }

        [Given(@"the test month is (.*)")]
        public void GivenTheMonthIs(string month)
        {
            this.month = month;
        }

        [When(@"user navigate to the sport page")]
        public void WhenUserIsNavigateToTheSportPage()
        {
            GetPages<HomePage>().SportClick();
        }

        [When(@"user is'nt logining")]
        public void WhenUserIsNtLoginingIn()
        {
            GetPages<SportPage>().SignInExitClick();
        }

        [When(@"user navigate to the football page")]
        public void WhenUserIsNavigateToTheFootballPage()
        {
            GetPages<SportPage>().FootballClick();
        }

        [When(@"user select league")]
        public void WhenUserSelectingLeague()
        {
            GetPages<FootballPage>().MoreClick();
            GetPages<FootballPage>().ClickOnLeague(league);
            GetPages<FootballPage>().ViewAllClick();
        }

        [When(@"user select month")]
        public void WhenUserSelectingMonth()
        {
            GetPages<ScoresFixturesPage>().ClickOnMonth(month);
        }

        [When(@"user is navigate to the match page")]
        public void WhenUserNavigatingToTheMatchPage()
        {
            GetPages<ScoresFixturesPage>().ClickOnTeam(firstTeam, secondTeam);
        }

        [Then(@"there must be specified teams with the specified match scores")]
        public void ThenThereMustBeSpecifiedTeamsWithTheSpecifiedScores()
        {
            score = new Score { Score1 = firstScore, Score2 = secondScore };
            Assert.IsTrue(GetPages<ScoresFixturesPage>().GetScore(firstTeam, secondTeam) == score);
        }

        [Then(@"there must be same teams with the same match scores")]
        public void ThenThereMustBeSameTeamsWithTheSameScores()
        {
            Assert.IsTrue(GetPages<FootballMatchPage>().GetScore(firstTeam, secondTeam) == score);
            Driver.StopDriver();
        }


    }
}
