// <copyright file MultiHelper.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;

namespace TsadriuUtilities
{
    /// <summary>
    /// A class that helps on dealing with <see cref="List{T}"/>.
    /// </summary>
    public static class ListHelper
    {
        /// <summary>
        /// Adds the <paramref name="array"/> into <paramref name="currentList"/>.
        /// If <paramref name="startIndex"/> is specified, it will add only from <paramref name="startIndex"/> (included) until the end of the <see cref="Array"/> or until it reaches <paramref name="endIndex"/> (included) if it is specified.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="currentList">List where <paramref name="array"/> will be added into.</param>
        /// <param name="array">Array of values.</param>
        /// <param name="startIndex">From which point of the <paramref name="array"/>'s index should added.</param>
        /// <param name="endIndex">From which point of the <paramref name="array"/>'s index should stop.</param>
        public static void AddRange<T>(this List<T> currentList, T[] array, int startIndex = 0, int endIndex = 0)
        {
            var list = new List<T>();
            list.AddRange(array);
            list = list.GetRange(startIndex, list.Count - (endIndex - 1));
            currentList.AddRange(list);
        }

        /// <summary>
        /// Adds the <paramref name="listToAdd"/> into <paramref name="currentList"/>. If <paramref name="index"/> is specified, it will add only from <paramref name="index"/> (included) until the end of the <see cref="List{T}"/>.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="currentList">List where <paramref name="listToAdd"/> will be added into.</param>
        /// <param name="listToAdd">Array of values.</param>
        /// <param name="index">From which point of the <paramref name="listToAdd"/>'s index should added.</param>
        public static void AddRange<T>(this List<T> currentList, List<T> listToAdd, int index = 0)
        {
            var list = new List<T>();
            list.AddRange(listToAdd);
            list = list.GetRange(index, list.Count - index);
            currentList.AddRange(list);
        }

        /// <summary>
        /// Transforms an <see cref="Array"/> to a <see cref="List{T}"/>.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="array"><see cref="Array"/> that you want to be converted to a <see cref="List{T}"/>.</param>
        /// <returns>A <see cref="List{T}"/> containing the <paramref name="array"/>'s values.</returns>
        public static List<T> ToList<T>(this T[] array)
        {
            var newList = new List<T>();
            newList.AddRange(array);
            return newList;
        }

        /// <summary>
        /// Orders the <see cref="List{T}"/> in ascending order.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="list"><see cref="List{T}"/> to be ordered.</param>
        public static void OrderByAscending<T>(this List<T> list)
        {
            list.Sort();
        }

        /// <summary>
        /// Orders the <see cref="List{T}"/> in descending order.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="list"><see cref="List{T}"/> to be ordered.</param>
        public static void OrderByDescending<T>(this List<T> list)
        {
            list.Reverse();
        }

        /// <summary>
        /// Converts an <see cref="List{T}"/> into a single line <see cref="string"/>. If <paramref name="separator"/> is not passed, it will separate by a space. Examples: ListToString(new int[] { 1, 3, 5 }) -> "1 3 5", ListToString(new string[] { "5", "2" }, "|") -> "5|2".
        /// Supported types:
        /// <see cref="DateTime"/>,
        /// <see cref="long"/>, <see cref="int"/>, <see cref="short"/>, <see cref="byte"/>,
        /// <see cref="float"/>, <see cref="double"/>, <see cref="decimal"/>.
        /// </summary>
        /// <param name="list"><see cref="List{T}"/> of objects.</param>
        /// <param name="separator"><see cref="string"/> separator. If nothing is passed, it will separate by a space.</param>
        /// <param name="startIndex">From which point of the <paramref name="list"/>'s index should added.</param>
        /// <param name="count">How many elements in the <paramref name="list"/> should be taken considering the <paramref name="startIndex"/>'s point.</param>
        /// <returns><see cref="List{T}"/> converted into a single <see cref="string"/> line.</returns>
        public static string ToString<T>(this List<T> list, string separator = " ", int startIndex = 0, int count = -1)
        {
            if (count == -1)
            {
                count = list.Count;
            }

            var values = list.GetRange(startIndex, count);
            return string.Join(separator, values);
        }

        /// <summary>
        /// Iterates through <paramref name="list"/> checking that it has at least 1 non null element.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="list"><see cref="List{T}"/> of objects.</param>
        /// <returns>Returns true if <paramref name="list"/> has at least 1 non null element. Otherwise returns false.</returns>
        public static bool HasAny<T>(this List<T> list)
        {
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == null)
                    {
                        continue;
                    }
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Iterates through the <paramref name="list"/>, returning the first item found that contains <paramref name="value"/>.
        /// </summary>
        /// <param name="list">Current list.</param>
        /// <param name="value">The value to search for.</param>
        /// <param name="stringComparison">String comparison. If nothing is passed, <see cref="StringComparison.OrdinalIgnoreCase"/> will be used.</param>
        /// <returns>The first item found in the list that contains <paramref name="value"/>. If <paramref name="value"/> is not present in the list, returns <see cref="string.Empty"/>.</returns>
        public static string GetValueLike(this List<string> list, string value, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
        {
            foreach (var element in list)
            {
                if (element.Contains(value, stringComparison))
                {
                    return element;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Iterates through the <paramref name="list"/>, returning the first item found that contains all <paramref name="values"/>.
        /// </summary>
        /// <param name="list">The list to iterate through.</param>
        /// <param name="stringComparison">String comparison. If nothing is passed, <see cref="StringComparison.OrdinalIgnoreCase"/> will be used.</param>
        /// <param name="values">The values to search in the <paramref name="list"/>.</param>
        /// <returns>The first item found in the <paramref name="list"/> that contains all <paramref name="values"/>. If any of the elements of the <paramref name="list"/>
        /// does not have all <paramref name="values"/>, returns <see cref="string.Empty"/>.</returns>
        public static string GetValueContaining(this List<string> list, StringComparison stringComparison, params string[] values)
        {
            int countOfValues = 0;

            foreach (var element in list)
            {
                foreach (var value in values)
                {
                    if (element.Contains(value, stringComparison))
                    {
                        countOfValues++;
                        continue;
                    }
                }

                if (countOfValues == values.Length)
                {
                    return element;
                }

                countOfValues = 0;
                continue;
            }

            return string.Empty;
        }

        /// <summary>
        /// Iterates through the <paramref name="list"/>, adding <paramref name="startItemTag"/> before the item and <paramref name="endItemTag"/> after the item.
        /// Example: <paramref name="startItemTag"/> is 'www.' and <paramref name="list"/> is 'google.com'. Method will return the elements as 'www.google.com'.
        /// </summary>
        /// <param name="list">The list of <see cref="string"/> to iterate through.</param>
        /// <param name="startItemTag">What to add <b>before</b> the item.</param>
        /// <param name="endItemTag">What to add <b>after</b> the item.</param>
        /// <returns>If both <paramref name="startItemTag"/> and <paramref name="endItemTag"/> are empty, it will return the same <paramref name="list"/>. If even one
        /// of <paramref name="startItemTag"/> or <paramref name="endItemTag"/> has a value, it will be added to the items of the <paramref name="list"/>.</returns>
        public static List<string> AddToElements(this List<string> list, string startItemTag, string endItemTag = null)
        {
            if (StringHelper.AreEmpty(startItemTag, endItemTag))
            {
                return list;
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (startItemTag.IsNotEmpty())
                {
                    list[i] = startItemTag + list[i];
                }

                if (endItemTag.IsNotEmpty())
                {
                    list[i] = list[i] + endItemTag;
                }
            }

            return list;
        }

        /// <summary>
        /// Returns a list where all occasions of <paramref name="valuesToRemove"/> have been removed from the elements of the <paramref name="list"/>.
        /// </summary>
        /// <param name="list">Current list.</param>
        /// <param name="valuesToRemove">The values to remove from the elements of the <paramref name="list"/>.</param>
        /// <returns>A list where all occasions of <paramref name="valuesToRemove"/> have been removed from the elements of the <paramref name="list"/>.</returns>
        public static List<string> RemoveFromElements(this List<string> list, params string[] valuesToRemove)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = list[i].Remove(valuesToRemove);
            }

            return list;
        }

        /// <summary>
        /// Returns a list where all occasions of <paramref name="oldValue"/> have been replaced by <paramref name="newValue"/> from the elements of the <paramref name="list"/>.
        /// </summary>
        /// <param name="list">Current list.</param>
        /// <param name="oldValue">Old value to be replaced.</param>
        /// <param name="newValue">New value that replaces the <paramref name="oldValue"/>.</param>
        /// <returns>A list where all occasions of <paramref name="oldValue"/> have been replaced by <paramref name="newValue"/> from the elements of the <paramref name="list"/>.</returns>
        public static List<string> ReplaceFromElements(this List<string> list, string oldValue, string newValue)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = list[i].Replace(oldValue, newValue);
            }

            return list;
        }

        /// <summary>
        /// Searches through the <paramref name="stringList"/>, returning the first instance found between <paramref name="start"/> and <paramref name="end"/>. Use <paramref name="startEndIncluded"/> if you want to include <paramref name="start"/> and <paramref name="end"/> in the returning <see cref="string"/>.
        /// </summary>
        /// <param name="stringList">List of <see cref="string"/> to search through.</param>
        /// <param name="start">The start tag.</param>
        /// <param name="end">The end tag.</param>
        /// <param name="startEndIncluded">If enabled, the returning <see cref="string"/> will keep the <paramref name="start"/> and <paramref name="end"/>in it.</param>
        /// <returns>The first index that was found with either the <paramref name="start"/> or <paramref name="end"/>. If neither are found, a <see cref="string.Empty"/> is returned instead.</returns>
        public static string GetBetween(this List<string> stringList, string start = null, string end = null, bool startEndIncluded = false)
        {
            for (int i = 0; i < stringList.Count; i++)
            {
                var result = stringList[i].GetBetween(start, end, startEndIncluded);

                if (result.IsNotEmpty())
                {
                    return result;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Searches through the <paramref name="stringList"/>, returning the first instance found between <paramref name="start"/> and <paramref name="end"/> for each index.
        /// If you want more instances per index, please use the method <see cref="GetMultipleBetweenIndexes(List{string}, string, string, bool)"/>.
        /// </summary>
        /// <param name="stringList">List of <see cref="string"/> to search through.</param>
        /// <param name="start">The start tag.</param>
        /// <param name="end">The end tag.</param>
        /// <param name="startEndIncluded">If enabled, the indexes will keep the <paramref name="start"/> and <paramref name="end"/>.</param>
        /// <returns>Multiple indexes that were found with either the <paramref name="start"/> or <paramref name="end"/>. If neither are found, an empty <b><![CDATA[List<string>]]></b> is returned instead.</returns>
        public static List<string> GetMultipleBetween(this List<string> stringList, string start = null, string end = null, bool startEndIncluded = false)
        {
            var newList = new List<string>();

            for (int i = 0; i < stringList.Count; i++)
            {
                var result = stringList[i].GetBetween(start, end, startEndIncluded);

                if (result.IsNotEmpty())
                {
                    newList.Add(result);
                }
            }

            return newList;
        }

        /// <summary>
        /// Searches through the <paramref name="stringList"/>, returningmultiple instances found between <paramref name="start"/> and <paramref name="end"/> for each index.
        /// If you want only one instance per index, please use the method <see cref="GetMultipleBetween(List{string}, string, string, bool)"/>.
        /// </summary>
        /// <param name="stringList">List of <see cref="string"/> to search through.</param>
        /// <param name="start">The start tag.</param>
        /// <param name="end">The end tag.</param>
        /// <param name="startEndIncluded">If enabled, the indexes will keep the <paramref name="start"/> and <paramref name="end"/>.</param>
        /// <returns>Multiple instances by multiple indexes that were found with either the <paramref name="start"/> or <paramref name="end"/>. If neither are found, an empty <b><![CDATA[List<string>]]></b> is returned instead.</returns>
        public static List<string> GetMultipleBetweenIndexes(this List<string> stringList, string start = null, string end = null, bool startEndIncluded = false)
        {
            var newList = new List<string>();

            for (int i = 0; i < stringList.Count; i++)
            {
                var multipleResults = stringList[i].GetMultipleBetween(start, end, startEndIncluded);

                foreach (var result in multipleResults)
                {
                    if (result.IsNotEmpty())
                    {
                        newList.Add(result);
                    }
                }
            }

            return newList;
        }

        /// <summary>
        /// Iterates through <paramref name="stringList"/>, keeping the content between <paramref name="start"/> and <paramref name="end"/>.
        /// </summary>
        /// <param name="stringList">The list to iterate through.</param>
        /// <param name="start">The start tag.</param>
        /// <param name="end">The end tag.</param>
        /// <param name="startEndIncluded">If enabled, the indexes will keep the <paramref name="start"/> and <paramref name="end"/>.</param>
        /// <param name="excludeEmptyIndexes">If enabled, empty indexes will be removed from the list.</param>
        /// <returns>New list with the indexes' content changed based on <paramref name="start"/> and/or <paramref name="end"/>.</returns>
        public static List<string> KeepBetween(this List<string> stringList, string start = null, string end = null, bool startEndIncluded = false, bool excludeEmptyIndexes = true)
        {
            List<string> newList = new List<string>();

            for (int i = 0; i < stringList.Count; i++)
            {
                var result = stringList[i].GetBetween(start, end, startEndIncluded);

                if (!excludeEmptyIndexes)
                {
                    newList.Add(result);
                    continue;
                }

                if (result.IsNotEmpty())
                {
                    newList.Add(result);
                }
            }

            return newList;
        }

        /// <summary>
        /// Iterates through <paramref name="stringList"/>, excluding the indexes that contain <paramref name="excludeStrings"/>.
        /// </summary>
        /// <param name="stringList">The list to iterate through.</param>
        /// <param name="excludeStrings"><see cref="string"/> to exclude from the <paramref name="stringList"/>. If <paramref name="excludeStrings"/> is found in any of the indexes of <paramref name="stringList"/>, it will be removed.</param>
        /// <returns>New list where the indexes that had <paramref name="excludeStrings"/> were removed from the <paramref name="stringList"/>.</returns>
        public static List<string> Exclude(this List<string> stringList, params string[] excludeStrings)
        {
            List<string> newList = new List<string>();

            for (int i = 0; i < stringList.Count; i++)
            {
                for (int j = 0; j < excludeStrings.Length; j++)
                {
                    if (stringList[i].Contains(excludeStrings[j], StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    newList.Add(stringList[i]);
                }
            }

            return newList;
        }
    }
}