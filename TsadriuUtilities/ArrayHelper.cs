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
    }
}