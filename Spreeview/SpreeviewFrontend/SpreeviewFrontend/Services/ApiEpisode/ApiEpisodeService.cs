using CommonLibrary.DataClasses.EpisodeModel;
using SpreeviewAPI.Wrappers;

namespace SpreeviewFrontend.Services.ApiEpisode;

public class ApiEpisodeService : IApiEpisodeService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ApiEpisodeService> _logger;

    public ApiEpisodeService(HttpClient httpClient, ILogger<ApiEpisodeService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }
    
    public async Task<ServiceObjectResponse<EpisodeGetDTO>> GetIndividualEpisode(int seriesId, int seasonNumber, int episodeNumber)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<EpisodeGetDTO>(
                $"{seriesId}/{seasonNumber}/{episodeNumber}");
            
            if (response != null)
            {
                Console.WriteLine(response);
                return new ServiceObjectResponse<EpisodeGetDTO>() { Type = ServiceResponseType.Success, Value = response};
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw new Exception(ex.Message);
        }
        return new ServiceObjectResponse<EpisodeGetDTO>() { Type = ServiceResponseType.Failure };
    }
}