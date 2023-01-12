// <copyright file ArrayHelper.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;

namespace TsadriuUtilities
{
    /// <summary>
    /// A class that helps on dealing with <see cref="Array"/>.
    /// </summary>
    public static class ArrayHelper
    {
        private static readonly Type intType = typeof(int);
        private static readonly Type shortType = typeof(short);
        private static readonly Type byteType = typeof(byte);

        /// <summary>
        /// Converts an <see cref="Array"/> into a single line <see cref="string"/>. If <paramref name="separator"/> is not passed, it will separate by a space. Examples: ArrayToString(new int[] { 1, 3, 5 }) -> "1 3 5", ArrayToString(new string[] { "5", "2" }, "|") -> "5|2".
        /// Supported types:
        /// <see cref="DateTime"/>,
        /// <see cref="long"/>, <see cref="int"/>, <see cref="short"/>, <see cref="byte"/>,
        /// <see cref="float"/>, <see cref="double"/>, <see cref="decimal"/>.
        /// </summary>
        /// <param name="array"><see cref="Array"/> of objects.</param>
        /// <param name="separator"><see cref="string"/> separator. If nothing is passed, it will separate by a space.</param>
        /// <returns><see cref="Array"/> converted into a single <see cref="string"/> line.</returns>
        public static string ToString<T>(this T[] array, string separator = " ")
        {
            return string.Join(separator, array);
        }

        /// <summary>
        /// Fills up the array with random numbers between <paramref name="min"/> (default: 0, inclusive) and <paramref name="max"/> (default: 100, inclusive).
        /// Supported types: <see cref="int"/>, <see cref="short"/> and <see cref="byte"/>.
        /// </summary>
        /// <param name="array">Current array.</param>
        /// <param name="min">The minimum number that can be generated.</param>
        /// <param name="max">The maximum number that can be generated.</param>
        /// <returns>An array which all indexes have been assigned a random number.</returns>
        public static T[] GenerateRandom<T>(this T[] array, int min = 0, int max = 100)
        {
            Type type = typeof(T);

            if (type == intType)
            {
                min = int.MinValue;
                max = int.MaxValue;
            }

            if (type == shortType)
            {
                min = short.MinValue;
                max = short.MaxValue;
            }

            if (type == byteType)
            {
                min = byte.MinValue;
                max = byte.MaxValue;
            }

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (T)Convert.ChangeType(new Random().Next(min, max + 1), typeof(T));
            }

            return array;
        }

        /// <summary>
        /// Iterates through the <paramref name="stringArray"/>, returning the first index found that contains <paramref name="value"/>.
        /// </summary>
        /// <param name="stringArray">Current array.</param>
        /// <param name="value">The value to search for.</param>
        /// <param name="stringComparison">String comparison. If nothing is passed, <see cref="StringComparison.OrdinalIgnoreCase"/> will be used.</param>
        /// <returns>The first index found in the array that contains <paramref name="value"/>. If <paramref name="value"/> is not present in the array, returns <see cref="string.Empty"/>.</returns>
        public static string GetValueLike(this string[] stringArray, string value, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
        {
            return stringArray.ToList().GetValueLike(value, stringComparison);
        }

        /// <summary>
        /// Iterates through the <paramref name="stringArray"/>, returning the first index found that contains all <paramref name="values"/>.
        /// </summary>
        /// <param name="stringArray">The array to iterate through.</param>
        /// <param name="stringComparison">String comparison. If nothing is passed, <see cref="StringComparison.OrdinalIgnoreCase"/> will be used.</param>
        /// <param name="values">The values to search in the <paramref name="stringArray"/>.</param>
        /// <returns>The first index found in the <paramref name="stringArray"/> that contains all <paramref name="values"/>. If any of the items of the <paramref name="stringArray"/>
        /// does not have all <paramref name="values"/>, returns <see cref="string.Empty"/>.</returns>
        public static string GetValueContaining(this string[] stringArray, StringComparison stringComparison, params string[] values)
        {
            return stringArray.ToList().GetValueContaining(stringComparison, values);
        }

        /// <summary>
        /// Iterates through the <paramref name="stringArray"/>, adding <paramref name="startItemTag"/> before the item and <paramref name="endItemTag"/> after the item.
        /// Example: <paramref name="startItemTag"/> is 'www.' and <paramref name="stringArray"/> is 'google.com'. Method will return the elements as 'www.google.com'.
        /// </summary>
        /// <param name="stringArray">The array of <see cref="string"/> to iterate through.</param>
        /// <param name="startItemTag">What to add <b>before</b> the item.</param>
        /// <param name="endItemTag">What to add <b>after</b> the item.</param>
        /// <returns>If both <paramref name="startItemTag"/> and <paramref name="endItemTag"/> are empty, it will return the same <paramref name="stringArray"/>. If even one
        /// of <paramref name="startItemTag"/> or <paramref name="endItemTag"/> has a value, it will be added to the items of the <paramref name="stringArray"/>.</returns>
        public static string[] AddToElements(this string[] stringArray, string startItemTag, string endItemTag = null)
        {
            return stringArray.ToList().AddToElements(startItemTag, endItemTag).ToArray();
        }

        /// <summary>
        /// Returns an array where all occasions of <paramref name="valuesToRemove"/> have been removed from the elements of the <paramref name="stringArray"/>.
        /// </summary>
        /// <param name="stringArray">Current array.</param>
        /// <param name="valuesToRemove">The values to remove from the indexes of the <paramref name="stringArray"/>.</param>
        /// <returns>An array where all occasions of <paramref name="valuesToRemove"/> have been removed from the elements of the <paramref name="stringArray"/>.</returns>
        public static string[] RemoveFromElements(this string[] stringArray, params string[] valuesToRemove)
        {
            return stringArray.ToList().RemoveFromElements(valuesToRemove).ToArray();
        }

        /// <summary>
        /// Returns an array where all occasions of <paramref name="oldValue"/> have been replaced by <paramref name="newValue"/> from the elements of the <paramref name="stringArray"/>.
        /// </summary>
        /// <param name="stringArray">Current array.</param>
        /// <param name="oldValue">Old value to be replaced.</param>
        /// <param name="newValue">New value that replaces the <paramref name="oldValue"/>.</param>
        /// <returns>An array where all occasions of <paramref name="oldValue"/> have been replaced by <paramref name="newValue"/> from the elements of the <paramref name="stringArray"/>.</returns>
        public static string[] ReplaceFromElements(this string[] stringArray, string oldValue, string newValue)
        {
            return stringArray.ToList().ReplaceFromElements(oldValue, newValue).ToArray();
        }

        /// <summary>
        /// Searches through the <paramref name="stringArray"/>, returning the first instance found between <paramref name="start"/> and <paramref name="end"/>. Use <paramref name="startEndIncluded"/> if you want to include <paramref name="start"/> and <paramref name="end"/> in the returning <see cref="string"/>.
        /// </summary>
        /// <param name="stringArray">List of <see cref="string"/> to search through.</param>
        /// <param name="start">The start tag.</param>
        /// <param name="end">The end tag.</param>
        /// <param name="startEndIncluded">If enabled, the returning <see cref="string"/> will keep the <paramref name="start"/> and <paramref name="end"/>in it.</param>
        /// <returns>The first index that was found with either the <paramref name="start"/> or <paramref name="end"/>. If neither are found, a <see cref="string.Empty"/> is returned instead.</returns>
        public static string GetBetween(this string[] stringArray, string start = null, string end = null, bool startEndIncluded = false)
        {
            return stringArray.ToList().GetBetween(start, end, startEndIncluded);
        }

        /// <summary>
        /// Searches through the <paramref name="stringArray"/>, returning multiple instances found between <paramref name="start"/> and <paramref name="end"/>. Use <paramref name="startEndIncluded"/> if you want to include <paramref name="start"/> and <paramref name="end"/> in the returning <b><![CDATA[List<string>]]></b>.
        /// </summary>
        /// <param name="stringArray">List of <see cref="string"/> to search through.</param>
        /// <param name="start">The start tag.</param>
        /// <param name="end">The end tag.</param>
        /// <param name="startEndIncluded">If enabled, the indexes will keep the <paramref name="start"/> and <paramref name="end"/>.</param>
        /// <returns>Multiple indexes that were found with either the <paramref name="start"/> or <paramref name="end"/>. If neither are found, an empty <b><![CDATA[List<string>]]></b> is returned instead.</returns>
        public static string[] GetMultipleBetween(this string[] stringArray, string start = null, string end = null, bool startEndIncluded = false)
        {
            return stringArray.ToList().GetMultipleBetween(start, end, startEndIncluded).ToArray();
        }

        /// <summary>
        /// Iterates through <paramref name="stringArray"/>, keeping the content between <paramref name="start"/> and <paramref name="end"/>.
        /// </summary>
        /// <param name="stringArray">The array to iterate through.</param>
        /// <param name="start">The start tag.</param>
        /// <param name="end">The end tag.</param>
        /// <param name="startEndIncluded">If enabled, the indexes will keep the <paramref name="start"/> and <paramref name="end"/>.</param>
        /// <param name="excludeEmptyIndexes">If enabled, empty indexes will be removed from the array.</param>
        /// <returns>New array with the indexes' content changed based on <paramref name="start"/> and/or <paramref name="end"/>.</returns>
        public static string[] KeepBetween(this string[] stringArray, string start = null, string end = null, bool startEndIncluded = false, bool excludeEmptyIndexes = true)
        {
            return stringArray.ToList().KeepBetween(start, end, startEndIncluded, excludeEmptyIndexes).ToArray();
        }

        /// <summary>
        /// Iterates through <paramref name="stringArray"/>, excluding the indexes that contain <paramref name="excludeStrings"/>.
        /// </summary>
        /// <param name="stringArray">The array to iterate through.</param>
        /// <param name="excludeStrings"><see cref="string"/> to exclude from the <paramref name="stringArray"/>. If <paramref name="excludeStrings"/> is found in any of the indexes of <paramref name="stringArray"/>, it will be removed.</param>
        /// <returns>New array where the indexes that had <paramref name="excludeStrings"/> were removed from the <paramref name="stringArray"/>.</returns>
        public static string[] Exclude(this string[] stringArray, params string[] excludeStrings)
        {
            return stringArray.ToList().Exclude(excludeStrings).ToArray();
        }

        /// <summary>
        /// Adds the <paramref name="arrayToAdd"/> into <paramref name="currentArray"/>.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="currentArray">Array where <paramref name="arrayToAdd"/> will be added into.</param>
        /// <param name="arrayToAdd">Array of values.</param>
        /// <returns>New array with <paramref name="currentArray"/> and <paramref name="arrayToAdd"/> combined.</returns>
        public static T[] AddRange<T>(this T[] currentArray, T[] arrayToAdd)
        {
            var newArray = new T[currentArray.Length + arrayToAdd.Length];

            for (int i = 0; i < currentArray.Length; i++)
            {
                newArray[i] = currentArray[i];
            }

            for (int i = 0; i < arrayToAdd.Length; i++)
            {
                newArray[currentArray.Length + i] = arrayToAdd[i];
            }

            return newArray;
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence within the entire <see cref="Array"/>.
        /// </summary>
        /// <param name="array">The array to be searched on.</param>
        /// <param name="item">The value that you want to get the index from the <paramref name="array"/>.</param>
        /// <returns>The zero-based index of the first occurrence of <paramref name="item"/> within the entire <see cref="Array"/>, if found; otherwise, -1.</returns>
        public static int IndexOf<T>(this T[] array, T item)
        {
            return array.ToList().IndexOf(item);
        }
    }
}