using CommonLibrary.DataClasses.ReviewModel;
using SpreeviewAPI.Database;

namespace SpreeviewAPI.Repository;

public class ReviewRepository
{
    private readonly ApplicationDbContext _context;

    public ReviewRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Review>?> Index()
        => _context.Reviews.ToList();

    public async Task<Review?> GetById(int id)
        => _context.Reviews.FirstOrDefault(x => x.Id == id);

    public async Task<List<Review>?> GetByEpisodeId(int id)
        => _context.Reviews.Where(r => r.EpisodeId == id).ToList();

    public async Task<Review?> Create(Review review)
    {
        await _context.Reviews.AddAsync(review);
        await _context.SaveChangesAsync();
        return review;
    }

    public async Task<Review?> Edit(ReviewUpdateDTO reviewDto)
    {
        var reviewToUpdate = await GetById(reviewDto.Id);
        reviewToUpdate.Contents = reviewDto.Contents;
        await _context.SaveChangesAsync();
        return reviewToUpdate;
    }

    public async Task<bool> Delete(int id)
    {
        var reviewToDelete = await GetById(id);
        if (reviewToDelete == null) return false;
        _context.Reviews.Remove(reviewToDelete);
        await _context.SaveChangesAsync();
        return true;
    }
}