using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Library.Blazor.Components;
using Library.Blazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<IBooksService, BookService>(
    client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));


await builder.Build().RunAsync();
