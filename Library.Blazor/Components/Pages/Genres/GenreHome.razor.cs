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
        _genres = _genres.ToList();
        _isLoading = false;
    }
    
    void EditGenre(GenreResponseDto genre)
    {
        // Implement the logic for editing a genre here
    }

    void DeleteGenre(GenreResponseDto genre)
    {
        // Implement the logic for deleting a genre here
    }
}