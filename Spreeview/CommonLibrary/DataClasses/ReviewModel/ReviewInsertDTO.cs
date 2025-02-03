using System.ComponentModel.DataAnnotations;

namespace CommonLibrary.DataClasses.ReviewModel
{
    public class ReviewInsertDTO : IInsertDTO
    {
		public int UserId { get; set; }
		public int SeriesId { get; set; }
		public int EpisodeId { get; set; }
		[MaxLength(1000)]
		public string Contents { get; set; }
		[Range(1, 10)]
		public int Rating { get; set; }
	}
}
