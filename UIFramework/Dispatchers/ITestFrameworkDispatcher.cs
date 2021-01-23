using UIFramework.Locators;

namespace UIFramework.Dispatchers
{
    public interface ITestFrameworkDispatcher
    {
        /// <summary>
        /// Performs the click action.
        /// </summary>
        /// <param name="findBy">The element on which to perfom the action.</param>
        /// <param name="index">The index of the element.</param>
        void Click(FindBy findBy, int index = 0);

        /// <summary>
        /// Performs the select action.
        /// </summary>
        /// <param name="findBy">The element on which to perfom the action.</param>
        /// <param name="index">The index of the element.</param>
        /// <param name="optionText">The text to select.</param>
        ITestFrameworkDispatcher Select(FindBy findBy, string optionText, int index = 0);

        /// <summary>
        /// Confirms a javascript alert.
        /// </summary>
        void ConfirmAlert();

        /// <summary>
        /// Dismisses a javascript alert.
        /// </summary>
        void DismissAlert();

        /// <summary>
        /// Performs the enter text action.
        /// </summary>
        /// <param name="findBy">The element on which to perfom the action.</param>
        /// <param name="text">The string characters to enter.</param>
        ITestFrameworkDispatcher EnterText(FindBy findBy, string text);

        /// <summary>
        /// Performs the clear text action.
        /// </summary>
        /// <param name="findBy">The element on which to perfom the action.</param>
        void ClearText(FindBy findBy);

        /// <summary>
        /// Performs the scroll down to action.
        /// </summary>
        /// <param name="findBy">The element on which to perfom the action.</param>
        /// <param name="within">The element within which to perform the action.</param>
        /// <param name="index">The index of the element.</param>
        void ScrollDownTo(FindBy findBy, FindBy within = null, int index = 0);

        /// <summary>
        /// Wait for element.
        /// </summary>
        /// <param name="findBy">The element on which to perfom the action.</param>
        void WaitForElement(FindBy findBy);

        /// <summary>
        /// Takes a screenshot.
        /// </summary>
        /// <param name="title">The screenshot title parameter.</param>
        /// <param name="path">The screenshot path parameter.</param>
        void TakeScreenShot(string title, string path);


        /// <summary>
        /// Get an attribute of an element
        /// </summary>
        /// <param name="findBy">The element on which to perfom the action.</param>
        /// <param name="attribute">Attribute to be found</param>
        /// <param name="index">The index of the element.</param>
        /// <returns>The value of the attribute</returns>
        string GetAttributeOfElement(FindBy findBy, string attribute, int index = 0);

        /// <summary>
        /// Refreshes the webpage.
        /// </summary>
        void Refresh();

        /// <summary>
        /// Waits for element to be invisible.
        /// </summary>
        /// <param name="findBy">The element on which to perfom the action.</param>
        void WaitForNoElement(FindBy findBy);

        /// <summary>
        /// Waits for text to be present in element.
        /// </summary>
        /// <param name="findBy">The element on which to perfom the action.</param>
        /// <param name="text">The text to expect.</param>
        void WaitForElementText(FindBy findBy, string text);

        /// <summary>
        /// Waits for value to be present in element.
        /// </summary>
        /// <param name="findBy">The element on which to perfom the action.</param>
        /// <param name="value">The value to expect.</param>
        void WaitForElementValue(FindBy findBy, string value);

        /// <summary>
        /// Waits for any value to be present in element.
        /// </summary>
        /// <param name="findBy">The element on which to perfom the action.</param>
        void WaitForAnyValue(FindBy findBy);

        /// <summary>
        /// Waits for element to be visible.
        /// </summary>
        /// <param name="findBy">The element on which to perfom the action.</param>
        void WaitForElementToBeVisible(FindBy findBy);

        /// <summary>
        /// Gets the number of elements that are matching the given FindBy
        /// </summary>
        /// <param name="findBy">The element to look for.</param>
        /// <returns></returns>
        int GetElementCount(FindBy findBy);


        /// <summary>
        /// Navigate to the page using page url
        /// </summary>
        /// <param name="url">url of the page</param>
        void NavigateToUrl(string url);
    }
}