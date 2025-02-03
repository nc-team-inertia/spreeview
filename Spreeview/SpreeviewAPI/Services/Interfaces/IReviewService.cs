using CommonLibrary.DataClasses.ReviewModel;

namespace SpreeviewAPI.Services.Interfaces;
public interface IReviewService
{
    Review? Create(Review review);
    Review? Delete(int id);
    Review? Edit(int id, Review review);
    Review? GetById(int id);
    IEnumerable<Review>? Index();
}