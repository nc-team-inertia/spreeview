using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Authorization;
using RecordShop.Frontend.Client.Identity.Models;
using SpreeviewAPI.Wrappers;

namespace SpreeviewFrontend.Client.Identity;

public class CookieAuthenticationStateProvider(
    IHttpClientFactory httpClientFactory,
    ILogger<CookieAuthenticationStateProvider> logger)
    : AuthenticationStateProvider, IAccountManager
{
    
    // http client pointing to authentication api
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("SpreeviewAPI");
    
    // json serializer options to use camelCase
    private readonly JsonSerializerOptions _jsonSerializerOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    
    // Helper field to get an empty claims principal
    private readonly ClaimsPrincipal _unauthenticated = new(new ClaimsIdentity());
    
    // Field to store current boolean authenticated state 
    private bool _isAuthenticated;

    /// <summary>
    /// Get authentication state.
    /// </summary>
    /// <remarks>
    /// Called by Blazor anytime and authentication-based decision needs to be made, then cached
    /// until the changed state notification is raised.
    /// </remarks>
    /// <returns>The authentication state asynchronous request.</returns>
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        _isAuthenticated = false;
        
        // Call user info endpoint
        var userInfoResponse = await _httpClient.GetAsync("manage/info");
        
        // Check if user is not authenticated
        if (!userInfoResponse.IsSuccessStatusCode)
        {
            logger.LogInformation("Could not authenticate user. Perhaps they are not logged in?");
            return new AuthenticationState(_unauthenticated);
        }
        
        // User is authenticated, so build the claims principal:
        var userJson = await userInfoResponse.Content.ReadAsStringAsync();
        var userInfo = JsonSerializer.Deserialize<UserInfoModel>(userJson, _jsonSerializerOptions);
        
        // Check if user info exists:
        if (userInfo == null)
        {
            logger.LogInformation("User is authenticated, but unable to retrieve user info.");
            return new AuthenticationState(_unauthenticated);
        }

        // Setup claims
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, userInfo.Email),
            new Claim(ClaimTypes.Name, userInfo.Email)
        };
        
        // add any additional claims
        claims.AddRange(
            userInfo.Claims.Where(c => c.Key != ClaimTypes.Name && c.Key != ClaimTypes.Email)
                .Select(c => new Claim(c.Key, c.Value)));
        
        // request the roles endpoint for the user's roles
        var rolesResponse = await _httpClient.GetAsync("roles");

        // Check if getting roles was not successful
        if (!userInfoResponse.IsSuccessStatusCode)
        {
            logger.LogInformation("Unable to get user roles from API");
            return new AuthenticationState(_unauthenticated);
        }
        
        // read the response into a string
        var rolesJson = await rolesResponse.Content.ReadAsStringAsync();
        
        // deserialize the roles string into an array
        var roles = JsonSerializer.Deserialize<RoleClaimModel[]>(rolesJson, _jsonSerializerOptions);
        
        // add any roles to the claims collection
        if (roles?.Length > 0)
        {
            foreach (var role in roles)
            {
                if (!string.IsNullOrEmpty(role.Type) && !string.IsNullOrEmpty(role.Value))
                {
                    claims.Add(new Claim(role.Type, role.Value, role.ValueType, role.Issuer,
                        role.OriginalIssuer));
                }
            }
        }
        
        // set the principal
        var id = new ClaimsIdentity(claims, nameof(CookieAuthenticationStateProvider));
        var user = new ClaimsPrincipal(id);
        _isAuthenticated = true;
        return new AuthenticationState(user);
    }

    
    public async Task<ServiceResponse> RegisterAsync(string email, string password)
    {
        // Call register endpoint
        var registerResponse = await _httpClient.PostAsJsonAsync(
            "register", new
            {
                email,
                password
            });
        
        // If unsuccessful
        if (!registerResponse.IsSuccessStatusCode)
        {
            return new ServiceResponse()
            {
                Type = ServiceResponseType.Failure,
                Messages = ["Failed to register user. Endpoint response did not indicate success."]
            };
        }
        
        // Else, success
        return new ServiceResponse() { Type = ServiceResponseType.Success };
    }
    
    public async Task<ServiceResponse> LoginAsync(string email, string password)
    {
        // Call the login endpoint
        var registerResponse = await _httpClient.PostAsJsonAsync(
            "login?useCookies=true", new
            {
                email,
                password
            });
        
        // If unsuccessful
        if (!registerResponse.IsSuccessStatusCode)
        {
            return new ServiceResponse()
            {
                Type = ServiceResponseType.Failure,
                Messages = ["Failed to login user. Please ensure the email and password are both correct."]
            };
        }
        
        // Else, success
        // notify that authentication state has changed, so that Blazor can update this across components.
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync()); 
        return new ServiceResponse() { Type = ServiceResponseType.Success };
    }
    
    public async Task<ServiceResponse> LogoutAsync()
    {
        
        // Call the logout endpoint (with empty content)
        const string Empty = "{}";
        var emptyContent = new StringContent(Empty, Encoding.UTF8, "application/json");
        await _httpClient.PostAsync("logout", emptyContent);
        
        // Notify Blazor that the authentication state has changed (logged out)
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        
        return new ServiceResponse() { Type = ServiceResponseType.Success };
    }

    public async Task<bool> CheckAuthenticatedAsync()
    {
        // Update authentication state
        await GetAuthenticationStateAsync();
        
        // Return a bool indicating authentication vs unauthentication
        return _isAuthenticated;
    }
}