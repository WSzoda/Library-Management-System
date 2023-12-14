using Library.Blazor.Services.LanguageService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;

namespace Library.Blazor.Components.Comps;

partial class LanguageModal
{
    [Parameter]
    public Action<LanguageResponseDto>? OnLanguageAdded { get; set; }
    
    [Parameter]
    public Action<LanguageResponseDto>? OnLanguageEdited { get; set; }
    
    [Parameter]
    public bool IsEdited { get; set; }
    
    [Parameter]
    public LanguageResponseDto? LanguageToEdit { get; set; }
    
    [Inject]
    private ILanguageService? LanguageService { get; set; }

    private string _languageName = default!;
    private bool _isOpen;
    private string _modalButtonsText = "Add Language";

    protected override void OnInitialized()
    {
        if(!IsEdited) return;
        _languageName = LanguageToEdit!.LanguageName;
        _modalButtonsText = "Edit Language";
    }


    private async Task HandleSubmit()
    {
        if (IsEdited)
        {
            LanguageToEdit!.LanguageName = _languageName;
            try
            {
                var editedLanguage = await LanguageService!.EditLanguageAsync(LanguageToEdit);
                OnLanguageEdited?.Invoke(editedLanguage);
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
        else
        {
            var language = new LanguageCreateDto { LanguageName = _languageName };
            try
            {
                var newLanguage = await LanguageService!.AddLanguageAsync(language);
                OnLanguageAdded?.Invoke(newLanguage);
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