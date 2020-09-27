using Automation_Home_Project.Assembly;
using Automation_Home_Project.PageObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace Automation_Home_Project.Tests.HomeTask1_tests
{
    [Binding]
    public class LinkSharingTest : PagesGet
    {
        string link = string.Empty;
        string article1;
        string article2;



        [Given(@"the BBC Home page is open")]
        public void GivenTheBBCHomePageIsOpen()
        {
            GetPages<HomePage>();
        }

        [When(@"I go to News")]
        public void WhenIGoToNews()
        {
            GetPages<HomePage>().NewsClick();
        }

        [When(@"click on ""(.*)"" tab")]
        public void WhenClickOnTab(string sectionName)
        {
            GetPages<NewsPage>().SignInExitClick();
            GetPages<NewsPage>().NavMenuButtonClick(sectionName);
        }

        [When(@"click the first article")]
        public void WhenClickTheFirstArticle()
        {
            GetPages<EntertaimentArtsPage>().FirstHeadlineClick();
        }

        [When(@"click Share")]
        public void WhenClickShare()
        {
            article1 = GetPages<SpecificNewsPage>().Article();
            GetPages<SpecificNewsPage>().ShareClick();
        }

        [When(@"copy the link")]
        public void WhenCopyTheLink()
        {
            link = GetPages<SpecificNewsPage>().ShareLink();
        }

        [When(@"navigate the link")]
        public void WhenNavigateTheLink()
        {
            Driver.WebDriver.Navigate().GoToUrl(link);
            article2 = GetPages<SpecificNewsPage>().Article();
        }

        [Then(@"the same article is open")]
        public void ThenTheSameArticleIsOpen()
        {
            Assert.AreEqual(article1, article2);
            Driver.StopDriver();
        }


    }
}
