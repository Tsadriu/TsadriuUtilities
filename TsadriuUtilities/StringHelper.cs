// <copyright file StringHelper.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Linq;

namespace TsadriuUtilities
{
    /// <summary>
    /// A class that helps on dealing with <see cref="string"/>.
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Searches through the <paramref name="text"/>, returning the content between the <paramref name="startTag"/> and <paramref name="endTag"/>. Use <paramref name="tagsIncluded"/> if you want to include them.
        /// </summary>
        /// <param name="text">Text to search though.</param>
        /// <param name="startTag">The start tag.</param>
        /// <param name="endTag">The end tag.</param>
        /// <param name="tagsIncluded">If enabled, it will return a string with the <paramref name="startTag"/> and <paramref name="endTag"/> included.</param>
        /// <returns>Returns string.Empty if nothing is found.</returns>
        public static string GetTagValue(string text, string startTag, string endTag = null, bool tagsIncluded = false)
        {
            if (IsEmpty(text))
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
                startTagIndex += tagsIncluded ? -startTag.Length : 0;

                if (string.IsNullOrEmpty(endTag))
                {
                    result = text.Substring(startTagIndex, textLength - startTagIndex);
                }
                else
                {
                    var endTagIndex = text.IndexOf(endTag, startTagIndex, StringComparison.OrdinalIgnoreCase);
                    endTagIndex += tagsIncluded ? endTag.Length : 0;

                    if (endTagIndex > -1)
                    {
                        result = text.Substring(startTagIndex, endTagIndex - startTagIndex);
                    }
                    else
                    {
                        result = text.Substring(startTagIndex, textLength - startTagIndex);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Searches through the <paramref name="text"/>, returning the content between the <paramref name="startTag"/> and <paramref name="endTag"/>. Use <paramref name="tagsIncluded"/> if you want to include them.
        /// </summary>
        /// <param name="text">Text to search though.</param>
        /// <param name="startTag">The start tag.</param>
        /// <param name="endTag">The end tag.</param>
        /// <param name="tagsIncluded">If enabled, it will return a string with the <paramref name="startTag"/> and <paramref name="endTag"/> included.</param>
        /// <returns>Returns an empty List of <see cref="string"/> if nothing is found or parameters <paramref name="text"/>, <paramref name="startTag"/> or <paramref name="endTag"/> are empty.</returns>
        public static List<string> GetTagValues(string text, string startTag, string endTag, bool tagsIncluded = false)
        {
            if (IsEmpty(text) || IsEmpty(startTag) || IsEmpty(endTag))
            {
                if (IsEmpty(startTag) || IsEmpty(endTag))
                {
                    Console.WriteLine("Parameters startTag and endTag cannot be empty. Either use GetTagValue or provide the necessary information to use this method.");
                }

                return new List<string>();
            }

            var list = new List<string>();
            var modifiedText = text;

            while(modifiedText.Contains(startTag))
            {
                var res = GetTagValue(modifiedText, startTag, endTag, tagsIncluded);
                modifiedText = GetTagValue(modifiedText, res, string.Empty, false);
                list.Add(res);
            }

            return list;
        }

        /// <summary>
        /// Checks if the <paramref name="value"/> is null, <see cref="string.Empty"/> or a white space ("", \n, \r, ...).
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>Returns true if the <paramref name="value"/> is empty. Returns false if not.</returns>
        public static bool IsEmpty(string value)
        {
            return string.IsNullOrWhiteSpace(value);
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

        /// <summary>
        /// Returns a <see cref="string"/> where all occasions of <paramref name="valuesToRemove"/> have been removed from the <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value to change.</param>
        /// <param name="valuesToRemove">The values to remove from <paramref name="value"/>.</param>
        /// <returns>Returns a <see cref="string"/> where all occasions of <paramref name="valuesToRemove"/> have been removed from the <paramref name="value"/>.</returns>
        public static string Remove(string value, params string[] valuesToRemove)
        {
            for (int i = 0; i < valuesToRemove.Length; i++)
            {
                value = value.Replace(valuesToRemove[i], string.Empty);
            }

            return value;
        }

        /// <summary>
        /// Returns the count of <paramref name="valueToCount"/> present in <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="valueToCount">The value to be counted in <paramref name="value"/>.</param>
        /// <returns>Returns the count of <paramref name="valueToCount"/> present in <paramref name="value"/>.</returns>
        public static int CharCount(string value, string valueToCount)
        {
            return value.Split(valueToCount).Length - 1;
        }
    }
}