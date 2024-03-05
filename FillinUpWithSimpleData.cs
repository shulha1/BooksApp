using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp2
{
    public class FillinUpWithSimpleData
    {
        public static void FillingData() 
        {

            string csvFilePath = "BooksApp2.csv";

            List<Book> books = new();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";"
            };

            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<BookMap>();
                var records = csv.GetRecords<Book>();

                using (var booksAppContext = new BookAppDbContext())
                {
                    // Add each record to the DbContext and save changes
                    foreach (var record in records)
                    {
                        booksAppContext.Books.Add(record);
                    }

                    booksAppContext.SaveChanges();
                }
            }


        }
    }
}
