using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HOTELpinSight
{
    static class WebDriverFactory
    {
        /// <summary>
        /// Create an instance of a web driver.
        /// </summary>
        /// <returns></returns>
        internal static IWebDriver Create()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            // options.AddArgument("headless"); // This would be added if running on a server through Jenkins.

            IWebDriver driver = new ChromeDriver(options);
            return driver;
        }
    }
}
