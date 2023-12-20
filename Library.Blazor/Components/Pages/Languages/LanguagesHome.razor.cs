using Library.Blazor.Services.LanguageService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Library.Blazor.Components.Pages.Languages;

partial class LanguagesHome
{
    [Inject]
    private ILanguageService? LanguageService { get; set; }
    
    private bool _isLoading = true;
    private IEnumerable<LanguageResponseDto> _languages = new List<LanguageResponseDto>();
    [Inject]
    NotificationService NotificationService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _languages = await LanguageService!.GetLanguagesAsync();
        _languages = _languages.ToList();
        _isLoading = false;
    }
    
    private void AddLanguage(LanguageResponseDto language)
    {
        var newLanguages = _languages.ToList();
        newLanguages.Add(language);
        _languages = newLanguages;
        StateHasChanged();
        NotificationService.Notify(NotificationSeverity.Success, "Success", "Language added.");
    }
    
    void EditLanguage(LanguageResponseDto language)
    {
        _languages.First(l => l.Id == language.Id).LanguageName = language.LanguageName;
        StateHasChanged();
        NotificationService.Notify(NotificationSeverity.Success, "Success", "Language edited.");
    }

    async void DeleteLanguage(LanguageResponseDto language)
    {
        try
        {
            await LanguageService!.DeleteLanguageAsync(language.Id);
            _languages = _languages.Where(l => l.Id != language.Id).ToList();
            StateHasChanged();
            NotificationService.Notify(NotificationSeverity.Success, "Success", "Language deleted.");
        }
        catch (Exception e)
        {
            NotificationService.Notify(NotificationSeverity.Error, "Error", "Something went wrong, try again.");
            Console.WriteLine(e.Message);
        }
    }
}