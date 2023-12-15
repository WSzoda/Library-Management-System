using Library.Blazor.Services.BookService;
using Library.Blazor.Services.RentService;
using Library.Blazor.Services.UsersService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;

namespace Library.Blazor.Components.Pages.Account;

partial class RentHistory
{
    [Inject]
    private IRentService? RentService { get; set; }
    
    [Inject]
    private IBookService? BookService { get; set; }
    
    private bool _isLoading = true;
    private IEnumerable<RentResponseDto> _rents = new List<RentResponseDto>();
    private IEnumerable<BookResponseDto> _books = new List<BookResponseDto>();

    protected override async Task OnInitializedAsync()
    {
        _rents = await RentService!.GetRentsAsync();
        _books = await BookService!.GetBooksAsync(null, null);
        _isLoading = false;
    }
}