//using Automation_Home_Project.Assembly;
//using Automation_Home_Project.PageObject;
//using Automation_Home_Project.Pages;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using TechTalk.SpecFlow;

//namespace Automation_Home_Project.Tests.Sport_tests
//{
//    [Binding]
//    public class TeamScoresTest : PagesGet
//    {
//        string firstTeam;
//        string secondTeam;
//        byte firstScore;
//        byte secondScore;
//        string league;
//        string month;
//        Score score;


//        [Given(@"the Home page is open")]
//        public void GivenTheHomePageIsOpen()
//        {
//            GetPages<HomePage>();
//        }

//        [Given(@"the team names is (.*)  (.*)")]
//        public void GivenTheTeamNamesIs(string team1, string team2)
//        {
//            firstTeam = team1;
//            secondTeam = team2;
//        }

//        [Given(@"the team scores is (.*)  (.*)")]
//        public void GivenTheTeamScoresIs(string score1, string score2)
//        {
//            firstScore = Convert.ToByte(score1);
//            secondScore = Convert.ToByte(score2);
//        }

//        [Given(@"the league is (.*)")]
//        public void GivenTheLeagueIs(string league)
//        {
//            this.league = league;
//        }

//        [Given(@"the month is (.*)")]
//        public void GivenTheMonthIs(string month)
//        {
//            this.month = month;
//        }

//        [When(@"user is navigate to the sport page")]
//        public void WhenUserIsNavigateToTheSportPage()
//        {
//            GetPages<HomePage>().SportClick();
//        }

//        [When(@"user is'nt logining in")]
//        public void WhenUserIsNtLoginingIn()
//        {
//            GetPages<SportPage>().SignInExitClick();
//        }

//        [When(@"user is navigate to the football page")]
//        public void WhenUserIsNavigateToTheFootballPage()
//        {
//            GetPages<SportPage>().FootballClick();
//        }

//        [When(@"user selecting league")]
//        public void WhenUserSelectingLeague()
//        {
//            GetPages<FootballPage>().MoreClick();
//            GetPages<FootballPage>().ClickOnLeague(league);
//            GetPages<FootballPage>().ViewAllClick();
//        }

//        [When(@"user selecting month")]
//        public void WhenUserSelectingMonth()
//        {
//            GetPages<ScoresFixturesPage>().ClickOnMonth(month);
//        }

//        [When(@"user navigating to the match page")]
//        public void WhenUserNavigatingToTheMatchPage()
//        {
//            GetPages<ScoresFixturesPage>().ClickOnTeam(firstTeam, secondTeam);
//        }

//        [Then(@"there must be specified teams with the specified scores")]
//        public void ThenThereMustBeSpecifiedTeamsWithTheSpecifiedScores()
//        {
//            score = new Score { Score1 = firstScore, Score2 = secondScore };
//            Assert.IsTrue(GetPages<ScoresFixturesPage>().GetScore(firstTeam, secondTeam) == score);
//        }

//        [Then(@"there must be same teams with the same scores")]
//        public void ThenThereMustBeSameTeamsWithTheSameScores()
//        {
//            Assert.IsTrue(GetPages<FootballMatchPage>().GetScore(firstTeam, secondTeam) == score);
//            Driver.StopDriver();
//        }


//    }
//}

//using Automation_Home_Project.Assembly;
//using Automation_Home_Project.PageObject;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using TechTalk.SpecFlow;

//namespace Automation_Home_Project.Tests.Sport_tests
//{
//    [Binding]
//    public class LinkSharingTest : PagesGet
//    {
//        string link;
//        string article1;
//        string article2;



//        [Given(@"the BBC Home page is open")]
//        public void GivenTheBBCHomePageIsOpen()
//        {
//            GetPages<HomePage>();
//        }

//        [When(@"I go to News")]
//        public void WhenIGoToNews()
//        {
//            GetPages<HomePage>().NewsClick();
//        }

//        [When(@"click on ""(.*)"" tab")]
//        public void WhenClickOnTab(string sectionName)
//        {
//            GetPages<NewsPage>().SignInExitClick();
//            GetPages<NewsPage>().NavMenuButtonClick(sectionName);
//        }

//        [When(@"click the first article")]
//        public void WhenClickTheFirstArticle()
//        {
//            GetPages<EntertaimentArtsPage>().FirstHeadlineClick();
//        }

//        [When(@"click Share")]
//        public void WhenClickShare()
//        {
//            article1 = GetPages<SpecificNewsPage>().Article();
//            GetPages<SpecificNewsPage>().ShareClick();
//        }

//        [When(@"copy the link")]
//        public void WhenCopyTheLink()
//        {
//            link = GetPages<SpecificNewsPage>().ShareLink();
//        }

//        [When(@"navigate the link")]
//        public void WhenNavigateTheLink()
//        {
//            Driver.WebDriver.Navigate().GoToUrl(link);
//            article2 = GetPages<SpecificNewsPage>().Article();
//        }

//        [Then(@"the same article is open")]
//        public void ThenTheSameArticleIsOpen()
//        {
//            Assert.AreEqual(article1, article2);
//            Driver.StopDriver();
//        }


//    }
//}