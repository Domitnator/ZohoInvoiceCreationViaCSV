using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using ZohoInvoiceRecordings.Client;

namespace ZohoInvoiceRecordings.Tests
{
    [TestClass]
    public class CreateInvoices: Base.BaseTest
    {
        [TestMethod]
        public async Task ShouldCreateInvoices()
        {
            UrenCSVReader reader = new UrenCSVReader(Options.Create(applicationSettings));
            var client = new ZohoClient(Options.Create(applicationSettings));
            var invoiceService = new ZohoInvoicesService(client, Options.Create(applicationSettings));
            
            var createInZoho = false;

            var outputs = await invoiceService.CreateInvoices(reader.ReadRecords(), createInZoho);

            Assert.IsNotNull(outputs);
        }

        [TestMethod]
        public async Task GetInvoice()
        {
            UrenCSVReader reader = new UrenCSVReader(Options.Create(applicationSettings));
            var client = new ZohoClient(Options.Create(applicationSettings));
            var invoiceService = new ZohoInvoicesService(client, Options.Create(applicationSettings));

            var response = await invoiceService.GetInvoice("XXX");

            Assert.IsNotNull(response);
        }
    }
}
