using CommonLibrary.DataClasses.Entities;
using SpreeviewAPI.Services.Interfaces;

namespace SpreeviewAPI.Services.Implementations;

public class ReviewService : IReviewService
{
    public IEnumerable<Review>? Index()
    {
        return new List<Review>();
    }

    public Review? GetById(int id)
    {
        return new Review();
    }

    public Review? Create(Review review)
    {
        return new Review();
    }

    public Review? Edit(int id, Review review)
    {
        return new Review();
    }

    public Review? Delete(int id)
    {
        return new Review();
    }
}
