// <copyright file DateTimeHelper.cs of solution TsadriuUtilities of developer Tsadriu>
// Copyright 2022 (C) Tsadriu. All rights reserved.
// </copyright>
using System;
using System.Globalization;

namespace TsadriuUtilities
{
    /// <summary>
    /// A class that helps on dealing with <see cref="DateTime"/>.
    /// </summary>
    public static class DateTimeHelper
    {
        /// <summary>
        /// Tries to convert a date from a <see cref="string"/> to a type of <see cref="DateTime"/>. If the conversion fails and <paramref name="canReturnNull"/> is true, returns null, otherwise returns <see cref="DateTime.MinValue"/>.
        /// </summary>
        /// <param name="dateAsString">The date as a <see cref="string"/>. Examples: "23/03/2012", "11-02-2001", "06.12.2019".</param>
        /// <param name="dateFormats">The date format. Examples: "dd/MM/yyyy", "MM/dd/yyyy".</param>
        /// <param name="dateCulture">The <see cref="CultureInfo"/> of the date (Is it an american date? Is it an italian date?). Default: <see cref="CultureInfo.InvariantCulture"/>.</param>
        /// <param name="canReturnNull">True to return a null if the conversion fails. Otherwise false to return a <see cref="DateTime.MinValue"/>.</param>
        /// <returns>If the parsing was successful, returns <see cref="DateTime"/>. If the parsing fails and <paramref name="canReturnNull"/> is true, returns null, otherwise returns <see cref="DateTime.MinValue"/>.</returns>
        [Obsolete("Method will be removed in 1.0.16. Please use method ToDateTime instead.", true)]
        public static DateTime? StringToDate(this string dateAsString, string[] dateFormats, CultureInfo dateCulture = null, bool canReturnNull = false)
        {
            return canReturnNull ? null : ToDateTime(dateAsString, dateFormats, dateCulture);
        }

        /// <inheritdoc cref="StringToDate(string, string[], CultureInfo, bool)"/>
        [Obsolete("Method will be removed in 1.0.16. Please use method ToDateTime instead.", true)]
        public static DateTime? StringToDate(this string dateAsString, string dateFormat, CultureInfo dateCulture = null, bool canReturnNull = false)
        {
            return StringToDate(dateAsString, new string[] { dateFormat }, dateCulture, canReturnNull);
        }

        /// <summary>
        /// Tries to convert a date from a <see cref="string"/> to a type of <see cref="DateTime"/>.
        /// </summary>
        /// <param name="dateAsString">The date as a <see cref="string"/>. Examples: "23/03/2012", "11-02-2001", "06.12.2019".</param>
        /// <param name="dateFormat">The date format. Examples: "dd/MM/yyyy", "MM/dd/yyyy".</param>
        /// <param name="dateCulture">The <see cref="CultureInfo"/> of the date (Is it an american date? Is it an italian date?).</param>
        /// <returns>If the parsing was successful, returns <see cref="DateTime"/>. If the parsing fails, returns <see cref="DateTime.MinValue"/>.</returns>
        public static DateTime ToDateTime(this string dateAsString, string dateFormat, CultureInfo dateCulture = null)
        {
            return ToDateTime(dateAsString, new string[] { dateFormat }, dateCulture);
        }

        /// <summary>
        /// Tries to convert a date from a <see cref="string"/> to a type of <see cref="DateTime"/>.
        /// </summary>
        /// <param name="dateAsString">The date as a <see cref="string"/>. Examples: "23/03/2012", "11-02-2001", "06.12.2019".</param>
        /// <param name="dateFormats">The date format. The more formats are passed, the more parses the program will try to do.</param>
        /// <param name="dateCulture">The <see cref="CultureInfo"/> of the date (Is it an american date? Is it an italian date?).</param>
        /// <returns>If the parsing was successful, returns <see cref="DateTime"/>. If the parsing fails, returns <see cref="DateTime.MinValue"/>.</returns>
        public static DateTime ToDateTime(this string dateAsString, string[] dateFormats, CultureInfo dateCulture = null)
        {
            if (dateCulture == null)
            {
                dateCulture = CultureInfo.InvariantCulture;
            }

            if (dateAsString.IsEmpty())
            {
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
            return dateValue;
        }

        /// <summary>
        /// Parses the date to return with the last day of the month.
        /// </summary>
        /// <param name="date">Date to be checked on.</param>
        /// <returns>Returns the date with the last day of the month.</returns>
        public static DateTime GetLastDayOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);
        }
    }
}
