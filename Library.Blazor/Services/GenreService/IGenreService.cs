using Library.DTOs;

namespace Library.Blazor.Services.GenreService
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreResponseDto>> GetGenresAsync();
    }
}
