using Microsoft.AspNetCore.Components.Authorization;
using SpreeviewFrontend.Services.AccountManagement;
using SpreeviewFrontend.Services;
using SpreeviewFrontend.Services.ApiHealth;

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
        builder.Services.AddScoped<AuthenticationStateProvider, AccountManagementService>();

        // Cascading authentication state
        // This doesn't work correctly on dotnet 8.0 due to a bug. See https://github.com/dotnet/aspnetcore/issues/53075
        // Using CascadingAuthenticationState for now.
        // builder.Services.AddCascadingAuthenticationState();

        // register the account management interface (satisfy IAccountManagement dependency with our previously added AuthenticationStateProvider).
        builder.Services.AddScoped(sp => (IAccountManagementService) sp.GetRequiredService<AuthenticationStateProvider>()); 
    }

    public static void SetupHttpClients(this WebApplicationBuilder builder)
    {
        // Get the backend URL from configuration
        string? backendUrl = builder.Configuration["BackendUrl"];

        if (string.IsNullOrEmpty(backendUrl))
        {
            throw new InvalidOperationException("BackendUrl not found in configuration.");
        }

        // Create a named HTTP client connecting to the  backend - this is used for AccountManagementService, as 
        // it cannot be used as a typed http client.
        builder.Services
            .AddHttpClient("SpreeviewAPI", client => client.BaseAddress = new Uri(backendUrl))
            .AddHttpMessageHandler<CookieHandler>();
        
        // Create health HTTP client
        builder.Services.AddHttpClient<IApiHealthService, ApiHealthService>(client => client.BaseAddress = new Uri(backendUrl + "/api/health"));

    }

    public static void SetupUserPreferences(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserPreferencesService, UserPreferencesService>();
    }
}