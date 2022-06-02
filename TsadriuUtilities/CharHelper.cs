// <copyright file CharHelper.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>

using System;

namespace TsadriuUtilities
{
    /// <summary>
    /// A class that helps on dealing with <see cref="char"/>.
    /// </summary>
    public static class CharHelper
    {
        /// <summary>
        /// Converts the <paramref name="value"/> into a <see cref="char"/>. If the length of <paramref name="value"/> is higher than 1, it will return the first character of <paramref name="value"/> or, if <paramref name="index"/> is passed, the character of the desired index.
        /// </summary>
        /// <param name="value">The <see cref="string"/> to get the value from.</param>
        /// <param name="index">The <paramref name="index"/> of the letter to be return. If <paramref name="index"/> is not passed, it will return the first letter of <paramref name="value"/>.</param>
        /// <returns>The first character of <paramref name="value"/> or, if <paramref name="index"/> is passed, the character of the desired index.</returns>
        public static char ToChar(this string value, int index = 0)
        {
            return value[index];
        }
    }
}
