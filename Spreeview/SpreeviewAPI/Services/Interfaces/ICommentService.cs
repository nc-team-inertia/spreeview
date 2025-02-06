using CommonLibrary.DataClasses.CommentModel;

namespace SpreeviewAPI.Services.Implementations;

public interface ICommentService
{
    Task<List<Comment>?> IndexAllComments();
    Task<Comment?> FindCommentById(int id);
    Task<List<Comment>?> FindCommentsByUserId(int userId);
    Task<List<Comment>?> FindCommentsByReviewId(int reviewId);
    Task<Comment?> CreateComment(Comment comment);
    Task<Comment?> UpdateComment(CommentUpdateDTO commentDto);
    Task<bool> DeleteComment(int id);
}
