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
        /// <returns>Date with the last day of the month.</returns>
        public static DateTime GetLastDayOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// Sets the <paramref name="day"/> in the <paramref name="date"/>.
        /// </summary>
        /// <param name="date">Current date.</param>
        /// <param name="day">Day to set. In case <paramref name="day"/> is higher than the month's max days, it will be clamped.</param>
        /// <returns>Date with the specified <paramref name="day"/>.</returns>
        public static DateTime SetDay(this DateTime date, int day)
        {
            int clampedDay = day.ClampValue(DateTime.MinValue.Day, DateTime.DaysInMonth(date.Year, date.Month));
            return new DateTime(date.Year, date.Month, clampedDay);
        }

        /// <summary>
        /// Sets the <paramref name="month"/> in the <paramref name="date"/>.
        /// </summary>
        /// <param name="date">Current date.</param>
        /// <param name="month">Month to set. In case <paramref name="month"/> is higher than the year's max months, it will be clamped.</param>
        /// <returns>Date with the specified <paramref name="month"/>.</returns>
        public static DateTime SetMonth(this DateTime date, int month)
        {
            int clampedMonth = month.ClampValue(DateTime.MinValue.Month, DateTime.MaxValue.Month);
            return new DateTime(date.Year, clampedMonth, 1).SetDay(date.Day);
        }

        /// <summary>
        /// Sets the <paramref name="year"/> in the <paramref name="date"/>.
        /// </summary>
        /// <param name="date">Current date.</param>
        /// <param name="year">Year to set.</param>
        /// <returns>Date with the specified <paramref name="year"/>.</returns>
        public static DateTime SetYear(this DateTime date, int year)
        {
            int clampedYear = year.ClampValue(DateTime.MinValue.Year, DateTime.MaxValue.Year);
            return new DateTime(clampedYear, 1, 1).SetMonth(date.Month).SetDay(date.Day);
        }
    }
}
