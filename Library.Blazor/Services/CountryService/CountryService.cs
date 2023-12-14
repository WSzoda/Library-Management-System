using System.Text;
using System.Text.Json;
using Library.DTOs;

namespace Library.Blazor.Services.CountryService;

public class CountryService : ICountryService
{
    private const string Endpoint = "api/countries";
    private readonly HttpClient _httpClient;

    public CountryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<CountryResponseDto>> GetCountriesAsync()
    {
        var stream = await _httpClient.GetStreamAsync(Endpoint);
        var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        var countries = await JsonSerializer.DeserializeAsync<IEnumerable<CountryResponseDto>>(stream, options);
        return countries!;
    }

    public async Task<CountryResponseDto> AddCountryAsync(CountryCreateDto countryCreateDto)
    {
        var countryJson = new StringContent(JsonSerializer.Serialize(countryCreateDto), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(Endpoint, countryJson);
        if (response.IsSuccessStatusCode)
        {
            var stream = response.Content.ReadAsStreamAsync();
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var country = await JsonSerializer.DeserializeAsync<CountryResponseDto>(stream.Result, options);
            return country!;
        }
        else
        {
            throw new Exception("Something went wrong");
        }
    }
    
    public async Task<CountryResponseDto> EditCountryAsync(CountryResponseDto country)
    {
        var countryJson = new StringContent(JsonSerializer.Serialize(country), Encoding.UTF8, "application/json");
        var response = await _httpClient.PatchAsync($"{Endpoint}/{country.Id}", countryJson);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Something went wrong");
        }

        return country;
    }

    public async Task DeleteCountryAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{Endpoint}/{id}");
        response.EnsureSuccessStatusCode();
    }
}