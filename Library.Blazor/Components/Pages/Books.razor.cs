using Library.Blazor.Services;
using Library.Domain;
using Library.DTOs;
using Microsoft.AspNetCore.Components;

namespace Library.Blazor.Components.Pages
{
    public partial class Books
    {
        [Inject]
        private IBooksService BooksService { get; set; }

        private IEnumerable<BookResponseDto> BooksList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            BooksList = await BooksService.GetBooksAsync();
        }
    }
}