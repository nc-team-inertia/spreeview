using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SpreeviewFrontend.Client.Identity;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


// register the cookie handler
builder.Services.AddTransient<CookieHandler>();

// set up authorization
builder.Services.AddAuthorizationCore();

// register the custom state provider
builder.Services.AddScoped<AuthenticationStateProvider, CookieAuthenticationStateProvider>();

// register the account management interface (satisfy IAccountManagement dependency with our previously added AuthenticationStateProvider).
builder.Services.AddScoped(sp => (IAccountManagement) sp.GetRequiredService<AuthenticationStateProvider>()); 

// Create a named HTTP client connecting to the  backend
string? backendUrl = builder.Configuration["BackendUrl"];

if (string.IsNullOrEmpty(backendUrl))
{
    throw new InvalidOperationException("BackendUrl not found in configuration.");
}

builder.Services
    .AddHttpClient("SpreeviewAPI", client => client.BaseAddress = new Uri(backendUrl))
    .AddHttpMessageHandler<CookieHandler>();


await builder.Build().RunAsync();
