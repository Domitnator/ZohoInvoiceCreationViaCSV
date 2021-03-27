using FileHelpers;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZohoInvoiceRecordings.Models;
using ZohoInvoiceRecordings.Models.Knab;

namespace ZohoInvoiceRecordings
{
    public class UrenCSVReader
    {
        private readonly FileHelperEngine<UrenCSV> _engine;
        private readonly ApplicationSettings _applicationSettings;

        public UrenCSVReader(IOptions<ApplicationSettings> applicationSettings)
        {
            _engine = new FileHelperEngine<UrenCSV>();
            _applicationSettings = applicationSettings.Value;
        }

        public List<UrenCSV> ReadRecords()
        {
            string filename = _applicationSettings.HoursFile;

            RemoveLastDelimiterFromEveryLine(filename);

            var records = _engine.ReadFile(filename);

            return records.ToList();
        }

        private void RemoveLastDelimiterFromEveryLine(string filename)
        {
            StringBuilder sb = new();
            string line;
            int counter = 0;

            // Read the file and display it line by line.  
            using (System.IO.StreamReader file =
                new(filename))
            {

                while ((line = file.ReadLine()) != null)
                {
                    System.Console.WriteLine(line);
                    sb.AppendLine(line.TrimEnd(new char[] { ';' }));
                    counter++;
                }

                file.Close();
            }

            System.IO.File.WriteAllText(filename, sb.ToString());
        }
    }
}
