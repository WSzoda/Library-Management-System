using Library.Blazor.Services.BookService;
using Library.Blazor.Services.GenreService;
using Library.Blazor.Services.LanguageService;
using Library.Domain;
using Library.DTOs;
using Microsoft.AspNetCore.Components;

namespace Library.Blazor.Components.Pages
{
    public partial class Books
    {
        [Inject]
        private IBooksService BooksService { get; set; }

        [Inject]
        private IGenreService GenreService { get; set; }

        [Inject]
        private ILanguageService LanguageService { get; set; }

        private IEnumerable<BookResponseDto> BooksList { get; set; } = new List<BookResponseDto>();
        private IEnumerable<GenreResponseDto> GenresList { get; set; } = new List<GenreResponseDto>();
        private IEnumerable<LanguageResponseDto> LanguagesList { get; set; } = new List<LanguageResponseDto>();
        private IEnumerable<int> SelectedGenresIds { get; set; } = new List<int>();
        private IEnumerable<int> SelectedLanguagesIds { get; set; } = new List<int>();

        private bool IsLoading { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            GenresList = await GenreService.GetGenresAsync();
            LanguagesList = await LanguageService.GetLanguagesAsync();
            BooksList = await BooksService.GetBooksAsync(null, null);
            IsLoading = false;
        }

        private void HandleSelectedGenresChanged(IEnumerable<int> newSelectedGenreIds)
        {
            SelectedGenresIds = newSelectedGenreIds;
        }

        private void HandleSelectedLanguagesChanged(IEnumerable<int> newSelectedLanguageIds)
        {
            SelectedLanguagesIds = newSelectedLanguageIds;
        }

        private async Task Filter()
        { 
            BooksList = await BooksService.GetBooksAsync(SelectedGenresIds.ToList(), SelectedLanguagesIds.ToList());
        }
    }
}