namespace UIFramework.Locators
{
    public static class Find
    {
        /// <summary>
        /// Method to locate elements by id.
        /// </summary>
        /// <param name="locator">The id attribute of the element.</param>
        /// <returns></returns>
        public static FindBy ById(string locator)
        {
            return new FindBy { How = How.Id, Locator = locator };
        }

        /// <summary>
        /// Method to locate elements by class name.
        /// </summary>
        /// <param name="className">The class name  attribute of the element.</param>
        /// <returns></returns>
        public static FindBy ByClass(string className)
        {
            return new FindBy { How = How.Class, Locator = className };
        }

        /// <summary>
        /// Method to locate elements by id, text or label.
        /// </summary>
        /// <param name="idTextOrLabel">The id, text or label attribute of the element.</param>
        /// <returns></returns>
        public static FindBy ByIdTextOrLabel(string idTextOrLabel)
        {
            return new FindBy { How = How.IdTextOrLabel, Locator = idTextOrLabel };
        }

        /// <summary>
        /// Method to locate elements by text.
        /// </summary>
        /// <param name="text">The text attribute of the element</param>
        /// <returns></returns>
        public static FindBy ByText(string text)
        {
            return new FindBy { How = How.Text, Locator = text };
        }

        /// <summary>
        /// Method to locate elements by partial text.
        /// </summary>
        /// <param name="text">The text attribute of the element</param>
        /// <returns></returns>
        public static FindBy ByPartialText(string text)
        {
            return new FindBy { How = How.PartialText, Locator = text };
        }

        /// <summary>
        /// Method to locate elements by xpath.
        /// </summary>
        /// <param name="xPath">The xpath attribute of the element.</param>
        /// <returns></returns>
        public static FindBy ByXPath(string xPath)
        {
            return new FindBy { How = How.XPath, Locator = xPath };
        }

        /// <summary>
        /// Method to locate elements by hyperlink text.
        /// </summary>
        /// <param name="text">The hyperlink text attribute of the element.</param>
        /// <returns></returns>
        public static FindBy ByHyperLinkText(string text)
        {
            return new FindBy { How = How.HyperlinkText, Locator = text };
        }

        /// <summary>
        /// Method to locate elements by hyperlink href.
        /// </summary>
        /// <param name="text">The hyperlink text attribute of the element.</param>
        /// <returns></returns>
        public static FindBy ByHyperLinkHref(string text)
        {
            return new FindBy { How = How.HyperlinkHref, Locator = text };
        }

        /// <summary>
        /// Method to locate elements by partial id.
        /// </summary>
        /// <param name="text">The hyperlink text attribute of the element.</param>
        /// <returns></returns>
        public static FindBy ByPartialId(string text)
        {
            return new FindBy { How = How.PartialId, Locator = text };
        }

        /// <summary>
        /// Method to locate elements by label text.
        /// </summary>
        /// <param name="text">The hyperlink text attribute of the element.</param>
        /// <returns></returns>
        public static FindBy ByLabel(string text)
        {
            return new FindBy { How = How.Label, Locator = text };
        }
    }
}
