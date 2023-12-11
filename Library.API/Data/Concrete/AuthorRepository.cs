using Library.API.Data.Abstract;
using Library.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Data.Concrete
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext _context;

        public AuthorRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task AddAuthor(Author author)
        {
            ArgumentNullException.ThrowIfNull(author);

            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAuthor(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentNullException(nameof(id));
            }
            
            var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);
            ArgumentNullException.ThrowIfNull(author);

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            var authors = await _context.Authors
                .Include(a => a.AuthorBooks!)
                .ThenInclude(ba => ba.Book)
                .Include(a => a.Country)
                .AsSplitQuery()
                .ToListAsync();
            return authors;
        }

        public async Task<Author> GetAuthorById(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);
            ArgumentNullException.ThrowIfNull(author);

            return author;
        }

        public async Task UpdateAuthor(Author author)
        {
            ArgumentNullException.ThrowIfNull(author);

            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }
    }
}