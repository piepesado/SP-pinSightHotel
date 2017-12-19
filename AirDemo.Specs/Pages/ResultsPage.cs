using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace HOTELpinSight.Pages
{
    public class ResultsPage : BasePage
    {
        public ResultsPage(IWebDriver driver) : base(driver)
        {
        }

        //MAP and CARD views common elements
        [FindsBy(How = How.Id, Using = "mapGoogle")]
        private IWebElement _googleMap;

        [FindsBy(How = How.Id, Using = "hotelnamesearch")]
        private IWebElement _searchHotelByName;

        [FindsBy(How = How.Id, Using = "sortby")]
        private IWebElement _sortByCombo;

        [FindsBy(How = How.Id, Using = "filterIcon")]
        private IWebElement _filterButton;

        [FindsBy(How = How.Id, Using = "text-button")]
        private IWebElement _searchRoomsButton;

        [FindsBy(How = How.Id, Using = "cardicon")]
        private IWebElement _cardView;

        [FindsBy(How = How.Id, Using = "mapicon")]
        private IWebElement _mapView;

        //CARD view elements
        //Try to find filter sliders identifiers.

        public void ClickCardView()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(_cardView));
            _cardView.Click();
        }

        public void ClickShowRooms()
        {
            _searchRoomsButton.Click();
        }
    }
}
