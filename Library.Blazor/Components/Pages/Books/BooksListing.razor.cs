using System.Security.Claims;
using Library.Blazor.Services.BookService;
using Library.Blazor.Services.LanguageService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Library.Blazor.Components.Pages.Books;

partial class BooksListing
{
    [Inject]
    private IBookService? BookService { get; set; }

    [Inject]
    AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    [Inject]
    NotificationService NotificationService { get; set; }
    
    

    private bool _isLoading = true;
    private IEnumerable<BookResponseDto> _books = new List<BookResponseDto>();

    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userRoles = authState.User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
        Console.WriteLine(string.Join(", ", userRoles));
        _books = await BookService!.GetBooksAsync(null, null);
        _books = _books.ToList();
        _isLoading = false;
    }

    private void AddBook(BookResponseDto book)
    {
        _books.ToList().Add(book);
        StateHasChanged();
        NotificationService.Notify(NotificationSeverity.Success, "Success", "Book added.");
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
        NotificationService.Notify(NotificationSeverity.Success, "Success", "Book edited.");
    }

    async void DeleteBook(BookResponseDto book)
    {
        _books.ToList().RemoveAll(l => l.Id == book.Id);
        StateHasChanged();
        NotificationService.Notify(NotificationSeverity.Success, "Success", "Book deleted.");
    }
}