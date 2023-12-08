using Library.Blazor.Services.GenreService;
using Library.Blazor.Services.LanguageService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;

namespace Library.Blazor.Components.Comps;

partial class AddGenreModal
{
    [Parameter]
    public Action<GenreResponseDto>? OnGenreAdded { get; set; }
    
    [Inject]
    private IGenreService? GenreService { get; set; }

    private string _genreName = default!;
    private bool _isOpen;

    private async Task HandleSubmit()
    {
        var genre = new GenreToCreateDto() { Name = _genreName };
        try
        {
            var newGenre = await GenreService!.AddGenreAsync(genre);
            OnGenreAdded?.Invoke(newGenre);
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