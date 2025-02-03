using Microsoft.AspNetCore.Components.Authorization;
using SpreeviewFrontend.Client.Identity;
using SpreeviewFrontend.Services;

namespace SpreeviewFrontend;

public static class WebApplicationBuilderExtensions
{
    public static void SetupRazorComponents(this WebApplicationBuilder builder)
    {
        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents()
            .AddInteractiveWebAssemblyComponents();
    }
    
    public static void SetupAuth(this WebApplicationBuilder builder)
    {
        // register the cookie handler
        builder.Services.AddTransient<CookieHandler>();

        // set up authorization
        builder.Services.AddAuthorization();

        // register the custom state provider
        builder.Services.AddScoped<AuthenticationStateProvider, CookieAuthenticationStateProvider>();

        // Cascading authentication state
        builder.Services.AddCascadingAuthenticationState();

        // register the account management interface (satisfy IAccountManagement dependency with our previously added AuthenticationStateProvider).
        builder.Services.AddScoped(sp => (IAccountManagement) sp.GetRequiredService<AuthenticationStateProvider>()); 
    }

    public static void SetupHttpClients(this WebApplicationBuilder builder)
    {
        // Create a named HTTP client connecting to the  backend
        string? backendUrl = builder.Configuration["BackendUrl"];

        if (string.IsNullOrEmpty(backendUrl))
        {
            throw new InvalidOperationException("BackendUrl not found in configuration.");
        }

        builder.Services
            .AddHttpClient("SpreeviewAPI", client => client.BaseAddress = new Uri(backendUrl))
            .AddHttpMessageHandler<CookieHandler>();

    }

    public static void SetupUserPreferences(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserPreferencesService, UserPreferencesService>();
    }
}