using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace HOTELpinSight.Pages
{
    [Binding]
    public class SearchHotelSteps
    {

        /// <summary>
        /// Web Driver
        /// </summary>
        private IWebDriver _driver;        
        private HotelSearchPage _hotelSearchPage;
        private SearchingPage _searchingPage;
        private ResultsPage _resultsPage;

        [Given(@"That Im logged in at pinSight")]
        public void GivenThatImLoggedInAtPinSight()
        {
            _driver = WebDriverFactory.Create();
            _hotelSearchPage = new HotelSearchPage(_driver);
            Assert.IsTrue(_driver.Title.Equals("P UAT Agency(987654) :: Home"));
        }
        
        [Given(@"I have entered (.*) as the city")]
        public void GivenIHaveEnteredCity(string search)
        {
            _hotelSearchPage.Search = search;          
            
        }
        
        [Given(@"I have entered checkin date")]
        public void GivenIHaveEnteredCheckinDate(string checkIn)
        {
            _hotelSearchPage.SelectCheckIn();
        }
        
        [Given(@"I have entered checkout date")]
        public void GivenIHaveEnteredCheckoutDate(string checkOut)
        {
            //_hotelSearchPage.EnterCheckOut = checkOut;
            
        }
        
        [When(@"I click on Search button")]
        public void WhenIClickOnSearchButton()
        {
            _hotelSearchPage.ClickSearchHotel();
        }
        
        [Then(@"Hotel search results should be displayed on screen")]
        public void ThenHotelSearchResultsShouldBeDisplayedOnScreen()
        {
            _searchingPage = new SearchingPage(_driver);
            _searchingPage.EnsurePageIsLoaded();            
        }
    }
}
