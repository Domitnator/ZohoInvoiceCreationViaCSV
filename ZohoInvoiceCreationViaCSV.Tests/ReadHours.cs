using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZohoInvoiceRecordings.Tests
{
    [TestClass]
    public class ReadHours: Base.BaseTest
    {
        [TestMethod]
        public void ReadCSVRecords()
        {
            UrenCSVReader reader = new(Options.Create(applicationSettings));

            var records = reader.ReadRecords();

            Assert.IsNotNull(records);
        }
    }
}
