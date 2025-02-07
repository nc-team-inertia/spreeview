using CommonLibrary.DataClasses.CommentModel;
using CommonLibrary.DataClasses.ReviewModel;
using SpreeviewAPI.Wrappers;

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
    
    public async Task<ServiceObjectResponse<List<CommentGetDTO>>> GetCommentsByUserId(int userId)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<List<CommentGetDTO>>($"user/{userId}");
            if (response != null)
            {
                Console.WriteLine(response[0].Contents);
                return new ServiceObjectResponse<List<CommentGetDTO>>() { Type = ServiceResponseType.Success, Value = response };
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return new ServiceObjectResponse<List<CommentGetDTO>>() { Type = ServiceResponseType.Failure };
    }
}