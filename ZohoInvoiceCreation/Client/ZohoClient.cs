using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using ZohoInvoiceCreation.Models.Zoho;
using ZohoInvoiceRecordings.Models;

namespace ZohoInvoiceRecordings.Client
{
    public class ZohoClient : WebClient
    {
        private readonly ApplicationSettings _applicationSettings;

        public ZohoClient(IOptions<ApplicationSettings> applicationSettings)
        {
            this._applicationSettings = applicationSettings.Value;

            this.BaseAddress = "https://invoice.zoho.com";
            this.Headers.Add("Authorization", $"Zoho-oauthtoken {_applicationSettings.AccessToken}");
            this.Headers.Add("X-com-zoho-invoice-organizationid", $"{_applicationSettings.OrganisationId}");
        }

        public async Task<InvoiceResponse> CreateInvoice(ZohoInvoiceCreation.Models.Zoho.Invoice invoice)
        {
            try
            {
                string response = await this.UploadStringTaskAsync("api/v3/invoices", JsonSerializer.Serialize(invoice));
                return JsonSerializer.Deserialize<InvoiceResponse>(response);
            }
            catch(Exception ex)
            {
                string message = ex.Message;
                return null;
            }
           
        }

        internal async Task<InvoiceResponse> GetInvoice(string invoicenumber)
        {
            string response = await this.DownloadStringTaskAsync($"api/v3/invoices/{invoicenumber}");

            return JsonSerializer.Deserialize<InvoiceResponse>(response);
        }
    }
}
