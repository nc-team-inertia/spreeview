namespace CommonLibrary.DataClasses.ReviewModel
{
    public class CommentUpdateDTO : IUpdateDTO
    {
		public string Contents { get; set; }
		public int UserId { get; set; }
		public int SeriesId { get; set; }
		public int Season { get; set; }
		public int Episode { get; set; }
	}
}
