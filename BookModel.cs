using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp2
{
    public class Book
    {
        public int BookId { get; set; }

        public string BookName { get; set; }

        public string Author { get; set; }

        public string OriginalLanguage { get; set; }

        public int YearPublished { get; set; }

        public string ApproximateSales { get; set; }

        public string BookGenre { get; set; }

    }
}
