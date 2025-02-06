using CommonLibrary.DataClasses.CommentModel;
using System.ComponentModel.DataAnnotations;

namespace CommonLibrary.DataClasses.ReviewModel;

public class ReviewGetDTO : IGetDTO
{
	public int Id { get; set; }
    public int UserId { get; set; }
    public int SeriesId { get; set; }
    public int SeasonNumber { get; set; }
    public int EpisodeNumber { get; set; }
    public int EpisodeId { get; set; }

    [MaxLength(1000)]
    public string Contents { get; set; } = "";

	[Range(1, 10)]
    public int Rating { get; set; }

    public List<Comment> Comments { get; set; } = [];
	public int Likes { get; set; }
    public DateTime DateAdded { get; set; }
}
