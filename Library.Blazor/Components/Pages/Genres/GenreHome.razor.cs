using Library.Blazor.Services.GenreService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Library.Blazor.Components.Pages.Genres;

partial class GenreHome
{
    [Inject]
    private IGenreService? GenreService { get; set; }
    [Inject]
    NotificationService NotificationService { get; set; }
    
    private IEnumerable<GenreResponseDto>? _genres;
    private bool _isLoading = true;


    protected override async Task OnInitializedAsync()
    {
        _genres = await GenreService!.GetGenresAsync();
        _isLoading = false;
    }
    
    private void AddGenre(GenreResponseDto genre)
    {
        _genres?.ToList().Add(genre);
        StateHasChanged();
        NotificationService.Notify(NotificationSeverity.Success, "Success", "Genre Added.");
    }
    
    private void EditGenre(GenreResponseDto genre)
    {
        _genres!.First(g => g.Id == genre.Id).Name = genre.Name;
        StateHasChanged();
        NotificationService.Notify(NotificationSeverity.Success, "Success", "Genre Edited.");
    }

    private async Task DeleteGenreAsync(GenreResponseDto genre)
    {
        try
        {
            await GenreService!.DeleteGenreAsync(genre.Id);
            _genres!.ToList().RemoveAll(g => g.Id == genre.Id);
            StateHasChanged();
            NotificationService.Notify(NotificationSeverity.Success, "Success", "Genre Deleted.");
        }
        catch (Exception e)
        {
            NotificationService.Notify(NotificationSeverity.Error, "Error", "Something went wrong, try again.");
            Console.WriteLine(e);
        }
    }
}