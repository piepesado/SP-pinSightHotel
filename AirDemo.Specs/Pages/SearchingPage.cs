using HOTELpinSight.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace HOTELpinSight.Pages
{
    public class SearchingPage : BasePage
    {

        public SearchingPage(IWebDriver driver) : base (driver)
        {
        }  


        [FindsBy(How = How.Id, Using = "dvPreloader")]
        private IWebElement loader;

        //move this procedure to a Helper class
        public void EnsurePageIsLoaded()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(loader));
        }

    }
}

