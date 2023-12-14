global using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using Library.Blazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Library.Blazor.Components;
using Library.Blazor.Services.AuthorizationService;
using Library.Blazor.Services.AuthorService;
using Library.Blazor.Services.BookService;
using Library.Blazor.Services.CountryService;
using Library.Blazor.Services.GenreService;
using Library.Blazor.Services.LanguageService;
using Library.Blazor.Services.PublisherService;
using Library.Blazor.Services.UsersService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<IBooksService, BookService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<ILanguageService, LanguageService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IPublisherService, PublisherService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IUsersService, UsersService>();

await builder.Build().RunAsync();
