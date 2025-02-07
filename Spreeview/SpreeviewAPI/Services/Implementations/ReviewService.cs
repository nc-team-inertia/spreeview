using CommonLibrary.DataClasses.ReviewModel;
using SpreeviewAPI.Repository.Interfaces;
using SpreeviewAPI.Services.Interfaces;

namespace SpreeviewAPI.Services.Implementations;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;
    public ReviewService(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }
    
    public async Task<List<Review>?> IndexAllReviews()
        => await _reviewRepository.IndexAllReviews();

    public async Task<Review?> FindReviewById(int id)
        => await _reviewRepository.FindReviewById(id); 

    public async Task<List<Review>?> FindReviewsByEpisodeId(int episodeId)
        => await _reviewRepository.FindReviewsByEpisodeId(episodeId);

    public async Task<List<Review>?> FindReviewsBySeriesId(int seriesId)
        => await _reviewRepository.FindReviewsBySeriesId(seriesId);

    public async Task<List<Review>?> FindReviewsForSeriesSeason(int seriesId, int seasonNumber)
        => await _reviewRepository.FindReviewsForSeriesSeason(seriesId, seasonNumber);

    public async Task<List<Review>?> FindReviewsByUserId(int userId)
        => await _reviewRepository.FindReviewsByUserId(userId);
    
    public async Task<Review?> CreateReview(Review review)
        => await _reviewRepository.CreateReview(review);

    public async Task<Review?> UpdateReview(ReviewUpdateDTO reviewDto)
        => await _reviewRepository.UpdateReview(reviewDto);

    public async Task<bool> DeleteReview(int id)
        => await _reviewRepository.DeleteReview(id);
}
