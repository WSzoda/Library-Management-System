using Library.Blazor.Services.AuthorService;
using Library.Blazor.Services.BookService;
using Library.Blazor.Services.GenreService;
using Library.Blazor.Services.LanguageService;
using Library.Blazor.Services.PublisherService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

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
        [Inject]
        private IBooksService BookService { get; set; }



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
            if (SelectedAuthor == String.Empty || SelectedGenre == String.Empty || SelectedLanguage == String.Empty ||
                SelectedPublisher == String.Empty)
            {
                return;
            }

            BookCreateDto bookCreateDto = new BookCreateDto
            {
                Title = _bookCreateDto.Title,
                YearOfPublishing = _bookCreateDto.YearOfPublishing,
                NumberOfPages = _bookCreateDto.NumberOfPages,
                Description = _bookCreateDto.Description,
                ISBN = _bookCreateDto.ISBN,
                Image = "Brak",
                LanguageId = LanguagesList.FirstOrDefault(l => l.LanguageName == SelectedLanguage)!.Id,
                GenreId = GenresList.FirstOrDefault(g => g.Name == SelectedGenre)!.Id,
                PublisherId = PublishersList.FirstOrDefault(p => p.Name == SelectedPublisher)!.Id,
                AuthorsIds = AuthorsList.Where(a => (a.Name + " " + a.Surname) == SelectedAuthor).Select(a => a.Id)
            };

            BookService.CreateBookAsync(bookCreateDto);
        }

        protected override async Task OnInitializedAsync()
        {
            AuthorsList = await AuthorService.GetAuthorsAsync();
            LanguagesList = await LanguageService.GetLanguagesAsync();
            GenresList = await GenreService.GetGenresAsync();
            PublishersList = await PublisherService.GetPublishersAsync();
        }

        private async Task HandleFileUpload(InputFileChangeEventArgs e)
        {
            var file = e.File;

            if (file is not null)
            {
                //TODO: Add image upload
            }
        }
    }
}
