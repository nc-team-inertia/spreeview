using CommonLibrary.DataClasses.SeasonModel;
using SpreeviewAPI.Services.Interfaces;
using SpreeviewAPI.Utilities;

namespace SpreeviewAPI.Services.Implementations;

public class SeasonService : ISeasonService
{
    private readonly IRequestManager _requestManager;
    public SeasonService(IRequestManager requestManager)
    {
        _requestManager = requestManager;
    }

	public async Task<Season?> FindSeasonByIds(int seriesId, int seasonNumber)
	{
		string urlSuffix = $"tv/{seriesId}/season/{seasonNumber}";
		Season? returnedSeason = await _requestManager.TmdbGetAsync<Season>(urlSuffix);
		return returnedSeason;
	}
}
