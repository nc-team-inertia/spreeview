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
    {
        return new List<Review>();
    }

    public async Task<Review?> GetById(int id)
    {
        return new Review();
    }

    public async Task<Review?> Create(Review review)
    {
        return new Review();
    }

    public async Task<Review?> Edit(ReviewUpdateDTO reviewDto)
    {
        return new Review();
    }

    public async Task<bool> Delete(int id)
    {
        return true;
    }
}
