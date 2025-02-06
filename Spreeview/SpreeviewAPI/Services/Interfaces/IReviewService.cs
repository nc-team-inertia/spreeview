using CommonLibrary.DataClasses.ReviewModel;

namespace SpreeviewAPI.Services.Interfaces;

public interface IReviewService
{
    Task<List<Review>?> IndexAllReviews();
    Task<Review?> FindReviewById(int id);
    Task<List<Review>?> FindReviewsByEpisodeId(int episodeId);
    Task<List<Review>?> FindReviewsBySeriesId(int seriesId);
    Task<List<Review>?> FindReviewsForSeriesSeason(int seriesId, int seasonNumber);
    Task<List<Review>?> FindReviewsByUserId(int userId);
    Task<Review?> CreateReview(Review review);
    Task<Review?> UpdateReview(ReviewUpdateDTO review);
    Task<bool> DeleteReview(int id);
}
