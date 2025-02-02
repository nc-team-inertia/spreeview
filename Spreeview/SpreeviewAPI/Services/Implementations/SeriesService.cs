using System.Text.Json;
using CommonLibrary.DataClasses.SeriesModel;
using SpreeviewAPI.Services.Interfaces;
using SpreeviewAPI.Wrappers;

namespace SpreeviewAPI.Services.Implementations;

public class SeriesService(IHttpClientFactory httpClientFactory) : ISeriesService
{
    public async Task<IEnumerable<Series>?> IndexPopular()
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

    public async Task<Series?> GetById(int id)
    {
        var urlSuffix = $"tv/{id}";
        Series? returnedSeries;
        try
        {
            using var client = httpClientFactory.CreateClient("tmdb");
            returnedSeries = await client.GetFromJsonAsync<Series>(urlSuffix);
        }
        catch (Exception ex)
        {
            returnedSeries = null;
        }
        return returnedSeries;
    }

    public async Task<List<Series>?> FindByKeywords(string query)
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
}
