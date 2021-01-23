using OpenQA.Selenium;
using System;

namespace UIFramework.Locators
{
    public class FindBy
    {
        /// <summary>
        /// Gets or sets the locator type.
        /// </summary>
        public How How { get; set; }

        /// <summary>
        /// Gets or sets the locator.
        /// </summary>
        public string Locator { get; set; }

        public static implicit operator By(FindBy instance)
        {
            if (instance != null)
            {
                return instance.How switch
                {
                    How.Id => By.Id(instance.Locator),
                    How.PartialId => By.XPath($".//*[contains(@id, '{instance.Locator}')]"),
                    How.Css => By.CssSelector(instance.Locator),
                    How.Class => By.ClassName(instance.Locator),
                    How.XPath => By.XPath(instance.Locator),
                    _ => throw new InvalidOperationException("what did you try to do???"),
                };
            }

            return null;
        }
    }
}
