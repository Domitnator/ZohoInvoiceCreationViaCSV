using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZohoInvoiceCreation.Models.Zoho;
using ZohoInvoiceRecordings.Models.Knab;

namespace ZohoInvoiceCreation.Helpers
{
    public class InvoiceHelper
    {
        public static double GetQuantity(List<UrenCSV> records)
        {
            double total = 0;
            foreach (var item in records)
            {
                total += Convert.ToDouble(item.Aantal.Trim(new char[] { '"' }));
            }

            return total;
        }

        public static double GetQuantity(List<Invoice> invoices)
        {
            double total = 0;
            foreach (var item in invoices)
            {
                total += Convert.ToDouble(item.LineItems.Sum(s => s.Quantity));
            }

            return total;
        }
    }
}
