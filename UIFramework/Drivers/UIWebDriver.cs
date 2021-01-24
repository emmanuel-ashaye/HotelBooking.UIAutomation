using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using UIFramework.Infrastructure;

namespace UIFramework.Drivers
{
    public class UIWebDriver : ITestDriver
    {
        /// <summary>
        /// The selenium web driver
        /// </summary>
        private static IWebDriver _driver;


        /// <summary>
        /// Represents the application under test.
        /// </summary>
        public readonly string _applicationUrl;

        /// <summary>
        /// The ui web driver constructor
        /// </summary>
        /// <param name="application">The executing application.</param>
        public UIWebDriver()
        {
        }

        /// <summary>
        /// Gets the selenium web driver
        /// </summary>
        public IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                    OpenApplication(Configuration.ApplicationBaseUrl);
                return _driver;
            }
        }

        /// <summary>
        /// Disposes the driver.
        /// </summary>
        public void Dispose()
        {
            _driver?.Dispose();
            _driver = null;
        }

        /// <summary>
        /// Opens the driver specific application.
        /// </summary>
        public void OpenApplication(string applicationUrl)
        {
            var waitLimit = TimeSpan.FromSeconds(7);
            DriverOptions options;

            if (Configuration.RemoteNode == "Chrome")
            {
                options = new ChromeOptions();
                ((ChromeOptions)options).AddArguments("chrome.switches",
                    "--disable-notifications",
                    "--disable-extensions",
                    "--start-maximized",
                    "no-sandbox",
                    "test-type");
            }
            else
            {
                options = new FirefoxOptions
                {
                    Profile = new FirefoxProfileManager().GetProfile("selenium")
                };
                ((FirefoxOptions)options).SetPreference("dom.webnotifications.enabled", true);
            }

            _driver = new RemoteWebDriver(new Uri(Configuration.RemoteDriverUrl), options.ToCapabilities(), waitLimit);
            _driver.Manage().Timeouts().ImplicitWait = waitLimit;
            _driver.Manage().Timeouts().PageLoad = waitLimit;
            _driver.Navigate().GoToUrl(applicationUrl);
        }
    }
}
