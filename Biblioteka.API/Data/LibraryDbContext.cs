using Library.Domain;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) {}
        public DbSet<Book> Books { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasOne(b => b.Genre).WithMany(g => g.Books).HasForeignKey(b => b.GenreId);
            modelBuilder.Entity<Book>().HasOne(b => b.Publisher).WithMany(p => p.Books).HasForeignKey(b => b.PublisherId);
            modelBuilder.Entity<Book>().HasOne(b => b.Language).WithMany(l => l.Books).HasForeignKey(b => b.LanguageId);
            modelBuilder.Entity<AuthorBook>().HasKey(ab => new { ab.AuthorId, ab.BookId });
            modelBuilder.Entity<AuthorBook>().HasOne(ab => ab.Author).WithMany(a => a.AuthorBooks).HasForeignKey(ab => ab.AuthorId);
            modelBuilder.Entity<AuthorBook>().HasOne(ab => ab.Book).WithMany(b => b.BookAuthors).HasForeignKey(ab => ab.BookId);
            
            modelBuilder.Entity<Review>().HasOne(r => r.Book).WithMany(b => b.Reviews).HasForeignKey(r => r.BookId);
            modelBuilder.Entity<Review>().HasOne(r => r.Customer).WithMany(r => r.Reviews).HasForeignKey(r => r.CustomerId);
            modelBuilder.Entity<Rental>().HasOne(r => r.Book).WithMany(b => b.Rentals).HasForeignKey(r => r.BookId);
            modelBuilder.Entity<Rental>().HasOne(r => r.Customer).WithMany(r => r.Rentals).HasForeignKey(r => r.CustomerId);
            modelBuilder.Entity<Publisher>().HasOne(p => p.Country).WithMany(c => c.Publishers).HasForeignKey(p => p.CountryId);
            modelBuilder.Entity<Author>().HasOne(a => a.Country).WithMany(c => c.Authors).HasForeignKey(a => a.CountryId);


            modelBuilder.Entity<Language>().HasData(
                new Language { Id = 1, LanguageName = "English" },
                new Language { Id = 2, LanguageName = "Polish" },
                new Language { Id = 3, LanguageName = "German" },
                new Language { Id = 4, LanguageName = "French" }
            );
            
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Fantasy" },
                new Genre { Id = 2, Name = "Science Fiction" },
                new Genre { Id = 3, Name = "Horror" },
                new Genre { Id = 4, Name = "Romance" }
            );
            
            modelBuilder.Entity<Worker>().HasData(
                new Worker{ Id = 1, Name = "Wojtek", Surname = "Szoda", Email = "test@wp.pl", Role = "Admin"},
                new Worker{ Id = 2, Name = "Jan", Surname = "Kowalski", Email = "kowalski@test.pl", Role = "Worker"},
                new Worker{ Id = 3, Name = "Adam", Surname = "Nowak", Email = "adam@nowak.pl", Role = "Worker"}
            );
            
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Poland" },
                new Country { Id = 2, Name = "United Kingdom" },
                new Country { Id = 3, Name = "United States" },
                new Country { Id = 4, Name = "France" },
                new Country { Id = 5, Name = "Germany" }
            );

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "J.R.R.", Surname = "Tolkien", CountryId = 2},
                new Author { Id = 2, Name = "Stephen", Surname = "King", CountryId = 3 },
                new Author { Id = 3, Name = "Andrzej", Surname = "Sapkowski", CountryId = 1 },
                new Author { Id = 4, Name = "George R.R.", Surname = "Martin", CountryId = 3 },
                new Author { Id = 5, Name = "J.K.", Surname = "Rowling", CountryId = 2 },
                new Author { Id = 6, Name = "H.P.", Surname = "Lovecraft", CountryId = 3 },
                new Author { Id = 7, Name = "William", Surname = "Shakespeare", CountryId = 2 },
                new Author { Id = 8, Name = "Jane", Surname = "Austen", CountryId = 2 },
                new Author { Id = 9, Name = "Emily", Surname = "Bronte", CountryId = 2 },
                new Author { Id = 10, Name = "Charlotte", Surname = "Bronte", CountryId = 2 },
                new Author { Id = 11, Name = "Anne", Surname = "Bronte", CountryId = 2 },
                new Author { Id = 12, Name = "Arthur Conan", Surname = "Doyle", CountryId = 2 },
                new Author { Id = 13, Name = "Agatha", Surname = "Christie", CountryId = 2 },
                new Author { Id = 14, Name = "Jules", Surname = "Verne", CountryId = 4 },
                new Author { Id = 15, Name = "Herman", Surname = "Melville", CountryId = 3 },
                new Author { Id = 16, Name = "Mark", Surname = "Twain", CountryId = 3 },
                new Author { Id = 17, Name = "Charles", Surname = "Dickens", CountryId = 2 },
                new Author { Id = 18, Name = "Fyodor", Surname = "Dostoevsky", CountryId = 5 }
            );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "PWN", CountryId = 1 },
                new Publisher { Id = 2, Name = "Wydawnictwo Literackie", CountryId = 1 },
                new Publisher { Id = 3, Name = "Penguin Books", CountryId = 2 }
            );
            
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Jan", Surname = "Kowalski", Email = "kowlski@jan.pl", PhoneNumber = "123456789", Address = "ul. Kowalska 1, 00-000 Warszawa" },
                new Customer { Id = 2, Name = "Adam", Surname = "Nowak", Email = "adam@nowak.pl", PhoneNumber = "987654321", Address = "ul. Nowaka 1, 00-000 Warszawa" },
                new Customer { Id = 3, Name = "Kamil", Surname = "Nowacki", Email = "kamil@nowacki.pl", PhoneNumber = "123123123", Address = "ul. Nowacki 1, 00-000 Warszawa" }
            );
            
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "The Great Gatsby",
                    YearOfPublishing = 1925,
                    NumberOfPages = 180,
                    Description = "A novel by F. Scott Fitzgerald",
                    ISBN = "978-3-16-148410-0",
                    Image = "great_gatsby.jpg",
                    LanguageId = 1,
                    GenreId = 2,
                    PublisherId = 3,
                },
                new Book
                {
                    Id = 2,
                    Title = "To Kill a Mockingbird",
                    YearOfPublishing = 1960,
                    NumberOfPages = 281,
                    Description = "A novel by Harper Lee",
                    ISBN = "978-3-16-148410-1",
                    Image = "to_kill_a_mockingbird.jpg",
                    LanguageId = 1,
                    GenreId = 4,
                    PublisherId = 3,
                },
                new Book
                {
                    Id = 3,
                    Title = "1984",
                    YearOfPublishing = 1949,
                    NumberOfPages = 328,
                    Description = "A dystopian novel by George Orwell",
                    ISBN = "978-3-16-148410-2",
                    Image = "1984.jpg",
                    LanguageId = 1,
                    GenreId = 2,
                    PublisherId = 3,
                },
                new Book
                {
                    Id = 4,
                    Title = "The Catcher in the Rye",
                    YearOfPublishing = 1951,
                    NumberOfPages = 277,
                    Description = "A novel by J.D. Salinger",
                    ISBN = "978-3-16-148410-3",
                    Image = "catcher_in_the_rye.jpg",
                    LanguageId = 1,
                    GenreId = 4,
                    PublisherId = 3,
                },
                new Book
                {
                    Id = 5,
                    Title = "The Hobbit",
                    YearOfPublishing = 1937,
                    NumberOfPages = 310,
                    Description = "A novel by J.R.R. Tolkien",
                    ISBN = "978-3-16-148410-4",
                    Image = "the_hobbit.jpg",
                    LanguageId = 1,
                    GenreId = 1,
                    PublisherId = 1,
                },
                new Book
                {
                    Id = 6,
                    Title = "The Lord of the Rings",
                    YearOfPublishing = 1954,
                    NumberOfPages = 1178,
                    Description = "A novel by J.R.R. Tolkien",
                    ISBN = "978-3-16-148410-5",
                    Image = "the_lord_of_the_rings.jpg",
                    LanguageId = 1,
                    GenreId = 1,
                    PublisherId = 1,
                }
            );
            
            modelBuilder.Entity<AuthorBook>().HasData(
                new AuthorBook { AuthorId = 1, BookId = 5 },
                new AuthorBook { AuthorId = 2, BookId = 6 },
                new AuthorBook { AuthorId = 5, BookId = 1 },
                new AuthorBook { AuthorId = 6, BookId = 2 },
                new AuthorBook { AuthorId = 10, BookId = 3 },
                new AuthorBook { AuthorId = 4, BookId = 4 }
            );
        }
    }
}