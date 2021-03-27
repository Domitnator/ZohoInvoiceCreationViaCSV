using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZohoInvoiceCreation.Models.Zoho
{
    public class PaymentGateway
    {
        [JsonPropertyName("configured")]
        public bool Configured { get; set; }

        [JsonPropertyName("additional_field1")]
        public string AdditionalField1 { get; set; }

        [JsonPropertyName("gateway_name")]
        public string GatewayName { get; set; }
    }
}
