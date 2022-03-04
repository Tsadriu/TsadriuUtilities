// <copyright file MultiHelper.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>
using System;

namespace TsadriuUtilities
{
    /// <summary>
    /// A class that helps on dealing with multiple things.
    /// </summary>
    public static class MultiHelper
    {
        private static readonly Type dateType = typeof(DateTime);
        private static readonly Type longType = typeof(long);
        private static readonly Type intType = typeof(int);
        private static readonly Type shortType = typeof(short);
        private static readonly Type byteType = typeof(byte);
        private static readonly Type floatType = typeof(float);
        private static readonly Type doubleType = typeof(double);
        private static readonly Type decimalType = typeof(decimal);

        /// <summary>
        /// Clamps a value based on its' parameters. Returns <paramref name="maxValue"/> if <paramref name="currentValue"/> is higher than it and returns <paramref name="minValue"/> if it is lower than it.
        /// Supported types:
        /// <see cref="DateTime"/>,
        /// <see cref="long"/>, <see cref="int"/>, <see cref="short"/>, <see cref="byte"/>,
        /// <see cref="float"/>, <see cref="double"/>, <see cref="decimal"/>.
        /// </summary>
        /// <param name="currentValue">Current value.</param>
        /// <param name="minValue">Minimum value that the <paramref name="currentValue"/> cannot succeed.</param>
        /// <param name="maxValue">Maximum value that the <paramref name="currentValue"/> cannot succeed.</param>
        /// <returns>Returns the clamped result of the operation.</returns>
        /// <exception cref="NotImplementedException">Throws <see cref="NotImplementedException"/> if trying to call this method with an unsupported <see cref="Type"/>.</exception>
        public static T ClampValue<T>(T currentValue, T minValue, T maxValue)
        {
            var currentType = typeof(T);

            if (currentType == dateType)
            {
                var val = Convert.ToDateTime(currentValue);
                var valMin = Convert.ToDateTime(minValue);
                var valMax = Convert.ToDateTime(maxValue);

                return (T)Convert.ChangeType(val > valMax ? valMax : val < valMin ? valMin : val, typeof(T));
            }

            if (currentType == longType)
            {
                var val = Convert.ToInt64(currentValue);
                var valMin = Convert.ToInt64(minValue);
                var valMax = Convert.ToInt64(maxValue);

                return (T)Convert.ChangeType(val > valMax ? valMax : val < valMin ? valMin : val, typeof(T));
            }

            if (currentType == intType)
            {
                var val = Convert.ToInt32(currentValue);
                var valMin = Convert.ToInt32(minValue);
                var valMax = Convert.ToInt32(maxValue);

                return (T)Convert.ChangeType(val > valMax ? valMax : val < valMin ? valMin : val, typeof(T));
            }

            if (currentType == shortType)
            {
                var val = Convert.ToInt16(currentValue);
                var valMin = Convert.ToInt16(minValue);
                var valMax = Convert.ToInt16(maxValue);

                return (T)Convert.ChangeType(val > valMax ? valMax : val < valMin ? valMin : val, typeof(T));
            }

            if (currentType == byteType)
            {
                var val = Convert.ToByte(currentValue);
                var valMin = Convert.ToByte(minValue);
                var valMax = Convert.ToByte(maxValue);

                return (T)Convert.ChangeType(val > valMax ? valMax : val < valMin ? valMin : val, typeof(T));
            }

            if (currentType == floatType)
            {
                var val = Convert.ToSingle(currentValue);
                var valMin = Convert.ToSingle(minValue);
                var valMax = Convert.ToSingle(maxValue);

                return (T)Convert.ChangeType(val > valMax ? valMax : val < valMin ? valMin : val, typeof(T));
            }

            if (currentType == doubleType)
            {
                var val = Convert.ToDouble(currentValue);
                var valMin = Convert.ToDouble(minValue);
                var valMax = Convert.ToDouble(maxValue);

                return (T)Convert.ChangeType(val > valMax ? valMax : val < valMin ? valMin : val, typeof(T));
            }

            if (currentType == decimalType)
            {
                var val = Convert.ToDecimal(currentValue);
                var valMin = Convert.ToDecimal(minValue);
                var valMax = Convert.ToDecimal(maxValue);

                return (T)Convert.ChangeType(val > valMax ? valMax : val < valMin ? valMin : val, typeof(T));
            }

            throw new NotImplementedException("The type of " + typeof(T) + " is not supported.");
        }

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
        public static string ArrayToString<T>(T[] array, string separator = " ")
        {
            return string.Join(separator, array);
        }
    }
}