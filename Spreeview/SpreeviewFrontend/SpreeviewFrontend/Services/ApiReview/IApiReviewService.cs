using CommonLibrary.DataClasses.ReviewModel;
using SpreeviewAPI.Wrappers;

namespace SpreeviewFrontend.Services.ApiReview;

public interface IApiReviewService
{
    Task<ServiceObjectResponse<List<ReviewGetDTO>>> GetEpisodeReviews(int episodeId);
    Task<ServiceObjectResponse<ReviewGetDTO?>> PostReviewAsync(ReviewInsertDTO review);
    Task<ServiceObjectResponse<ReviewGetDTO?>> PutReviewAsync(ReviewUpdateDTO review);
    Task<ServiceObjectResponse<List<ReviewGetDTO?>>> GetReviewsByUserId(int id);
}