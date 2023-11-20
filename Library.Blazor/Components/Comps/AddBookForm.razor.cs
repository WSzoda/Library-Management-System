using Library.Blazor.Services.AuthorService;
using Library.Blazor.Services.GenreService;
using Library.Blazor.Services.LanguageService;
using Library.Blazor.Services.PublisherService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;

namespace Library.Blazor.Components.Comps
{
    public partial class AddBookForm
    {
        [Inject]
        private IAuthorService AuthorService { get; set; }
        [Inject]
        private IGenreService GenreService { get; set; }
        [Inject]
        private ILanguageService LanguageService { get; set; }
        [Inject]
        private IPublisherService PublisherService { get; set; }



        private IEnumerable<AuthorResponseDto> AuthorsList { get; set; } = new List<AuthorResponseDto>();
        private IEnumerable<LanguageResponseDto> LanguagesList { get; set; } = new List<LanguageResponseDto>();
        private IEnumerable<GenreResponseDto> GenresList { get; set; } = new List<GenreResponseDto>();
        private IEnumerable<PublisherResponseDto> PublishersList { get; set; } = new List<PublisherResponseDto>();
        private string SelectedAuthor { get; set; } = String.Empty;
        private string SelectedGenre { get; set; } = String.Empty;
        private string SelectedLanguage { get; set; } = String.Empty;
        private string SelectedPublisher { get; set; } = String.Empty;

        private BookCreateDto _bookCreateDto = new BookCreateDto();

        private void CreateBook()
        {

        }

        protected override async Task OnInitializedAsync()
        {
            AuthorsList = await AuthorService.GetAuthorsAsync();
            LanguagesList = await LanguageService.GetLanguagesAsync();
            GenresList = await GenreService.GetGenresAsync();
            PublishersList = await PublisherService.GetPublishersAsync();
        }
    }
}
