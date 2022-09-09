// <copyright file HtmlHelper.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Globalization;
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

        /*public static List<string> GetLinks(this string html, bool keepLinkName = false)
        {
            string endTag = keepLinkName ? "<" : "\"";
            var test = html.GetMultipleBetween("href=\"", "</a>", true);
            return html.GetMultipleBetween("href=\"", endTag);
        }*/

        /*public static string GetLinkLike(this string html, string value, bool keepLinkName = false)
        {
            string endTag = keepLinkName ? "<" : "\"";
            var step1 = html.GetBetween("href=\"", value, true);
            return html.GetBetween("href=\"", value, true).GetBetween("href=\"").Remove("\">");
        }*/
    }
}
