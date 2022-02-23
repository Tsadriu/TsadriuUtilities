// <copyright file Main.cs of solution TsadriuUtilities of developer Tsadriu>
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
            var dateType = typeof(DateTime);
            var longType = typeof(long);
            var intType = typeof(int);
            var shortType = typeof(short);
            var byteType = typeof(byte);
            var floatType = typeof(float);
            var doubleType = typeof(double);
            var decimalType = typeof(decimal);

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
    }
}