using Library.DTOs;

namespace Library.Blazor.Services.CountryService;

public interface ICountryService
{
    Task<IEnumerable<CountryResponseDto>> GetCountriesAsync();
    Task<CountryResponseDto> AddCountryAsync(CountryCreateDto countryCreateDto);
    Task<CountryResponseDto> EditCountryAsync(CountryResponseDto country);
    Task DeleteCountryAsync(int id);
}