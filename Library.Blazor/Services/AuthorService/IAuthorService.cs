using Library.DTOs;

namespace Library.Blazor.Services.AuthorService
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorResponseDto>> GetAuthorsAsync();
        Task<AuthorResponseDto> GetAuthorByIdAsync(int id);
        Task<AuthorResponseDto> AddAuthorAsync(AuthorCreateDto author);
    }
}
