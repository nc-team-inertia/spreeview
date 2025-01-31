using CommonLibrary.DataClasses.EpisodeModel;
using SpreeviewAPI.Services.Interfaces;

namespace SpreeviewAPI.Services.Implementations;

public class EpisodeService : IEpisodeService
{
    private readonly IHttpClientFactory _httpClientFactory;
    public EpisodeService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<Episode?> FindByIds(int seriesId, int seasonNumber, int episodeNumber)
    {
        HttpClient client;
        Episode? returnedEpisode;

        string urlSuffix = $"tv/{seriesId}/season/{seasonNumber}/episode/{episodeNumber}";

        try
        {
            using (client = _httpClientFactory.CreateClient("tmdb"))
            {
                returnedEpisode = await client.GetFromJsonAsync<Episode>(urlSuffix);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error has occured: ", ex.Message);
            returnedEpisode = null;
        }

        return returnedEpisode;
    }
}
