using Microsoft.AspNetCore.Components.Authorization;
using SpreeviewFrontend.Services.AccountManagement;
using SpreeviewFrontend.Services;
using SpreeviewFrontend.Services.ApiCommentService;
using SpreeviewFrontend.Services.ApiEpisode;
using SpreeviewFrontend.Services.ApiHealth;
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

        // Create a named HTTP client connecting to the  backend - this is used for AccountManagementService, as 
        // it cannot be used as a typed http client.
        builder.Services
            .AddHttpClient("SpreeviewAPI", client => client.BaseAddress = new Uri(backendUrl))
            .AddHttpMessageHandler<CookieHandler>();
        
        // Create all http services for API endpoints:
        builder.Services.AddHttpClient<IApiHealthService, ApiHealthService>(client => client.BaseAddress = new Uri(backendUrl + "/api/health/"));
        builder.Services.AddHttpClient<IApiCommentService, ApiCommentService>(client => client.BaseAddress = new Uri(backendUrl + "/api/comment/"));
        builder.Services.AddHttpClient<IApiEpisodeService, ApiEpisodeService>(client => client.BaseAddress = new Uri(backendUrl + "/api/episode/"));
        builder.Services.AddHttpClient<IApiReviewService, ApiReviewService>(client => client.BaseAddress = new Uri(backendUrl + "/api/review/"));
        builder.Services.AddHttpClient<IApiSeasonService, ApiSeasonService>(client => client.BaseAddress = new Uri(backendUrl + "/api/season/"));
        builder.Services.AddHttpClient<IApiSeriesService, ApiSeriesService>(client => client.BaseAddress = new Uri(backendUrl + "/api/series/"));


    }

    public static void SetupUserPreferences(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserPreferencesService, UserPreferencesService>();
    }
}