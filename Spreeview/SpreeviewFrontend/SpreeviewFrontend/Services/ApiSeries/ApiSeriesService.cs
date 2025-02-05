namespace SpreeviewFrontend.Services.ApiSeries;

public class ApiSeriesService : IApiSeriesService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ApiSeriesService> _logger;

    public ApiSeriesService(HttpClient httpClient, ILogger<ApiSeriesService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }
}