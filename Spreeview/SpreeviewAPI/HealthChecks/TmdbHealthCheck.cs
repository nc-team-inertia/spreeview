using CommonLibrary.DataClasses.EpisodeModel;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using SpreeviewAPI.Utilities;

namespace SpreeviewAPI.HealthChecks;

public class TmdbHealthCheck : IHealthCheck
{
    private readonly IRequestManager _requestManager;
    public TmdbHealthCheck(IRequestManager requestManager)
    {
        _requestManager = requestManager;
    }

    public async Task<HealthCheckResult> CheckHealthAsync
        (HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        string urlSuffix = "https://api.themoviedb.org/3/tv/60572/season/1/episode/21";
        Episode? healthCheckEpisode = await _requestManager.TmdbGetAsync<Episode>(urlSuffix);

        string expectedEpisodeTitle = "Bye Bye Butterfree";

        if (healthCheckEpisode == null)
            return HealthCheckResult.Unhealthy($"The TMDb API is down.");

        if (healthCheckEpisode.Title != expectedEpisodeTitle)
            return HealthCheckResult.Unhealthy($"The TMDb API is operational, but returned data is incorrect.");

        return HealthCheckResult.Healthy($"The TMDb API is operational, and working correctly.");
    }
}
