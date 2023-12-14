using Library.Blazor.Services.CountryService;
using Library.Blazor.Services.LanguageService;
using Library.Blazor.Services.PublisherService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;

namespace Library.Blazor.Components.Comps;

partial class PublisherModal
{
    [Parameter]
    public Action<PublisherResponseDto>? OnPublisherAdded { get; set; }
    
    [Parameter]
    public Action<PublisherResponseDto>? OnPublisherEdited { get; set; }
    
    [Parameter]
    public bool IsEdited { get; set; }
    
    [Parameter]
    public PublisherResponseDto? PublisherToEdit { get; set; }
    
    [Inject]
    private IPublisherService? PublisherService { get; set; }
    [Inject]
    private ICountryService? CountryService { get; set; }

    private string _publisherName = default!;
    private int _yearOfCreation;
    private int _countryId;
    private bool _isOpen;
    private string _selectedCountry = string.Empty;
    private IEnumerable<CountryResponseDto> _countries = new List<CountryResponseDto>();
    private string _modalButtonsText = "Add Publisher";

    protected override async Task OnInitializedAsync()
    {
        _countries = await CountryService!.GetCountriesAsync();
        _countries = _countries.ToList();
        if (IsEdited)
        {
            _publisherName = PublisherToEdit!.Name;
            _yearOfCreation = PublisherToEdit.YearOfCreation;
            _selectedCountry = _countries.First(c => c.Id == PublisherToEdit.CountryId).Name;
            _modalButtonsText = "Edit Publisher";
        }
    }
    
    
    private async Task HandleSubmit()
    {
        var country = _countries.FirstOrDefault(c => c.Name == _selectedCountry);
        if(country == null || _publisherName == string.Empty || _yearOfCreation == 0)
        {
            return;
        }
        
        var publisher = new PublisherCreateDto() { Name = _publisherName, YearOfCreation = _yearOfCreation, CountryId = country.Id};
        try
        {
            var newPublisher = await PublisherService!.AddPublisherAsync(publisher);
            OnPublisherAdded?.Invoke(newPublisher);
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
    
    private void AddNewCountry(CountryResponseDto country)
    {
        _countries = _countries.Append(country);
        _selectedCountry = country.Name;
        StateHasChanged();
    }

}