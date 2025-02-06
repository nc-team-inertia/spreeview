using CommonLibrary.DataClasses.CommentModel;
using SpreeviewAPI.Repository.Interfaces;

namespace SpreeviewAPI.Services.Implementations;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }
    
    public async Task<List<Comment>?> IndexAllComments()
        => await _commentRepository.IndexAllComments();

    public async Task<Comment?> FindCommentById(int id)
        => await _commentRepository.FindCommentById(id);

    public async Task<List<Comment>?> FindCommentsByUserId(int userId)
        => await _commentRepository.FindCommentsByUserId(userId);

    public async Task<List<Comment>?> FindCommentsByReviewId(int reviewId)
        => await _commentRepository.FindCommentsByReviewId(reviewId);

    public async Task<Comment?> CreateComment(Comment comment)
        => await _commentRepository.CreateComment(comment);

    public async Task<Comment?> UpdateComment(CommentUpdateDTO commentDto)
        => await _commentRepository.UpdateComment(commentDto);

    public async Task<bool> DeleteComment(int id)
        => await _commentRepository.DeleteComment(id);
}
