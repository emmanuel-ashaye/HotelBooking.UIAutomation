using System;
using System.Collections.Generic;
using System.Text;

namespace UIFramework.Locators
{
    public enum How
    {
        /// <summary>
        /// The id attribute.
        /// </summary>
        Id,

        /// <summary>
        /// The id, text or label atttribute.
        /// </summary>
        IdTextOrLabel,

        /// <summary>
        /// The class attribtue.
        /// </summary>
        Class,

        /// <summary>
        /// The text attribute.
        /// </summary>
        Text,

        /// <summary>
        /// The partial text attribute.
        /// </summary>
        PartialText,

        /// <summary>
        /// The css atttribute.
        /// </summary>
        Css,

        /// <summary>
        /// The xpath attribute.
        /// </summary>
        XPath,

        /// <summary>
        /// The hyperlink text attribute.
        /// </summary>
        HyperlinkText,

        /// <summary>
        /// The hyperlink href attribute.
        /// </summary>
        HyperlinkHref,

        /// <summary>
        /// The partial id attribute.
        /// </summary>
        PartialId,

        /// <summary>
        /// The label text attribute.
        /// </summary>
        Label
    }
}
