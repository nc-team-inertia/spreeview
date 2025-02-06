using CommonLibrary.DataClasses.ReviewModel;
using SpreeviewAPI.Wrappers;

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
    public async Task<ServiceObjectResponse<ReviewGetDTO?>> PostReviewAsync(ReviewInsertDTO review)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync(_httpClient.BaseAddress, review);
            if (response != null)
            {
                Console.WriteLine(response.Content);
                return new ServiceObjectResponse<ReviewGetDTO?>() { Type = ServiceResponseType.Success };
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return new ServiceObjectResponse<ReviewGetDTO?>() { Type = ServiceResponseType.Failure };
    }
}