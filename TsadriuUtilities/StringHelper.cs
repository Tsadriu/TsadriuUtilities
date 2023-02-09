// <copyright file StringHelper.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TsadriuUtilities.Enums.BoolHelper;
using TsadriuUtilities.Enums.StringHelper;

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
            if (text.IsEmpty())
            {
                return string.Empty;
            }
            
            string copyOfText = text;

            int startIndex = -1;

            if (start != null && start.Length > 0)
            {
                startIndex = text.IndexOf(start, StringComparison.OrdinalIgnoreCase);
            }

            if (startIndex > -1)
            {
                startIndex += startEndIncluded ? 0 : start.Length;
                copyOfText = text.Substring(startIndex + (startEndIncluded ? start.Length : 0));
            }

            int endIndex = -1;

            if (end != null && end.Length > 0)
            {
                endIndex = (text.Length - copyOfText.Length);

                int currentEndIndex = copyOfText.IndexOf(end, StringComparison.OrdinalIgnoreCase);

                switch (currentEndIndex)
                {
                    case > -1:
                        endIndex += copyOfText.IndexOf(end, StringComparison.OrdinalIgnoreCase);
                        break;
                    case -1:
                        endIndex = -1;
                        break;
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
                    Console.WriteLine($"Parameters {nameof(start)} and {nameof(end)} cannot be empty. Either use method GetBetween() or provide the necessary information to use this method.");
                }

                return list;
            }

            var elements = new List<string>();
            int startIndex = 0;

            while (startIndex > -1)
            {
                startIndex = text.IndexOf(start, startIndex);
                if (startIndex == -1)
                {
                    break;
                }

                if (!startEndIncluded)
                {
                    startIndex += start.Length;
                }
                int endIndex = text.IndexOf(end, startIndex);
                if (endIndex == -1)
                {
                    break;
                }

                if (startEndIncluded)
                {
                    endIndex += end.Length;
                }

                elements.Add(text.Substring(startIndex, endIndex - startIndex));
                startIndex = endIndex;
            }

            return elements;
        }

        /// <summary>
        /// Searches through the <paramref name="text"/>, using the <paramref name="start"/> as the start tag and then searches the <paramref name="text"/> <b>backwards</b> until the <paramref name="end"/> tag is found.
        /// </summary>
        /// <param name="text">Text to search through.</param>
        /// <param name="start">From where the text starts.</param>
        /// <param name="end">From where the text ends.</param>
        /// <param name="startEndIncluded">If enabled, it will return the content with the <paramref name="start"/> and <paramref name="end"/> included.</param>
        /// <returns>The first instance found between <paramref name="start"/> and <paramref name="end"/>. If both <paramref name="start"/> and <paramref name="end"/> are not found, returns a <see cref="string.Empty"/>.</returns>
        public static string GetBetweenReverse(this string text, string start = null, string end = null, bool startEndIncluded = false)
        {
            if (text.IsEmpty())
            {
                return string.Empty;
            }

            start ??= string.Empty;
            end ??= string.Empty;
            
            bool hasFoundStart = true;
            bool hasFoundEnd = true;
            
            int startIndex = text.LastIndexOf(start);

            if (startIndex == -1)
            {
                start = string.Empty;
                startIndex = text.Length;
                hasFoundStart = false;
            }
            else
            {
                // This insures that the start character is also selected
                startIndex++;
            }

            string copyOfText = text.Substring(0, startIndex);

            int endIndex = copyOfText.LastIndexOf(end);

            if (endIndex == -1)
            {
                end = string.Empty;
                endIndex = 0;
                hasFoundEnd = false;
            }
            else
            {
                // This insures that the end character is also selected
                 endIndex++;
            }

            if (!hasFoundStart && !hasFoundEnd)
            {
                return string.Empty;
            }
            
            if (startEndIncluded)
            {
                return end + copyOfText.Substring(endIndex) + start;
            }

            return copyOfText.Substring(endIndex);
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
            return values.All(value => text.Contains(value, stringComparison));
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
            return values.Any(value => text.Contains(value, stringComparison));

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
            if (!IsNotEmpty(value))
            {
                return value;
            }

            if (index >= value.Length)
            {
                return value;
            }

            char[] charArray = value.ToCharArray();

            char charToModify = char.ToUpper(charArray[index]);

            charArray[index] = charToModify;

            return string.Concat(charArray);
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
            foreach (string valueToRemove in valuesToRemove)
            {
                value = value.Replace(valueToRemove, string.Empty);
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
            foreach (string tag in tags)
            {
                tag.Remove("<", ">", "/");
                string[] tagsToRemove = { $"<{tag}>", $"</{tag}>", $"<{tag}/>" };
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
        /// <param name="value">The value to be split.</param>
        /// <param name="separator">The separator.</param>
        /// <param name="keepSeparator">Setting it to true, the <paramref name="separator"/> will be included in the result of the split.</param>
        /// <returns>A list of <see cref="string"/> that contains <paramref name="value"/> split by the <paramref name="separator"/>.</returns>
        public static List<string> Split(this string value, string separator, bool keepSeparator = false)
        {
            List<string> splitValue = value.Split(separator).ToList();

            if (!keepSeparator)
            {
                return splitValue;
            }

            var stringBuilder = new StringBuilder();

            for (int i = 1; i < splitValue.Count; i++)
            {
                splitValue[i] = stringBuilder.Append(separator + splitValue[i]).ToString();
                stringBuilder.Clear();
            }

            return splitValue;
        }

        /// <summary>
        /// Splits the <paramref name="value"/> based on the <paramref name="splitType"/>.
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <param name="splitType">The split type.</param>
        /// <param name="keepSeparator">° <b>True</b> - Keeps the <paramref name="separator"/> after splitting.<br/>
        /// ° <b>False</b> - Removes the <paramref name="separator"/> after splitting.</param>
        /// <param name="separator">The separator to use to split the <paramref name="value"/>. This is only used when <paramref name="splitType"/> is <see cref="SplitType.UserDefined"/>.</param>
        /// <returns>A list of <see cref="string"/> that contains <paramref name="value"/> split by the <paramref name="splitType"/>.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static List<string> SplitBy(this string value, SplitType splitType, bool keepSeparator = false, string separator = null)
        {
            return splitType switch
            {
                SplitType.CarriageReturn => value.Split("\r", keepSeparator),
                SplitType.Dash => value.Split("-", keepSeparator),
                SplitType.DoubleQuote => value.Split("\"", keepSeparator),
                SplitType.EnvironmentNewLine => value.Split(Environment.NewLine, keepSeparator),
                SplitType.Equal => value.Split("=", keepSeparator),
                SplitType.NewLine => value.Split("\n", keepSeparator),
                SplitType.SingleQuote => value.Split("'", keepSeparator),
                SplitType.Space => value.Split(" ", keepSeparator),
                SplitType.Underscore => value.Split("_", keepSeparator),
                SplitType.UserDefined => value.Split(separator, keepSeparator),
                _ => throw new NotImplementedException($"Type '{splitType}' has not been implemented."),
            };

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

            foreach (char character in charArray)
            {
                if (char.IsUpper(character))
                {
                    stringBuilder.Append(separator);
                }

                stringBuilder.Append(character);
            }

            return stringBuilder.ToString();
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

            foreach (char character in charArray)
            {
                if (char.IsLower(character))
                {
                    stringBuilder.Append(separator);
                }

                stringBuilder.Append(character);
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
