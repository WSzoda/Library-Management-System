using Library.Blazor.Services.AuthorService;
using Library.Blazor.Services.CountryService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;
using static System.String;

namespace Library.Blazor.Components.Comps;

partial class AddAuthorModal
{
    //TODO: End implementation
    [Parameter]
    public Action<AuthorResponseDto>? OnAuthorAdded { get; set; }
    
    [Inject]
    private IAuthorService? AuthorService { get; set; }
    [Inject]
    private ICountryService? CountryService { get; set; }

    private string _name = default!;
    private string _surname = default!;
    private string _selectedCountry = default!;
    private bool _isOpen;
    private IEnumerable<CountryResponseDto> _countries = default!;

    protected override async Task OnInitializedAsync()
    {
        _countries = await CountryService!.GetCountriesAsync();
        _countries = _countries.ToList();
    }

    private async Task HandleSubmit()
    {
        var country = _countries.FirstOrDefault(c => c.Name == _selectedCountry);
        if (country == null || IsNullOrEmpty(_name) || IsNullOrEmpty(_surname))
        { 
            return; 
        }
        var author = new AuthorCreateDto() { Name = _name, Surname = _surname, CountryId = country.Id};
        try
        {
            var newAuthor = await AuthorService!.AddAuthorAsync(author);
            OnAuthorAdded?.Invoke(newAuthor);
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
