// <copyright file StrHelper.cs of solution TsadriuUtilities of developer Tsadriu>
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

        /// <summary>
        /// Checks if the <paramref name="value"/> is null, <see cref="string.Empty"/> or a white space ("").
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>Returns true if the <paramref name="value"/> is empty. Returns false if not.</returns>
        public static bool IsEmpty(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if <paramref name="value"/> contains any kind of character.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>Returns true if the <paramref name="value"/> is not empty. Returns false if not.</returns>
        public static bool IsNotEmpty(string value)
        {
            return !IsEmpty(value);
        }

        /// <summary>
        /// Changes a lower-case letter to be upper-case. If <paramref name="index"/> is not passed, it will change the first letter of <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value to change.</param>
        /// <param name="index">The index of the letter to be changed. If <paramref name="index"/> is not passed, it will change the first letter of <paramref name="value"/>.</param>
        /// <returns>Returns the new string with the changed value. Returns the same <paramref name="value"/> if it was empty or <paramref name="index"/> was invalid.</returns>
        public static string LetterUpperCase(string value, int index = 0)
        {
            if (IsNotEmpty(value))
            {
                if (index < value.Length)
                {
                    char[] charArray = value.ToCharArray();

                    char charToModify = char.ToUpper(charArray[index]);

                    charArray[index] = charToModify;

                    return string.Concat(charArray);
                }
            }

            return value;
        }

        /// <summary>
        /// Changes a upper-case letter to be lower-case. If <paramref name="index"/> is not passed, it will change the first letter of <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value to change.</param>
        /// <param name="index">The index of the letter to be changed. If <paramref name="index"/> is not passed, it will change the first letter of <paramref name="value"/>.</param>
        /// <returns>Returns the new string with the changed value. Returns the same <paramref name="value"/> if it was empty or <paramref name="index"/> was invalid.</returns>
        public static string LetterLowerCase(string value, int index = 0)
        {
            if (IsNotEmpty(value))
            {
                if (index < value.Length)
                {
                    char[] charArray = value.ToCharArray();

                    char charToModify = char.ToLower(charArray[index]);

                    charArray[index] = charToModify;

                    return string.Concat(charArray);
                }
            }

            return value;
        }
    }
}