using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TsadriuUtilities;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DateTimeHelperTest()
        {
            DateTime test1 = (DateTime)DateTimeHelper.StringToDate("25/03/2020", new string[] { "dd-MM-yyyy", "dd/MM/yyyy" }, System.Globalization.CultureInfo.InvariantCulture);
            DateTime test2 = (DateTime)DateTimeHelper.StringToDate("25/03/2020", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime test3 = (DateTime)DateTimeHelper.StringToDate("25/03/2020", new string[] { "dd-MM-yyyy", "dd/MM/yyyy" });
            DateTime test4 = (DateTime)DateTimeHelper.StringToDate("25/03/2020", "dd/MM/yyyy");

            Assert.IsNotNull(test1);
            Assert.IsFalse(test1 == DateTime.MinValue);

            Assert.IsNotNull(test2);
            Assert.IsFalse(test2 == DateTime.MinValue);

            Assert.IsNotNull(test3);
            Assert.IsFalse(test3 == DateTime.MinValue);

            Assert.IsNotNull(test4);
            Assert.IsFalse(test4 == DateTime.MinValue);

            
        }

        [TestMethod]
        public void MultiHelperTest()
        {
            DateTime[] dateTimeArray = new DateTime[] { DateTime.Today, DateTime.Now, new DateTime(2020, 03, 20) };

            var result = MultiHelper.ArrayToString(dateTimeArray, "&");

            Assert.IsFalse(result.Contains(dateTimeArray.GetType().ToString()));

            var listaString = new List<string>() { "Fabio", "Proto" };
            var arrayString = new string[] { "Massimo", "Tito", "Giada", "Zina", "Jonah" };

            ListHelper.AddRange(ref listaString, arrayString, 2);

            var test = ListHelper.ToList(arrayString);

            ListHelper.OrderByDescending(ref test);
        }
    }
}
