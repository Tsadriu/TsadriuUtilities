// <copyright file NumberHelper.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>
using System;
using System.Globalization;

namespace TsadriuUtilities
{
    /// <summary>
    /// A class that helps on dealing with numbers.
    /// </summary>
    public static class NumberHelper
    {
        private static readonly Type longType = typeof(long);
        private static readonly Type intType = typeof(int);
        private static readonly Type shortType = typeof(short);
        private static readonly Type byteType = typeof(byte);
        private static readonly Type floatType = typeof(float);
        private static readonly Type doubleType = typeof(double);
        private static readonly Type decimalType = typeof(decimal);

        /// <summary>
        /// Converts a <see cref="string"/> into a <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">Number as a <see cref="string"/> ('46e-9', '5.6', '1,4E-05', etc...).</param>
        /// <param name="culture">Current culture of <paramref name="value"/>.</param>
        /// <returns>Returns the parsed <paramref name="value"/> as a <see cref="decimal"/>. If the conversion fails, returns <see cref="decimal.Zero"/>.</returns>
        public static decimal ToDecimal(this string value, CultureInfo culture = null)
        {
            if (culture == null)
            {
                culture = CultureInfo.InvariantCulture;
                value = value.Replace(",", ".");
            }

            if (StringHelper.IsNotEmpty(value))
            {
                if (decimal.TryParse(value, NumberStyles.Float, culture, out decimal valueAsDecimal))
                {
                    return valueAsDecimal;
                }
            }

            return decimal.Zero;
        }

        /// <summary>
        /// Converts a <see cref="string"/> into a <see cref="double"/>.
        /// </summary>
        /// <param name="value">Number as a <see cref="string"/> ('46e-9', '5.6', '1,4E-05', etc...).</param>
        /// <param name="culture">Current culture of <paramref name="value"/>.</param>
        /// <returns>Returns the parsed <paramref name="value"/> as a <see cref="double"/>. If the conversion fails, returns 0.0d.</returns>
        public static double ToDouble(this string value, CultureInfo culture)
        {
            if (culture == null)
            {
                culture = CultureInfo.InvariantCulture;
                value = value.Replace(",", ".");
            }

            if (StringHelper.IsNotEmpty(value))
            {
                if (double.TryParse(value, NumberStyles.Float, culture, out double valuesAsDouble))
                {
                    return valuesAsDouble;
                }
            }

            return 0.0d;
        }

        /// <summary>
        /// Converts a <see cref="string"/> into a <see cref="int"/>.
        /// </summary>
        /// <param name="value">Number as a <see cref="string"/>.</param>
        /// <returns>The partsed <paramref name="value"/> as a <see cref="int"/>. If the conversion fails, returns 0.</returns>
        public static int ToInt(this string value)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }

            return 0;
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
        /// Checks if <paramref name="value"/> is in the range of <paramref name="minValue"/> and <paramref name="maxValue"/>. Setting <paramref name="inclusive"/> to true will also include <paramref name="minValue"/> and <paramref name="maxValue"/> in the verification.
        /// </summary>
        /// <typeparam name="T">Supported types: <see cref="long"/>, <see cref="int"/>, <see cref="short"/>, <see cref="byte"/>,
        /// <see cref="float"/>, <see cref="double"/>, <see cref="decimal"/>.</typeparam>
        /// <param name="value">The value to be checked on.</param>
        /// <param name="minValue">Minimum value.</param>
        /// <param name="maxValue">Maximum value.</param>
        /// <param name="inclusive">Set to true to include <paramref name="minValue"/> and <paramref name="maxValue"/> in the verification.</param>
        /// <returns>True if <paramref name="value"/> is between <paramref name="minValue"/> and <paramref name="maxValue"/>. Otherwise returns false.</returns>
        [Obsolete("Please use the method IsBetween", true)]
        public static bool Between<T>(T value, T minValue, T maxValue, bool inclusive = true)
        {
           return IsBetween(value, minValue, maxValue, inclusive);
        }

        /// <summary>
        /// Checks if <paramref name="value"/> is in the range of <paramref name="minValue"/> and <paramref name="maxValue"/>. Setting <paramref name="inclusive"/> to true will also include <paramref name="minValue"/> and <paramref name="maxValue"/> in the verification.
        /// </summary>
        /// <typeparam name="T">Supported types: <see cref="long"/>, <see cref="int"/>, <see cref="short"/>, <see cref="byte"/>,
        /// <see cref="float"/>, <see cref="double"/>, <see cref="decimal"/>.</typeparam>
        /// <param name="value">The value to be checked on.</param>
        /// <param name="minValue">Minimum value.</param>
        /// <param name="maxValue">Maximum value.</param>
        /// <param name="inclusive">Set to true to include <paramref name="minValue"/> and <paramref name="maxValue"/> in the verification.</param>
        /// <returns>True if <paramref name="value"/> is between <paramref name="minValue"/> and <paramref name="maxValue"/>. Otherwise returns false.</returns>
        public static bool IsBetween<T>(this T value, T minValue, T maxValue, bool inclusive = true)
        {
            var currentType = typeof(T);

            if (currentType == longType)
            {
                var val = Convert.ToInt64(value);
                var valMin = Convert.ToInt64(minValue);
                var valMax = Convert.ToInt64(maxValue);

                return inclusive ? val >= valMin && val <= valMax : val > valMin && val < valMax;
            }

            if (currentType == intType)
            {
                var val = Convert.ToInt32(value);
                var valMin = Convert.ToInt32(minValue);
                var valMax = Convert.ToInt32(maxValue);

                return inclusive ? val >= valMin && val <= valMax : val > valMin && val < valMax;
            }

            if (currentType == shortType)
            {
                var val = Convert.ToInt16(value);
                var valMin = Convert.ToInt16(minValue);
                var valMax = Convert.ToInt16(maxValue);

                return inclusive ? val >= valMin && val <= valMax : val > valMin && val < valMax;
            }

            if (currentType == byteType)
            {
                var val = Convert.ToByte(value);
                var valMin = Convert.ToByte(minValue);
                var valMax = Convert.ToByte(maxValue);

                return inclusive ? val >= valMin && val <= valMax : val > valMin && val < valMax;
            }

            if (currentType == floatType)
            {
                var val = Convert.ToSingle(value);
                var valMin = Convert.ToSingle(minValue);
                var valMax = Convert.ToSingle(maxValue);

                return inclusive ? val >= valMin && val <= valMax : val > valMin && val < valMax;
            }

            if (currentType == doubleType)
            {
                var val = Convert.ToDouble(value);
                var valMin = Convert.ToDouble(minValue);
                var valMax = Convert.ToDouble(maxValue);

                return inclusive ? val >= valMin && val <= valMax : val > valMin && val < valMax;
            }

            if (currentType == decimalType)
            {
                var val = Convert.ToDecimal(value);
                var valMin = Convert.ToDecimal(minValue);
                var valMax = Convert.ToDecimal(maxValue);

                return inclusive ? val >= valMin && val <= valMax : val > valMin && val < valMax;
            }

            throw new NotImplementedException("The type of " + typeof(T) + " is not supported.");
        }

        /// <summary>
        /// Checks if <paramref name="value"/> is null or is a zero.
        /// </summary>
        /// <typeparam name="T">Supported types: <see cref="long"/>, <see cref="int"/>, <see cref="short"/>, <see cref="byte"/>,
        /// <see cref="float"/>, <see cref="double"/>, <see cref="decimal"/>.</typeparam>
        /// <param name="value">Numeric value to be checked.</param>
        /// <returns>True if <paramref name="value"/> is null or zero, otherwise it returns false.</returns>
        public static bool IsNullOrZero<T>(this T value)
        {
            if (value == null)
            {
                return true;
            }

            if (typeof(T) == typeof(byte) || typeof(T) == typeof(byte?))
            {
                byte? valueOfT = (byte?)Convert.ChangeType(value, typeof(byte?));

                return valueOfT == 0;
            }

            if (typeof(T) == typeof(short) || typeof(T) == typeof(short?))
            {
                short? valueOfT = (short?)Convert.ChangeType(value, typeof(short?));

                return valueOfT == 0;
            }

            if (typeof(T) == typeof(int) || typeof(T) == typeof(int?))
            {
                int? valueOfT = (int?)Convert.ChangeType(value, typeof(int?));

                return valueOfT == 0;
            }

            if (typeof(T) == typeof(long) || typeof(T) == typeof(long?))
            {
                long? valueOfT = (long?)Convert.ChangeType(value, typeof(long?));

                return valueOfT == 0;
            }

            if (typeof(T) == typeof(float) || typeof(T) == typeof(float?))
            {
                float? valueOfT = (float?)Convert.ChangeType(value, typeof(float?));

                return valueOfT == 0;
            }

            if (typeof(T) == typeof(double) || typeof(T) == typeof(double?))
            {
                double? valueOfT = (double?)Convert.ChangeType(value, typeof(double?));

                return valueOfT == 0;
            }

            if (typeof(T) == typeof(decimal) || typeof(T) == typeof(decimal?))
            {
                decimal valueOfT = (decimal)Convert.ChangeType(value, typeof(decimal));

                return valueOfT == 0;
            }

            return false;
        }

        /// <summary>
        /// Checks if <paramref name="value"/> is <b>not</b> null or zero.
        /// </summary>
        /// <typeparam name="T">Supported types: <see cref="long"/>, <see cref="int"/>, <see cref="short"/>, <see cref="byte"/>,
        /// <see cref="float"/>, <see cref="double"/>, <see cref="decimal"/>.</typeparam>
        /// <param name="value">Numeric value to be checked.</param>
        /// <returns>True if <paramref name="value"/> is <b>not</b> null or zero, otherwise it returns false.</returns>
        public static bool IsNotNullOrZero<T>(this T value)
        {
            return !value.IsNullOrZero();
        }
    }
}
