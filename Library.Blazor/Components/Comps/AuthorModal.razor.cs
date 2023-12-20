using Library.Blazor.Services.AuthorService;
using Library.Blazor.Services.CountryService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;
using Radzen;
using static System.String;

namespace Library.Blazor.Components.Comps;

partial class AuthorModal
{
    [Parameter]
    public Action<AuthorResponseDto>? OnAuthorAdded { get; set; }
    
    [Parameter]
    public Action<AuthorResponseDto>? OnAuthorEdited { get; set; }
    
    [Parameter]
    public AuthorResponseDto? AuthorToEdit { get; set; }
    
    [Parameter]
    public bool IsEdited { get; set; }

    [Inject]
    private IAuthorService? AuthorService { get; set; }
    [Inject]
    private ICountryService? CountryService { get; set; }
    [Inject]
    NotificationService NotificationService { get; set; }

    private string _name = default!;
    private string _surname = default!;
    private string _selectedCountry = default!;
    private bool _isOpen;
    private string _modalButtonsText = "Add Author";
    private IEnumerable<CountryResponseDto> _countries = default!;

    protected override async Task OnInitializedAsync()
    {
        _countries = await CountryService!.GetCountriesAsync();
        _countries = _countries.ToList();
        if (IsEdited)
        {
            _name = AuthorToEdit!.Name;
            _surname = AuthorToEdit.Surname;
            _selectedCountry = _countries.First(c => c.Id == AuthorToEdit.CountryId).Name;
            _modalButtonsText = "Edit Author";
        }
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
            NotificationService.Notify(NotificationSeverity.Error, "Error", "Something went wrong, try again.");
            Console.WriteLine(e.Message);
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
    
    private void AddNewCountry(CountryResponseDto country)
    {
        _countries = _countries.Append(country);
        _selectedCountry = country.Name;
        StateHasChanged();
    }
}
