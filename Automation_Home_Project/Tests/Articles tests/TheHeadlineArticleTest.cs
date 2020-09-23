using Automation_Home_Project.Assembly;
using Automation_Home_Project.PageObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace Automation_Home_Project
{
    [Binding]
    public class TheHeadlineArticleTest: PagesGet
    {
        string testArticle;

        [Given(@"the test headline article is ""(.*)""")]
        public void GivenTheTestHeadlineArticleIs(string article)
        {
            testArticle=article;
        }
        
        [When(@"user navigating to the News page")]
        public void WhenUserNavigatingToTheNewsPage()
        {
            GetPages<HomePage>().NewsClick();
        }
        
        [Then(@"the headline article at the News page should be")]
        public void ThenTheHeadlineArticleAtTheNewsPageShouldBe()
        {
            Assert.AreEqual(testArticle, GetPages<NewsPage>().HeadlineArticle());
        }
    }
}
