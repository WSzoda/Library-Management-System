using Library.Blazor.Services.CountryService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;

namespace Library.Blazor.Components.Pages.Countries;

partial class CountriesHome
{
    [Inject]
    private ICountryService? CountryService { get; set; }
    
    private IEnumerable<CountryResponseDto>? _countries;
    private bool _isLoading = true;
    
    protected override async Task OnInitializedAsync()
    {
        _countries = await CountryService!.GetCountriesAsync();
        _countries = _countries.ToList();
        _isLoading = false;
    }
    
    private void AddCountry(CountryResponseDto country)
    {
        _countries?.ToList().Add(country);
    }
    
    private void EditCountry(CountryResponseDto country)
    {
        _countries!.First(l => l.Id == country.Id).Name = country.Name;
        StateHasChanged();
    }
    
    private async void DeleteCountry(CountryResponseDto country)
    {
        await CountryService!.DeleteCountryAsync(country.Id);
        _countries!.ToList().RemoveAll(l => l.Id == country.Id);
        StateHasChanged();
    }
}