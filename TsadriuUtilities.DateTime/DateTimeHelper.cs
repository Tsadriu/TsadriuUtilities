// Author: Tsadriu
// Date: 11/06/2023

using System;
using System.Globalization;

namespace TsadriuUtilities
{
    /// <summary>
    /// Class that helps on manipulating and managing <b><see cref="DateTime"/></b> types.
    /// </summary>
    public static class DateTimeHelper
    {
        /// <summary>
        /// All of the date styles possible from the <b><see cref="DateTimeStyles"/></b> enum.
        /// </summary>
        private static readonly Array dateStyles = Enum.GetValues(typeof(DateTimeStyles));

        /// <summary>
        /// Attempts to convert a date from a <see cref="string"/> to a <see cref="DateTime"/> object.
        /// </summary>
        /// <param name="date">The date represented as a <see cref="string"/>.<br/>
        /// Examples: "23/03/2012", "11-02-2001 23:12:04", "06.12.2019".</param>
        /// <param name="cultureInfo">The <see cref="CultureInfo"/> of the date.</param>
        /// <param name="dateTimeStyle">The date time style of the date.</param>
        /// <param name="formats">The date formats to use for parsing.<br/>
        /// Examples: "dd/MM/yyyy", "MM/dd/yyyy".</param>
        /// <returns>If the parsing was successful, returns the parsed <see cref="DateTime"/> object.<br/>
        /// If the parsing fails, an <see cref="ArgumentException"/> is thrown.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="date"/> is null or empty.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="date"/> could not be converted into a <see cref="DateTime"/> object.</exception>
        public static DateTime ToDateTime(this string date, CultureInfo cultureInfo, DateTimeStyles? dateTimeStyle, params string[] formats)
        {
            if (string.IsNullOrWhiteSpace(date))
            {
                throw new ArgumentNullException(nameof(date), "The date cannot be empty.");
            }

            Array currentDateStyles = dateTimeStyle == null ? dateStyles : new[] { dateTimeStyle };

            foreach (string format in formats)
            {
                foreach (DateTimeStyles dateStyle in currentDateStyles)
                {
                    if (DateTime.TryParseExact(date, format, cultureInfo, dateStyle, out DateTime result))
                    {
                        return result;
                    }
                }
            }

            throw new ArgumentException($"Could not parse the date '{date}'. Please check if the format of the date is provided in the formats parameter.");
        }

        /// <summary>
        /// Attempts to convert a date from a <see cref="string"/> to a <see cref="DateTime"/> object.
        /// </summary>
        /// <param name="date">The date represented as a <see cref="string"/>.<br/>
        /// Examples: "23/03/2012", "11-02-2001 23:12:04", "06.12.2019".</param>
        /// <param name="cultureInfo">The <see cref="CultureInfo"/> of the date.</param>
        /// <param name="formats">The date formats to use for parsing.<br/>
        /// Examples: "dd/MM/yyyy", "MM/dd/yyyy".</param>
        /// <returns>If the parsing was successful, returns the parsed <see cref="DateTime"/> object.<br/>
        /// If the parsing fails, an <see cref="ArgumentException"/> is thrown.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="date"/> is null or empty.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="date"/> could not be converted into a <see cref="DateTime"/> object.</exception>
        public static DateTime ToDateTime(this string date, CultureInfo cultureInfo, params string[] formats) => date.ToDateTime(cultureInfo, null, formats);

        /// <summary>
        /// Attempts to convert a date from a <see cref="string"/> to a <see cref="DateTime"/> object.<br/>
        /// <b><see cref="CultureInfo.InvariantCulture"/></b> will be used for the culture.
        /// </summary>
        /// <param name="date">The date represented as a <see cref="string"/>.<br/>
        /// Examples: "23/03/2012", "11-02-2001 23:12:04", "06.12.2019".</param>
        /// <param name="formats">The date formats to use for parsing.<br/>
        /// Examples: "dd/MM/yyyy", "MM/dd/yyyy".</param>
        /// <returns>If the parsing was successful, returns the parsed <see cref="DateTime"/> object.<br/>
        /// If the parsing fails, an <see cref="ArgumentException"/> is thrown.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="date"/> is null or empty.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="date"/> could not be converted into a <see cref="DateTime"/> object.</exception>
        public static DateTime ToDateTime(this string date, params string[] formats) => date.ToDateTime(CultureInfo.InvariantCulture, null, formats);
        
        /// <summary>
        /// Attempts to convert a date from a <see cref="string"/> to a nullable <see cref="DateTime"/>.
        /// </summary>
        /// <param name="date">The date represented as a <see cref="string"/>.<br/>
        /// Examples: "23/03/2012", "11-02-2001 23:12:04", "06.12.2019".</param>
        /// <param name="cultureInfo">The <see cref="CultureInfo"/> of the date.</param>
        /// <param name="dateTimeStyle">The date time style of the date.</param>
        /// <param name="formats">The date formats to use for parsing.<br/>
        /// Examples: "dd/MM/yyyy", "MM/dd/yyyy".</param>
        /// <returns>If the parsing was successful, returns the parsed <see cref="DateTime"/> object.<br/>
        /// If the parsing fails (or the <paramref name="date"/> parameter is null or empty), it returns null.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="date"/> is null or empty.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="date"/> could not be converted into a <see cref="DateTime"/> object.</exception>
        public static DateTime? ToNullableDateTime(this string date, CultureInfo cultureInfo, DateTimeStyles? dateTimeStyle, params string[] formats)
        {
            if (string.IsNullOrWhiteSpace(date))
            {
                return null;
            }

            Array currentDateStyles = dateTimeStyle == null ? dateStyles : new[] { dateTimeStyle };

            foreach (string format in formats)
            {
                foreach (DateTimeStyles dateStyle in currentDateStyles)
                {
                    if (DateTime.TryParseExact(date, format, cultureInfo, dateStyle, out DateTime result))
                    {
                        return result;
                    }
                }
            }

            return null;
        }
        
        /// <summary>
        /// Attempts to convert a date from a <see cref="string"/> to a nullable <see cref="DateTime"/>.
        /// </summary>
        /// <param name="date">The date represented as a <see cref="string"/>.<br/>
        /// Examples: "23/03/2012", "11-02-2001 23:12:04", "06.12.2019".</param>
        /// <param name="cultureInfo">The <see cref="CultureInfo"/> of the date.</param>
        /// <param name="formats">The date formats to use for parsing.<br/>
        /// Examples: "dd/MM/yyyy", "MM/dd/yyyy".</param>
        /// <returns>If the parsing was successful, returns the parsed <see cref="DateTime"/> object.<br/>
        /// If the parsing fails (or the <paramref name="date"/> parameter is null or empty), it returns null.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="date"/> is null or empty.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="date"/> could not be converted into a <see cref="DateTime"/> object.</exception>
        public static DateTime? ToNullableDateTime(this string date, CultureInfo cultureInfo, params string[] formats) => date.ToNullableDateTime(cultureInfo, null, formats);
        
        /// <summary>
        /// Attempts to convert a date from a <see cref="string"/> to a nullable <see cref="DateTime"/>.<br/>
        /// <b><see cref="CultureInfo.InvariantCulture"/></b> will be used for the culture.
        /// </summary>
        /// <param name="date">The date represented as a <see cref="string"/>.<br/>
        /// Examples: "23/03/2012", "11-02-2001 23:12:04", "06.12.2019".</param>
        /// <param name="formats">The date formats to use for parsing.<br/>
        /// Examples: "dd/MM/yyyy", "MM/dd/yyyy".</param>
        /// <returns>If the parsing was successful, returns the parsed <see cref="DateTime"/> object.<br/>
        /// If the parsing fails (or the <paramref name="date"/> parameter is null or empty), it returns null.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="date"/> is null or empty.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="date"/> could not be converted into a <see cref="DateTime"/> object.</exception>
        public static DateTime? ToNullableDateTime(this string date, params string[] formats) => date.ToNullableDateTime(CultureInfo.InvariantCulture, null, formats);

        /// <summary>
        /// Parses the date to return with the last day of the month.
        /// </summary>
        /// <param name="date">Date to be checked on.</param>
        /// <returns>Date with the last day of the month.</returns>
        public static DateTime GetLastDayOfMonth(this DateTime date) => new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);

        /// <summary>
        /// Sets the <b><paramref name="day"/></b> of the month in the specified <b><paramref name="date"/></b>.
        /// </summary>
        /// <param name="date">Current date.</param>
        /// <param name="day">The day to set. If the specified <b><paramref name="day"/></b> is higher than the maximum number of days in the month, it will be clamped to the maximum day of the month.</param>
        /// <returns>A new DateTime instance with the specified <paramref name="day"/> and the remaining date components from the original date.</returns>
        public static DateTime SetDay(this DateTime date, int day)
        {
            int clampedDay = day <= DateTime.MinValue.Day ? DateTime.MinValue.Day : day >= DateTime.DaysInMonth(date.Year, date.Month) ? DateTime.DaysInMonth(date.Year, date.Month) : day;
            return new DateTime(date.Year, date.Month, clampedDay);
        }

        /// <summary>
        /// Sets the <paramref name="month"/> of the year in the <paramref name="date"/>.
        /// </summary>
        /// <param name="date">Current date.</param>
        /// <param name="month">The month to set. If the specified <paramref name="month"/> is higher than the maximum number of months in a year, it will be clamped to the maximum month of the year.</param>
        /// <returns>A new DateTime instance with the specified <paramref name="month"/> and the remaining date components from the original date.</returns>
        public static DateTime SetMonth(this DateTime date, int month)
        {
            int clampedMonth = month <= DateTime.MinValue.Month ? DateTime.MinValue.Month : month >= DateTime.MaxValue.Month ? DateTime.MaxValue.Month : month;
            return new DateTime(date.Year, clampedMonth, 1).SetDay(date.Day);
        }

        /// <summary>
        /// Sets the <paramref name="year"/> in the specified <paramref name="date"/>.
        /// </summary>
        /// <param name="date">Current date.</param>
        /// <param name="year">The year to set. It can be any valid year within the acceptable range (between <b><see cref="DateTime.MinValue"/></b> and <b><see cref="DateTime.MaxValue"/></b>).</param>
        /// <returns>A new DateTime instance with the specified <paramref name="year"/> and the remaining date components from the original date.</returns>
        public static DateTime SetYear(this DateTime date, int year)
        {
            int clampedYear = year <= DateTime.MinValue.Year ? DateTime.MinValue.Year : year >= DateTime.MaxValue.Year ? DateTime.MaxValue.Year : year;
            return new DateTime(clampedYear, 1, 1).SetMonth(date.Month).SetDay(date.Day);
        }

        /// <summary>
        /// Removes the specified number of days from the given <paramref name="date"/> and returns the resulting date.<br/>
        /// The <b><paramref name="days"/></b> parameter can be positive or negative, as the absolute value (<see cref="Math.Abs(int)"/>) is used and then converted to a negative value for subtraction.
        /// </summary>
        /// <param name="date">The original date.</param>
        /// <param name="days">The number of days to remove.</param>
        /// <returns>The resulting date after removing the specified number of days.</returns>
        public static DateTime RemoveDays(this DateTime date, int days) => date.AddDays(-Math.Abs(days));

        /// <summary>
        /// Removes the specified number of months from the given <paramref name="date"/> and returns the resulting date.<br/>
        /// The <b><paramref name="months"/></b> parameter can be positive or negative, as the absolute value (<see cref="Math.Abs(int)"/>) is used and then converted to a negative value for subtraction.
        /// </summary>
        /// <param name="date">The original date.</param>
        /// <param name="months">The number of months to remove.</param>
        /// <returns>The resulting date after removing the specified number of months.</returns>
        public static DateTime RemoveMonths(this DateTime date, int months) => date.AddMonths(-Math.Abs(months));

        /// <summary>
        /// Removes the specified number of years from the given <paramref name="date"/> and returns the resulting date.<br/>
        /// The <b><paramref name="years"/></b> parameter can be positive or negative, as the absolute value (<see cref="Math.Abs(int)"/>) is used and then converted to a negative value for subtraction.
        /// </summary>
        /// <param name="date">The original date.</param>
        /// <param name="years">The number of years to remove.</param>
        /// <returns>The resulting date after removing the specified number of years.</returns>
        public static DateTime RemoveYears(this DateTime date, int years) => date.AddYears(-Math.Abs(years));
    }
}