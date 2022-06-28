// <copyright file BoolHelper.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>

using System;
using TsadriuUtilities.Enums.BoolHelper;

namespace TsadriuUtilities
{
    /// <summary>
    /// A class that helps on dealing with <see cref="bool"/>.
    /// </summary>
    public static class BoolHelper
    {
        /// <summary>
        /// Tries to parse the <paramref name="value"/> into a <see cref="bool"/>.
        /// </summary>
        /// <param name="value">The <see cref="string"/> to be parsed as a <see cref="bool"/>.</param>
        /// <param name="searchType">The type of search mode to use on <paramref name="trueValues"/>, <paramref name="falseValues"/> and <paramref name="value"/>.</param>
        /// <param name="trueValues">The values that will make the <paramref name="value"/> return true.</param>
        /// <param name="falseValues">The values that will make the <paramref name="value"/> return false.</param>
        /// <returns>If the conversion was successfull, it will return <paramref name="value"/> as true or false depending on where it was found (<paramref name="trueValues"/>, <paramref name="falseValues"/>). If <paramref name="value"/> is not found in any of those, it'll launch an <see cref="ArgumentOutOfRangeException"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown the <paramref name="value"/> is not found in <paramref name="trueValues"/> and <paramref name="falseValues"/>.</exception>
        public static bool ToBool(this string value, SearchType searchType, string[] trueValues, string[] falseValues)
        {
            switch (searchType)
            {
                case SearchType.Contains:
                    foreach (var val in trueValues)
                    {
                        if (value.Contains(val, StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }

                    foreach (var val in falseValues)
                    {
                        if (value.Contains(val, StringComparison.OrdinalIgnoreCase))
                        {
                            return false;
                        }
                    }
                    break;
                case SearchType.Equals:
                    foreach (var val in trueValues)
                    {
                        if (value.Equals(val, StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }

                    foreach (var val in falseValues)
                    {
                        if (value.Equals(val, StringComparison.OrdinalIgnoreCase))
                        {
                            return false;
                        }
                    }
                    break;
            }

            throw new ArgumentOutOfRangeException(nameof(value), $"Value '{value}' was not in either the {nameof(trueValues)} or the {nameof(falseValues)}.");
        }
    }
}
