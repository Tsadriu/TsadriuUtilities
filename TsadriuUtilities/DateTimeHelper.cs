// <copyright file DateTimeHelper.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>
using System;
using System.Globalization;

namespace TsadriuUtilities
{
    /// <summary>
    /// A class that helps on dealing with Dates.
    /// </summary>
    public static class DateTimeHelper
    {
        /// <summary>
        /// Tries to convert a date from a <see cref="string"/> to a type of <see cref="DateTime"/>. If the conversion fails and <paramref name="canReturnNull"/> is true, returns null, otherwise returns <see cref="DateTime.MinValue"/>.
        /// </summary>
        /// <param name="dateAsString">The date as a <see cref="string"/>. Examples: "23/03/2012", "11-02-2001", "06.12.2019".</param>
        /// <param name="dateFormats">The date format. Examples: "dd/MM/yyyy", "MM/dd/yyyy".</param>
        /// <param name="dateCulture">The <see cref="CultureInfo"/> of the date (Is it an american date? Is it an italian date?).</param>
        /// <param name="canReturnNull">True to return a null if the conversion fails. Otherwise false to return a <see cref="DateTime.MinValue"/></param>
        /// <returns>If the parsing was successful, returns <see cref="DateTime"/>. If the parsing fails and <paramref name="canReturnNull"/> is true, returns null, otherwise returns <see cref="DateTime.MinValue"/>.</returns>
        public static DateTime? StringToDate(string dateAsString, string[] dateFormats, CultureInfo dateCulture, bool canReturnNull = false)
        {
            if (StrHelper.IsEmpty(dateAsString))
            {
                if (canReturnNull)
                {
                    return null;
                }

                Console.WriteLine("The date value is empty.");
                return DateTime.MinValue;
            }

            // Ignore the spaces in the date value.
            var dateStyle = DateTimeStyles.AllowWhiteSpaces;
            var dateValue = DateTime.MinValue;

            for (int i = 0; i < dateFormats.Length; i++)
            {
                var successConversion = DateTime.TryParseExact(dateAsString, dateFormats[i], dateCulture, dateStyle, out DateTime result);

                if (successConversion)
                {
                    return result;
                }
            }

            Console.WriteLine("No valid date format to parse the date '" + dateAsString + "'.");
            return canReturnNull ? null : dateValue;
        }

        /// <inheritdoc cref="StringToDate(string, string[], CultureInfo, bool)"/>
        public static DateTime? StringToDate(string dateAsString, string dateFormat, CultureInfo dateCulture, bool canReturnNull = false)
        {
            return StringToDate(dateAsString, new string[] { dateFormat }, dateCulture, canReturnNull);
        }

        /// <summary>
        /// Tries to convert a date from a <see cref="string"/> to a type of <see cref="DateTime"/> with culture <see cref="CultureInfo.InvariantCulture"/>. If the conversion fails and <paramref name="canReturnNull"/> is true, returns null, otherwise returns <see cref="DateTime.MinValue"/>.
        /// </summary>
        /// <param name="dateAsString">The date as a <see cref="string"/>. Examples: "23/03/2012", "11-02-2001", "06.12.2019".</param>
        /// <param name="dateFormats">The date format. Examples: "dd/MM/yyyy", "MM/dd/yyyy".</param>
        /// <param name="canReturnNull">True to return a null if the conversion fails. Otherwise false to return a <see cref="DateTime.MinValue"/></param>
        /// <returns>If the parsing was successful, returns <see cref="DateTime"/>. If the parsing fails and <paramref name="canReturnNull"/> is true, returns null, otherwise returns <see cref="DateTime.MinValue"/>.</returns>
        public static DateTime? StringToDate(string dateAsString, string[] dateFormats, bool canReturnNull = false)
        {
            return StringToDate(dateAsString, dateFormats, CultureInfo.InvariantCulture, canReturnNull);
        }

        /// <inheritdoc cref="StringToDate(string, string[], bool)"/>
        public static DateTime? StringToDate(string dateAsString, string dateFormat, bool canReturnNull = false)
        {
            return StringToDate(dateAsString, dateFormat, CultureInfo.InvariantCulture, canReturnNull);
        }
    }
}
