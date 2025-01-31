using CommonLibrary.DataClasses.ReviewModel;

namespace CommonLibrary.DataClasses.CommentModel;

public class Comment : IEntity
{
	public int Id { get; set; }
	public string Contents { get; set; } = "";
	public Review Review { get; set; }
	public int UserId { get; set; }
	public DateTime DateAdded { get; set; }
}