using Microsoft.AspNetCore.Components.Authorization;
using SpreeviewFrontend.Services.AccountManagement;
using SpreeviewFrontend.Services;
using SpreeviewFrontend.Services.ApiCommentService;
using SpreeviewFrontend.Services.ApiEpisode;
using SpreeviewFrontend.Services.ApiHealth;
using SpreeviewFrontend.Services.ApiIdentity;
using SpreeviewFrontend.Services.ApiReview;
using SpreeviewFrontend.Services.ApiSeason;
using SpreeviewFrontend.Services.ApiSeries;

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
        
        // Scoped HTTP client (one per circuit)
        builder.Services.AddScoped(sp =>
        {
            // Set use default credentials to true, so that cookies are passed with the request
            var client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });
            client.BaseAddress = new Uri(backendUrl);
            client.DefaultRequestHeaders.Add("X-Requested-With", ["XMLHttpRequest"]);
            return client;
        });

    }

    public static void SetupApiServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IApiIdentityService, ApiIdentityService>();
        builder.Services.AddScoped<IApiHealthService, ApiHealthService>();
        builder.Services.AddScoped<IApiCommentService, ApiCommentService>();
        builder.Services.AddScoped<IApiEpisodeService, ApiEpisodeService>();
        builder.Services.AddScoped<IApiSeasonService, ApiSeasonService>();
        builder.Services.AddScoped<IApiSeriesService, ApiSeriesService>();
        builder.Services.AddScoped<IApiReviewService, ApiReviewService>();
    }

    public static void SetupUserPreferences(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserPreferencesService, UserPreferencesService>();
    }
}