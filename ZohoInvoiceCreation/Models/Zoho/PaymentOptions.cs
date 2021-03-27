using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZohoInvoiceCreation.Models.Zoho
{
    public class PaymentOptions
    {
        [JsonPropertyName("payment_gateways")]
        public List<PaymentGateway> PaymentGateways { get; set; }
    }
}
