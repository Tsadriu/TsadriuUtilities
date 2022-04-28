using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
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

            ListHelper.AddRange(ref listaString, arrayString, 1, 3);

            var test = ListHelper.ToList(arrayString);

            ListHelper.OrderByDescending(ref test);
        }

        [TestMethod]
        public void StrHelperTest()
        {
            var text = "This fox is <b>very</b> sneaky!\nI hope nothing <b>happens</b> to my food...";

            Assert.IsTrue(StringHelper.GetTagValue(text, "very", "\n", true) == "very</b> sneaky!\n");

            var table = new TTable();
            table.AddColumn("Data", "Ore", "Minuti", "Ore Svolte", "Ore Effettive Ticket", "Attivita", "Branch", "Commit", "Orario di registrazione");
            table.AddData("Data", DateTime.Today.ToString("yyyy-MM-dd"));
            table.AddData("Ore", 2);
            table.AddData("Minuti", 47);
            table.AddData("Ore Svolte", 2.677);
            table.AddData("Ore Effettive Ticket", 2.75);
            table.AddData("Ore Effettive Ticket", 5.0);
            table.AddData("Attivita", "Questo è un test");
            table.AddData("Branch", "Ticket_999TEST");
            table.AddData("Commit", "Non esistente");
            table.AddData("Orario di registrazione", DateTime.Now);

            var contentList = table.TableToCsv(true, ";");
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TEST CSV");

            DirectoryHelper.Exist(path, true);

            File.AppendAllLines(Path.Combine(path, "file_test.csv"), contentList);
        }
    }
}
