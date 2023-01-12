// <copyright file HtmlHelper.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>
using System;
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
        /// Checks the <paramref name="html"/> and tries to return the first link that is in between the <b><![CDATA[href=""]]></b> and <b><![CDATA[href='']]></b>.
        /// </summary>
        /// <param name="html">Html string with the link inside of it.</param>
        /// <returns>The first link found in between the <b><![CDATA[href=""]]></b> and <b><![CDATA[href='']]></b>. If the link is not found, returns a <see cref="string.Empty"/>.</returns>
        public static string GetHrefLink(this string html)
        {
            var value = html.GetBetween("href=\"", "\"");

            if (value.IsNotEmpty())
            {
                return value;
            }

            if (value.IsEmpty() || !value.OrContains(StringComparison.OrdinalIgnoreCase, "http", "https", "www"))
            {
                value = html.GetBetween("href='", "'");
            }

            return value;
        }

        /// <summary>
        /// Checks the <paramref name="html"/> and tries to return multiple links that are in between the <b><![CDATA[href=""]]></b> and <b><![CDATA[href='']]></b>.
        /// </summary>
        /// <param name="html">Html string with the links inside of it.</param>
        /// <returns>The multiple links that are between the <b><![CDATA[href=""]]></b> and <b><![CDATA[href='']]></b>. If no links are found, returns an empty <b><![CDATA[List<string>]]></b>.</returns>
        public static List<string> GetMultipleHrefLinks(this string html)
        {
            var value = html.GetMultipleBetween("href=\"", "\"");
            value.AddRange(html.GetMultipleBetween("href='", "'"));
            return value;
        }

        /// <summary>
        /// Checks the <paramref name="html"/> and tries to return the first table that is in between the <b><![CDATA[<table></table>]]></b>.
        /// </summary>
        /// <param name="html">Html string with the table inside of it.</param>
        /// <returns>The first table found in between the <b><![CDATA[<table></table>]]></b>. If the table is not found, returns a <see cref="string.Empty"/>.</returns>
        public static string GetTable(this string html)
        {
            return html.GetBetween("<table", "</table>", true);
        }

        /// <summary>
        /// Checks the <paramref name="html"/> and tries to return multiple tables that are in between the <b><![CDATA[<table></table>]]></b>.
        /// </summary>
        /// <param name="html">Html string with the links inside of it.</param>
        /// <returns>The multiple tables that are between the <b><![CDATA[<table></table>]]></b>. If no tables are found, returns an empty <b><![CDATA[List<string>]]></b>.</returns>
        public static List<string> GetMultipleTables(this string html)
        {
            return html.GetMultipleBetween("<table", "</table>", true);
        }

        /// <summary>
        /// Checks the <paramref name="htmlTable"/> and tries to return the rows that are in between the <b><![CDATA[<table></table>]]></b>.
        /// </summary>
        /// <param name="htmlTable">The content must contain only <b>one table</b> and nothing else.</param>
        /// <returns>The multiple rows that are between the <b><![CDATA[<tr></tr>]]></b>. If no rows are found, returns an empty <b><![CDATA[List<string>]]></b>.</returns>
        public static List<string> GetRowsFromTable(this string htmlTable)
        {
            return htmlTable.GetMultipleBetween("<tr", "</tr>", true);
        }

        /// <summary>
        /// Checks the <paramref name="htmlTable"/> and tries to return the data that are in between the <b><![CDATA[<tr></tr>]]></b>.
        /// </summary>
        /// <param name="htmlTable">The content must contain only <b>one table</b> and nothing else.</param>
        /// <returns>The multiple data that is between the <b><![CDATA[<tr></tr>]]></b>. If no data is found, returns an empty <b><![CDATA[List<string>]]></b>.</returns>
        public static List<string> GetDataFromRows(this string htmlTable)
        {
            return htmlTable.GetMultipleBetween("<td", "</td>", true);
        }

        /// <summary>
        /// Checks the <paramref name="htmlTables"/> and tries to return all the data that are in multiple rows of multiple tables.
        /// </summary>
        /// <param name="htmlTables">The content can contain <b>multiple tables</b> and nothing else.</param>
        /// <returns>Multiple data that is between the <b><![CDATA[<tr></tr>]]></b> of multiple tables. If no data is found, returns an empty <b><![CDATA[List<string>]]></b>.</returns>
        public static List<string> GetMultipleDataFromTables(this List<string> htmlTables)
        {
            return htmlTables.GetMultipleBetweenIndexes("<td", "</td>", true);
        }
    }
}
