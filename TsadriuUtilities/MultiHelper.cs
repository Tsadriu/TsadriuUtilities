// <copyright file MultiHelper.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace TsadriuUtilities
{
    /// <summary>
    /// A class that helps on dealing with multiple things.
    /// </summary>
    public static class MultiHelper
    {
        private static readonly Type dateType = typeof(DateTime);
        private static readonly Type dateNullType = typeof(DateTime?);
        private static readonly Type longType = typeof(long);
        private static readonly Type longNullType = typeof(long?);
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
        public static T ClampValue<T>(this T currentValue, T minValue, T maxValue)
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
        /// Checks if all <paramref name="objects"/> are not null. If all of <paramref name="objects"/> are not null, returns true. Otherwise returns false.
        /// </summary>
        /// <typeparam name="T">The base item type.</typeparam>
        /// <param name="objects">Objects to check if they're not null.</param>
        /// <returns>True if all <paramref name="objects"/> <b>are not null</b>. If even one of <paramref name="objects"/> is null, returns false.</returns>
        public static bool AreNotNull<T>(params T[] objects)
        {
            foreach (var currentObject in objects)
            {
                if (currentObject == null)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Generates a <see cref="Guid"/> based on <paramref name="value"/>.
        /// </summary>
        /// <param name="value">Value to generate a <see cref="Guid"/>.</param>
        /// <returns>Instance of <see cref="Guid"/>.</returns>
        public static Guid GenerateGuid(this string value)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(value));
            return new Guid(hash);
        }

        /// <summary>
        /// Checks if <paramref name="value"/> is in the range of <paramref name="minValue"/> and <paramref name="maxValue"/>. Setting <paramref name="inclusive"/> to true will also include <paramref name="minValue"/> and <paramref name="maxValue"/> in the verification.
        /// </summary>
        /// <typeparam name="T">Supported types: <see cref="DateTime"/>, <see cref="long"/>, <see cref="int"/>, <see cref="short"/>, <see cref="byte"/>,
        /// <see cref="float"/>, <see cref="double"/>, <see cref="decimal"/>.</typeparam>
        /// <param name="value">The value to be checked on.</param>
        /// <param name="minValue">Minimum value.</param>
        /// <param name="maxValue">Maximum value.</param>
        /// <param name="inclusive">Set to true to include <paramref name="minValue"/> and <paramref name="maxValue"/> in the verification.</param>
        /// <returns><b>True</b> if <paramref name="value"/> is between <paramref name="minValue"/> and <paramref name="maxValue"/>. If the <paramref name="value"/> is not between <paramref name="minValue"/> and/or <paramref name="maxValue"/> or either <paramref name="minValue"/> or <paramref name="maxValue"/> is null, it returns <b>false</b>.</returns>
        public static bool IsBetween<T>(this T value, T minValue, T maxValue, bool inclusive = true)
        {
            var currentType = typeof(T);

            if (currentType.IsEquivalentTo(dateType, dateNullType))
            {
                if (!AreNotNull(value, minValue, maxValue))
                {
                    Console.WriteLine($"One of the parameters was null:\nDate: {value}\nDateMin: {minValue}\nDateMax: {maxValue}");
                    return false;
                }

                var val = Convert.ToDateTime(value);
                var valMin = Convert.ToDateTime(minValue);
                var valMax = Convert.ToDateTime(maxValue);

                return inclusive ? val >= valMin && val <= valMax : val > valMin && val < valMax;
            }

            if (currentType.IsEquivalentTo(longType, longNullType))
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
        /// Determines whether <paramref name="type"/> is equivalent to any <paramref name="validTypes"/>.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="validTypes">The valid types to check on <paramref name="type"/>.</param>
        /// <returns>° <b>True</b> if <paramref name="type"/> is found in <paramref name="validTypes"/>.<br/>
        /// ° <b>False</b> if <paramref name="type"/> is <b>not</b> found in <paramref name="validTypes"/>.</returns>
        public static bool IsEquivalentTo(this Type type, params Type[] validTypes)
        {
            foreach (var validType in validTypes)
            {
                if (type.IsEquivalentTo(validType))
                {
                    return true;
                }
            }

            return false;
        }
    }
}