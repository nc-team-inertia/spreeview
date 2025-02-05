using CommonLibrary.DataClasses.SeasonModel;
using SpreeviewAPI.Wrappers;

namespace SpreeviewFrontend.Services.ApiSeason;

public interface IApiSeasonService
{
    Task<ServiceObjectResponse<SeasonGetDTO>> GetSeasonById(int seriesId, int seasonNumber);
}