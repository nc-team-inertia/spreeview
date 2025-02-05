using CommonLibrary.DataClasses.CommentModel;

namespace SpreeviewAPI.Services.Implementations;

public interface ICommentService
{
    Task<List<Comment>?> Index();
    Task<Comment?> GetById(int id);
    Task<List<Comment>?> GetByUserId(int userId);
    Task<List<Comment>?> GetByReviewId(int reviewId);
    Task<Comment?> Create(Comment comment);
    Task<Comment?> Update(CommentUpdateDTO commentDto);
    Task<bool> Delete(int id);
}