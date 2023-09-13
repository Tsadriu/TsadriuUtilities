// Author: Tsadriu
// Date: 13/06/2023

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TsadriuUtilities.Enums;

namespace TsadriuUtilities
{
    /// <summary>
    /// Class that helps on manipulating and managing <b><see cref="string"/></b> types.
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Retrieves the substring between two specified strings within the given text, using the specified string comparison.
        /// </summary>
        /// <param name="text">The text to search within.</param>
        /// <param name="start">The starting string (exclusive) to search for.</param>
        /// <param name="end">The ending string (exclusive) to search for.</param>
        /// <param name="comparison">The string comparison to use when searching for the start and end strings.</param>
        /// <param name="startEndIncluded">Specifies whether the start and end strings should be included in the result.</param>
        /// <returns>
        /// The substring between the start and end strings, or an empty string if the start or end strings are not found.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when both the <paramref name="start"/> and <paramref name="end"/> parameters are null or empty.
        /// </exception>
        public static string GetBetween(this string? text, string? start, string? end, StringComparison comparison, bool startEndIncluded = false)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            bool isStartNull = string.IsNullOrEmpty(start);
            bool isEndNull = string.IsNullOrEmpty(end);

            // If the user does not use valid values (sends null or string.empty), return the entire text back
            if (isStartNull && isEndNull)
            {
                throw new ArgumentNullException(nameof(start), $"Either the {nameof(start)} or {nameof(end)} parameter has to have a value.");
            }

            string copyOfText = text;

            // Just give the indexes -2 in case the start/end params are null/empty
            int startIndex = isStartNull ? 0 : copyOfText.IndexOf(start!, comparison);

            /* If the start tag was given but not found, exit immediately with a string.Empty
             * Example case:
             * text = "Hello this is a beautiful day."
             * text.GetBetween("Good morning", "day") = string.Empty;
             */
            if (startIndex == -1 && !isStartNull)
            {
                return string.Empty;
            }

            // Get the section of the text
            copyOfText = copyOfText.Substring(startIndex + start!.Length);

            int endIndex = isEndNull ? copyOfText.Length : copyOfText.IndexOf(end!, comparison);

            /* If the end tag was given but not found, exit immediately with a string.Empty
             * Example case:
             * text = "Hello this is a beautiful day."
             * text.GetBetween("Hello", "How are you?") = string.Empty;
             */
            if (endIndex == -1 && !isEndNull)
            {
                return string.Empty;
            }

            // Get the section of the text
            copyOfText = copyOfText.Substring(0, endIndex);

            if (!startEndIncluded)
            {
                return copyOfText;
            }

            if (startIndex > 0 && !isStartNull)
            {
                copyOfText = string.Concat(start, copyOfText);
            }

            if (endIndex > 0 && !isEndNull)
            {
                copyOfText = string.Concat(copyOfText, end);
            }

            return copyOfText;
        }

        /// <summary>
        /// Retrieves the substring between two specified strings within the given text, using the specified string comparison.
        /// <b><see cref="StringComparison.OrdinalIgnoreCase"/></b> is used when comparing strings.
        /// </summary>
        /// <param name="text">The text to search within.</param>
        /// <param name="start">The starting string (exclusive) to search for.</param>
        /// <param name="end">The ending string (exclusive) to search for.</param>
        /// <param name="startEndIncluded">Specifies whether the start and end strings should be included in the result.</param>
        /// <returns>
        /// The substring between the start and end strings, or an empty string if the start or end strings are not found.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when both the <paramref name="start"/> and <paramref name="end"/> parameters are null or empty.
        /// </exception>
        public static string GetBetween(this string? text, string? start, string? end, bool startEndIncluded = false) => GetBetween(text, start, end, StringComparison.OrdinalIgnoreCase, startEndIncluded);

        /// <summary>
        /// Searches through the <paramref name="text"/>, using the <paramref name="start"/> as the start tag and then searches the <paramref name="text"/> <b>backwards</b> until the <paramref name="end"/> tag is found.
        /// </summary>
        /// <param name="text">Text to search through.</param>
        /// <param name="start">From where the text starts.</param>
        /// <param name="end">From where the text ends.</param>
        /// <param name="comparison">The string comparison rules to use when searching for the start and end strings.</param>
        /// <param name="startEndIncluded">If enabled, it will return the content with the <paramref name="start"/> and <paramref name="end"/> included.</param>
        /// <returns>The first instance found between <paramref name="start"/> and <paramref name="end"/>. If both <paramref name="start"/> and <paramref name="end"/> are not found, returns a <see cref="string.Empty"/>.</returns>
        public static string GetBetweenReverse(this string text, string? start, string? end, StringComparison comparison, bool startEndIncluded = false)
        {
            if (text.IsEmpty())
            {
                return string.Empty;
            }

            start ??= string.Empty;
            end ??= string.Empty;

            bool hasFoundStart = true;
            bool hasFoundEnd = true;

            int startIndex = text.LastIndexOf(start, comparison);

            // If the starting tag has not been found, we'll start from the end of the text
            if (startIndex == -1)
            {
                startIndex = text.Length;
                hasFoundStart = false;
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
                endIndex += end.Length;
            }

            if (!hasFoundStart && !hasFoundEnd)
            {
                return string.Empty;
            }

            return startEndIncluded ? string.Concat(end, copyOfText.AsSpan(endIndex), start) : copyOfText.Substring(endIndex);
        }

        /// <summary>
        /// Searches through the <paramref name="text"/>, using the <paramref name="start"/> as the start tag and then searches the <paramref name="text"/> <b>backwards</b> until the <paramref name="end"/> tag is found.<br/>
        /// <b><see cref="StringComparison.OrdinalIgnoreCase"/></b> is used when comparing strings.
        /// </summary>
        /// <param name="text">Text to search through.</param>
        /// <param name="start">From where the text starts.</param>
        /// <param name="end">From where the text ends.</param>
        /// <param name="startEndIncluded">If enabled, it will return the content with the <paramref name="start"/> and <paramref name="end"/> included.</param>
        /// <returns>The first instance found between <paramref name="start"/> and <paramref name="end"/>. If both <paramref name="start"/> and <paramref name="end"/> are not found, returns a <see cref="string.Empty"/>.</returns>
        public static string GetBetweenReverse(this string text, string? start, string? end, bool startEndIncluded = false) => text.GetBetweenReverse(start, end, StringComparison.OrdinalIgnoreCase, startEndIncluded);

        /// <summary>
        /// Retrieves multiple substrings from the specified <paramref name="text"/> that are located between the specified <paramref name="start"/> and <paramref name="end"/> strings.
        /// </summary>
        /// <param name="text">The text from which to extract the substrings.</param>
        /// <param name="start">The starting string to search for.</param>
        /// <param name="end">The ending string to search for.</param>
        /// <param name="comparison">The type of string comparison to use.</param>
        /// <param name="startEndIncluded">A flag indicating whether the start and end strings should be included in the extracted substrings.</param>
        /// <returns>An enumerable collection of substrings located between the start and end strings.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="start"/> or <paramref name="end"/> is null or empty.</exception>
        public static List<string> GetManyBetween(this string? text, string? start, string? end, StringComparison comparison, bool startEndIncluded = false)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new List<string>();
            }

            if (string.IsNullOrEmpty(start))
            {
                throw new ArgumentNullException(nameof(start), $"The {nameof(start)} parameter cannot be null or empty!");
            }

            if (string.IsNullOrEmpty(end))
            {
                throw new ArgumentNullException(nameof(end), $"The {nameof(end)} parameter cannot be null or empty!");
            }

            if (!text.Contains(start, comparison) || !text.Contains(end, comparison))
            {
                return new List<string>();
            }

            var result = new List<string>();
            int startLength = start.Length;
            int endLength = end.Length;

            ReadOnlySpan<char> span = text.AsSpan();

            while (true)
            {
                int sliceStart = span.IndexOf(start, comparison);
                if (sliceStart == -1)
                {
                    break;
                }

                int sliceEnd = span.Slice(sliceStart + startLength).IndexOf(end, comparison);
                if (sliceEnd == -1)
                {
                    break;
                }

                ReadOnlySpan<char> slice = span.Slice(startLength + sliceStart, sliceEnd);

                result.Add(startEndIncluded ? $"{start}{slice.ToString()}{end}" : slice.ToString());

                span = span.Slice(sliceEnd + endLength + sliceStart + startLength);
            }

            return result;
        }

        /// <summary>
        /// Retrieves multiple substrings from the specified <paramref name="text"/> that are located between the specified <paramref name="start"/> and <paramref name="end"/> strings.<br/>
        /// <b><see cref="StringComparison.OrdinalIgnoreCase"/></b> is used when comparing strings.
        /// </summary>
        /// <param name="text">The text from which to extract the substrings.</param>
        /// <param name="start">The starting string to search for.</param>
        /// <param name="end">The ending string to search for.</param>
        /// <param name="startEndIncluded">A flag indicating whether the start and end strings should be included in the extracted substrings.</param>
        /// <returns>An enumerable collection of substrings located between the start and end strings.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="start"/> or <paramref name="end"/> is null or empty.</exception>
        public static List<string> GetManyBetween(this string? text, string? start, string? end, bool startEndIncluded = false) => GetManyBetween(text, start, end, StringComparison.OrdinalIgnoreCase, startEndIncluded);

        /// <summary>
        /// Returns a copy of this string converted to lowercase.<br/>
        /// If an <paramref name="index"/> is provided, only the character at that position will be converted to be lowercase.
        /// </summary>
        /// <param name="text">The text to be altered.</param>
        /// <param name="index">The desired character to be altered (default is -1, which means the whole string will be lowercase).</param>
        /// <returns>The lowercase equivalent of the current string.<br/>
        /// If an <paramref name="index"/> is provided, only the character at that position will be converted to be lowercase.</returns>
        public static string ToLower(this string? text, int index = -1) => ToLower(text, index == -1 ? null : new Range(index, index));

        /// <summary>
        /// Returns a copy of this string converted to lowercase in a specified range. Example:<br/>
        /// "Hello WORLD".ToLower(6, 10) -> "Hello world".<br/>
        /// If both <paramref name="startIndex"/> and <paramref name="endIndex"/> are -1, the entire string will be converted to be lowercase.
        /// </summary>
        /// <remarks>If one index is -1, the other one must also be -1.</remarks>
        /// <param name="text">The text to be altered.</param>
        /// <param name="startIndex">The start index of the character to be altered (inclusive).</param>
        /// <param name="endIndex">The end index of the character to be altered (inclusive).</param>
        /// <returns>The lowercase equivalent of the current string based on the specified range.<br/>
        /// If both indexes are -1, the whole string will be converted in lowercase.</returns>
        public static string ToLower(this string? text, int startIndex, int endIndex)
        {
            // If one of the indexes is -1, the other one must be of the same value to avoid unexpected results
            if ((startIndex == -1 && endIndex != -1) || (startIndex != -1 && endIndex == -1))
            {
                throw new Exception("If one of the indexes provided is -1, the other index must also be -1 to avoid unexpected results!");
            }

            return text.ToLower(startIndex == -1 && endIndex == -1 ? null : new Range(startIndex, endIndex));
        }

        /// <summary>
        /// Returns a new string with the characters in the specified range converted to lowercase.<br/>
        /// If the input string is null or empty, the original string is returned.<br/>
        /// If no range is provided, the entire string is converted to lowercase.<br/>
        /// If the provided range is out of range for the input string, the original string is returned.
        /// </summary>
        /// <param name="text">The input string to modify.</param>
        /// <param name="range">An optional range indicating the characters to convert to lowercase. If null, the entire string is converted.<br/>
        /// Both <see cref="Range.Start"/> and <see cref="Range.End"/> numbers are inclusive.</param>
        /// <returns>
        /// A new string with the characters in the specified range converted to lowercase,
        /// or the entire string converted to lowercase if no range is provided,
        /// or the original string if the input string is null, empty, or the provided range is out of range.
        /// </returns>
        public static string ToLower(this string? text, Range? range = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text!;
            }

            if (range is null)
            {
                return text.ToLower();
            }

            var currentRange = (Range)range;

            if (currentRange.Start.Value >= text.Length || currentRange.End.Value >= text.Length)
            {
                return text;
            }

            char[] charArray = text.ToCharArray();
            int charsToAlter = (currentRange.End.Value - currentRange.Start.Value) + 1;

            for (int i = 0; i < charsToAlter; i++)
            {
                charArray[currentRange.Start.Value + i] = char.ToLower(charArray[currentRange.Start.Value + i]);
            }

            var builder = new StringBuilder(text.Length);
            builder.Append(charArray);
            return builder.ToString();
        }

        /// <summary>
        /// Returns a copy of this string converted to uppercase.<br/>
        /// If an <paramref name="index"/> is provided, only the character at that position will be converted to be uppercase.
        /// </summary>
        /// <param name="text">The text to be altered.</param>
        /// <param name="index">The desired character to be altered (default is -1, which means the whole string will be uppercase).</param>
        /// <returns>The uppercase equivalent of the current string.<br/>
        /// If an <paramref name="index"/> is provided, only the character at that position will be converted to be uppercase.</returns>
        public static string ToUpper(this string? text, int index = -1) => ToUpper(text, index == -1 ? null : new Range(index, index));

        /// <summary>
        /// Returns a copy of this string converted to uppercase in a specified range. Example:<br/>
        /// "Hello world".ToUpper(6, 10) -> "Hello WORLD".<br/>
        /// If both <paramref name="startIndex"/> and <paramref name="endIndex"/> are -1, the entire string will be converted to be uppercase.
        /// </summary>
        /// <remarks>If one index is -1, the other one must also be -1.</remarks>
        /// <param name="text">The text to be altered.</param>
        /// <param name="startIndex">The start index of the character to be altered (inclusive).</param>
        /// <param name="endIndex">The end index of the character to be altered (inclusive).</param>
        /// <returns>The uppercase equivalent of the current string based on the specified range.<br/>
        /// If both indexes are -1, the whole string will be converted in uppercase.</returns>
        public static string ToUpper(this string? text, int startIndex, int endIndex)
        {
            // If one of the indexes is -1, the other one must be of the same value to avoid unexpected results
            if ((startIndex == -1 && endIndex != -1) || (startIndex != -1 && endIndex == -1))
            {
                throw new Exception("If one of the indexes provided is -1, the other index must also be -1 to avoid unexpected results!");
            }

            return text.ToUpper(startIndex == -1 && endIndex == -1 ? null : new Range(startIndex, endIndex));
        }

        /// <summary>
        /// Returns a new string with the characters in the specified range converted to uppercase.<br/>
        /// If the input string is null or empty, the original string is returned.<br/>
        /// If no range is provided, the entire string is converted to uppercase.<br/>
        /// If the provided range is out of range for the input string, the original string is returned.
        /// </summary>
        /// <param name="text">The input string to modify.</param>
        /// <param name="range">An optional range indicating the characters to convert to uppercase. If null, the entire string is converted.<br/>
        /// Both <see cref="Range.Start"/> and <see cref="Range.End"/> numbers are inclusive.</param>
        /// <returns>
        /// A new string with the characters in the specified range converted to uppercase,
        /// or the entire string converted to uppercase if no range is provided,
        /// or the original string if the input string is null, empty, or the provided range is out of range.
        /// </returns>
        public static string ToUpper(this string? text, Range? range = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text!;
            }

            if (range is null)
            {
                return text.ToUpper();
            }

            var currentRange = (Range)range;

            if (currentRange.Start.Value >= text.Length || currentRange.End.Value >= text.Length)
            {
                return text;
            }

            char[] charArray = text.ToCharArray();
            int charsToAlter = (currentRange.End.Value - currentRange.Start.Value) + 1;

            for (int i = 0; i < charsToAlter; i++)
            {
                charArray[currentRange.Start.Value + i] = char.ToUpper(charArray[currentRange.Start.Value + i]);
            }

            var builder = new StringBuilder(text.Length);
            builder.Append(charArray);
            return builder.ToString();
        }

        /// <summary>
        /// Retrieves all uppercase letters from the input string.
        /// </summary>
        /// <param name="text">The input string from which to extract uppercase letters.</param>
        /// <returns>A new string containing only the uppercase letters present in the input string.</returns>
        /// <exception cref="Exception">Throw when <paramref name="text"/> is null.</exception>
        public static string GetUppercaseLetters(this string text) => text is null ? throw new Exception("The value cannot be null.") : string.Concat(text.Where(char.IsUpper));

        /// <summary>
        /// Retrieves all lowercase letters from the input string.
        /// </summary>
        /// <param name="text">The input string from which to extract lowercase letters.</param>
        /// <returns>A new string containing only the lowercase letters present in the input string.</returns>
        /// <exception cref="Exception">Throw when <paramref name="text"/> is null.</exception>
        public static string GetLowercaseLetters(this string text) => text is null ? throw new Exception("The value cannot be null.") : string.Concat(text.Where(char.IsLower));

        /// <summary>
        /// Determines whether the specified string is empty or consists only of white-space characters.
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns>true if the string is empty or contains only white-space characters; otherwise, false.</returns>
        public static bool IsEmpty(this string? value) => string.IsNullOrWhiteSpace(value);

        /// <summary>
        /// Determines whether the specified string is not empty and contains at least one non-white-space character.
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns>true if the string is not empty and contains at least one non-white-space character; otherwise, false.</returns>
        public static bool IsNotEmpty(this string? value) => !string.IsNullOrWhiteSpace(value);

        /// <summary>
        /// Replaces multiple occurrences of strings specified in <b><paramref name="valuesToRemove"/></b> with <b><see cref="string.Empty"/></b> in the <paramref name="value"/> string.
        /// </summary>
        /// <param name="value">The original string.</param>
        /// <param name="valuesToRemove">An array of strings to be replaced with <b><see cref="string.Empty"/></b>.</param>
        /// <returns>A new string with the specified occurrences replaced by <b><see cref="string.Empty"/></b>.</returns>
        public static string RemoveMany(this string value, params string?[]? valuesToRemove)
        {
            if (valuesToRemove == null)
            {
                return value;
            }

            foreach (string? valueToRemove in valuesToRemove)
            {
                if (string.IsNullOrEmpty(valueToRemove))
                {
                    continue;
                }

                value = value.Replace(valueToRemove, string.Empty);
            }

            return value;
        }

        /// <summary>
        /// Counts the number of occurrences of a specified <b><paramref name="valueToCount"/></b> within the <b><paramref name="value"/></b> string.
        /// </summary>
        /// <param name="value">The original string.</param>
        /// <param name="valueToCount">The string to be counted.</param>
        /// <returns>The number of occurrences of the specified string within the original string.</returns>
        public static int TextCount(this string value, string valueToCount)
        {
            return value.Split(valueToCount).Length - 1;
        }

        /// <summary>
        /// Checks whether a string contains all specified values, using the specified string comparison.
        /// </summary>
        /// <param name="text">The string to search within.</param>
        /// <param name="comparison">The string comparison to use when checking for the values.</param>
        /// <param name="values">The values to check for in the string.</param>
        /// <returns><c>true</c> if the string contains all specified values; otherwise, <c>false</c>.</returns>
        public static bool ContainsAll(this string text, StringComparison comparison, params string[] values) => values.All(value => text.Contains(value, comparison));

        /// <summary>
        /// Checks whether a string contains all specified values.<br/>
        /// <b><see cref="StringComparison.OrdinalIgnoreCase"/></b> is used when comparing strings.
        /// </summary>
        /// <param name="text">The string to search within.</param>
        /// <param name="values">The values to check for in the string.</param>
        /// <returns><c>true</c> if the string contains all specified values; otherwise, <c>false</c>.</returns>
        public static bool ContainsAll(this string text, params string[] values) => text.ContainsAll(StringComparison.OrdinalIgnoreCase, values);

        /// <summary>
        /// Checks whether a string contains any of the specified values, using the specified string comparison.
        /// </summary>
        /// <param name="text">The string to search within.</param>
        /// <param name="comparison">The string comparison to use when checking for the values.</param>
        /// <param name="values">The values to check for in the string.</param>
        /// <returns><c>true</c> if the string contains any of the specified values; otherwise, <c>false</c>.</returns>
        public static bool ContainsAny(this string text, StringComparison comparison, params string[] values) => values.Any(value => text.Contains(value, comparison));

        /// <summary>
        /// Checks whether a string contains any of the specified values.<br/>
        /// <b><see cref="StringComparison.OrdinalIgnoreCase"/></b> is used when comparing strings.
        /// </summary>
        /// <param name="text">The string to search within.</param>
        /// <param name="values">The values to check for in the string.</param>
        /// <returns><c>true</c> if the string contains any of the specified values; otherwise, <c>false</c>.</returns>
        public static bool ContainsAny(this string text, params string[] values) => text.ContainsAny(StringComparison.OrdinalIgnoreCase, values);

        /// <summary>
        /// Splits the specified <b><paramref name="value"/></b> string based on the specified <b><paramref name="splitByEnum"/></b>.
        /// </summary>
        /// <param name="value">The string to split.</param>
        /// <param name="splitByEnum">The type of split to perform.</param>
        /// <param name="keepSeparator">A flag indicating whether to include the separator in the resulting substrings.</param>
        /// <param name="separator">The user-defined separator string. This parameter is only used and required when <b><paramref name="splitByEnum"/></b> is set to <b><see cref="StringSplitByEnum.UserDefined"/></b>.</param>
        /// <returns>A list of substrings from the original string.</returns>
        /// <exception cref="NotImplementedException">Thrown when <paramref name="splitByEnum"/> is not implemented.</exception>
        public static List<string> SplitBy(this string value, StringSplitByEnum splitByEnum, bool keepSeparator = false, string? separator = null)
        {
            return splitByEnum switch
            {
                StringSplitByEnum.CarriageReturn or StringSplitByEnum.NewLineMacOs => value.Split("\r", keepSeparator),
                StringSplitByEnum.Coma => value.Split(",", keepSeparator),
                StringSplitByEnum.Dash => value.Split("-", keepSeparator),
                StringSplitByEnum.Dot => value.Split(".", keepSeparator),
                StringSplitByEnum.DoubleQuote => value.Split("\"", keepSeparator),
                StringSplitByEnum.EnvironmentNewLine => value.Split(Environment.NewLine, keepSeparator),
                StringSplitByEnum.Equal => value.Split("=", keepSeparator),
                StringSplitByEnum.NewLine => value.Split("\n", keepSeparator),
                StringSplitByEnum.NewLineNonUnix => value.Split("\r\n", keepSeparator),
                StringSplitByEnum.NewLineUnix => value.Split("\n", keepSeparator),
                StringSplitByEnum.SingleQuote => value.Split("'", keepSeparator),
                StringSplitByEnum.Space => value.Split(" ", keepSeparator),
                StringSplitByEnum.Underscore => value.Split("_", keepSeparator),
                StringSplitByEnum.UserDefined => value.Split(separator, keepSeparator),
                _ => throw new NotImplementedException($"Type '{splitByEnum}' has not been implemented."),
            };
        }

        /// <summary>
        /// Splits the specified <paramref name="value"/> string into substrings based on the specified <paramref name="separator"/>.
        /// </summary>
        /// <param name="value">The string to split.</param>
        /// <param name="separator">The string used as the separator.</param>
        /// <param name="keepSeparator">A flag indicating whether to include the separator in the resulting substrings.</param>
        /// <returns>A list of substrings from the original string.</returns>
        private static List<string> Split(this string? value, string? separator, bool keepSeparator = false)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return new List<string>();
            }

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
    }
}
