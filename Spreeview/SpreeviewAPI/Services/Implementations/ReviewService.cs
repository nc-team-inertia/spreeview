using CommonLibrary.DataClasses.ReviewModel;
using SpreeviewAPI.Database;
using SpreeviewAPI.Repository;
using SpreeviewAPI.Services.Interfaces;

namespace SpreeviewAPI.Services.Implementations;

public class ReviewService : IReviewService
{
    private readonly ReviewRepository _reviewRepository;

    public ReviewService(ReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }
    
    public async Task<IEnumerable<Review>?> Index()
        => await _reviewRepository.Index();

    public async Task<Review?> GetById(int id)
        => await _reviewRepository.GetById(id); 

    public async Task<IEnumerable<Review>?> GetByEpisodeId(int episodeId)
        => await _reviewRepository.GetByEpisodeId(episodeId);

    public async Task<IEnumerable<Review>?> GetBySeriesId(int seriesId)
        => await _reviewRepository.GetBySeriesId(seriesId);
    
    public async Task<IEnumerable<Review>?> GetByUserId(int userId)
        => await _reviewRepository.GetByUserId(userId);
    
    public async Task<Review?> Create(Review review)
        => await _reviewRepository.Create(review);

    public async Task<Review?> Edit(ReviewUpdateDTO reviewDto)
        => await _reviewRepository.Edit(reviewDto);

    public async Task<bool> Delete(int id)
        => await _reviewRepository.Delete(id);
}
