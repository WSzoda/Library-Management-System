using Biblioteka.Data.Abstract;
using Biblioteka.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka.Data.Concrete
{
    public class AuthorBookRepository : IAuthorBookRepository
    {
        private readonly LibraryDbContext _context;

        public AuthorBookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task AddAuthorBook(AuthorBook authorBook)
        {
            ArgumentNullException.ThrowIfNull(authorBook);

            _context.AuthorBooks.Add(authorBook);
            await _context.SaveChangesAsync();
        }

        public async Task AddAuthorBooks(IEnumerable<AuthorBook> authorBooks)
        {
            ArgumentNullException.ThrowIfNull(authorBooks);

            _context.AuthorBooks.AddRange(authorBooks);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAuthorBook(int authorId, int bookId)
        {
            if(authorId < 0 || bookId < 0)
            {
                throw new ArgumentException("Invalid argument: authorId or bookId cannot be less than zero.");
            }
            var authorBook = _context.AuthorBooks.FirstOrDefaultAsync(ab => ab.AuthorId == authorId && ab.BookId == bookId);
            ArgumentNullException.ThrowIfNull(authorBook);

            _context.Remove(authorBook);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AuthorBook>> GetAuthorBooksForAuthorId(int authorId)
        {
            if(authorId < 0)
            {
                throw new ArgumentException("Invalid argument: authorId cannot be less than zero.");
            }
            var authorBooks = await _context.AuthorBooks.Include(ab => ab.Author).Include(ab => ab.Book).Where(ab => ab.AuthorId == authorId).ToListAsync();
            return authorBooks;
        }

        public async Task<IEnumerable<AuthorBook>> GetAuthorBooksForBookId(int bookId)
        {
            if (bookId < 0)
            {
                throw new ArgumentException("Invalid argument: bookId cannot be less than zero.");
            }
            var authorBooks = await _context.AuthorBooks.Include(ab => ab.Author).Include(ab => ab.Book).Where(ab => ab.BookId == bookId).ToListAsync();
            return authorBooks;
        }
        public async Task<IEnumerable<AuthorBook>> GetAuthorBooks()
        {
            return await _context.AuthorBooks.Include(ab => ab.Author).Include(ab => ab.Book).ToListAsync();
        }
    }
}
