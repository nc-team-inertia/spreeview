using SpreeviewAPI.Wrappers;

namespace SpreeviewFrontend.Services.ApiIdentity;

public interface IApiIdentityService
{
    Task<ServiceObjectResponse<int>> GetUserIdAsync();
}