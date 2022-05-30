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
    }
}