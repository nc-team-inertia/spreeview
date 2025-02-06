using CommonLibrary.DataClasses.ReviewModel;
using SpreeviewAPI.Wrappers;

namespace SpreeviewFrontend.Services.ApiReview;

public interface IApiReviewService
{
    
    Task<ServiceObjectResponse<ReviewGetDTO?>> PostReviewAsync(ReviewInsertDTO review);
}