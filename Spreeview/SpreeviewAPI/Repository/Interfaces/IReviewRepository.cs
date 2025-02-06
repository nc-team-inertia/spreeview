using CommonLibrary.DataClasses.ReviewModel;

namespace SpreeviewAPI.Repository.Interfaces;

public interface IReviewRepository
{
    Task<Review?> CreateReview(Review review);
    Task<bool> DeleteReview(int id);
    Task<Review?> FindReviewById(int id);
    Task<List<Review>?> FindReviewsByEpisodeId(int id);
    Task<List<Review>?> FindReviewsBySeriesId(int seriesId);
    Task<List<Review>?> FindReviewsByUserId(int userId);
    Task<List<Review>?> IndexAllReviews();
    Task<Review?> UpdateReview(ReviewUpdateDTO reviewDto);
}
