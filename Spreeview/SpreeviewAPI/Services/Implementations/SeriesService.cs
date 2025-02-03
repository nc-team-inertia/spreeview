using CommonLibrary.DataClasses.SeriesModel;
using SpreeviewAPI.Services.Interfaces;
using SpreeviewAPI.Wrappers;

namespace SpreeviewAPI.Services.Implementations;

public class SeriesService(IHttpClientFactory httpClientFactory) : ISeriesService
{
    public async Task<IEnumerable<SeriesDTO>?> IndexPopular()
    {
        const string urlSuffix = $"trending/tv/week";
        SeriesResponse? seriesResponse;
        try
        {
            using var httpClient = httpClientFactory.CreateClient("tmdb");
            seriesResponse = await httpClient.GetFromJsonAsync<SeriesResponse>(urlSuffix);
        }
        catch (Exception e)
        {
            return null;
        }
        return seriesResponse?.Results;
    }

    public async Task<List<SeriesDTO>?> IndexTopRated()
    {
        const string urlSuffix = $"tv/top_rated";
        SeriesResponse? seriesResponse;

        try
        {
            using var httpClient = httpClientFactory.CreateClient("tmdb");
            seriesResponse = await httpClient.GetFromJsonAsync<SeriesResponse>(urlSuffix);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error has occured: ", ex.Message);
            return null;
        }

        return seriesResponse?.Results;
    }

    public async Task<SeriesDTO?> GetById(int id)
    {
        var urlSuffix = $"tv/{id}";
        SeriesDTO? returnedSeries;
        try
        {
            using var client = httpClientFactory.CreateClient("tmdb");
            returnedSeries = await client.GetFromJsonAsync<SeriesDTO>(urlSuffix);
        }
        catch (Exception ex)
        {
            returnedSeries = null;
        }
        return returnedSeries;
    }

    public async Task<List<SeriesDTO>?> FindByKeywords(string query)
    {
        string urlSuffix = $"search/tv?query={query}";
        SeriesResponse? seriesResponse;

        try
        {
            using var httpClient = httpClientFactory.CreateClient("tmdb");
            seriesResponse = await httpClient.GetFromJsonAsync<SeriesResponse>(urlSuffix);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error has occurred: ", ex.Message);
            seriesResponse = null;
        }

        return seriesResponse?.Results;
    }

    public async Task<List<SeriesDTO>?> FindRecommendationsById(int seriesId)
    {
        string urlSuffix = $"tv/{seriesId}/recommendations";
        SeriesResponse? seriesResponse;

        try
        {
            using var httpClient = httpClientFactory.CreateClient("tmdb");
            seriesResponse = await httpClient.GetFromJsonAsync<SeriesResponse>(urlSuffix);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error has occurred: ", ex.Message);
            seriesResponse = null;
        }

        return seriesResponse?.Results;
    }
}
