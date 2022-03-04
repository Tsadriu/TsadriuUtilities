// <copyright file NumberHelper.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>
using System;

namespace TsadriuUtilities
{
    /// <summary>
    /// A class that helps on dealing with numbers.
    /// </summary>
    public static class NumberHelper
    {
        /// <summary>
        /// Converts an exponential number to a <see cref="decimal"/>. Example: 46e-9 returns 0.000000046.
        /// </summary>
        /// <param name="value">Number as a <see cref="string"/> (46e-9).</param>
        /// <returns>Returns the parsed <paramref name="value"/> as a <see cref="decimal"/>. If the conversion fails, returns <see cref="decimal.Zero"/>.</returns>
        public static decimal? ExponentialToDecimal(string value)
        {
            if (StrHelper.IsNotEmpty(value))
            {
                if (double.TryParse(value, out double valueAsDouble))
                {
                    return Convert.ToDecimal(valueAsDouble);
                }
            }

            return decimal.Zero;
        }

        /// <summary>
        /// Converts an exponential number to a <see cref="double"/>. Example: 46e-9 returns 0.000000046.
        /// </summary>
        /// <param name="value">Number as a <see cref="string"/> (46e-9).</param>
        /// <returns>Returns the parsed <paramref name="value"/> as a <see cref="double"/>. If the conversion fails, returns 0.0d.</returns>
        public static double? ExponentialToDouble(string value)
        {
            if (StrHelper.IsNotEmpty(value))
            {
                if (double.TryParse(value, out double valueAsDouble))
                {
                    return valueAsDouble;
                }
            }

            return 0.0d;
        }
    }
}
