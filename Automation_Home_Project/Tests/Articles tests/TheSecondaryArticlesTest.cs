using Automation_Home_Project.Assembly;
using Automation_Home_Project.PageObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Automation_Home_Project
{
    [Binding]
    public class TheSecondaryArticlesTest : PagesGet
    {
        List<string> searchResults = new List<string>();
        [Given(@"the expected secondary articles is (.*)")]
        public void GivenTheExpectedSecondaryArticlesIs(string expectedSearchResults)
        {
            searchResults= expectedSearchResults.Split('.').Where(x => x.Length > 0).Select(x => x + '.').ToList();
        }
        
        [When(@"user navigating to the news page")]
        public void WhenUserNavigatingToTheNewsPage()
        {
            GetPages<HomePage>().NewsClick();
        }
        
        
        [Then(@"the search results should contain expected articles")]
        public void ThenTheSearchResultsShouldContainExpectedArticles()
        {
            //Assert.IsTrue(GetPages<NewsPage>().SecondaryArticleList().Contains(searchResults[1]));
            foreach (var res in searchResults)
            {
                Assert.IsTrue(GetPages<NewsPage>().SecondaryArticleList().Contains(res));
            }
        }
        [TestCleanup]
        public void TestCleanup()
        {
            Driver.StopDriver();
        }
    }
}
