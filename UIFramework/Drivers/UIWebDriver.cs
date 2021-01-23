using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

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
        public UIWebDriver(string applicationUrl)
        {
            _applicationUrl = applicationUrl;
        }

        /// <summary>
        /// Gets the selenium web driver
        /// </summary>
        public IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                    OpenApplication(_applicationUrl);
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
            var timeout = TimeSpan.FromSeconds(7);

            //var service = ChromeDriverService.CreateDefaultService("./");
            var options = new ChromeOptions();
            options.AddArguments("chrome.switches",
                "--disable-notifications",
                "--disable-extensions",
                "--start-maximized",
                "no-sandbox",
                "test-type");

            _driver = new RemoteWebDriver(new Uri("http://selenium-runner:4444/wd/hub"), options);
            //_driver = new ChromeDriver(service, options, timeout);

            _driver.Manage().Timeouts().ImplicitWait = timeout;
            _driver.Manage().Timeouts().PageLoad = timeout;
            _driver.Navigate().GoToUrl(applicationUrl);
        }
    }
}
