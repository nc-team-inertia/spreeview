using System.Text.Json;
using Microsoft.AspNetCore.Components.Authorization;
using RecordShop.Frontend.Client.Identity.Models;
using SpreeviewAPI.Wrappers;

namespace SpreeviewFrontend.Client.Identity;

public class CookieAuthenticationStateProvider : AuthenticationStateProvider, IAccountManager
{
    private readonly ILogger<CookieAuthenticationStateProvider> _logger;
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    // ReSharper disable once ConvertToPrimaryConstructor
    public CookieAuthenticationStateProvider(IHttpClientFactory httpClientFactory, ILogger<CookieAuthenticationStateProvider> logger)
    {
        _httpClient = httpClientFactory.CreateClient("SpreeviewAPI");
        _jsonSerializerOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        _logger = logger;
    }
    
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        // Get the authentication state
        
        throw new NotImplementedException();
    }

    public Task<ServiceResponse> LoginAsync(string email, string password)
    {
        string[] messages = ["An unknown error prevented login from succeeding."];
        
        // Call login endpoint

        var response = new ServiceResponse() { Type= ServiceResponseType.Failure, Messages = messages };
        
        throw new NotImplementedException();
    }

    public Task<ServiceResponse> LogoutAsync()
    {
        string[] messages = ["An unknown error prevented logout from succeeding."];

        // Call logout endpoint

        
        var response = new ServiceResponse() { Type= ServiceResponseType.Failure, Messages = messages };
        
        throw new NotImplementedException();
    }

    public Task<ServiceResponse> RegisterAsync(string email, string password)
    {
        string[] messages = ["An unknown error prevented register from succeeding."];

        // Call register endpoint
        
        var response = new ServiceResponse() { Type= ServiceResponseType.Failure, Messages = messages };
        
        throw new NotImplementedException();
    }

    public Task<ServiceObjectResponse<bool>> CheckAuthenticatedAsync()
    {
        string[] messages = ["An unknown error prevented authentication check from succeeding."];

        // Check whether user is authenticated
        
        var response = new ServiceObjectResponse<bool>() { Type= ServiceResponseType.Failure, Messages = messages };

        throw new NotImplementedException();
    }
}