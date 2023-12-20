using Library.Blazor.Services.GenreService;
using Library.Blazor.Services.LanguageService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Library.Blazor.Components.Comps;

partial class GenreModal
{
    [Parameter]
    public Action<GenreResponseDto>? OnGenreAdded { get; set; }
    
    [Parameter]
    public Action<GenreResponseDto>? OnGenreEdited { get; set; }
    
    [Parameter]
    public bool IsEdited { get; set; }
    
    [Parameter]
    public GenreResponseDto? GenreToEdit { get; set; }
    
    [Inject]
    private IGenreService? GenreService { get; set; }
    [Inject]
    NotificationService NotificationService { get; set; }

    private string _genreName = default!;
    private bool _isOpen;
    private string _modalButtonsText = "Add Genre";


    protected override void OnInitialized()
    {
        if (!IsEdited) return;
        _genreName = GenreToEdit!.Name;
        _modalButtonsText = "Edit Genre";
    }

    private async Task HandleSubmit()
    {
        if(IsEdited)
        {
            GenreToEdit!.Name = _genreName;
            try
            {
                var editedGenre = await GenreService!.EditGenreAsync(GenreToEdit);
                OnGenreEdited?.Invoke(editedGenre);
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
        else
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