using Library.DTOs;

namespace Library.Blazor.Services.LanguageService
{
    public interface ILanguageService
    {
        Task<IEnumerable<LanguageResponseDto>> GetLanguagesAsync();
        public Task AddLanguageAsync(LanguageCreateDto language);   
    }
}
