using Automation_Home_Project.Assembly;
using Automation_Home_Project.PageObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Automation_Home_Project
{
    [Binding]
    public class FirstSearchResultTest:PagesGet
    {
        string firstSearchResultArticle;

        [Given(@"the specified value is (.*)")]
        public void GivenTheSpecifiedValueIs(string article)
        {
            firstSearchResultArticle=article;
        }
        
        [When(@"user is navigate to the News page")]
        public void WhenUserIsNavigateToTheNewsPage()
        {
            GetPages<HomePage>().NewsClick();
        }
        
        [When(@"user is not logining in")]
        public void WhenUserIsNotLoginingIn()
        {
            GetPages<NewsPage>().SignInExitClick();
        }
        
        [When(@"user input search word")]
        public void WhenUserInputSearchWord()
        {
            GetPages<NewsPage>().SearchInput(GetPages<NewsPage>().CategoryName());
        }
        
        [Then(@"the the name of the first article should be like a specified value")]
        public void ThenTheTheNameOfTheFirstArticleShouldBeLikeASpecifiedValue()
        {
            IList<IWebElement> list = GetPages<SearchResultPage>().SearchItemsList();
            Assert.AreEqual(list[0].Text, "Chuggington: Badge Quest: Home Sweet Home");
        }
    }
}
