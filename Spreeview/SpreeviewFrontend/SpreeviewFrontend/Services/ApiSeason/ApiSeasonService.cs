using SpreeviewFrontend.Services.ApiReview;

namespace SpreeviewFrontend.Services.ApiSeason;

public class ApiSeasonService : IApiSeasonService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ApiSeasonService> _logger;

    public ApiSeasonService(HttpClient httpClient, ILogger<ApiSeasonService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }
}