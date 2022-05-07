﻿// <copyright file NumberHelper.cs of solution TsadriuUtilities of developer Tsadriu>
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
            if (StringHelper.IsNotEmpty(value))
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
            if (StringHelper.IsNotEmpty(value))
            {
                if (double.TryParse(value, out double valueAsDouble))
                {
                    return valueAsDouble;
                }
            }

            return 0.0d;
        }

        /// <summary>
        /// Returns the highest number present in the <paramref name="sequence"/>.
        /// Supported types:
        /// <see cref="long"/>, <see cref="int"/>, <see cref="short"/>, <see cref="byte"/>,
        /// <see cref="float"/>, <see cref="double"/>, <see cref="decimal"/>.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="sequence">Sequence of numbers.</param>
        /// <returns>The highest number present in <paramref name="sequence"/>. If it's not found (or sequence is null or empty), returns 0.</returns>
        public static T Max<T>(params T[] sequence)
        {
            if (sequence.Length == 0)
            {
                return (T)Convert.ChangeType(0, typeof(T));
            }

            var max = (decimal)Convert.ChangeType(sequence[0], typeof(decimal));

            for (int i = 0; i < sequence.Length; i++)
            {
                var currentValue = (decimal)Convert.ChangeType(sequence[i], typeof(decimal));

                if (currentValue <= max)
                {
                    continue;
                }

                max = currentValue;
            }

            return (T)Convert.ChangeType(max, typeof(T));
        }

        /// <summary>
        /// Returns the lowest number present in the <paramref name="sequence"/>.
        /// Supported types:
        /// <see cref="long"/>, <see cref="int"/>, <see cref="short"/>, <see cref="byte"/>,
        /// <see cref="float"/>, <see cref="double"/>, <see cref="decimal"/>.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="sequence">Sequence of numbers.</param>
        /// <returns>The lowest number present in <paramref name="sequence"/>. If it's not found (or sequence is null or empty), returns 0.</returns>
        public static T Min<T>(params T[] sequence)
        {
            if (sequence.Length == 0)
            {
                return (T)Convert.ChangeType(0, typeof(T));
            }

            var min = (decimal)Convert.ChangeType(sequence[0], typeof(decimal));

            for (int i = 0; i < sequence.Length; i++)
            {
                var currentValue = (decimal)Convert.ChangeType(sequence[i], typeof(decimal));

                if (currentValue >= min)
                {
                    continue;
                }

                min = currentValue;
            }

            return (T)Convert.ChangeType(min, typeof(T));
        }
    }
}
