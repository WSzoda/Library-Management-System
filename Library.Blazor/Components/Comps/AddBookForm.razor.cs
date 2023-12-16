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
        [Parameter]
        public bool IsEdited { get; set; }
        
        [Inject]
        private IAuthorService AuthorService { get; set; }
        [Inject]
        private IGenreService GenreService { get; set; }
        [Inject]
        private ILanguageService LanguageService { get; set; }
        [Inject]
        private IPublisherService PublisherService { get; set; }
        [Inject]
        private IBookService BookService { get; set; }

        
        
        private bool _isOpen;
        private string _modalButtonsText = "Add Book";


        private IEnumerable<AuthorResponseDto> AuthorsList { get; set; } = new List<AuthorResponseDto>();
        private IEnumerable<LanguageResponseDto> LanguagesList { get; set; } = new List<LanguageResponseDto>();
        private IEnumerable<GenreResponseDto> GenresList { get; set; } = new List<GenreResponseDto>();
        private IEnumerable<PublisherResponseDto> PublishersList { get; set; } = new List<PublisherResponseDto>();
        private string SelectedAuthor { get; set; } = String.Empty;
        private string SelectedGenre { get; set; } = String.Empty;
        private string SelectedLanguage { get; set; } = String.Empty;
        private string SelectedPublisher { get; set; } = String.Empty;

        private BookCreateDto _bookCreateDto = new BookCreateDto();
        
        private void CloseModal()
        {
            _isOpen = false;
        }
    
        private void OpenModal()
        {
            _isOpen = true;
        }

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
            CloseModal();
        }

        protected override async Task OnInitializedAsync()
        {
            if (IsEdited)
            {
                _modalButtonsText = "Edit Book";
            }
            
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

        private void AddNewLanguage(LanguageResponseDto language)
        {
            LanguagesList = LanguagesList.Append(language);
            SelectedLanguage = language.LanguageName;
            StateHasChanged();
        }
        
        private void AddNewGenre(GenreResponseDto genre)
        {
            GenresList = GenresList.Append(genre);
            SelectedGenre = genre.Name;
            StateHasChanged();
        }
        private void AddNewPublisher(PublisherResponseDto publisher)
        {
            PublishersList = PublishersList.Append(publisher);
            SelectedPublisher = publisher.Name;
            StateHasChanged();
        }
        private void AddNewAuthor(AuthorResponseDto author)
        {
            AuthorsList = AuthorsList.Append(author);
            SelectedAuthor = author.Name;
            StateHasChanged();
        }
    }
}
