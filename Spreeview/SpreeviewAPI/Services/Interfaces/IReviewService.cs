using CommonLibrary.DataClasses.ReviewModel;

namespace SpreeviewAPI.Services.Interfaces;
public interface IReviewService
{
    Task<Review?> Create(Review review);
    Review? Delete(int id);
    Review? Edit(int id, Review review);
    Task<Review?> GetById(int id);
    Task<IEnumerable<Review>?> Index();
}