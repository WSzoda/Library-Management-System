using Library.Domain;
using Library.DTOs;

namespace Library.Blazor.Services.BookService
{
    public interface IBooksService
    {
        Task<IEnumerable<BookResponseDto>> GetBooksAsync(List<int>? genreIds, List<int>? languageIds);
        Task<BookResponseDto> GetBookAsync(int id);
        Task<BookResponseDto> CreateBookAsync(BookCreateDto book);
    }
}