using Library.Blazor.Services.BookService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;

namespace Library.Blazor.Components.Pages.Books;

partial class BookSingle
{
    [Parameter]
    public int Id { get; set; }
    
    [Inject]
    private IBookService? BookService { get; set; }

    private BookResponseDto? Book { get; set; }
    private bool _isLoading = true;

    protected override async Task OnInitializedAsync()
    {
        // Fetch the book details from your service based on the provided Id
        Book = await BookService!.GetBookAsync(Id);
        _isLoading = false;
    }

    private void RentBook()
    {
    }
    
}