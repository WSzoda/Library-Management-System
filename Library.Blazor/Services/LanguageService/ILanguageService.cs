using Library.DTOs;

namespace Library.Blazor.Services.LanguageService
{
    public interface ILanguageService
    {
        Task<IEnumerable<LanguageResponseDto>> GetLanguagesAsync();
        public Task<LanguageResponseDto> AddLanguageAsync(LanguageCreateDto language);   
    }
}
