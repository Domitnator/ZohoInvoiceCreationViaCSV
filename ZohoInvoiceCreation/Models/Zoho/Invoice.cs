using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZohoInvoiceCreation.Models.Zoho
{
    public class Invoice
    {
        [JsonPropertyName("customer_id")]
        public long CustomerId { get; set; }

        [JsonPropertyName("contact_persons")]
        public List<string> ContactPersons { get; set; }

        [JsonPropertyName("invoice_number")]
        public string InvoiceNumber { get; set; }

        [JsonPropertyName("reference_number")]
        public string ReferenceNumber { get; set; }

        //[JsonPropertyName("place_of_supply")]
        //public string PlaceOfSupply { get; set; }

        //[JsonPropertyName("gst_treatment")]
        //public string GstTreatment { get; set; }

        //[JsonPropertyName("gst_no")]
        //public string GstNo { get; set; }

        [JsonPropertyName("template_id")]
        public long TemplateId { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("payment_terms")]
        public int PaymentTerms { get; set; }

        [JsonPropertyName("payment_terms_label")]
        public string PaymentTermsLabel { get; set; }

        [JsonPropertyName("due_date")]
        public string DueDate { get; set; }

        [JsonPropertyName("discount")]
        public int Discount { get; set; }

        [JsonPropertyName("is_discount_before_tax")]
        public bool IsDiscountBeforeTax { get; set; }

        [JsonPropertyName("discount_type")]
        public string DiscountType { get; set; }

        [JsonPropertyName("is_inclusive_tax")]
        public bool IsInclusiveTax { get; set; }

        [JsonPropertyName("exchange_rate")]
        public int ExchangeRate { get; set; }

        [JsonPropertyName("recurring_invoice_id")]
        public string RecurringInvoiceId { get; set; }

        [JsonPropertyName("invoiced_estimate_id")]
        public string InvoicedEstimateId { get; set; }

        [JsonPropertyName("salesperson_name")]
        public string SalespersonName { get; set; }

        [JsonPropertyName("custom_fields")]
        public List<CustomField> CustomFields { get; set; }

        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("line_items")]
        public List<LineItem> LineItems { get; set; }

        [JsonPropertyName("payment_options")]
        public PaymentOptions PaymentOptions { get; set; }

        [JsonPropertyName("allow_partial_payments")]
        public bool AllowPartialPayments { get; set; }

        [JsonPropertyName("custom_body")]
        public string CustomBody { get; set; }

        [JsonPropertyName("custom_subject")]
        public string CustomSubject { get; set; }

        [JsonPropertyName("notes")]
        public string Notes { get; set; }

        [JsonPropertyName("terms")]
        public string Terms { get; set; }

        [JsonPropertyName("shipping_charge")]
        public int ShippingCharge { get; set; }

        [JsonPropertyName("adjustment")]
        public int Adjustment { get; set; }

        [JsonPropertyName("adjustment_description")]
        public string AdjustmentDescription { get; set; }

        [JsonPropertyName("reason")]
        public string Reason { get; set; }
    }
}
