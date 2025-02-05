using SpreeviewAPI.Wrappers;

namespace SpreeviewFrontend.Client.Identity;

public interface IAccountManagementService
{
    /// <summary>
    /// Attempt to login a user with specified email and password.
    /// </summary>
    /// <param name="email">The user's email address.</param>
    /// <param name="password">The user's password.</param>
    /// <returns>A service response indicating success or failure.</returns>
    public Task<ServiceResponse> LoginAsync(string email, string password);
    
    /// <summary>
    /// Attempt to log out the current user.
    /// </summary>
    /// <returns>A service response indicating success or failure.</returns>
    public Task<ServiceResponse> LogoutAsync();
    
    /// <summary>
    /// Attempt to register a new user with the given email and password.
    /// </summary>
    /// <param name="email">The user's email address.</param>
    /// <param name="password">The user's password.</param>
    /// <returns>A service response indicating success or failure.</returns>
    public Task<ServiceResponse> RegisterAsync(string email, string password);
    
    /// <summary>
    /// Check the current authentication status.
    /// </summary>
    /// <returns>A bool indicating the authentication state.</returns>
    public Task<bool> CheckAuthenticatedAsync();
}