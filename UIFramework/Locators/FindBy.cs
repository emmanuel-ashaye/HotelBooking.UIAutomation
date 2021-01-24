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

        public static implicit operator By(FindBy locator)
        {
            if (locator != null)
            {
                return locator.How switch
                {
                    How.Id => By.Id(locator),
                    How.PartialId => By.XPath($".//*[contains(@id, '{locator}')]"),
                    How.Css => By.CssSelector(locator),
                    How.Class => By.ClassName(locator),
                    How.XPath => By.XPath(locator),
                    _ => throw new InvalidOperationException("what did you try to do???"),
                };
            }

            return null;
        }

        public static implicit operator string(FindBy instance)
        {
            return instance.Locator;
        }

        public override string ToString()
        {
            return Locator?.ToString();
        }
    }
}
