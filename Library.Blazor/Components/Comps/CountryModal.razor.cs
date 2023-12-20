using Library.Blazor.Services.CountryService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Library.Blazor.Components.Comps;

partial class CountryModal
{
    [Parameter]
    public Action<CountryResponseDto>? OnCountryAdded { get; set; }
    
    [Parameter]
    public Action<CountryResponseDto>? OnCountryEdited { get; set; }
    
    [Parameter]
    public bool IsEdited { get; set; }
    
    [Parameter]
    public CountryResponseDto? CountryToEdit { get; set; }
    
    
    [Inject]
    private ICountryService? CountryService { get; set; }
    [Inject]
    NotificationService NotificationService { get; set; }

    private string _countryName = default!;
    private bool _isOpen;
    private string _modalButtonsText = "Add Country";

    protected override void OnInitialized()
    {
        if (!IsEdited) return;
        _countryName = CountryToEdit!.Name;
        _modalButtonsText = "Edit Country";
    }
    
    private async Task HandleSubmit()
    {
        if (IsEdited)
        {
            try
            {
                CountryToEdit!.Name = _countryName;
                var editedCountry = await CountryService!.EditCountryAsync(CountryToEdit);
                OnCountryEdited?.Invoke(editedCountry);
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
        var country = new CountryCreateDto() { Name = _countryName };
        try
        {
            var newCountry = await CountryService!.AddCountryAsync(country);
            OnCountryAdded?.Invoke(newCountry);
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

}