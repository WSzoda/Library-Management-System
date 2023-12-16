using Library.Blazor.Services.BookService;
using Library.Blazor.Services.LanguageService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;

namespace Library.Blazor.Components.Pages.Books;

partial class BooksListing
{
    [Inject]
    private IBookService? BookService { get; set; }
    
    private bool _isLoading = true;
    private IEnumerable<BookResponseDto> _books = new List<BookResponseDto>();

    protected override async Task OnInitializedAsync()
    {
        _books = await BookService!.GetBooksAsync(null, null);
        _books = _books.ToList();
        _isLoading = false;
    }
    
    private void AddBooks(BookResponseDto books)
    {
        _books.ToList().Add(books);
    }
    
    void EditBook(BookResponseDto book)
    {
        var bookOrg = _books.First(l => l.Id == book.Id);
        bookOrg.Title = book.Title;
        bookOrg.Authors = book.Authors;
        bookOrg.Description = book.Description;
        bookOrg.Publisher = book.Publisher;
        bookOrg.Genre = book.Genre;
        bookOrg.Language = book.Language;
        bookOrg.Reviews = book.Reviews;
        bookOrg.IsAvailable = book.IsAvailable;
        bookOrg.NumberOfPages = book.NumberOfPages;
        bookOrg.YearOfPublishing = book.YearOfPublishing;
        bookOrg.ISBN = book.ISBN;
        StateHasChanged();
    }

    async void DeleteBook(BookResponseDto book)
    {
        _books.ToList().RemoveAll(l => l.Id == book.Id);
        StateHasChanged();
    }
}