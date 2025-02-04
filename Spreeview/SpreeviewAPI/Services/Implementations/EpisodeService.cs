using CommonLibrary.DataClasses.EpisodeModel;
using SpreeviewAPI.Services.Interfaces;
using SpreeviewAPI.Utilities;

namespace SpreeviewAPI.Services.Implementations;

public class EpisodeService : IEpisodeService
{
    private readonly IRequestManager _requestManager;
    public EpisodeService(IRequestManager requestManager)
    {
        _requestManager = requestManager;
    }

    public async Task<Episode?> FindEpisodeByIds(int seriesId, int seasonNumber, int episodeNumber)
    {
        string urlSuffix = $"tv/{seriesId}/season/{seasonNumber}/episode/{episodeNumber}";
        Episode? returnedEpisode = await _requestManager.TmdbGetAsync<Episode>(urlSuffix);
        return returnedEpisode;
    }
}
