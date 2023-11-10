using Biblioteka.Data.Abstract;
using Biblioteka.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka.Data.Concrete
{
    public class BooksRepository : IBooksRepository
    {
        private readonly LibraryDbContext _context;

        public BooksRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async void AddBook(Book book)
        {
            ArgumentNullException.ThrowIfNull(book);

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async void DeleteBook(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            ArgumentNullException.ThrowIfNull(book);

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var books = await _context.Books
                .Include(b => b.Language)
                .Include(b => b.Genre)
                .Include(b => b.Publisher)
                .Include(b => b.BookAuthors!)
                .ThenInclude(ba => ba.Author)
                .Include(b => b.Reviews)
                .AsSplitQuery()
                .ToListAsync();
            return books;
        }

        public async Task<Book> GetBookById(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var book = await _context.Books
                .Include(b => b.Language)
                .Include(b => b.Genre)
                .Include(b => b.Publisher)
                .Include(b => b.BookAuthors!)
                .ThenInclude(ba => ba.Author)
                .Include(b => b.Reviews)
                .AsSplitQuery()
                .FirstOrDefaultAsync(x => x.Id == id);
            
            ArgumentNullException.ThrowIfNull(book);
            return book;
        }
        public async void UpdateBook(Book book)
        {
            ArgumentNullException.ThrowIfNull(book);

            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
    }
}