using CommonLibrary.DataClasses.ReviewModel;
using CommonLibrary.DataClasses.SeriesModel;
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

    public async Task<ServiceObjectResponse<List<ReviewGetDTO>>> GetReviewsByUserId(int userId)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<List<ReviewGetDTO>>($"api/review/user/{userId}");
            if (response != null)
            {
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
            var response = await _httpClient.PostAsJsonAsync("api/review/", review);
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

    public async Task<ServiceObjectResponse<ReviewGetDTO?>> PutReviewAsync(ReviewUpdateDTO review)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync("api/review/", review);
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
                $"api/review/episode/{episodeId}");

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