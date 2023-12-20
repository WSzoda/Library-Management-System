using Library.Domain;
using Library.DTOs;

namespace Library.Blazor.Services.BookService
{
    public interface IBookService
    {
        Task<IEnumerable<BookResponseDto>> GetBooksAsync(List<int>? genreIds, List<int>? languageIds);
        Task<BookResponseDto> GetBookAsync(int id);
        Task<BookResponseDto> CreateBookAsync(BookCreateDto book);
        Task<BookResponseDto> EditBookAsync(int bookId, BookCreateDto book);
    }
}