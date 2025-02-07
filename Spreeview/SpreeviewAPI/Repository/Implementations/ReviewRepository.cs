using CommonLibrary.DataClasses.ReviewModel;
using SpreeviewAPI.Database;
using SpreeviewAPI.Repository.Interfaces;

namespace SpreeviewAPI.Repository.Implementations;

public class ReviewRepository : IReviewRepository
{
    private readonly ApplicationDbContext _context;
    public ReviewRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Review>?> IndexAllReviews()
        => _context.Reviews.ToList();

    public async Task<Review?> FindReviewById(int id)
        => _context.Reviews.FirstOrDefault(x => x.Id == id);

    public async Task<List<Review>?> FindReviewsByEpisodeId(int id)
        => _context.Reviews.Where(r => r.EpisodeId == id).ToList();

    public async Task<List<Review>?> FindReviewsBySeriesId(int seriesId)
        => _context.Reviews.Where(r => r.SeriesId == seriesId).ToList();

    public async Task<List<Review>?> FindReviewsForSeriesSeason(int seriesId, int seasonNumber)
        => _context.Reviews.Where(r => r.SeriesId == seriesId &&
                                       r.SeasonNumber == seasonNumber).ToList();

    public async Task<List<Review>?> FindReviewsByUserId(int userId)
        => _context.Reviews.Where(r => r.UserId == userId).ToList();

    public async Task<Review?> CreateReview(Review review)
    {
        review.DateAdded = DateTime.Now;
        await _context.Reviews.AddAsync(review);
        await _context.SaveChangesAsync();
        return review;
    }

    public async Task<Review?> UpdateReview(ReviewUpdateDTO reviewDto)
    {
        var reviewToUpdate = await FindReviewById(reviewDto.Id);
        reviewToUpdate.Contents = reviewDto.Contents;
        await _context.SaveChangesAsync();
        return reviewToUpdate;
    }

    public async Task<bool> DeleteReview(int id)
    {
        var reviewToDelete = await FindReviewById(id);
        if (reviewToDelete == null) return false;
        _context.Reviews.Remove(reviewToDelete);
        await _context.SaveChangesAsync();
        return true;
    }
}
