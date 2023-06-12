using System.Globalization;
using TsadriuUtilities;

namespace Test
{
    public class DateTimeHelperTest
    {
        [Test]
        public void ToDateTimeTest()
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
        public void ToNullableDateTimeTest()
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
        public void GetLastDayOfMonthTest()
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
        public void SetDayTest()
        {
            var dateOne = new DateTime(2023, 2, 1);

            // February does not have 30 days, let's see if the method works
            dateOne = dateOne.SetDay(30);
            
            Assert.That(dateOne, Is.EqualTo(new DateTime(2023, 2,28)));
            
            var dateTwo = new DateTime(2023, 5, 1);
            dateTwo = dateTwo.SetDay(27);
            
            Assert.That(dateTwo, Is.EqualTo(new DateTime(2023, 5,27)));
            
            var dateThree = new DateTime(2018, 2, 24);
            
            // Negative values should be clamped to 1.
            dateThree = dateThree.SetDay(-5);
            Assert.That(dateThree, Is.EqualTo(new DateTime(2018, 2,1)));
        }
        
        [Test]
        public void SetMonthTest()
        {
            var dateOne = new DateTime(2023, 1, 1);
            
            // A year has 12 months, let's see if the method works
            dateOne = dateOne.SetMonth(13);
            
            Assert.That(dateOne, Is.EqualTo(new DateTime(2023, 12,1)));
            
            var dateTwo = new DateTime(2023, 3, 1);
            dateTwo = dateTwo.SetMonth(5);
            
            Assert.That(dateTwo, Is.EqualTo(new DateTime(2023, 5,1)));
            
            var dateThree = new DateTime(2018, 2, 24);
            
            // Negative values should be clamped to 1.
            dateThree = dateThree.SetMonth(-5);
            Assert.That(dateThree, Is.EqualTo(new DateTime(2018, 1,24)));
        }
        
        [Test]
        public void SetYearTest()
        {
            var dateOne = new DateTime(2023, 2, 1);

            // Year cannot go above 9999, let's see if the method works
            dateOne = dateOne.SetYear(100000);
            
            Assert.That(dateOne, Is.EqualTo(new DateTime(9999, 2,1)));
            
            var dateTwo = new DateTime(2023, 5, 1);
            dateTwo = dateTwo.SetYear(27);
            
            Assert.That(dateTwo, Is.EqualTo(new DateTime(27, 5,1)));
            
            var dateThree = new DateTime(2018, 2, 24);
            
            // Negative values should be clamped to 1.
            dateThree = dateThree.SetYear(-5);
            Assert.That(dateThree, Is.EqualTo(new DateTime(1, 2,24)));
        }
        
        [Test]
        public void RemoveDaysTest()
        {
            var dateOne = new DateTime(2023, 1, 1);
            dateOne = dateOne.RemoveDays(2);
            Assert.That(dateOne, Is.EqualTo(new DateTime(2022, 12,30)));
            
            var dateTwo = new DateTime(2023, 5, 1);
            dateTwo = dateTwo.RemoveDays(-5);
            Assert.That(dateTwo, Is.EqualTo(new DateTime(2023, 4,26)));
        }
        
        
        [Test]
        public void RemoveMonthsTest()
        {
            var dateOne = new DateTime(2023, 2, 1);
            dateOne = dateOne.RemoveMonths(2);
            Assert.That(dateOne, Is.EqualTo(new DateTime(2022, 12,1)));
            
            var dateTwo = new DateTime(2023, 3, 31);
            dateTwo = dateTwo.RemoveMonths(-1);
            Assert.That(dateTwo, Is.EqualTo(new DateTime(2023, 2,28)));
        }
        
        
        [Test]
        public void RemoveYearsTest()
        {
            var dateOne = new DateTime(2023, 2, 1);
            dateOne = dateOne.RemoveYears(2);
            Assert.That(dateOne, Is.EqualTo(new DateTime(2021, 2,1)));
            
            var dateTwo = new DateTime(2020, 2, 29);
            dateTwo = dateTwo.RemoveYears(-5);
            Assert.That(dateTwo, Is.EqualTo(new DateTime(2015, 2,28)));
        }
    }
}
