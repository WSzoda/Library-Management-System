using Biblioteka.Data.Abstract;
using Library.Domain;
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

        public async Task<IEnumerable<AuthorBook>> GetAuthorBooks(int id, bool getByAuthorId = true)
        {
            if (id < 0)
            {
                throw new ArgumentException("Invalid argument: ID cannot be less than zero.");
            }

            IQueryable<AuthorBook> query = _context.AuthorBooks.Include(ab => ab.Author).Include(ab => ab.Book);

            if (getByAuthorId)
            {
                query = query.Where(ab => ab.AuthorId == id);
            }
            else
            {
                query = query.Where(ab => ab.BookId == id);
            }

            var authorBooks = await query.ToListAsync();
            return authorBooks;
        }

        public async Task<IEnumerable<AuthorBook>> GetAuthorBooks()
        {
            return await _context.AuthorBooks.Include(ab => ab.Author).Include(ab => ab.Book).ToListAsync();
        }
    }
}
