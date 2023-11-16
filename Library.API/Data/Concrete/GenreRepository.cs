using Biblioteka.Data;
using Library.API.Data.Abstract;
using Library.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Data.Concrete
{
    public class GenreRepository : IGenreRepository
    {
        private readonly LibraryDbContext _context;

        public GenreRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre> GetGenreById(int id)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(x => x.Id == id);
            ArgumentNullException.ThrowIfNull(genre);
            return genre;
        }

        public Task AddGenre(Genre genre)
        {
            ArgumentNullException.ThrowIfNull(genre);
            _context.Genres.Add(genre);
            return _context.SaveChangesAsync();
        }

        public async Task UpdateGenre(Genre genre)
        {
            ArgumentNullException.ThrowIfNull(genre);

            var genreToUpdate = await _context.Genres.FirstOrDefaultAsync(x => x.Id == genre.Id);
            ArgumentNullException.ThrowIfNull(genreToUpdate);

            _context.Entry(genreToUpdate).CurrentValues.SetValues(genre);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGenre(int id)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(x => x.Id == id);
            ArgumentNullException.ThrowIfNull(genre);

            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
        }
    }
}
