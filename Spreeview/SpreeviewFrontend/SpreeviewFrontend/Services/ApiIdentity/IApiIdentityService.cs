namespace SpreeviewFrontend.Services.ApiIdentity;

public interface IApiIdentityService
{
    Task<int> GetUserIdAsync();
}