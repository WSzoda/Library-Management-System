using Library.Blazor.Services.CountryService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;

namespace Library.Blazor.Components.Comps;

partial class AddCountryModal
{
    [Parameter]
    public Action<CountryResponseDto>? OnCountryAdded { get; set; }
    
    [Inject]
    private ICountryService? CountryService { get; set; }

    private string _countryName = default!;
    private bool _isOpen;

    private async Task HandleSubmit()
    {
        var country = new CountryCreateDto() { Name = _countryName };
        try
        {
            var newCountry = await CountryService!.AddCountryAsync(country);
            OnCountryAdded?.Invoke(newCountry);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
        finally
        {
            CloseModal();
        }
    }

    private void CloseModal()
    {
        _isOpen = false;
    }
    
    private void OpenModal()
    {
        _isOpen = true;
    }

}