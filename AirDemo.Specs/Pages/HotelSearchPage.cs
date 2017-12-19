using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;

namespace HOTELpinSight.Pages
{
    public class HotelSearchPage : BasePage
    {

        public HotelSearchPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "ucPWP_ctl08_55218_lnkGoToBackOffice")]
        private IWebElement _backOfficeButton;

        [FindsBy(How = How.Id, Using = "autoSuggest")]
        private IWebElement _search;

        //Not sure about the identifiers

        //Datepickers
        [FindsBy(How = How.LinkText, Using = "Check-in")]
        private IWebElement _checkInDatePicker;

        [FindsBy(How = How.LinkText, Using = "Pick a year from the dropdown")]
        private IWebElement _checkInDatePickerYear;

        [FindsBy(How = How.LinkText, Using = "Pick a month from the dropdown")]
        private IWebElement _checkInDatePickerMonth;

        [FindsBy(How = How.LinkText, Using = "Go to the previous month")]
        private IWebElement _checkInDatePickerNavBack;

        [FindsBy(How = How.LinkText, Using = "Go to the next month")]
        private IWebElement _checkInDatePickerNavNext;

        [FindsBy(How = How.LinkText, Using = "Check-out")]
        private IWebElement _checkOutDatePicker;

        [FindsBy(How = How.Id, Using = "search")]
        private IWebElement _searchButton;

        public string Search
        {
            get
            {
                return _search.Text;
            }
            set
            {
                _search.SendKeys(value);
            }
        }

        public void SelectCheckIn()
        {
            Actions selectCheckIn = new Actions(_driver);
            selectCheckIn.MoveToElement(_checkInDatePicker);
            _checkInDatePicker.Click();
            if(_checkInDatePickerYear.Text != "2018")
                new SelectElement(_checkInDatePickerYear).SelectByValue("2018");
            new SelectElement(_checkInDatePickerMonth).SelectByValue("May");

            IList<IWebElement> rows = _checkInDatePicker.FindElements(By.TagName("tr"));
            IList<IWebElement> columns = _checkInDatePicker.FindElements(By.TagName("td"));

            foreach(IWebElement cell in columns)
            {
                if (cell.ToString().Equals("6"))
                {
                    cell.FindElement(By.LinkText("6")).Click();
                    break;
                }
            }

            selectCheckIn.Perform();
        }

        /*
        public void SelectCheckOut()
        {
            Actions selectCheckOut = new Actions(_driver);
            selectCheckOut.MoveToElement(_checkOutDatePicker);
            _checkOutDatePicker.Click();
            if (_checkOutDatePicker.Text != "2018")
                new SelectElement(_checkOutDatePickerYear).SelectByValue("2018");
            new SelectElement()
        }
        */
        
        public void ClickSearchHotel()
        {
            _searchButton.Click();
        }

        public void EnsurePageIsLoaded()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(_backOfficeButton));
        }

        public SearchingPage Login()
        {
            _searchButton.Click();
            return new SearchingPage(_driver);
        }
    }
}
