using Automation_Home_Project.PageObject;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Automation_Home_Project.Assembly
{
    public class PagesGet
    {
        public static T GetPages<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(Driver.WebDriver, page);
            return page;
        }
    }
}
