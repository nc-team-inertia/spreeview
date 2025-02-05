using CommonLibrary.DataClasses.EpisodeModel;
using SpreeviewAPI.Wrappers;

namespace SpreeviewFrontend.Services.ApiEpisode;

public interface IApiEpisodeService
{
    Task<ServiceObjectResponse<EpisodeGetDTO>> GetIndividualEpisode(int seriesId, int seasonNumber, int episodeNumber);
}