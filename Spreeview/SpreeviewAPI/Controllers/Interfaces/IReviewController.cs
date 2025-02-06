using CommonLibrary.DataClasses.ReviewModel;
using Microsoft.AspNetCore.Mvc;

namespace SpreeviewAPI.Controllers.Interfaces;

public interface IReviewController
{
    Task<ActionResult> PostReview(ReviewInsertDTO dto);
    Task<ActionResult> DeleteReview(int id);
    Task<ActionResult> PutReview(ReviewUpdateDTO dto);
    Task<ActionResult> GetReviewsByEpisodeId(int episodeId);
    Task<ActionResult> GetReviewsBySeriesId(int seriesId);
    Task<ActionResult> GetReviewsByUserId(int userId);
    Task<ActionResult> GetReviewById(int id);
    Task<ActionResult> IndexAllReviews();
}
