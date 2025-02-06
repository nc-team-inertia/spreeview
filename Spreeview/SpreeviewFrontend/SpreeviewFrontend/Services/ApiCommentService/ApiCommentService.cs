namespace SpreeviewFrontend.Services.ApiCommentService;

public class ApiCommentService : IApiCommentService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ApiCommentService> _logger;

    public ApiCommentService(IHttpClientFactory httpClientFactory, ILogger<ApiCommentService> logger)
    {
        _httpClient = httpClientFactory.CreateClient("SpreeviewAPI");
        _httpClient.BaseAddress = new Uri(_httpClient.BaseAddress, "api/comment/");

        _logger = logger;
    }
}