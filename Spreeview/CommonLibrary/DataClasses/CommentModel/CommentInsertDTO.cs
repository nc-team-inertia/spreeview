using CommonLibrary.DataClasses.Entities;

namespace CommonLibrary.DataClasses.CommentModel
{
    public class CommentInsertDTO : IInsertDTO
    {
		public string Contents { get; set; }
		public Review Review { get; set; }
		public int UserId { get; set; }
		public DateTime DateAdded { get; set; }
	}
}
