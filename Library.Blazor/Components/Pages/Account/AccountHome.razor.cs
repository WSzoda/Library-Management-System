using Library.Blazor.Services.UsersService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;

namespace Library.Blazor.Components.Pages.Account;

partial class AccountHome
{
    [Inject]
    private IUsersService? UsersService { get; set; }
    
    private bool _isLoading = true;
    private UserResponseDto _user = null!;

    protected override async Task OnInitializedAsync()
    {
        _user = await UsersService!.GetCurrentUserAsync();
        _isLoading = false;
    }
}