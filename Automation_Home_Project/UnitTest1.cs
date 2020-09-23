using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Automation_Home_Project.PageObject;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Automation_Home_Project.Assembly;
using Automation_Home_Project.Pages;
using NUnit;
using Assert = NUnit.Framework.Assert;

namespace Automation_Home_Project
{
    [TestClass]
    public class UnitTest1: PagesGet
    {
        readonly List<string> searchResults = new List<string>() { "The justice, an iconic champion of women's rights, dies at 87 after suffering from pancreatic cancer.","The forest fires have had a devastating impact on the wildlife of the world's largest wetland." };
        readonly string league = "Scottish Prem";
        readonly string month = "AUG";


        //[TestInitialize]
        //public void TestInit()
        //{
        //    Driver.Initialize();
        //}



        [TestMethod]
        public void The_Headline_Article_Should_Be_Like_Value()
        {
            GetPages<HomePage>().NewsClick();
            Assert.AreEqual("Trump denies minimising Covid risk: I 'up-played' it", GetPages<NewsPage>().HeadlineArticle());
        }



        [TestMethod]
        public void The_Secondary_Articles_Should_Be_Like_Value_List()
        {
            GetPages<HomePage>().NewsClick();
            GetPages<NewsPage>().SignInExitClick();
            foreach (var res in searchResults)
            {
                Assert.IsTrue(GetPages<NewsPage>().SecondaryArticleList().Contains(res));
            }
        }

        [TestMethod]
        public void The_First_Article_Search_Result_Should_Be_Like_A_Value()
        {
            GetPages<HomePage>().NewsClick();
            GetPages<NewsPage>().SignInExitClick();
            GetPages<NewsPage>().SearchInput(GetPages<NewsPage>().CategoryName());
            IList<IWebElement> list = GetPages<SearchResultPage>().SearchItemsList();
            Assert.AreEqual(list[0].Text, "Chuggington: Badge Quest: Home Sweet Home");
        }

        [DataTestMethod]
        [DataRow("Celtic", "Motherwell", (byte)3, (byte)0)]
        [DataRow("Hibernian", "Aberdeen", (byte)0, (byte)1)]
        [DataRow("Kilmarnock", "Dundee United", (byte)4, (byte)0)]
        [DataRow("Livingston", "Ross County", (byte)1, (byte)0)]
        public void The_Score_Should(string team1, string team2, byte score1, byte score2)
        {
            Score score = new Score { Score1 = score1, Score2 = score2 };
            Driver.ImplicitWait(10);
            GetPages<HomePage>().SportClick();
            GetPages<SportPage>().SignInExitClick();
            GetPages<SportPage>().FootballClick();
            GetPages<FootballPage>().MoreClick();
            GetPages<FootballPage>().ClickOnLeague(league);
            GetPages<FootballPage>().ViewAllClick();
            GetPages<ScoresFixturesPage>().ClickOnMonth(month);
            GetPages<ScoresFixturesPage>().ClickOnTeam(team1, team2);
            Assert.Multiple(() => {
                Assert.That(GetPages<ScoresFixturesPage>().GetScore(team1, team2) == score);
                Assert.That(GetPages<FootballMatchPage>().GetScore(team1, team2) == score);
            });
            
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Driver.StopDriver();
        }

      
    }
}
