using Library.Domain;

namespace Library.API.Data.Abstract
{
    public interface ILanguageRepository
    {
        Task<IEnumerable<Language>> GetAllLanguages();
        Task<Language> GetLanguageById(int id);
        Task AddLanguage(Language language);
        Task UpdateLanguage(Language language);
        Task DeleteLanguage(int id);
    }
}
