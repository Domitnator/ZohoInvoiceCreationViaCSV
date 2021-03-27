using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ZohoInvoiceCreation.Helpers;
using ZohoInvoiceCreation.Models.Zoho;
using ZohoInvoiceRecordings.Client;
using ZohoInvoiceRecordings.Models;
using ZohoInvoiceRecordings.Models.Knab;

namespace ZohoInvoiceRecordings
{
    public class ZohoInvoicesService
    {
        private readonly ZohoClient client;
        private readonly ApplicationSettings applicationSettings;

        public ZohoInvoicesService(ZohoClient client, IOptions<ApplicationSettings> applicationSettings)
        {
            this.client = client;
            this.applicationSettings = applicationSettings.Value;
        }

        public async Task<List<ImportOutput>> CreateInvoices(List<UrenCSV> records,bool createInZoho)
        {
            List<Invoice> invoices = new();
            List<ImportOutput> outputs = new();

            var klantRecords = records.GroupBy(s => s.Klant);
            var sprintNumber = applicationSettings.SprintNumber;
            var invoiceDate = DateTime.Parse(applicationSettings.InvoiceDate);

            foreach (var klantItem in klantRecords)
            {
                if (applicationSettings.CustomerNamesWhichShouldBeGroupedByWorkOrderNumber.Contains(klantItem.Key.ToLower()))
                {
                    var werkbonRecords = klantItem.GroupBy(s => s.Werkbonnummer);

                    invoices.AddRange(CreateInvoices(sprintNumber, invoiceDate, klantItem.Key, werkbonRecords));
                }
                else
                {
                    invoices.Add(CreateInvoice(sprintNumber, invoiceDate, klantRecords.Where(s => s.Key == klantItem.Key).SelectMany(group => group).ToList(), klantItem.Key));
                }
            }

            // Check the hours
            if (InvoiceHelper.GetQuantity(invoices) == applicationSettings.TotalAmountOfHours)
            {
                if (createInZoho)
                {
                    foreach (var item in invoices)
                    {
                        ImportOutput output = new ImportOutput { Invoice = item };

                        try
                        {
                            output.InvoiceResponse = await SubmitInvoice(item);
                        }
                        catch(Exception ex)
                        {
                            output.InvoiceResponse = new InvoiceResponse
                            {
                                Code = -1,
                                Message = ex.Message
                            };
                        }

                        outputs.Add(output);
                    }
                }
            }

            if(outputs.Any())
                System.IO.File.WriteAllText(this.applicationSettings.OutputFile, JsonSerializer.Serialize(outputs));

            return outputs;
        }

        public async Task<InvoiceResponse> GetInvoice(string invoicenumber)
        {
            return await client.GetInvoice(invoicenumber);
        }

        public Invoice CreateInvoice(string sprintNumber, DateTime invoiceDate, List<UrenCSV> records, string klantNaam, string werkbonNummer = "")
        {
            return new Invoice()
            {
                CustomerId = Convert.ToInt64(applicationSettings.CustomerId),
                Date = invoiceDate.ToString("yyyy-MM-dd"),
                PaymentTerms = applicationSettings.PaymentTerms,
                TemplateId = applicationSettings.InvoiceTemplateId,
                IsDiscountBeforeTax = true,
                Notes = applicationSettings.InvoiceNote,
                ReferenceNumber = GetReferenceNumber(sprintNumber, invoiceDate, klantNaam, werkbonNummer),
                LineItems = new List<LineItem>
                 {
                      new LineItem
                      {
                           Name = GetLineItemName(klantNaam, werkbonNummer),
                           Quantity = InvoiceHelper.GetQuantity(records),
                           Rate = applicationSettings.InvoiceRate,
                           TaxId = applicationSettings.TaxId,
                           TaxType = "tax",
                           TaxPercentage = applicationSettings.TaxPercentage,
                      }
                 },
                ContactPersons = applicationSettings.InvoiceContactPersons
            };
        }

        private async Task<InvoiceResponse> SubmitInvoice(Invoice item)
        {
            return await client.CreateInvoice(item);
        }

        private string GetLineItemName(string klantNaam, string werkbonNummer)
        {
            if (String.IsNullOrEmpty(werkbonNummer))
            {
                return $"{klantNaam}";
            }

            return $"{klantNaam} ({werkbonNummer})";
        }

        private string GetReferenceNumber(string sprintNumber, DateTime invoiceDate, string klantNaam, string werkbonNummer)
        {
            if (String.IsNullOrEmpty(werkbonNummer))
            {
                return $"Sprint {invoiceDate:yyyy}-{sprintNumber} - {klantNaam}";
            }

            return $"Sprint {invoiceDate:yyyy}-{sprintNumber} - {klantNaam} ({werkbonNummer})";
        }

        private List<Invoice> CreateInvoices(string sprintNumber, DateTime invoiceDate, string klantNaam, IEnumerable<IGrouping<string, UrenCSV>> records)
        {
            var invoices = new List<Invoice>();

            foreach (var item in records)
            {
                invoices.Add(CreateInvoice(sprintNumber, invoiceDate, records.Where(s => s.Key == item.Key).SelectMany(group => group).ToList(), klantNaam, item.Key));
            }

            return invoices;
        }

    }
}
