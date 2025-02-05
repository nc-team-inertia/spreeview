using CommonLibrary.DataClasses.ApiHealthModel;
using CommonLibrary.DataClasses.ApiHealthModel;
using SpreeviewAPI.Wrappers;

namespace SpreeviewFrontend.Services.HealthCheck;

public interface IApiHealthService
{
    public Task<ServiceObjectResponse<ApiHealth>> GetHealthAsync();

}