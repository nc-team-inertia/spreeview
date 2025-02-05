using CommonLibrary.DataClasses.ApiHealthModel;
using CommonLibrary.DataClasses.ApiHealthModel;
using SpreeviewAPI.Wrappers;

namespace SpreeviewFrontend.Services.ApiHealth;

public interface IApiHealthService
{
    public Task<ServiceObjectResponse<CommonLibrary.DataClasses.ApiHealthModel.ApiHealth>> GetHealthAsync();

}