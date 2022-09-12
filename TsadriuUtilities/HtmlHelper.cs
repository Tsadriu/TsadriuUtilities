// <copyright file HtmlHelper.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>
using System.Collections.Generic;
using System.Net;

namespace TsadriuUtilities
{
    /// <summary>
    /// A class that helps on dealing with html text.
    /// </summary>
    public static class HtmlHelper
    {
        /// <summary>
        /// Converts the <paramref name="decodedHtml"/> into a HTML-encoded <see cref="string"/>.
        /// </summary>
        /// <param name="decodedHtml">Html text to encode.</param>
        /// <returns>An econded <see cref="string"/>.</returns>
        public static string EncodeHtml(this string decodedHtml)
        {
            return WebUtility.HtmlEncode(decodedHtml);
        }

        /// <summary>
        /// Converts the <paramref name="encodedHtml"/> into a decoded <see cref="string"/>.
        /// </summary>
        /// <param name="encodedHtml">Html text to decode.</param>
        /// <returns>A decoded <see cref="string"/>.</returns>
        public static string DecodeHtml(this string encodedHtml)
        {
            return WebUtility.HtmlDecode(encodedHtml);
        }

        /// <summary>
        /// Checks the <paramref name="html"/> and tries to return link that is in between the <b><![CDATA[href=""]]></b>.
        /// </summary>
        /// <param name="html">Html string with the link inside of it.</param>
        /// <returns>The link in between the <b><![CDATA[href=""]]></b>. If the link is not found, returns a <see cref="string.Empty"/>.</returns>
        public static string GetHrefLink(this string html)
        {
            return html.GetBetween("href=\"", "\"");
        }

        /// <summary>
        /// Checks the <paramref name="html"/> and tries to return multiple links that are in between the <b><![CDATA[href=""]]></b>.
        /// </summary>
        /// <param name="html">Html string with the links inside of it.</param>
        /// <returns>The multiple links that are between the <b><![CDATA[href=""]]></b>. If no links are found, return an empty <b><![CDATA[List<string>]]></b>.</returns>
        public static List<string> GetMultipleHrefLinks(this string html)
        {
            return html.GetMultipleBetween("href=\"", "\"");
        }
    }
}
