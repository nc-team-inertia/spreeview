using CommonLibrary.DataClasses.ReviewModel;

namespace CommonLibrary.DataClasses.CommentModel
{
    public class CommentUpdateDTO : IUpdateDTO
    {
	    public int Id { get; set; }
		public string Contents { get; set; }
	}
}
