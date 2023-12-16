using Library.Blazor.Services.LanguageService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;

namespace Library.Blazor.Components.Pages.Languages;

partial class LanguagesHome
{
    [Inject]
    private ILanguageService? LanguageService { get; set; }
    
    private bool _isLoading = true;
    private IEnumerable<LanguageResponseDto> _languages = new List<LanguageResponseDto>();

    protected override async Task OnInitializedAsync()
    {
        _languages = await LanguageService!.GetLanguagesAsync();
        _languages = _languages.ToList();
        _isLoading = false;
    }
    
    private void AddLanguage(LanguageResponseDto language)
    {
        _languages.ToList().Add(language);
    }
    
    void EditLanguage(LanguageResponseDto language)
    {
        _languages.First(l => l.Id == language.Id).LanguageName = language.LanguageName;
        StateHasChanged();
    }

    async void DeleteLanguage(LanguageResponseDto language)
    {
        await LanguageService!.DeleteLanguageAsync(language.Id);
        _languages.ToList().RemoveAll(l => l.Id == language.Id);
        StateHasChanged();
    }
}