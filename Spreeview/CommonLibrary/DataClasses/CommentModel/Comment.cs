namespace CommonLibrary.DataClasses.CommentModel;

public class Comment : IEntity
{
	public int Id { get; set; }
	public string Contents { get; set; } = "";
	public int UserId { get; set; }
	public DateTime DateAdded { get; set; }
	public int ReviewId { get; set; }
	public int SeriesId { get; set; }
	public int SeasonNumber { get; set; }
	public int EpisodeNumber { get; set; }
}
