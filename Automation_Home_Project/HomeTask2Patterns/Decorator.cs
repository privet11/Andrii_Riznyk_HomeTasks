using OpenQA.Selenium;

namespace Automation_Home_Project.HomeTask2Patterns
{
    public abstract class Page : Driver
    {
        public abstract void SignInExitClick(IWebElement exitButt);
    }

    public class ConcreteComponent : Page
    {
        public override void SignInExitClick(IWebElement exitButt)
        {
            exitButt.Click();
        }
    }

    public abstract class Decorator : Page
    {
        protected Page page;

        public Decorator(Page page)
        {
            this.page = page;
        }

        public void SetComponent(Page page)
        {
            this.page = page;
        }
        public override void SignInExitClick(IWebElement exitButt)
        {
            if (page != null)
            {
                page.SignInExitClick(exitButt);
            }

        }

        public class DecoratorWithDisplayChecking : Decorator
        {
            public DecoratorWithDisplayChecking(Page p) : base(p)
            { }

            public override void SignInExitClick(IWebElement exitButt)
            {
                if (exitButt.Displayed)
                {
                    base.SignInExitClick(exitButt);
                }
            }

        }
    }
}
