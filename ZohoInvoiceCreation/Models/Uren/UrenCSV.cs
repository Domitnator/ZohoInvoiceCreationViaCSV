using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZohoInvoiceRecordings.Models.Knab
{
    [DelimitedRecord(";")]
    [IgnoreFirst(1)]
    public class UrenCSV
    {
        public string Klant { get; set; }

        public string Werkbonnummer { get; set; }

        public string PBI { get; set; }

        public string Datum { get; set; }

        public string Aantal { get; set; }

        public string Omschrijving { get; set; }
    }
}
