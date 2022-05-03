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
            var t = StringHelper.GetTagValues("<?xml version=\"1.0\" encoding=\"UTF-8\"?><gesmes:Envelope xmlns:gesmes=\"http://www.gesmes.org/xml/2002-08-01\" xmlns=\"http://www.ecb.int/vocabulary/2002-08-01/eurofxref\"><gesmes:subject>Reference rates</gesmes:subject><gesmes:Sender><gesmes:name>European Central Bank</gesmes:name></gesmes:Sender><Cube><Cube time='2022-04-29'><Cube currency='USD' rate='1.0540'/><Cube currency='JPY' rate='137.01'/><Cube currency='BGN' rate='1.9558'/><Cube currency='CZK' rate='24.605'/><Cube currency='DKK' rate='7.4415'/><Cube currency='GBP' rate='0.83908'/><Cube currency='HUF' rate='378.71'/><Cube currency='PLN' rate='4.6780'/><Cube currency='RON' rate='4.9479'/><Cube currency='SEK' rate='10.2958'/><Cube currency='CHF' rate='1.0229'/><Cube currency='ISK' rate='137.80'/><Cube currency='NOK' rate='9.7525'/><Cube currency='HRK' rate='7.5667'/><Cube currency='TRY' rate='15.6385'/><Cube currency='AUD' rate='1.4699'/><Cube currency='BRL' rate='5.1608'/><Cube currency='CAD' rate='1.3426'/><Cube currency='CNY' rate='6.9441'/><Cube currency='HKD' rate='8.2703'/><Cube currency='IDR' rate='15301.52'/><Cube currency='ILS' rate='3.4993'/><Cube currency='INR' rate='80.6380'/><Cube currency='KRW' rate='1326.71'/><Cube currency='MXN' rate='21.4181'/><Cube currency='MYR' rate='4.5886'/><Cube currency='NZD' rate='1.6119'/><Cube currency='PHP' rate='55.200'/><Cube currency='SGD' rate='1.4545'/><Cube currency='THB' rate='36.026'/><Cube currency='ZAR' rate='16.6473'/></Cube></Cube></gesmes:Envelope>", "<Cube ", "/>", true);
        }
    }
}
