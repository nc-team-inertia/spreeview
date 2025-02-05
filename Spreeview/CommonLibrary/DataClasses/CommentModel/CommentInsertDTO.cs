using CommonLibrary.DataClasses.ReviewModel;

namespace CommonLibrary.DataClasses.CommentModel
{
    public class CommentInsertDTO : IInsertDTO
    {
		public string Contents { get; set; }
		public int ReviewId { get; set; }
	}
}
