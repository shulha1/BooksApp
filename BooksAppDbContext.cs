using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp2
{
public class BookAppDbContext : DbContext 
{ 
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 

        optionsBuilder
            .UseSqlServer(
                @"Server = (localdb)\mssqllocaldb;Database = BooksApp;Trusted_Connection = True;")
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging()
            .LogTo(Console.WriteLine,
                new[] { DbLoggerCategory.Database.Command.Name },
                LogLevel.Information);

        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Book>()
            .ToTable("My Books");

            modelBuilder
                .Entity<Book>()
                .HasKey(x => x.BookId);
            

        modelBuilder
            .Entity<Book>()
            .Property(x => x.BookName)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder
            .Entity<Book>()
            .Property(x => x.BookGenre)
            .IsRequired();

        modelBuilder
            .Entity<Book>()
            .Property(x => x.Author)
            .IsRequired();

        modelBuilder
            .Entity<Book>()
            .Property(x => x.ApproximateSales)
            .IsRequired();

        modelBuilder
            .Entity<Book>()
            .Property(x => x.OriginalLanguage)
            .IsRequired();

        modelBuilder
            .Entity<Book>()
            .Property(x => x.YearPublished)
            .IsRequired();
    }
}

}
