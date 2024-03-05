using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp2
{
    public class CreatingDatabase
    {
        public static void CreatingDatabaseMethod()
        {
            using var booksAppContext = new BookAppDbContext();

            booksAppContext.Database.EnsureDeleted();

            booksAppContext.Database.EnsureCreated();
        }
    }
}
