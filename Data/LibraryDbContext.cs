using Biblioteka.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasOne(b => b.Genre).WithMany(g => g.Books).HasForeignKey(b => b.GenreId);
            modelBuilder.Entity<Book>().HasOne(b => b.Publisher).WithMany(p => p.Books).HasForeignKey(b => b.PublisherId);
            modelBuilder.Entity<Book>().HasOne(b => b.Language).WithMany(l => l.Books).HasForeignKey(b => b.LanguageId);
            modelBuilder.Entity<Book>().HasMany(b => b.Authors).WithMany(a => a.Books);
            modelBuilder.Entity<Review>().HasOne(r => r.Book).WithMany(b => b.Reviews).HasForeignKey(r => r.BookId);
            modelBuilder.Entity<Review>().HasOne(r => r.Customer).WithMany(r => r.Reviews).HasForeignKey(r => r.CustomerId);
            modelBuilder.Entity<Rental>().HasOne(r => r.Book).WithMany(b => b.Rentals).HasForeignKey(r => r.BookId);
            modelBuilder.Entity<Rental>().HasOne(r => r.Customer).WithMany(r => r.Rentals).HasForeignKey(r => r.CustomerId);
            modelBuilder.Entity<Publisher>().HasOne(p => p.Country).WithMany(c => c.Publishers).HasForeignKey(p => p.CountryId);
            modelBuilder.Entity<Author>().HasOne(a => a.Country).WithMany(c => c.Authors).HasForeignKey(a => a.CountryId);
        }
    }
}