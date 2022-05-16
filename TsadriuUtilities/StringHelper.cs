// <copyright file StringHelper.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;

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
        public static string GetTagValue(this string text, string startTag, string endTag = null, bool tagsIncluded = false)
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

                if (startTagIndex > -1)
                {
                    startTagIndex += tagsIncluded ? -startTag.Length : 0;
                }

                if (string.IsNullOrEmpty(endTag))
                {
                    result = text.Substring(startTagIndex, textLength - startTagIndex);
                }
                else
                {
                    var endTagIndex = text.IndexOf(endTag, startTagIndex, StringComparison.OrdinalIgnoreCase);

                    if (endTagIndex > -1)
                    {
                        endTagIndex += tagsIncluded ? endTag.Length : 0;
                    }

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
        public static List<string> GetTagValues(this string text, string startTag, string endTag, bool tagsIncluded = false)
        {
            var list = new List<string>();

            if (AreEmpty(text, startTag, endTag))
            {
                if (AreEmpty(startTag, endTag))
                {
                    Console.WriteLine("Parameters startTag and endTag cannot be empty. Either use GetTagValue or provide the necessary information to use this method.");
                }

                return list;
            }

            var modifiedText = text;

            while (modifiedText.Contains(startTag))
            {
                var result = GetTagValue(modifiedText, startTag, endTag, tagsIncluded);
                modifiedText = GetTagValue(modifiedText, result, string.Empty, false);
                list.Add(result);
            }

            return list;
        }

        /// <summary>
        /// Checks if the <paramref name="value"/> is null, <see cref="string.Empty"/> or a white space ("", \n, \r, ...).
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>Returns true if the <paramref name="value"/> is empty. Returns false if it's not empty.</returns>
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Checks if <paramref name="value"/> contains any kind of character.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>Returns true if the <paramref name="value"/> is not empty. Returns false if it contains any kind of character.</returns>
        public static bool IsNotEmpty(this string value)
        {
            return !IsEmpty(value);
        }

        /// <summary>
        /// Checks if all instances of <paramref name="values"/> are null, <see cref="string.Empty"/> or a white space ("", \n, \r, ...).
        /// </summary>
        /// <param name="values">The values to check.</param>
        /// <returns>Returns true if even one of the instances of <paramref name="values"/> is empty. Returns false if all of them are not empty.</returns>
        public static bool AreEmpty(params string[] values)
        {
            foreach (var value in values)
            {
                if (IsEmpty(value))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if all instances of <paramref name="values"/> are not empty.
        /// </summary>
        /// <param name="values">The values to check.</param>
        /// <returns>Returns true if even one of the instances of <paramref name="values"/> is not empty. Returns false if all of them are empty.</returns>
        public static bool AreNotEmpty(params string[] values)
        {
            return !AreEmpty(values);
        }

        /// <summary>
        /// Changes a lower-case letter to be upper-case. If <paramref name="index"/> is not passed, it will change the first letter of <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value to change.</param>
        /// <param name="index">The index of the letter to be changed. If <paramref name="index"/> is not passed, it will change the first letter of <paramref name="value"/>.</param>
        /// <returns>Returns the new string with the changed value. Returns the same <paramref name="value"/> if it was empty or <paramref name="index"/> was invalid.</returns>
        public static string LetterUpperCase(this string value, int index = 0)
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
        public static string LetterLowerCase(this string value, int index = 0)
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
        public static string Remove(this string value, params string[] valuesToRemove)
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
        public static int CharCount(this string value, string valueToCount)
        {
            return value.Split(valueToCount).Length - 1;
        }
    }
}