using Library.DTOs;
using System.Text.Json;

namespace Library.Blazor.Services
{
    public class GenreService : IGenreService
    {
        private readonly HttpClient _httpClient;

        public GenreService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<IEnumerable<GenreResponseDto>> GetGenresAsync()
        {
            var stream = await _httpClient.GetStreamAsync("api/genres");
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var genres = await JsonSerializer.DeserializeAsync<IEnumerable<GenreResponseDto>>(stream, options);
            return genres!;
        }
    }
}
