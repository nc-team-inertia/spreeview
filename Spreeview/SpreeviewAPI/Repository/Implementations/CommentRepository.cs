using CommonLibrary.DataClasses.CommentModel;
using SpreeviewAPI.Database;
using SpreeviewAPI.Repository.Interfaces;

namespace SpreeviewAPI.Repository.Implementations;

public class CommentRepository : ICommentRepository
{
    private readonly ApplicationDbContext _context;
    public CommentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Comment>?> IndexAllComments()
        => _context.Comments.ToList();

    public async Task<Comment?> FindCommentById(int id)
        => _context.Comments.FirstOrDefault(x => x.Id == id);

    public async Task<List<Comment>?> FindCommentsByUserId(int userId)
        => _context.Comments.Where(x => x.UserId == userId).ToList();

    public async Task<List<Comment>?> FindCommentsByReviewId(int reviewId)
        => _context.Comments.Where(x => x.ReviewId == reviewId).ToList();

    public async Task<Comment?> CreateComment(Comment comment)
    {
        comment.DateAdded = DateTime.Now;
        var review = _context.Reviews.FirstOrDefault(x => x.Id == comment.ReviewId);
        if (review == null) return null;
        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();
        return comment;
    }

    public async Task<Comment?> UpdateComment(CommentUpdateDTO commentDto)
    {
        var commentToUpdate = await FindCommentById(commentDto.Id);
        commentToUpdate.Contents = commentDto.Contents;
        _context.Comments.Update(commentToUpdate);
        await _context.SaveChangesAsync();
        return commentToUpdate;
    }

    public async Task<bool> DeleteComment(int id)
    {
        var commentToDelete = await FindCommentById(id);
        if (commentToDelete == null) return false;
        _context.Comments.Remove(commentToDelete);
        _context.SaveChangesAsync();
        return true;
    }
}
