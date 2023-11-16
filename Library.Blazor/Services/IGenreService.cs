using Library.DTOs;

namespace Library.Blazor.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreResponseDto>> GetGenresAsync();
    }
}
