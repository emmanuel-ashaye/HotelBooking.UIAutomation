using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using UIFramework.Drivers;
using UIFramework.Locators;

namespace UIFramework.Dispatchers
{
    public class UIWebDispatcher : ITestFrameworkDispatcher
    {
        /// <summary>
        /// The <see cref="UIWebDriver"/> member.
        /// </summary>
        private readonly UIWebDriver _testDriver;

        /// <summary>
        /// The <see cref="IWebDriver"/> property.
        /// </summary>
        private IWebDriver Driver => _testDriver.Driver;

        /// <summary>
        /// The ui web dispatcher constructor.
        /// </summary>
        /// <param name="uiWebDriver">The driver to be dispatched.</param>
        public UIWebDispatcher(UIWebDriver uiWebDriver)
        {
            _testDriver = uiWebDriver;
        }

        /// <summary>
        /// Performs the clear text action.
        /// </summary>
        /// <param name="findBy">The element on which to perfom the action.</param>
        public void ClearText(FindBy findBy)
        {
            Driver.FindElements(findBy).First().Clear();
        }

        /// <summary>
        /// Performs the enter text action.
        /// </summary>
        /// <param name="findBy">The element on which to perfom the action.</param>
        /// <param name="text">The string characters to enter.</param>
        public ITestFrameworkDispatcher EnterText(FindBy findBy, string text)
        {
            Driver.FindElements(findBy).First().SendKeys(text);
            return this;
        }

        /// <summary>
        /// Refreshes the webpage.
        /// </summary>
        public void Refresh()
        {
            Driver.Navigate().Refresh();
        }

        /// <summary>
        /// Takes a screenshot.
        /// </summary>
        /// <param name="title">The screenshot title parameter.</param>
        /// <param name="path">The screenshot path parameter.</param>
        public void TakeScreenShot(string title, string path)
        {
            ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile($"{path}\\{title}.png", ScreenshotImageFormat.Png);
        }

        /// <summary>
        /// Queries for text.
        /// </summary>
        /// <param name="findBy">The element on which to perfom the action.</param>
        /// <returns></returns>
        public IEnumerable<string> QueryForText(FindBy findBy)
        {
            return Driver.FindElements(findBy).Select(x => x.Text);
        }

        /// <summary>
        /// Queries alert for text.
        /// </summary>
        /// <returns></returns>
        public string QueryAlertForText()
        {
            return Driver.SwitchTo().Alert().Text;
        }

        /// <summary>
        /// Queries dropdown list for text.
        /// </summary>
        /// <param name="findBy">The element on which to perfom the action.</param>
        /// <returns>The selected text.</returns>
        public string QueryListForSelectedText(FindBy findBy)
        {
            var element = Driver.FindElement(findBy);
            var dropdown = new SelectElement(element);
            return dropdown.SelectedOption.Text;
        }

        /// <summary>
        /// Performs the scroll down to action.
        /// </summary>
        /// <param name="findBy">The element on which to perfom the action.</param>
        /// <param name="within">The element within which to perform the action.</param>
        /// <param name="index">The index of the element.</param>
        public void ScrollDownTo(FindBy findBy, FindBy within = null, int index = 0)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript($"window.scrollTo(0,{Driver.FindElement(findBy).Location.Y});");
        }

        /// <summary>
        /// Performs the click action.
        /// </summary>
        /// <param name="findBy">The element on which to perfom the action.</param>
        /// <param name="index">The index of the element.</param>
        public void Click(FindBy findBy, int index = 0)
        {
            WaitForElementToBeVisible(findBy);
            Driver.FindElements(findBy)[index].Click();
        }

        /// <summary>
        /// Get an attribute of an element
        /// </summary>
        /// <param name="findBy">The element on which to perfom the action.</param>
        /// <param name="attribute">Attribute to be found</param>
        /// <param name="index">The index of the element.</param>
        /// <returns>The value of the attribute</returns>
        public string GetAttributeOfElement(FindBy findBy, string attribute, int index = 0)
        {
            return Driver.FindElements(findBy)[index].GetAttribute(attribute);
        }

        /// <summary>
        /// Performs the select action on a select element.
        /// </summary>
        /// <param name="findBy">The select element on which to perfom the action.</param>
        /// <param name="index">The index of the element.</param>
        /// <param name="optionText">The text to select.</param>
        public ITestFrameworkDispatcher Select(FindBy findBy, string optionText, int index = 0)
        {
            new SelectElement(Driver.FindElements(findBy)[index]).SelectByText(optionText);
            return this;
        }

        /// <summary>
        /// Confirms a javascript alert.
        /// </summary>
        public void ConfirmAlert()
        {
            Driver.SwitchTo().Alert().Accept();
        }

        /// <summary>
        /// Dismisses a javascript alert.
        /// </summary>
        public void DismissAlert()
        {
            Driver.SwitchTo().Alert().Dismiss();
        }

        /// <summary>
        /// Wait for element.
        /// </summary>
        /// <param name="findBy">The element on which to perfom the action.</param>
        public void WaitForElement(FindBy findBy)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(7))
                .Until(e => e.FindElements(findBy).Any());
        }

        /// <summary>
        /// Waits for element to be visible.
        /// </summary>
        /// <param name="findBy">The element on which to perfom the action.</param>
        public void WaitForElementToBeVisible(FindBy findBy)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(7))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(findBy));
        }

        /// <summary>
        /// Waits for element to be invisible.
        /// </summary>
        /// <param name="findBy">The element on which to perfom the action.</param>
        public void WaitForNoElement(FindBy findBy)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(7))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(findBy));
        }

        /// <summary>
        /// Waits for text to be present in element.
        /// </summary>
        /// <param name="findBy">The element on which to perfom the action.</param>
        /// <param name="text">The text to expect.</param>
        public void WaitForElementText(FindBy findBy, string text)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(7))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementLocated(findBy, text));
        }

        /// <summary>
        /// Waits for value to be present in element.
        /// </summary>
        /// <param name="findBy">The element on which to perfom the action.</param>
        /// <param name="value">The value to expect.</param>
        public void WaitForElementValue(FindBy findBy, string value)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(7))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(findBy, value));
        }

        /// <summary>
        /// Waits for any value to be present in element.
        /// </summary>
        /// <param name="findBy">The element on which to perfom the action.</param>
        public void WaitForAnyValue(FindBy findBy)
        {
            new WebDriverWait(Driver, TimeSpan.FromSeconds(7))
                .Until(e => e.FindElement(findBy).GetAttribute("value").Length > 0);
        }

        /// <summary>
        /// Gets the number of elements that are matching the given FindBy
        /// </summary>
        /// <param name="findBy">The element to look for.</param>
        /// <returns></returns>
        public int GetElementCount(FindBy findBy)
        {
            return Driver.FindElements(findBy).Count;
        }

        /// <summary>
        /// Navigate to the page using page url
        /// </summary>
        /// <param name="url">url of the page</param>
        public void NavigateToUrl(string url)
        {
            Driver.Navigate().GoToUrl(_testDriver._applicationUrl);
        }
    }
}