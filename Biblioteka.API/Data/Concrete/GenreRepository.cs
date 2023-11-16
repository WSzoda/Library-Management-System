using Biblioteka.Data;
using Library.API.Data.Abstract;
using Library.Domain;

namespace Library.API.Data.Concrete
{
    public class GenreRepository : IGenreRepository
    {
        private readonly LibraryDbContext _context;

        public GenreRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Genre>> GetAllGenres()
        {
            throw new NotImplementedException();
        }

        public Task<Genre> GetGenreById(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddGenre(Genre genre)
        {
            throw new NotImplementedException();
        }

        public Task UpdateGenre(Genre genre)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGenre(int id)
        {
            throw new NotImplementedException();
        }
    }
}
