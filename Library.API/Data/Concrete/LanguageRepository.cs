using Biblioteka.Data;
using Library.API.Data.Abstract;
using Library.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Data.Concrete
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly LibraryDbContext _context;

        public LanguageRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Language>> GetAllLanguages()
        {
            var languages = await _context.Languages.ToListAsync();
            return languages;
        }

        public async Task<Language> GetLanguageById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id cannot be less than 1");
            }

            var language = await _context.Languages.FirstOrDefaultAsync(x => x.Id == id);
            ArgumentNullException.ThrowIfNull(language);

            return language;
        }

        public async Task AddLanguage(Language language)
        {
            ArgumentNullException.ThrowIfNull(language);
            _context.Languages.Add(language);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLanguage(Language language)
        {
            ArgumentNullException.ThrowIfNull(language);

            var languageToUpdate = await _context.Languages.FirstOrDefaultAsync(x => x.Id == language.Id);
            ArgumentNullException.ThrowIfNull(languageToUpdate);

            _context.Entry(languageToUpdate).CurrentValues.SetValues(language);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLanguage(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id cannot be less than 1");
            }

            var languageToDelete = await _context.Languages.FirstOrDefaultAsync(x => x.Id == id);
            ArgumentNullException.ThrowIfNull(languageToDelete);

            _context.Languages.Remove(languageToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
