using System.Globalization;
using TsadriuUtilities;

namespace Test
{
    public class DateTimeHelperTest
    {
        [Test]
        public void ToDateTime_WhenValidDateWithWeirdFormats_ReturnsParsedDateTime()
        {
            const string dateOne = "22.05.2023";
            var dateOneResult = dateOne.ToDateTime(CultureInfo.GetCultureInfoByIetfLanguageTag("it"), DateTimeStyles.None, "dd.MM.yyyy");
            Assert.That(dateOneResult, Is.EqualTo(new DateTime(2023, 5, 22)));

            const string dateTwo = "2076/23/10";
            var dateTwoResult = dateTwo.ToDateTime(CultureInfo.InvariantCulture, "yyyy/dd/MM");
            Assert.That(dateTwoResult, Is.EqualTo(new DateTime(2076, 10, 23)));

            const string dateThree = "2123@25@02";
            var dateThreeResult = dateThree.ToDateTime("yyyy@dd@MM");
            Assert.That(dateThreeResult, Is.EqualTo(new DateTime(2123, 2, 25)));
        }

        [Test]
        public void ToNullableDateTime_WhenValidDateWithWeirdFormats_ReturnsParsedDateTime()
        {
            const string dateOne = "22.05.2023#";
            DateTime? dateOneResult = dateOne.ToNullableDateTime(CultureInfo.GetCultureInfoByIetfLanguageTag("it"), "dd.MM.yyyy");
            Assert.That(dateOneResult, Is.EqualTo(null));

            const string dateTwo = "05202312";
            DateTime? dateTwoResult = dateTwo.ToNullableDateTime(CultureInfo.InvariantCulture, "ddyyyyMM");
            Assert.That(dateTwoResult, Is.EqualTo(new DateTime(2023, 12, 5)));

            const string dateThree = "31@4172@01";
            DateTime? dateThreeResult = dateThree.ToNullableDateTime("dd@yyyy@MM");
            Assert.That(dateThreeResult, Is.EqualTo(new DateTime(4172, 1, 31)));
        }

        [Test]
        public void GetLastDayOfMonth_ReturnsLastDaysOfMonth_ForEachMonth()
        {
            DateTime january = new DateTime(2023, 1, 1).GetLastDayOfMonth();
            DateTime february = january.AddMonths(1).GetLastDayOfMonth();
            DateTime march = january.AddMonths(2).GetLastDayOfMonth();
            DateTime april = january.AddMonths(3).GetLastDayOfMonth();
            DateTime may = january.AddMonths(4).GetLastDayOfMonth();
            DateTime june = january.AddMonths(5).GetLastDayOfMonth();
            DateTime july = january.AddMonths(6).GetLastDayOfMonth();
            DateTime august = january.AddMonths(7).GetLastDayOfMonth();
            DateTime september = january.AddMonths(8).GetLastDayOfMonth();
            DateTime october = january.AddMonths(9).GetLastDayOfMonth();
            DateTime november = january.AddMonths(10).GetLastDayOfMonth();
            DateTime december = january.AddMonths(11).GetLastDayOfMonth();

            Assert.Multiple(() =>
            {
                Assert.That(january, Is.EqualTo(new DateTime(2023, 1, 31)));
                Assert.That(february, Is.EqualTo(new DateTime(2023, 2, 28)));
                Assert.That(march, Is.EqualTo(new DateTime(2023, 3, 31)));
                Assert.That(april, Is.EqualTo(new DateTime(2023, 4, 30)));
                Assert.That(may, Is.EqualTo(new DateTime(2023, 5, 31)));
                Assert.That(june, Is.EqualTo(new DateTime(2023, 6, 30)));
                Assert.That(july, Is.EqualTo(new DateTime(2023, 7, 31)));
                Assert.That(august, Is.EqualTo(new DateTime(2023, 8, 31)));
                Assert.That(september, Is.EqualTo(new DateTime(2023, 9, 30)));
                Assert.That(october, Is.EqualTo(new DateTime(2023, 10, 31)));
                Assert.That(november, Is.EqualTo(new DateTime(2023, 11, 30)));
                Assert.That(december, Is.EqualTo(new DateTime(2023, 12, 31)));
            });
        }

        [Test]
        public void SetDay_ReturnsValidDay_ForSpecificMonth()
        {
            var dateOne = new DateTime(2023, 2, 1);

            // February does not have 30 days, let's see if the method works
            dateOne = dateOne.SetDay(30);

            Assert.That(dateOne, Is.EqualTo(new DateTime(2023, 2, 28)));

            var dateTwo = new DateTime(2023, 5, 1);
            dateTwo = dateTwo.SetDay(27);

            Assert.That(dateTwo, Is.EqualTo(new DateTime(2023, 5, 27)));

            var dateThree = new DateTime(2018, 2, 24);

            // Negative values should be clamped to 1.
            dateThree = dateThree.SetDay(-5);
            Assert.That(dateThree, Is.EqualTo(new DateTime(2018, 2, 1)));
        }

        [Test]
        public void SetMonth_ReturnsValidMonth_ForSpecificYear()
        {
            var dateOne = new DateTime(2023, 1, 1);

            // A year has 12 months, let's see if the method works
            dateOne = dateOne.SetMonth(13);

            Assert.That(dateOne, Is.EqualTo(new DateTime(2023, 12, 1)));

            var dateTwo = new DateTime(2023, 3, 1);
            dateTwo = dateTwo.SetMonth(5);

            Assert.That(dateTwo, Is.EqualTo(new DateTime(2023, 5, 1)));

            var dateThree = new DateTime(2018, 2, 24);

            // Negative values should be clamped to 1.
            dateThree = dateThree.SetMonth(-5);
            Assert.That(dateThree, Is.EqualTo(new DateTime(2018, 1, 24)));
        }

        [Test]
        public void SetYear_ReturnsValidYear_InRangeOfDateTimeMinAndMax()
        {
            var dateOne = new DateTime(2023, 2, 1);

            // Year cannot go above 9999, let's see if the method works
            dateOne = dateOne.SetYear(100000);

            Assert.That(dateOne, Is.EqualTo(new DateTime(9999, 2, 1)));

            var dateTwo = new DateTime(2023, 5, 1);
            dateTwo = dateTwo.SetYear(27);

            Assert.That(dateTwo, Is.EqualTo(new DateTime(27, 5, 1)));

            var dateThree = new DateTime(2018, 2, 24);

            // Negative values should be clamped to 1.
            dateThree = dateThree.SetYear(-5);
            Assert.That(dateThree, Is.EqualTo(new DateTime(1, 2, 24)));
        }

        [Test]
        public void RemoveDays_SubtractsCorrectAmountOfDays()
        {
            var dateOne = new DateTime(2023, 1, 1);
            dateOne = dateOne.RemoveDays(2);
            Assert.That(dateOne, Is.EqualTo(new DateTime(2022, 12, 30)));

            var dateTwo = new DateTime(2023, 5, 1);
            dateTwo = dateTwo.RemoveDays(-5);
            Assert.That(dateTwo, Is.EqualTo(new DateTime(2023, 4, 26)));
        }


        [Test]
        public void RemoveMonths_SubtractsCorrectAmountOfMonths()
        {
            var dateOne = new DateTime(2023, 2, 1);
            dateOne = dateOne.RemoveMonths(2);
            Assert.That(dateOne, Is.EqualTo(new DateTime(2022, 12, 1)));

            var dateTwo = new DateTime(2023, 3, 31);
            dateTwo = dateTwo.RemoveMonths(-1);
            Assert.That(dateTwo, Is.EqualTo(new DateTime(2023, 2, 28)));
        }


        [Test]
        public void RemoveYears_SubtractsCorrectAmountOfYears()
        {
            var dateOne = new DateTime(2023, 2, 1);
            dateOne = dateOne.RemoveYears(2);
            Assert.That(dateOne, Is.EqualTo(new DateTime(2021, 2, 1)));

            var dateTwo = new DateTime(2020, 2, 29);
            dateTwo = dateTwo.RemoveYears(-5);
            Assert.That(dateTwo, Is.EqualTo(new DateTime(2015, 2, 28)));
        }

        [Test]
        public void ToDateTime_WhenValidDate_ReturnsParsedDateTime()
        {
            // Arrange
            string date = "23/03/2012";
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            DateTimeStyles? dateTimeStyle = null;
            string[] formats = { "dd/MM/yyyy" };
            DateTime expectedDateTime = new DateTime(2012, 03, 23);

            // Act
            DateTime result = date.ToDateTime(cultureInfo, dateTimeStyle, formats);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDateTime));
        }

        [Test]
        public void ToDateTime_WhenValidDateTime_ReturnsParsedDateTime()
        {
            // Arrange
            string date = "11-02-2001 23:12:04";
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            DateTimeStyles? dateTimeStyle = null;
            string[] formats = { "dd-MM-yyyy HH:mm:ss" };
            DateTime expectedDateTime = new DateTime(2001, 02, 11, 23, 12, 04);

            // Act
            DateTime result = date.ToDateTime(cultureInfo, dateTimeStyle, formats);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDateTime));
        }

        [Test]
        public void ToDateTime_WhenValidDateWithCustomFormat_ReturnsParsedDateTime()
        {
            // Arrange
            string date = "06.12.2019";
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            DateTimeStyles? dateTimeStyle = null;
            string[] formats = { "dd.MM.yyyy" };
            DateTime expectedDateTime = new DateTime(2019, 12, 06);

            // Act
            DateTime result = date.ToDateTime(cultureInfo, dateTimeStyle, formats);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDateTime));
        }

        [Test]
        public void ToDateTime_WhenInvalidDateFormat_ThrowsArgumentException()
        {
            // Arrange
            string date = "2021/09/30";
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            DateTimeStyles? dateTimeStyle = null;
            string[] formats = { "dd-MM-yyyy" };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => date.ToDateTime(cultureInfo, dateTimeStyle, formats));
        }

        [Test]
        public void ToDateTime_WhenInvalidDateValue_ThrowsArgumentException()
        {
            // Arrange
            string date = "invalid-date";
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            DateTimeStyles? dateTimeStyle = null;
            string[] formats = { "dd-MM-yyyy" };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => date.ToDateTime(cultureInfo, dateTimeStyle, formats));
        }

        [Test]
        public void ToDateTime_WhenDateTimeStyleProvided_UsesProvidedDateTimeStyle()
        {
            // Arrange
            string date = "23/03/2012";
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            DateTimeStyles dateTimeStyle = DateTimeStyles.AllowLeadingWhite;
            string[] formats = { "dd/MM/yyyy" };
            DateTime expectedDateTime = new DateTime(2012, 03, 23);

            // Act
            DateTime result = date.ToDateTime(cultureInfo, dateTimeStyle, formats);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDateTime));
        }

        [Test]
        public void ToNullableDateTime_WhenValidDate_ReturnsParsedDateTime()
        {
            // Arrange
            string date = "23/03/2012";
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            DateTimeStyles? dateTimeStyle = null;
            string[] formats = { "dd/MM/yyyy" };
            DateTime? expectedDateTime = new DateTime(2012, 03, 23);

            // Act
            DateTime? result = date.ToNullableDateTime(cultureInfo, dateTimeStyle, formats);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDateTime));
        }

        [Test]
        public void ToNullableDateTime_WhenValidDateTime_ReturnsParsedDateTime()
        {
            // Arrange
            string date = "11-02-2001 23:12:04";
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            DateTimeStyles? dateTimeStyle = null;
            string[] formats = { "dd-MM-yyyy HH:mm:ss" };
            DateTime? expectedDateTime = new DateTime(2001, 02, 11, 23, 12, 04);

            // Act
            DateTime? result = date.ToNullableDateTime(cultureInfo, dateTimeStyle, formats);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDateTime));
        }

        [Test]
        public void ToNullableDateTime_WhenValidDateWithCustomFormat_ReturnsParsedDateTime()
        {
            // Arrange
            string date = "06.12.2019";
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            DateTimeStyles? dateTimeStyle = null;
            string[] formats = { "dd.MM.yyyy" };
            DateTime? expectedDateTime = new DateTime(2019, 12, 06);

            // Act
            DateTime? result = date.ToNullableDateTime(cultureInfo, dateTimeStyle, formats);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDateTime));
        }

        [Test]
        public void ToNullableDateTime_WhenInvalidDateFormat_ReturnsNull()
        {
            // Arrange
            string date = "2021/09/30";
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            DateTimeStyles? dateTimeStyle = null;
            string[] formats = { "dd-MM-yyyy" };

            // Act
            DateTime? result = date.ToNullableDateTime(cultureInfo, dateTimeStyle, formats);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void ToNullableDateTime_WhenInvalidDateValue_ReturnsNull()
        {
            // Arrange
            string date = "invalid-date";
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            DateTimeStyles? dateTimeStyle = null;
            string[] formats = { "dd-MM-yyyy" };

            // Act
            DateTime? result = date.ToNullableDateTime(cultureInfo, dateTimeStyle, formats);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void ToNullableDateTime_WhenDateTimeStyleProvided_UsesProvidedDateTimeStyle()
        {
            // Arrange
            string date = "23/03/2012";
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            DateTimeStyles dateTimeStyle = DateTimeStyles.AllowLeadingWhite;
            string[] formats = { "dd/MM/yyyy" };
            DateTime? expectedDateTime = new DateTime(2012, 03, 23);

            // Act
            DateTime? result = date.ToNullableDateTime(cultureInfo, dateTimeStyle, formats);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDateTime));
        }

        [Test]
        public void GetLastDayOfMonth_ReturnsLastDayOfMonth()
        {
            // Arrange
            DateTime date = new DateTime(2023, 6, 13);
            DateTime expectedLastDayOfMonth = new DateTime(2023, 6, 30);

            // Act
            DateTime result = date.GetLastDayOfMonth();

            // Assert
            Assert.That(result, Is.EqualTo(expectedLastDayOfMonth));
        }

        [Test]
        public void GetLastDayOfMonth_WhenLeapYear_ReturnsLastDayOfMonth()
        {
            // Arrange
            DateTime date = new DateTime(2024, 2, 15);
            DateTime expectedLastDayOfMonth = new DateTime(2024, 2, 29);

            // Act
            DateTime result = date.GetLastDayOfMonth();

            // Assert
            Assert.That(result, Is.EqualTo(expectedLastDayOfMonth));
        }

        [Test]
        public void SetDay_WithValidDay_ReturnsNewDateWithSpecifiedDay()
        {
            // Arrange
            DateTime date = new DateTime(2023, 6, 13);
            int day = 25;
            DateTime expectedDate = new DateTime(2023, 6, 25);

            // Act
            DateTime result = date.SetDay(day);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDate));
        }

        [Test]
        public void SetDay_WithDayLessThanMinimum_ReturnsNewDateWithMinimumDay()
        {
            // Arrange
            DateTime date = new DateTime(2023, 6, 13);
            int day = -3;
            DateTime expectedDate = new DateTime(2023, 6, 1);

            // Act
            DateTime result = date.SetDay(day);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDate));
        }

        [Test]
        public void SetDay_WithDayGreaterThanMaximum_ReturnsNewDateWithMaximumDay()
        {
            // Arrange
            DateTime date = new DateTime(2023, 6, 13);
            int day = 30;
            DateTime expectedDate = new DateTime(2023, 6, 30);

            // Act
            DateTime result = date.SetDay(day);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDate));
        }

        [Test]
        public void SetMonth_WithValidMonth_ReturnsNewDateWithSpecifiedMonth()
        {
            // Arrange
            DateTime date = new DateTime(2023, 6, 13);
            int month = 10;
            DateTime expectedDate = new DateTime(2023, 10, 13);

            // Act
            DateTime result = date.SetMonth(month);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDate));
        }

        [Test]
        public void SetMonth_WithMonthLessThanMinimum_ReturnsNewDateWithMinimumMonth()
        {
            // Arrange
            DateTime date = new DateTime(2023, 6, 13);
            int month = 1;
            DateTime expectedDate = new DateTime(2023, 1, 13);

            // Act
            DateTime result = date.SetMonth(month);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDate));
        }

        [Test]
        public void SetMonth_WithMonthGreaterThanMaximum_ReturnsNewDateWithMaximumMonth()
        {
            // Arrange
            DateTime date = new DateTime(2023, 6, 13);
            int month = 15;
            DateTime expectedDate = new DateTime(2023, 12, 13);

            // Act
            DateTime result = date.SetMonth(month);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDate));
        }

        [Test]
        public void SetYear_WithValidYear_ReturnsNewDateWithSpecifiedYear()
        {
            // Arrange
            DateTime date = new DateTime(2023, 6, 13);
            int year = 2025;
            DateTime expectedDate = new DateTime(2025, 6, 13);

            // Act
            DateTime result = date.SetYear(year);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDate));
        }

        [Test]
        public void SetYear_WithYearLessThanMinimum_ReturnsNewDateWithMinimumYear()
        {
            // Arrange
            DateTime date = new DateTime(2023, 6, 13);
            int year = DateTime.MinValue.Year;
            DateTime expectedDate = new DateTime(DateTime.MinValue.Year, 6, 13);

            // Act
            DateTime result = date.SetYear(year);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDate));
        }

        [Test]
        public void SetYear_WithYearGreaterThanMaximum_ReturnsNewDateWithMaximumYear()
        {
            // Arrange
            DateTime date = new DateTime(2023, 6, 13);
            int year = DateTime.MaxValue.Year;
            DateTime expectedDate = new DateTime(DateTime.MaxValue.Year, 6, 13);

            // Act
            DateTime result = date.SetYear(year);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDate));
        }

        [Test]
        public void RemoveDays_WithPositiveDays_ReturnsDateWithDaysRemoved()
        {
            // Arrange
            DateTime date = new DateTime(2023, 6, 13);
            int days = 5;
            DateTime expectedDate = new DateTime(2023, 6, 8);

            // Act
            DateTime result = date.RemoveDays(days);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDate));
        }

        [Test]
        public void RemoveDays_WithNegativeDays_ReturnsDateWithDaysRemoved()
        {
            // Arrange
            DateTime date = new DateTime(2023, 6, 13);
            int days = -5;
            DateTime expectedDate = new DateTime(2023, 6, 8);

            // Act
            DateTime result = date.RemoveDays(days);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDate));
        }

        [Test]
        public void RemoveDays_WithZeroDays_ReturnsSameDate()
        {
            // Arrange
            DateTime date = new DateTime(2023, 6, 13);
            int days = 0;
            DateTime expectedDate = new DateTime(2023, 6, 13);

            // Act
            DateTime result = date.RemoveDays(days);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDate));
        }

        [Test]
        public void RemoveMonths_WithPositiveMonths_ReturnsDateWithMonthsRemoved()
        {
            // Arrange
            DateTime date = new DateTime(2023, 6, 13);
            int months = 3;
            DateTime expectedDate = new DateTime(2023, 3, 13);

            // Act
            DateTime result = date.RemoveMonths(months);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDate));
        }

        [Test]
        public void RemoveMonths_WithNegativeMonths_ReturnsDateWithMonthsRemoved()
        {
            // Arrange
            DateTime date = new DateTime(2023, 6, 13);
            int months = -3;
            DateTime expectedDate = new DateTime(2023, 3, 13);

            // Act
            DateTime result = date.RemoveMonths(months);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDate));
        }

        [Test]
        public void RemoveMonths_WithZeroMonths_ReturnsSameDate()
        {
            // Arrange
            DateTime date = new DateTime(2023, 6, 13);
            int months = 0;
            DateTime expectedDate = new DateTime(2023, 6, 13);

            // Act
            DateTime result = date.RemoveMonths(months);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDate));
        }

        [Test]
        public void RemoveYears_WithPositiveYears_ReturnsDateWithYearsRemoved()
        {
            // Arrange
            DateTime date = new DateTime(2023, 6, 13);
            int years = 2;
            DateTime expectedDate = new DateTime(2021, 6, 13);

            // Act
            DateTime result = date.RemoveYears(years);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDate));
        }

        [Test]
        public void RemoveYears_WithNegativeYears_ReturnsDateWithYearsRemoved()
        {
            // Arrange
            DateTime date = new DateTime(2023, 6, 13);
            int years = -2;
            DateTime expectedDate = new DateTime(2021, 6, 13);

            // Act
            DateTime result = date.RemoveYears(years);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDate));
        }

        [Test]
        public void RemoveYears_WithZeroYears_ReturnsSameDate()
        {
            // Arrange
            DateTime date = new DateTime(2023, 6, 13);
            int years = 0;
            DateTime expectedDate = new DateTime(2023, 6, 13);

            // Act
            DateTime result = date.RemoveYears(years);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDate));
        }

        [Test]
        public void FromUnixTimeToDateTime_ConvertsCorrectly()
        {
            long unixTime = 1609459200;// January 1, 2021 UTC
            var expectedDateTime = new DateTime(2021, 1, 1, 0, 0, 0).ToLocalTime();

            var convertedDateTime = unixTime.FromUnixTimeToDateTime();

            Assert.AreEqual(expectedDateTime, convertedDateTime);
        }

        [Test]
        public void FromUnixTimeToDateTimeUtc_ConvertsCorrectly()
        {
            long unixTime = 1609459200;// January 1, 2021 UTC
            var expectedDateTime = new DateTime(2021, 1, 1, 0, 0, 0);

            var convertedDateTime = unixTime.FromUnixTimeToDateTimeUtc();

            Assert.AreEqual(expectedDateTime, convertedDateTime);
        }

        [Test]
        public void FromDateTimeToUnixTime_Utc_ConvertsCorrectly()
        {
            var dateTime = new DateTime(2021, 1, 1, 0, 0, 0);
            var expectedUnixTime = 1609459200;

            var convertedUnixTime = dateTime.FromDateTimeToUnixTimeUtc();

            Assert.AreEqual(expectedUnixTime, convertedUnixTime);
        }

        [Test]
        public void FromDateTimeToUnixTime_TimeSpanProvided_ConvertsCorrectly()
        {
            var dateTime = new DateTime(2021, 1, 1, 0, 0, 0);
            var timeSpan = TimeSpan.FromHours(3);
            var expectedUnixTime = 1609459200 - 3 * 60 * 60;// Subtract 3 hours in seconds

            var convertedUnixTime = dateTime.FromDateTimeToUnixTime(timeSpan);

            Assert.AreEqual(expectedUnixTime, convertedUnixTime);
        }

        [TestCase(-1)]
        [TestCase(long.MaxValue)]
        public void FromUnixTimeToDateTime_ErroneousInputs_ThrowsArgumentOutOfRangeException(long inputUnixTime)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => inputUnixTime.FromUnixTimeToDateTime());
        }

        [TestCase(-1)]
        [TestCase(long.MaxValue)]
        public void FromUnixTimeToDateTimeUtc_ErroneousInputs_ThrowsArgumentOutOfRangeException(long inputUnixTime)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => inputUnixTime.FromUnixTimeToDateTimeUtc());
        }

        [Test]
        public void FromDateTimeToUnixTime_ErroneousInputs_ThrowsArgumentException()
        {
            var dateTime = new DateTime(2100, 12, 31);
            // Larger than int.MaxValue
            var longTimespan = new TimeSpan(long.MaxValue);

            Assert.Throws<ArgumentException>(() => dateTime.FromDateTimeToUnixTime(longTimespan));
        }
    }
}