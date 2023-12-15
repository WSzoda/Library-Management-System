using Library.Blazor.Services.UsersService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;

namespace Library.Blazor.Components.Comps;

partial class EditPasswordModal
{
    [Inject]
    public IUsersService? UsersService { get; set; }
    
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