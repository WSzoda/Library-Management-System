using Library.Blazor.Services.AuthorizationService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;

namespace Library.Blazor.Components.Pages.Authorization;

partial class Register
{
    [Inject]
    public IAuthService authService { get; set; }

    [Inject]
    private NavigationManager navigationManager { get; set; }

    private string email;
    private string password;
    private string confirmPassword;
    private string name;
    private string surname;

    private async Task HandleSubmit()
    {

        var newUser = new RegisterUserDto
        {
            Email = email,
            Password = password,
            ConfirmPassword = confirmPassword,
            Name = name,
            Surname = surname
        };

        var response = await authService.Register(newUser);

        if(response.IsSuccessStatusCode)
        {
            navigationManager.NavigateTo("/login");
        }
        // Implement registration logic here
        // You can use the provided properties (email, password, etc.) to capture user input
        // Perform validation and send the registration data to your backend API
        // Redirect or show appropriate messages based on the registration result
    }
}