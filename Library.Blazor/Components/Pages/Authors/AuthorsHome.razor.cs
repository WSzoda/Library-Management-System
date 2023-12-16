using Library.Blazor.Services.AuthorService;
using Library.Blazor.Services.CountryService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;

namespace Library.Blazor.Components.Pages.Authors;

partial class AuthorsHome
{
    [Inject]
    private IAuthorService? AuthorsService { get; set; }
    
    private IEnumerable<AuthorResponseDto>? _authors;
    private bool _isLoading = true;
    
    protected override async Task OnInitializedAsync()
    {
        _authors = await AuthorsService!.GetAuthorsAsync();
        _authors = _authors.ToList();
        _isLoading = false;
    }
    
    private void AddAuthor(AuthorResponseDto author)
    {
        _authors?.ToList().Add(author);
    }
    
    private void EditAuthor(AuthorResponseDto author)
    {
        var authorList = _authors!.First(l => l.Id == author.Id);
        authorList.Name = author.Name;
        authorList.Surname = author.Surname;
        authorList.CountryId = author.CountryId;
        StateHasChanged();
    }
}