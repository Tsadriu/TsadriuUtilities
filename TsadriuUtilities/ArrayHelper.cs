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
    }
}