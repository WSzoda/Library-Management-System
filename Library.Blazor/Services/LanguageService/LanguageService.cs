using System.Net.Http.Json;
using System.Text.Json;
using Library.DTOs;

namespace Library.Blazor.Services.LanguageService
{
    public class LanguageService : ILanguageService
    {
        private const string Endpoint = "api/languages";
        private readonly HttpClient _httpClient;

        public LanguageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<LanguageResponseDto>> GetLanguagesAsync()
        {
            var stream = await _httpClient.GetStreamAsync(Endpoint);
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var languages = await JsonSerializer.DeserializeAsync<IEnumerable<LanguageResponseDto>>(stream, options);
            return languages!;
        }
    }
}
