namespace SpreeviewFrontend.Services.ApiCommentService;

public class ApiCommentService : IApiCommentService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ApiCommentService> _logger;

    public ApiCommentService(HttpClient httpClient, ILogger<ApiCommentService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }
}