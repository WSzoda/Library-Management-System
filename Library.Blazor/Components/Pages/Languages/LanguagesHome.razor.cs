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
    
    void EditLanguage(LanguageResponseDto language)
    {
        // Implement the logic for editing a genre here
    }

    void DeleteLanguage(LanguageResponseDto language)
    {
        // Implement the logic for deleting a genre here
    }
}