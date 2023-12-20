using Library.Blazor.Services.AuthorizationService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Library.Blazor.Components.Pages.Authorization;

partial class Register
{
    [Inject]
    public IAuthService authService { get; set; }

    [Inject]
    private NavigationManager navigationManager { get; set; }
    [Inject]
    NotificationService NotificationService { get; set; }

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
        else
        {
            NotificationService.Notify(NotificationSeverity.Error, "Error", "Something went wrong, try again.");
            Console.WriteLine(response.Content.ReadAsStringAsync());
        }
    }
}