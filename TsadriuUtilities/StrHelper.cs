﻿// <copyright file StrHelper.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>
using System;

namespace TsadriuUtilities
{
    /// <summary>
    /// A class that helps on dealing with <see cref="string"/>.
    /// </summary>
    [Obsolete("StrHelper class is deprecated, please use class StringHelper instead.")]
    public static class StrHelper
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
            return StringHelper.GetTagValue(text, startTag, endTag, tagsIncluded);
        }

        /// <summary>
        /// Checks if the <paramref name="value"/> is null, <see cref="string.Empty"/> or a white space ("", \n, \r, ...).
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>Returns true if the <paramref name="value"/> is empty. Returns false if not.</returns>
        public static bool IsEmpty(string value)
        {
            return StringHelper.IsEmpty(value);
        }

        /// <summary>
        /// Checks if <paramref name="value"/> contains any kind of character.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>Returns true if the <paramref name="value"/> is not empty. Returns false if not.</returns>
        public static bool IsNotEmpty(string value)
        {
            return StringHelper.IsNotEmpty(value);
        }

        /// <summary>
        /// Changes a lower-case letter to be upper-case. If <paramref name="index"/> is not passed, it will change the first letter of <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value to change.</param>
        /// <param name="index">The index of the letter to be changed. If <paramref name="index"/> is not passed, it will change the first letter of <paramref name="value"/>.</param>
        /// <returns>Returns the new string with the changed value. Returns the same <paramref name="value"/> if it was empty or <paramref name="index"/> was invalid.</returns>
        public static string LetterUpperCase(string value, int index = 0)
        {
            return StringHelper.LetterUpperCase(value, index);
        }

        /// <summary>
        /// Changes a upper-case letter to be lower-case. If <paramref name="index"/> is not passed, it will change the first letter of <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value to change.</param>
        /// <param name="index">The index of the letter to be changed. If <paramref name="index"/> is not passed, it will change the first letter of <paramref name="value"/>.</param>
        /// <returns>Returns the new string with the changed value. Returns the same <paramref name="value"/> if it was empty or <paramref name="index"/> was invalid.</returns>
        public static string LetterLowerCase(string value, int index = 0)
        {
            return StringHelper.LetterLowerCase(value, index);
        }

        /// <summary>
        /// Returns a <see cref="string"/> where all occasions of <paramref name="valuesToRemove"/> have been removed from the <paramref name="value"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="valuesToRemove"></param>
        /// <returns></returns>
        public static string Remove(string value, params string[] valuesToRemove)
        {
            return StringHelper.Remove(value, valuesToRemove);
        }
    }
}