using Library.Blazor.Services.UsersService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Library.Blazor.Components.Comps;

partial class EditPasswordModal
{
    [Inject]
    public IUsersService? UsersService { get; set; }
    [Inject]
    NotificationService NotificationService { get; set; }
    
    private string _password = default!;
    private string _confirmPassword = default!;
    
    private bool _isOpen;
    
    private async Task HandleSubmit()
    {
        var passwordEditDto = new PasswordEditDto()
        {
            Password = _password,
            ConfirmPassword = _confirmPassword
        };
        
        try
        {
            await UsersService!.EditUserPassword(passwordEditDto);
        }
        catch (Exception e)
        {
            NotificationService.Notify(NotificationSeverity.Error, "Error", "Something went wrong, try again.");
            Console.WriteLine(e.Message);
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