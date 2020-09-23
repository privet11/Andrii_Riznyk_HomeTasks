using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Home_Project.PageObject
{
    public class NewsPage:Driver
    {
        //[FindsBy(How = How.XPath, Using = "//button[@class='sign_in-exit']")]
        private readonly IWebElement signInExitButt = WebDriver.FindElement(By.XPath("//button[@class='sign_in-exit']"));
        private readonly IList<IWebElement> headlineArticle = WebDriver.FindElements(By.XPath("//h3[contains(@class,'heading__title')]"));
        private readonly IList<IWebElement> secondaryArticleList = WebDriver.FindElements(By.XPath("//p[contains(@class,'gs-c-promo')]"));
        private readonly IWebElement category = WebDriver.FindElement(By.XPath("//a[@class='nw-o-link']"));
        private readonly IWebElement searchInput = WebDriver.FindElement(By.XPath("//input[contains(@id,'search')]"));
        private readonly IList<IWebElement> navMenuButtons = WebDriver.FindElements(By.XPath("//li[contains(@class,'gs-u-display-block')]"));

        public string HeadlineArticle() => headlineArticle.FirstOrDefault().Text;

        public string CategoryName() => category.Text;

        public IEnumerable<string> SecondaryArticleList() => secondaryArticleList.Select(x => x.Text);

        public void SignInExitClick()
        {
            if (signInExitButt != null)
            {
                signInExitButt.Click();
            }
        }
        public void NavMenuButtonClick(string section)
        {
            navMenuButtons.Where(bt => bt.Text == section).FirstOrDefault().Click();
        }

        public void SearchInput(string item) => searchInput.SendKeys(item);


    }
}
