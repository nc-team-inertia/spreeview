using CommonLibrary.DataClasses.ReviewModel;

namespace SpreeviewAPI.Services.Interfaces;
public interface IReviewService
{
    Task<IEnumerable<Review>?> Index();
    Task<Review?> GetById(int id);
    Task<IEnumerable<Review>?> GetByEpisodeId(int episodeId);
    Task<Review?> Create(Review review);
    Task<Review?> Edit(ReviewUpdateDTO review);
    Task<bool> Delete(int id);
}