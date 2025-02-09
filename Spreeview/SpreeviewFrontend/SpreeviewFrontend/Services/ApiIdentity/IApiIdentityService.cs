using SpreeviewAPI.Wrappers;

namespace SpreeviewFrontend.Services.ApiIdentity;

public interface IApiIdentityService
{
    Task<ServiceObjectResponse<int>> GetUserIdAsync();
    Task<ServiceObjectResponse<string>> GetUserNameByIdAsync(int userId);
}
