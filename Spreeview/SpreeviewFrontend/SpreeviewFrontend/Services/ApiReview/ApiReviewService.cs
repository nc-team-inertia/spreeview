using CommonLibrary.DataClasses.ReviewModel;
using CommonLibrary.DataClasses.SeriesModel;
using SpreeviewAPI.Wrappers;

namespace SpreeviewFrontend.Services.ApiReview;

public class ApiReviewService : IApiReviewService 
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ApiReviewService> _logger;

    public ApiReviewService(IHttpClientFactory httpClientFactory, ILogger<ApiReviewService> logger)
    {
        _httpClient = httpClientFactory.CreateClient("SpreeviewAPI");
        _httpClient.BaseAddress = new Uri(_httpClient.BaseAddress, "api/review/");
        _logger = logger;
    }

    public async Task<ServiceObjectResponse<List<ReviewGetDTO>>> GetReviewsByUserId(int userId)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<List<ReviewGetDTO>>($"api/review/user/{userId}");
            if (response != null)
            {
                Console.WriteLine(response);
                return new ServiceObjectResponse<List<ReviewGetDTO>>() { Type = ServiceResponseType.Success, Value = response };
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return new ServiceObjectResponse<List<ReviewGetDTO>>() { Type = ServiceResponseType.Failure };
    }
    
    public async Task<ServiceObjectResponse<ReviewGetDTO?>> PostReviewAsync(ReviewInsertDTO review)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("", review);
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

    public async Task<ServiceObjectResponse<List<ReviewGetDTO>>> GetEpisodeReviews(int episodeId)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<List<ReviewGetDTO>>(
                $"episode/{episodeId}");

            if (response != null)
            {
                return new ServiceObjectResponse<List<ReviewGetDTO>>() { Type = ServiceResponseType.Success, Value = response };
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw new Exception(ex.Message);
        }
        return new ServiceObjectResponse<List<ReviewGetDTO>>() { Type = ServiceResponseType.Failure };
    }
}