using CommonLibrary.DataClasses.SeriesModel;
using SpreeviewAPI.Services.Interfaces;
using SpreeviewAPI.Utilities;
using SpreeviewAPI.Wrappers;

namespace SpreeviewAPI.Services.Implementations;

public class SeriesService: ISeriesService
{
    private readonly IRequestManager _requestManager;
    public SeriesService(IRequestManager requestManager)
    {
        _requestManager = requestManager;
    }

    public async Task<List<Series>?> IndexPopularSeries()
    {
        const string urlSuffix = $"trending/tv/week";
        List<Series>? returnedSeriesList = null;

        SeriesResponse? returnedResponse = await _requestManager.TmdbGetAsync<SeriesResponse>(urlSuffix);

        if (returnedResponse != null)
            returnedSeriesList = returnedResponse.Results;

        return returnedSeriesList;
    }

    public async Task<List<Series>?> IndexTopRatedSeries()
    {
        const string urlSuffix = $"tv/top_rated";
        List<Series>? returnedSeriesList = null;

        SeriesResponse? returnedResponse = await _requestManager.TmdbGetAsync<SeriesResponse>(urlSuffix);

        if (returnedResponse != null)
            returnedSeriesList = returnedResponse.Results;

        return returnedSeriesList;
    }

    public async Task<Series?> FindSeriesById(int seriesId)
    {
        var urlSuffix = $"tv/{seriesId}";
        Series? returnedSeries = await _requestManager.TmdbGetAsync<Series>(urlSuffix);
        return returnedSeries;
    }

    public async Task<List<Series>?> FindSeriesByKeywords(string query)
    {
        string urlSuffix = $"search/tv?query={query}";
        List<Series>? returnedSeriesList = null;

        SeriesResponse? returnedResponse = await _requestManager.TmdbGetAsync<SeriesResponse>(urlSuffix);

        if (returnedResponse != null)
            returnedSeriesList = returnedResponse.Results;

        return returnedSeriesList;
    }

    public async Task<List<Series>?> FindRecommendationsById(int seriesId)
    {
        string urlSuffix = $"tv/{seriesId}/recommendations";
        List<Series>? returnedSeriesList = null;

        SeriesResponse? returnedResponse = await _requestManager.TmdbGetAsync<SeriesResponse>(urlSuffix);

        if (returnedResponse != null)
            returnedSeriesList = returnedResponse.Results;

        return returnedSeriesList;
    }
}
