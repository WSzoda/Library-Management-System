using Library.Blazor.Services.GenreService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;

namespace Library.Blazor.Components.Pages.Genres;

partial class GenreHome
{
    [Inject]
    private IGenreService? GenreService { get; set; }
    
    private IEnumerable<GenreResponseDto>? _genres;
    private bool _isLoading = true;


    protected override async Task OnInitializedAsync()
    {
        _genres = await GenreService!.GetGenresAsync();
        _isLoading = false;
    }
    
    private void EditGenre(GenreResponseDto genre)
    {
        _genres!.First(g => g.Id == genre.Id).Name = genre.Name;
        StateHasChanged();
    }

    private async Task DeleteGenreAsync(GenreResponseDto genre)
    {
        await GenreService!.DeleteGenreAsync(genre.Id);
        _genres!.ToList().RemoveAll(g => g.Id == genre.Id);
        StateHasChanged();
    }
}