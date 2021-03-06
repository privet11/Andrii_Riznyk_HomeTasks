﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Home_Project.PageObject
{
    public class EntertaimentArtsPage : Driver
    {
        private readonly IList<IWebElement> headlinesList = WebDriver.FindElements(By.XPath("//a[contains(@class,'gs-c-promo')]"));
        //a[contains(@class,'gs-c-promo-heading gs-o-faux-block-link__overlay-link gel-paragon-bold gs-u-mt+ nw-o-link-split__anchor')]

        public void FirstHeadlineClick() 
        { 
            headlinesList.Where(x=> x.Displayed).FirstOrDefault().Click(); 
        }

        

    }
}
