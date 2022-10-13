// <copyright file StringHelper.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TsadriuUtilities
{
    /// <summary>
    /// A class that helps on dealing with <see cref="string"/>.
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Searches through the <paramref name="text"/>, returning the first instance found between <paramref name="start"/> and <paramref name="end"/>.
        /// <br>Use <paramref name="startEndIncluded"/> if you want to include <paramref name="start"/> and <paramref name="end"/> in the returning <see cref="string"/>.</br>
        /// </summary>
        /// <param name="text">Text to search through.</param>
        /// <param name="start">The start tag.</param>
        /// <param name="end">The end tag.</param>
        /// <param name="startEndIncluded">If enabled, it will return a <see cref="string"/> with the <paramref name="start"/> and <paramref name="end"/> included in it.</param>
        /// <returns>Returns <see cref="string.Empty"/> if nothing is found.</returns>
        public static string GetBetween(this string text, string start = null, string end = null, bool startEndIncluded = false)
        {
            var copyOfText = text;

            if (copyOfText.IsEmpty())
            {
                return string.Empty;
            }

            var startIndex = -1;

            if (start != null && start.Length > 0)
            {
                startIndex = text.IndexOf(start, StringComparison.OrdinalIgnoreCase);
            }

            if (startIndex > -1)
            {
                startIndex += startEndIncluded ? 0 : start.Length;
                copyOfText = text.Substring(startIndex + (startEndIncluded ? start.Length : 0));
            }

            var endIndex = -1;

            if (end != null && end.Length > 0)
            {
                endIndex = (text.Length - copyOfText.Length);

                var currentEndIndex = copyOfText.IndexOf(end, StringComparison.OrdinalIgnoreCase);

                if (currentEndIndex > -1)
                {
                    endIndex += copyOfText.IndexOf(end, StringComparison.OrdinalIgnoreCase);
                }
                else if (currentEndIndex == -1)
                {
                    endIndex = -1;
                }
            }

            if (endIndex > -1)
            {
                endIndex += startEndIncluded ? end.Length : 0;
            }

            if (endIndex > -1 && startIndex > -1)
            {
                return text.Substring(startIndex, endIndex - startIndex);
            }

            if (startIndex > -1 && end.IsEmpty())
            {
                return text.Substring(startIndex, text.Length - startIndex);
            }

            if (endIndex > -1 && start.IsEmpty())
            {
                return text.Substring(0, endIndex);
            }

            return string.Empty;
        }

        /// <summary>
        /// Searches through the <paramref name="text"/>, returning multiple instances found between <paramref name="start"/> and <paramref name="end"/>. Use <paramref name="startEndIncluded"/> if you want to include <paramref name="start"/> and <paramref name="end"/> in the returning List of <see cref="string"/>.
        /// </summary>
        /// <param name="text">Text to search through.</param>
        /// <param name="start">From where the text begins.</param>
        /// <param name="end">Until where the text stops.</param>
        /// <param name="startEndIncluded">If enabled, it will return the content with the <paramref name="start"/> and <paramref name="end"/> included.</param>
        /// <returns>Multiple instances found between <paramref name="start"/> and <paramref name="end"/>. If nothing is found, or parameters <paramref name="text"/>, <paramref name="start"/> or <paramref name="end"/> are empty, returns an empty List of <see cref="string"/> .</returns>
        public static List<string> GetMultipleBetween(this string text, string start, string end, bool startEndIncluded = false)
        {
            var list = new List<string>();

            if (AreEmpty(text, start, end))
            {
                if (AreEmpty(start, end))
                {
                    Console.WriteLine($"Parameters {nameof(start)} and {nameof(end)} cannot be empty. Either use method GetBetwee() or provide the necessary information to use this method.");
                }

                return list;
            }

            var modifiedText = text;

            while (modifiedText.Contains(start, StringComparison.OrdinalIgnoreCase))
            {
                var result = GetBetween(modifiedText, start, end, startEndIncluded);
                if (IsEmpty(result))
                {
                    break;
                }
                modifiedText = GetBetween(modifiedText, result, string.Empty, false);
                list.Add(result);
            }

            return list;
        }

        /// <summary>
        /// <b>This method is unstable and unfinished. Using it will throw an <see cref="NotImplementedException"/>.</b>
        /// Searches through the <paramref name="text"/>, using the <paramref name="end"/> as the end tag and then searches the <paramref name="text"/> <b>backwards</b> until the <paramref name="start"/> tag is found.
        /// </summary>
        /// <param name="text">Text to search through.</param>
        /// <param name="end">From where the text ends.</param>
        /// <param name="start">From where the text starts.</param>
        /// <param name="startEndIncluded">If enabled, it will return the content with the <paramref name="end"/> and <paramref name="start"/> included.</param>
        /// <returns>The first instance found between <paramref name="end"/> and <paramref name="start"/>. If both <paramref name="end"/> and <paramref name="start"/> are not found, returns a <see cref="string.Empty"/>.</returns>
        public static string GetBetweenReverse(this string text, string end = null, string start = null, bool startEndIncluded = false)
        {
            throw new NotImplementedException("This method has not been implemented yet.");
            
            if (text.IsEmpty())
            {
                return string.Empty;
            }

            var copyOfText = text;

            var endIndex = copyOfText.LastIndexOf(end);

            if (endIndex > -1)
            {
                copyOfText = copyOfText.Substring(0, endIndex);
            }

            var startIndex = copyOfText.LastIndexOf(start);

            if (startIndex > -1)
            {
                copyOfText = copyOfText.Substring(startIndex, endIndex - startIndex);
                var x = copyOfText.Substring(startIndex, copyOfText.Length - startIndex);
            }

            if (endIndex > -1 && startIndex > -1)
            {
                return copyOfText;
            }

            return string.Empty;
        }

        /// <summary>
        /// Checks a <see cref="string"/> if it has all instances of <paramref name="values"/>.
        /// </summary>
        /// <param name="text">Current <see cref="string"/>.</param>
        /// <param name="stringComparison">The type of <see cref="StringComparison"/>.</param>
        /// <param name="values">The <paramref name="values"/> to search in the <paramref name="text"/>.</param>
        /// <returns>True if all <paramref name="values"/> are present in the <paramref name="text"/>. Otherwise returns false.</returns>
        public static bool AndContains(this string text, StringComparison stringComparison, params string[] values)
        {
            foreach (var value in values)
            {
                if(!text.Contains(value, stringComparison))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks a <see cref="string"/> if it has at least one instance of <paramref name="values"/>.
        /// </summary>
        /// <param name="text">Current <see cref="string"/>.</param>
        /// <param name="stringComparison">The type of <see cref="StringComparison"/>.</param>
        /// <param name="values">The <paramref name="values"/> to search in the <paramref name="text"/>.</param>
        /// <returns>True if at least one instance <paramref name="values"/> is present in the <paramref name="text"/>. Otherwise returns false.</returns>
        public static bool OrContains(this string text, StringComparison stringComparison, params string[] values)
        {
            foreach (var value in values)
            {
                if (text.Contains(value, stringComparison))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if the <paramref name="value"/> is null, <see cref="string.Empty"/> or a white space ("", \n, \r, ...).
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>True if the <paramref name="value"/> is empty.</returns>
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Checks if <paramref name="value"/> contains any kind of character.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>True if the <paramref name="value"/> is not empty.</returns>
        public static bool IsNotEmpty(this string value)
        {
            return !IsEmpty(value);
        }

        /// <summary>
        /// Iterates through <paramref name="values"/> and checks them if they are null, <see cref="string.Empty"/> or white space ("", \n, \r, ...).
        /// </summary>
        /// <param name="values">The values to check.</param>
        /// <returns>Returns true if all instances of <paramref name="values"/> are null, <see cref="string.Empty"/> or white space ("", \n, \r, ...). Returns false if even one of them is <b>not</b> empty.</returns>
        public static bool AreEmpty(params string[] values)
        {
            foreach (var value in values)
            {
                if (IsNotEmpty(value))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if all instances of <paramref name="values"/> are not empty, returning true if all of them are not empty.
        /// </summary>
        /// <param name="values">The values to check.</param>
        /// <returns>Returns true if all instances of <paramref name="values"/> are not empty. Returns false if even one of them is empty.</returns>
        public static bool AreNotEmpty(params string[] values)
        {
            foreach (var value in values)
            {
                if (IsEmpty(value))
                {
                    return false;
                }
            }

            return true;
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
        /// Iterates through <paramref name="valuesToRemove"/> and removes them from <paramref name="value"/> (if they are present).
        /// </summary>
        /// <param name="value">The value to change.</param>
        /// <param name="valuesToRemove">The values to remove from <paramref name="value"/>.</param>
        /// <returns>A <see cref="string"/> where all occasions of <paramref name="valuesToRemove"/> have been removed from the <paramref name="value"/>.</returns>
        public static string Remove(this string value, params string[] valuesToRemove)
        {
            for (int i = 0; i < valuesToRemove.Length; i++)
            {
                value = value.Replace(valuesToRemove[i], string.Empty);
            }

            return value;
        }

        /// <summary>
        /// Counts the number of <paramref name="valueToCount"/> present in <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value to be checked.</param>
        /// <param name="valueToCount">The value to be counted in <paramref name="value"/>.</param>
        /// <returns>Returns the count of <paramref name="valueToCount"/> present in <paramref name="value"/>.</returns>
        public static int CharCount(this string value, string valueToCount)
        {
            return value.Split(valueToCount).Length - 1;
        }

        /// <summary>
        /// Iterates through <paramref name="tags"/> and will remove them from the <paramref name="value"/>. <paramref name="tags"/> will only be removed
        /// if they correspond to <![CDATA[<]]><paramref name="tags"/><![CDATA[>]]>, <![CDATA[</]]><paramref name="tags"/><![CDATA[>]]> or <![CDATA[<]]><paramref name="tags"/><![CDATA[/>]]>.
        /// </summary>
        /// <param name="value">The value where <paramref name="tags"/> will be removed.</param>
        /// <param name="tags">The tags to remove from <paramref name="value"/>.</param>
        /// Returns a <see cref="string"/> where all instances of <paramref name="tags"/> are removed.
        public static string RemoveTags(this string value, params string[] tags)
        {
            foreach (var tag in tags)
            {
                tag.Remove("<", ">", "/");
                var tagsToRemove = new string[] { $"<{tag}>", $"</{tag}>", $"<{tag}/>" };
                value = value.Remove(tagsToRemove);
            }

            return value;
        }

        /// <summary>
        /// Reverses a string.
        /// </summary>
        /// <param name="value"><see cref="string"/> to be reversed.</param>
        /// <returns>Reversed <see cref="string"/>. If <paramref name="value"/> is null or <see cref="string.Empty"/>, it will return <see cref="string.Empty"/>.</returns>
        public static string Reverse(this string value)
        {
            if (value.IsEmpty())
            {
                return string.Empty;
            }

            char[] charArray = value.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        /// <summary>
        /// Splits the <paramref name="value"/> based on the <paramref name="separator"/>.
        /// </summary>
        /// <param name="value">The value to be splitted.</param>
        /// <param name="separator">The separator.</param>
        /// <param name="keepSeparator">Setting it to true, the <paramref name="separator"/> will be included in the result of the split.</param>
        /// <returns>A list of <see cref="string"/> that contains <paramref name="value"/> splitted by the <paramref name="separator"/>.</returns>
        public static List<string> Split(this string value, string separator, bool keepSeparator = false)
        {
            var splittedValue = value.Split(separator).ToList();

            if (keepSeparator)
            {
                var stringBuilder = new StringBuilder();

                for (int i = 1; i < splittedValue.Count; i++)
                {
                    splittedValue[i] = stringBuilder.Append(separator + splittedValue[i]).ToString();
                    stringBuilder.Clear();
                }
            }

            return splittedValue;
        }

        /// <summary>
        /// Separates the <paramref name="value"/> by upper-case characters.
        /// </summary>
        /// <param name="value">The value to be splitted.</param>
        /// <param name="separator">The separator to use when a character is separated.</param>
        /// <returns>The <paramref name="value"/> splitted by upper-case characters.</returns>
        [Obsolete("This method has the wrong name. Please use the method 'SeparateByUpperCase()'.", true)]
        public static string SplitByUpperCase(this string value, string separator = " ")
        {
            return value.SeparateByUpperCase(separator);
        }

        /// <summary>
        /// Separates the <paramref name="value"/> by upper-case characters.
        /// </summary>
        /// <param name="value">The value to be separated.</param>
        /// <param name="separator">The separator to use when a character is separated.</param>
        /// <returns>The <paramref name="value"/> separated by upper-case characters.</returns>
        public static string SeparateByUpperCase(this string value, string separator = " ")
        {
            var charArray = value.ToCharArray();
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < charArray.Length; i++)
            {
                if (char.IsUpper(charArray[i]))
                {
                    stringBuilder.Append(separator);
                }

                stringBuilder.Append(charArray[i]);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Separates the <paramref name="value"/> by lower-case characters.
        /// </summary>
        /// <param name="value">The value to be separated.</param>
        /// <param name="separator">The separator to use when a character is separated.</param>
        /// <returns>The <paramref name="value"/> separated by lower-case characters.</returns>
        [Obsolete("This method has the wrong name. Please use the method 'SeparateByLowerCase()'.", true)]
        public static string SplitByLowerCase(this string value, string separator = " ")
        {
            return value.SeparateByLowerCase(separator);
        }

        /// <summary>
        /// Separates the <paramref name="value"/> by upper-case characters.
        /// </summary>
        /// <param name="value">The value to be separated.</param>
        /// <param name="separator">The separator to use when a character is separated.</param>
        /// <returns>The <paramref name="value"/> separated by upper-case characters.</returns>
        public static string SeparateByLowerCase(this string value, string separator = " ")
        {
            var charArray = value.ToCharArray();
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < charArray.Length; i++)
            {
                if (char.IsLower(charArray[i]))
                {
                    stringBuilder.Append(separator);
                }

                stringBuilder.Append(charArray[i]);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Reads the <paramref name="value"/>, returning the present upper-case letters.
        /// </summary>
        /// <param name="value">The value to get the upper-case letters.</param>
        /// <param name="separator">The separator to use when appending the upper-case letters together.</param>
        /// <returns>The upper-case letters present in the <paramref name="value"/> in a <see cref="string"/>.</returns>
        public static string GetUpperCaseLetters(this string value, string separator = null)
        {
            var charArray = value.ToCharArray();
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < charArray.Length; i++)
            {
                if (char.IsUpper(charArray[i]))
                {
                    stringBuilder.Append(charArray[i]);

                    if (i + 1 < charArray.Length && separator != null)
                    {
                        stringBuilder.Append(separator);
                    }
                }
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Reads the <paramref name="value"/>, returning the present lower-case letters.
        /// </summary>
        /// <param name="value">The value to get the lower-case letters.</param>
        /// <param name="separator">The separator to use when appending the lower-case letters together.</param>
        /// <returns>The lower-case letters present in the <paramref name="value"/> in a <see cref="string"/>.</returns>

        public static string GetLowerCaseLetters(this string value, string separator = null)
        {
            var charArray = value.ToCharArray();
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < charArray.Length; i++)
            {
                if (char.IsLower(charArray[i]))
                {
                    stringBuilder.Append(charArray[i]);


                    if (i + 1 < charArray.Length && separator != null)
                    {
                        stringBuilder.Append(separator);
                    }
                }
            }

            return stringBuilder.ToString();
        }
    }
}