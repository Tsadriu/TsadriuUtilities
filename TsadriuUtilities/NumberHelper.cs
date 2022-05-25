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
        /// Converts a <see cref="string"/> into a <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">Number as a <see cref="string"/> ('46e-9', '5.6', etc...).</param>
        /// <returns>Returns the parsed <paramref name="value"/> as a <see cref="decimal"/>. If the conversion fails, returns <see cref="decimal.Zero"/>.</returns>
        public static decimal ToDecimal(this string value)
        {
            if (StringHelper.IsNotEmpty(value))
            {
                if (double.TryParse(value, out double valueAsDecimal))
                {
                    return Convert.ToDecimal(valueAsDecimal);
                }
            }

            return decimal.Zero;
        }

        /// <summary>
        /// Converts a <see cref="string"/> into a <see cref="double"/>.
        /// </summary>
        /// <param name="value">Number as a <see cref="string"/> ('46e-9', '5.6', etc...).</param>
        /// <returns>Returns the parsed <paramref name="value"/> as a <see cref="double"/>. If the conversion fails, returns 0.0d.</returns>
        public static double ToDouble(this string value)
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

        /// <summary>
        /// Check if <paramref name="value"/> is between <paramref name="min"/> and <paramref name="max"/>. Setting <paramref name="included"/> to true will also include <paramref name="min"/> and <paramref name="max"/> in the verification.
        /// </summary>
        /// <typeparam name="T">Supported types: <see cref="long"/>, <see cref="int"/>, <see cref="short"/>, <see cref="byte"/>,
        /// <see cref="float"/>, <see cref="double"/>, <see cref="decimal"/>.</typeparam>
        /// <param name="value">The value to be checked on.</param>
        /// <param name="min">Minimum value.</param>
        /// <param name="max">Maximum value.</param>
        /// <param name="included">Set to true to include <paramref name="min"/> and <paramref name="max"/> in the verification.</param>
        /// <returns>True if <paramref name="value"/> is between <paramref name="min"/> and <paramref name="max"/>. Otherwise returns false.</returns>
        public static bool Between<T>(T value, T min, T max, bool included = true)
        {
            var currentValue = (decimal)Convert.ChangeType(value, typeof(decimal));
            var currentMin = (decimal)Convert.ChangeType(min, typeof(decimal));
            var currentMax = (decimal)Convert.ChangeType(max, typeof(decimal));

            if (included)
            {
                return currentValue >= currentMin && currentValue <= currentMax;
            }
            else
            {
                return currentValue > currentMin && currentValue < currentMax;
            }
        }
    }
}
