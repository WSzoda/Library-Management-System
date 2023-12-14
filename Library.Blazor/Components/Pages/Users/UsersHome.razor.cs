using Library.Blazor.Services.UsersService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;

namespace Library.Blazor.Components.Pages.Users;

partial class UsersHome
{
    [Inject]
    private IUsersService? UsersService { get; set; }
    
    private bool _isLoading = true;
    private IEnumerable<UserResponseDto> _users = new List<UserResponseDto>();

    protected override async Task OnInitializedAsync()
    {
        _users = await UsersService!.GetUsersAsync();
        _isLoading = false;
    }

    private void EditUser(UserResponseDto user)
    {
        var userEntity = _users.First(l => l.Id == user.Id);
        userEntity.Name = user.Name;
        userEntity.Surname = user.Surname;
        userEntity.Email = user.Email;
        StateHasChanged();
    }
}