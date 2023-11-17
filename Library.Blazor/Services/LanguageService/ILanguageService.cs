using Library.DTOs;

namespace Library.Blazor.Services.LanguageService
{
    public interface ILanguageService
    {
        Task<IEnumerable<LanguageResponseDto>> GetLanguagesAsync();
    }
}
