using CommonLibrary.DataClasses.CommentModel;
using SpreeviewAPI.Database;

namespace SpreeviewAPI.Repository;

public class CommentRepository 
{
    private readonly ApplicationDbContext _context;

    public CommentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Comment>?> Index()
        => _context.Comments.ToList();

    public async Task<Comment?> GetById(int id)
        => _context.Comments.FirstOrDefault(x => x.Id == id);

    public async Task<List<Comment>?> GetByUserId(int userId)
        => _context.Comments.Where(x => x.UserId == userId).ToList();

    public async Task<List<Comment>?> GetByReviewId(int reviewId)
        => _context.Comments.Where(x => x.ReviewId == reviewId).ToList();

    public async Task<Comment?> Create(Comment comment)
    {
        comment.DateAdded = DateTime.Now;
        var review = _context.Reviews.FirstOrDefault(x => x.Id == comment.ReviewId);
        if (review == null) return null;
        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();
        return comment;
    }

    public async Task<Comment?> Update(CommentUpdateDTO commentDto)
    {
        var commentToUpdate = await GetById(commentDto.Id);
        commentToUpdate.Contents = commentDto.Contents;
        _context.Comments.Update(commentToUpdate);
        await _context.SaveChangesAsync();
        return commentToUpdate;
    }

    public async Task<bool> Delete(int id)
    {
        var commentToDelete = await GetById(id);
        if (commentToDelete == null) return false;
        _context.Comments.Remove(commentToDelete);
        _context.SaveChangesAsync();
        return true;
    }
}