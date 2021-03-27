using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZohoInvoiceCreation.Models.Zoho
{
    public class LineItem
    {
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("time_entry_ids")]
        public List<TimeEntryId> TimeEntryIds { get; set; }

        [JsonPropertyName("expense_id")]
        public string ExpenseId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("item_order")]
        public int ItemOrder { get; set; }

        [JsonPropertyName("rate")]
        public int Rate { get; set; }

        [JsonPropertyName("quantity")]
        public double Quantity { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }

        [JsonPropertyName("tax_id")]
        public long TaxId { get; set; }

        [JsonPropertyName("tax_name")]
        public string TaxName { get; set; }

        [JsonPropertyName("tax_type")]
        public string TaxType { get; set; }

        [JsonPropertyName("tax_percentage")]
        public double TaxPercentage { get; set; }

        //[JsonPropertyName("item_total")]
        //public int ItemTotal { get; set; }
    }
}
