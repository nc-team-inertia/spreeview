namespace SpreeviewFrontend.Services.ApiReview;

public class ApiReviewService : IApiReviewService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ApiReviewService> _logger;

    public ApiReviewService(HttpClient httpClient, ILogger<ApiReviewService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }
}