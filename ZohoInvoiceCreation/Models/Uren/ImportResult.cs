using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZohoInvoiceRecordings.Models.Knab
{
    public class ImportResult
    {
        public bool Succeeded { get; set; }

        public string ImportException { get; set; }

        public int RecordsImported { get; set; }
    }
}
