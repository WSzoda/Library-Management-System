using Library.Domain;
using Library.DTOs;

namespace Library.Blazor.Services
{
    public interface IBooksService
    {
        Task<IEnumerable<BookResponseDto>> GetBooksAsync();
        Task<BookResponseDto> GetBookAsync(int id);
    }
}