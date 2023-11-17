using Library.Domain;
using Library.DTOs;

namespace Library.Blazor.Services.BookService
{
    public interface IBooksService
    {
        Task<IEnumerable<BookResponseDto>> GetBooksAsync();
        Task<IEnumerable<BookResponseDto>> GetBooksAsync(List<int>? genreIds);
        Task<BookResponseDto> GetBookAsync(int id);
    }
}