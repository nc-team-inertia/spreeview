using CommonLibrary.DataClasses.CommentModel;

namespace SpreeviewAPI.Repository.Interfaces;

public interface ICommentRepository
{
    Task<Comment?> CreateComment(Comment comment);
    Task<bool> DeleteComment(int id);
    Task<Comment?> FindCommentById(int id);
    Task<List<Comment>?> FindCommentsByReviewId(int reviewId);
    Task<List<Comment>?> FindCommentsByUserId(int userId);
    Task<List<Comment>?> IndexAllComments();
    Task<Comment?> UpdateComment(CommentUpdateDTO commentDto);
}
