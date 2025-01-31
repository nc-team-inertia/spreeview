using System.Text.Json;
using CommonLibrary.DataClasses.SeriesModel;
using SpreeviewAPI.Services.Interfaces;

namespace SpreeviewAPI.Services.Implementations;

public class SeriesService(IHttpClientFactory _httpClientFactory) : ISeriesService
{
    private readonly IHttpClientFactory _httpClientFactory;
    public IEnumerable<Series>? Index()
    {
        return new List<Series>();
    }

    public async Task<Series?> GetById(int id)
    {
        string urlSuffix = $"tv/{id}";
        Series? returnedSeries;
        try
        {
            using var client = _httpClientFactory.CreateClient("tmdb");
            returnedSeries = await client.GetFromJsonAsync<Series>(urlSuffix);
        }
        catch (Exception ex)
        {
            returnedSeries = null;
        }
        return returnedSeries;
    }
}
