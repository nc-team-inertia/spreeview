using CommonLibrary.DataClasses.CommentModel;
using CommonLibrary.DataClasses.ReviewModel;
using SpreeviewAPI.Wrappers;
using System.Globalization;

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

	public async Task<ServiceObjectResponse<CommentGetDTO?>> PostReviewComment(CommentInsertDTO comment)
	{
		try
		{
			var response = await _httpClient.PostAsJsonAsync("", comment);
			if (response != null)
			{
				Console.WriteLine(response.Content);
				return new ServiceObjectResponse<CommentGetDTO?>() { Type = ServiceResponseType.Success };
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
		return new ServiceObjectResponse<CommentGetDTO?>() { Type = ServiceResponseType.Failure };
	}

	public async Task<ServiceObjectResponse<List<CommentGetDTO>>> GetReviewComments(int reviewId)
	{
		try
		{
			var response = await _httpClient.GetFromJsonAsync<List<CommentGetDTO>>(
				$"review/{reviewId}");

			if (response != null)
			{
				return new ServiceObjectResponse<List<CommentGetDTO>>() { Type = ServiceResponseType.Success, Value = response };
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine($"An error occurred: {ex.Message}");
			throw new Exception(ex.Message);
		}
		return new ServiceObjectResponse<List<CommentGetDTO>>() { Type = ServiceResponseType.Failure };
	}
}