using Library.Blazor.Services.LanguageService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;

namespace Library.Blazor.Components.Comps;

partial class AddLanguageForm
{
    [Inject]
    private ILanguageService? LanguageService { get; set; }

    private string _languageName = default!;
    private bool _isOpen = false;

    private async Task HandleSubmit()
    {
        var language = new LanguageCreateDto { Name = _languageName };
        try
        {
            await LanguageService!.AddLanguageAsync(language);
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