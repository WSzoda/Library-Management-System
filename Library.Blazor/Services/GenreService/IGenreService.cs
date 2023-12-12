using Library.Domain;
using Library.DTOs;

namespace Library.Blazor.Services.GenreService
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreResponseDto>> GetGenresAsync();
        Task<GenreResponseDto> AddGenreAsync(GenreToCreateDto dto);
        Task<GenreResponseDto> EditGenreAsync(GenreResponseDto dto);
        Task DeleteGenreAsync(int id);
    }
}
