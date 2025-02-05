using CommonLibrary.DataClasses.HealthModel;
using SpreeviewAPI.Wrappers;

namespace SpreeviewFrontend.Services.HealthCheck;

public interface IHealthService
{
    public Task<ServiceObjectResponse<Health>> GetHealthAsync();

}