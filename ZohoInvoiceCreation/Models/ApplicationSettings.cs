using System.Collections.Generic;

namespace ZohoInvoiceRecordings.Models
{
    public class ApplicationSettings
    {
        public int OrganisationId { get; set; }
        public string AccessToken { get; set; }

        public string CustomerId { get; set; }

        public string HoursFile { get; set; }

        public string OutputFile { get; set; }

        public List<string> CustomerNamesWhichShouldBeGroupedByWorkOrderNumber { get; set; }

        public List<string> InvoiceContactPersons { get; set; }

        public string InvoiceNote { get; set; }

        public int InvoiceRate { get; set; }

        public int TaxPercentage { get; set; }

        public long TaxId { get; set; }

        public long InvoiceTemplateId { get; set; }

        public int PaymentTerms { get; set; }

        public string SprintNumber { get; set; }

        public string InvoiceDate { get; set; }

        public double TotalAmountOfHours { get; set; }
    }
}
