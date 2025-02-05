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
}