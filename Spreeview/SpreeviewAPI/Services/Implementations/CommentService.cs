using CommonLibrary.DataClasses.CommentModel;
using SpreeviewAPI.Repository;

namespace SpreeviewAPI.Services.Implementations;

public class CommentService : ICommentService
{
    private readonly CommentRepository _commentRepository;

    public CommentService(CommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }
    
    public async Task<List<Comment>?> Index()
        => await _commentRepository.Index();

    public async Task<Comment?> GetById(int id)
        => await _commentRepository.GetById(id);

    public async Task<List<Comment>?> GetByUserId(int userId)
        => await _commentRepository.GetByUserId(userId);

    public async Task<List<Comment>?> GetByReviewId(int reviewId)
        => await _commentRepository.GetByReviewId(reviewId);

    public async Task<Comment?> Create(Comment comment)
        => await _commentRepository.Create(comment);

    public async Task<Comment?> Update(CommentUpdateDTO commentDto)
        => await _commentRepository.Update(commentDto);

    public async Task<bool> Delete(int id)
        => await _commentRepository.Delete(id);
}