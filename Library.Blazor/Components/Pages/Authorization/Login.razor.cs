using Library.Blazor.Services.AuthorizationService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;

namespace Library.Blazor.Components.Pages.Authorization;

partial class Login
{
    [Inject]
    public IAuthService AuthorizationService { get; set; }
    
    private string email;
    private string password;
    private string errorMessage;

    private async Task HandleSubmit()
    {
        var loginModel = new LoginDto() { Email = email, Password = password };
        var response = await AuthorizationService.Login(loginModel);

        if (response.IsSuccessStatusCode)
        {
            var token = await response.Content.ReadAsStringAsync();
            Console.WriteLine(token);
        }
        else
        {
            // Failed login
            errorMessage = await response.Content.ReadAsStringAsync();
            Console.WriteLine(errorMessage);
        }
    }
}