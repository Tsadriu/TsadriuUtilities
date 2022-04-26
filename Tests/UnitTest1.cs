using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TsadriuUtilities;
using TsadriuUtilities.Objects;

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

            ListHelper.AddRange(ref listaString, arrayString, 1, 3);

            var test = ListHelper.ToList(arrayString);

            ListHelper.OrderByDescending(ref test);
        }

        [TestMethod]
        public void StrHelperTest()
        {
            var text = "This fox is <b>very</b> sneaky!\nI hope nothing <b>happens</b> to my food...";

            Assert.IsTrue(StringHelper.GetTagValue(text, "very", "\n", true) == "very</b> sneaky!\n");

            var table = new Table("Name", "Retains the info of the students names.");
            
            table.AddData("Name", "Fabio", "Alessandro", "Jonah");

            table.AddColumn("Last name", "Retains the info of the students last name.");
            table.AddData("Last Name", "Oliveira de Sousa", "Proto", "Stenblik");

            table.AddColumn("Age");
            table.AddData("Age", 22, 22, 18, 14, 8, 2, 3);


            table.RemoveData("Age", 18);

            table.TableToCsv();
        }
    }
}
