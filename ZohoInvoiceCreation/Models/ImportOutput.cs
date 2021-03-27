using ZohoInvoiceCreation.Models.Zoho;

namespace ZohoInvoiceRecordings.Models
{
    public class ImportOutput
    {
        public Invoice Invoice { get; set; }

        public InvoiceResponse InvoiceResponse { get; set; }
    }
}
