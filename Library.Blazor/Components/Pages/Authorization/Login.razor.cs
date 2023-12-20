using Library.Blazor.Services.AuthorizationService;
using Library.DTOs;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Library.Blazor.Components.Pages.Authorization;

partial class Login
{
    [Inject]
    public IAuthService AuthorizationService { get; set; }

    [Inject]
    public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    [Inject]
    NotificationService NotificationService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }


    private string email;
    private string password;
    private string errorMessage;

    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        if (authState.User.Identity.IsAuthenticated)
        {
            NavigationManager.NavigateTo("/account");
        }
    }

    private async Task HandleSubmit()
    {
        var loginModel = new LoginDto() { Email = email, Password = password };
        var response = await AuthorizationService.Login(loginModel);

        if (response.IsSuccessStatusCode)
        {
            var token = await response.Content.ReadAsStringAsync();
            NavigationManager.NavigateTo("/", true);
            Console.WriteLine(token);
        }
        else
        {
            NotificationService.Notify(NotificationSeverity.Error, "Error", "Something went wrong, try again.");
            errorMessage = await response.Content.ReadAsStringAsync();
            Console.WriteLine(errorMessage);
        }
    }
}