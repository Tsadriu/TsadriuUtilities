// <copyright file Main.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>
using System;

namespace TsadriuUtilities
{
    /// <summary>
    /// A class that helps on dealing with strings.
    /// </summary>
    public static class StrHelper
    {
        /// <summary>
        /// Searches through an input text returning the value between the start tag and end tag.
        /// </summary>
        /// <param name="text">Text to search though.</param>
        /// <param name="startTag">The start tag.</param>
        /// <param name="endTag">The end tag.</param>
        /// <returns>Returns string.empty if nothing is found.</returns>
        public static string GetTagValue(string text, string startTag, string endTag = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            var textLength = text.Length;
            var result = string.Empty;

            // Find the index of the first tag.
            var startTagIndex = text.IndexOf(startTag, StringComparison.OrdinalIgnoreCase);

            // If startTag is bigger than -1 it means we found it.
            if (startTagIndex > -1)
            {
                startTagIndex += startTag.Length;

                if (string.IsNullOrEmpty(endTag))
                {
                    result = text.Substring(startTagIndex, textLength - startTagIndex);
                }
                else
                {
                    var endTagIndex = text.IndexOf(endTag, startTagIndex, StringComparison.OrdinalIgnoreCase);

                    result = endTagIndex > -1 ? text.Substring(startTagIndex, endTagIndex - startTagIndex) : text.Substring(startTagIndex, textLength - startTagIndex);
                }
            }

            return result;
        }
    }
}