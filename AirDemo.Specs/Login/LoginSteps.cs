using HOTELpinSight.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using TechTalk.SpecFlow;

namespace HOTELpinSight.Specs.Login
{
    [Binding]
    public class LoginSteps
    {
        /// <summary>
        /// Web Driver
        /// </summary>
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private HotelSearchPage _hotelSearchPage;

        [Given(@"Given that I navigate to pinSight application")]
        public void GivenGivenThatINavigateToTheTravelNXTApplication()
        {
            _driver = WebDriverFactory.Create();
            _loginPage = LoginPage.NavigateTo(_driver);
        }
        
        [Given(@"And I enter (.*) as the username")]
        public void GivenAndIEnterTheUsername(string username)
        {
            _loginPage.Username = username;
        }
        
        [Given(@"I enter the password")]
        public void GivenIEnterThePassword()
        {
            _loginPage.Password = "Test@123";
        }

        [When(@"I press login")]
        public void WhenIPressLogin()
        {
            _hotelSearchPage = _loginPage.Login();
        }
        
        [Then(@"I should land on the Hotel page")]
        public void ThenIShouldLandOnTheBackofficePage()
        {
            _hotelSearchPage.EnsurePageIsLoaded();

            Assert.IsTrue(_driver.Title.Contains("P UAT"));
            Thread.Sleep(5000);
        }

        [AfterScenario]
        public void CleanUp()
        {
            if (_driver != null)
            {
                _driver.Close();
                _driver.Dispose();
            }
        }
    }
}
