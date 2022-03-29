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
        /// Adds the <paramref name="array"/> into <paramref name="currentList"/>. If <paramref name="startIndex"/> is specified, it will add only from <paramref name="startIndex"/> (included) until the end of the <see cref="Array"/>.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="currentList">List where <paramref name="array"/> will be added into.</param>
        /// <param name="array">Array of values.</param>
        /// <param name="startIndex">From which point of the <paramref name="array"/>'s index should added.</param>
        /// <returns></returns>
        public static void AddRange<T>(ref List<T> currentList, T[] array, int startIndex = 0, int endIndex = 0)
        {
            var list = new List<T>();
            list.AddRange(array);
            list = list.GetRange(startIndex, list.Count - startIndex);
            currentList.AddRange(list);
        }

        /// <summary>
        /// Adds the <paramref name="listToAdd"/> into <paramref name="currentList"/>. If <paramref name="index"/> is specified, it will add only from <paramref name="index"/> (included) until the end of the <see cref="Array"/>.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="currentList">List where <paramref name="listToAdd"/> will be added into.</param>
        /// <param name="listToAdd">Array of values.</param>
        /// <param name="index">From which point of the <paramref name="listToAdd"/>'s index should added.</param>
        /// <returns></returns>
        public static void AddRange<T>(ref List<T> currentList, List<T> listToAdd, int index = 0)
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
        public static List<T> ToList<T>(T[] array)
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
        public static void OrderByAscending<T>(ref List<T> list)
        {
            list.Sort();
        }

        /// <summary>
        /// Orders the <see cref="List{T}"/> in descending order.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="list"><see cref="List{T}"/> to be ordered.</param>
        public static void OrderByDescending<T>(ref List<T> list)
        {
            list.Reverse();
        }
    }
}