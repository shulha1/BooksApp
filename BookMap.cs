using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp2
{
    public class BookMap : ClassMap<Book>
    {
        public BookMap()
        {
            Map(m => m.BookName).Name("BookName");
            Map(m => m.Author).Name("Author");
            Map(m => m.OriginalLanguage).Name("OriginalLanguage");
            Map(m => m.YearPublished).Name("YearPublished");
            Map(m => m.ApproximateSales).Name("ApproximateSales");
            Map(m => m.BookGenre).Name("BookGenre");
        }
    }
}
