using Library.DTOs;
using System.Text.Json;

namespace Library.Blazor.Services.GenreService
{
    public class GenreService : IGenreService
    {
        private const string Endpoint = "api/genres";
        private readonly HttpClient _httpClient;

        public GenreService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<IEnumerable<GenreResponseDto>> GetGenresAsync()
        {
            var stream = await _httpClient.GetStreamAsync(Endpoint);
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var genres = await JsonSerializer.DeserializeAsync<IEnumerable<GenreResponseDto>>(stream, options);
            return genres!;
        }
    }
}
