using Library.Blazor.Services.UsersService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;

namespace Library.Blazor.Components.Comps;

partial class UserModal
{
    [Parameter]
    public Action<UserResponseDto>? OnUserEdited { get; set; }
    
    [Parameter]
    public bool IsEdited { get; set; }
    
    [Parameter]
    public UserResponseDto? UserToEdit { get; set; }
    
    [Inject]
    private IUsersService? UsersService { get; set; }

    private string _userName = default!;
    private string _userSurname = default!;
    private string _userEmail = default!;
    private bool _isOpen;
    private string _modalButtonsText = "Edit User";


    protected override void OnInitialized()
    {
        if (!IsEdited) return;
        _userName = UserToEdit!.Name;
        _userSurname = UserToEdit!.Surname;
        _userEmail = UserToEdit!.Email;
    }

    private async Task HandleSubmit()
    {
        UserToEdit!.Name = _userName;
        UserToEdit!.Surname = _userSurname;
        UserToEdit!.Email = _userEmail;
        try
        {
            var editedUser = await UsersService!.EditUser(UserToEdit);
            OnUserEdited?.Invoke(editedUser);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
        finally
        {
            CloseModal();
        }
    }

    private void CloseModal()
    {
        _isOpen = false;
    }
    
    private void OpenModal()
    {
        _isOpen = true;
    }
}