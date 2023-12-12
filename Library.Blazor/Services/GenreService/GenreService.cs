using System.Text;
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

        public async Task<GenreResponseDto> AddGenreAsync(GenreToCreateDto dto)
        {
            var genreJson = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(Endpoint, genreJson);
            response.EnsureSuccessStatusCode();
            
            var responseStream = await response.Content.ReadAsStreamAsync();
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var genre = JsonSerializer.DeserializeAsync<GenreResponseDto>(responseStream, options);
            return genre.Result!;
        }

        public async Task<GenreResponseDto> EditGenreAsync(GenreResponseDto dto)
        {
            var genreJson = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PatchAsync($"{Endpoint}/{dto.Id}", genreJson);
            response.EnsureSuccessStatusCode();
            return dto;
        }
        
        public async Task DeleteGenreAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Endpoint}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
