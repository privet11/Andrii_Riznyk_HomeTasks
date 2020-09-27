using Automation_Home_Project.Assembly;
using Automation_Home_Project.HomeTask2Patterns;
using OpenQA.Selenium;

namespace Automation_Home_Project.PageObject
{
    public class SportPage: Driver
    {
        private readonly IWebElement footballButt = WebDriver.FindElement(By.XPath("//a[@data-stat-title='Football']"));
        //[FindsBy(How = How.XPath, Using = "//button[@class='sign_in-exit']")]
        //private readonly IWebElement signInExitButt;
        private readonly IWebElement signInExitButt = WebDriver.FindElement(By.XPath("//button[@class='sign_in-exit']"));


        public void FootballClick() => footballButt.Click();
        //public void SignInExitClick()
        //{
        //    ExplicitWait(10, By.XPath("//button[@class='sign_in-exit']"));
        //    signInExitButt.Click();
        //}

        public void ClientSignInExitClick(Page page)
        {
           page.SignInExitClick(signInExitButt);
        }
    }
}
