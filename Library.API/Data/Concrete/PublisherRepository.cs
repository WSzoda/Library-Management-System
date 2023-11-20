using Biblioteka.Data;
using Library.API.Data.Abstract;
using Library.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Data.Concrete
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly LibraryDbContext _context;

        public PublisherRepository(LibraryDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Publisher>> GetAllPublishers()
        {
            var publishers = await _context.Publishers
                .Include(p => p.Books)
                .Include(p => p.Country)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();
            return publishers;
        }

        public async Task<Publisher> GetPublisherById(int id)
        {
            if (id <= 0)
            { 
                throw new ArgumentException("Id cannot be less than 1");
            }
            var publisher = await _context.Publishers
                .Include(p => p.Books)
                .Include(p => p.Country)
                .AsSplitQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            ArgumentNullException.ThrowIfNull(publisher);
            return publisher;
        }
    }
}
