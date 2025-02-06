﻿using CommonLibrary.DataClasses.ReviewModel;
using SpreeviewAPI.Wrappers;

namespace SpreeviewFrontend.Services.ApiReview;

public interface IApiReviewService
{
    Task<ServiceObjectResponse<List<ReviewGetDTO>>> GetEpisodeReviews(int episodeId);
    
    Task<ServiceObjectResponse<ReviewGetDTO?>> PostReviewAsync(ReviewInsertDTO review);
}