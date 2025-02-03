using CommonLibrary.DataClasses.EpisodeModel;

namespace CommonLibrary.DataClasses.SeasonModel
{
    public class SeasonGetDTO : IGetDTO
    {
		public int Id { get; set; }
		public int SeasonNumber { get; set; }
		public DateOnly ReleaseDate { get; set; }
		public string PosterPath { get; set; }
		public List<Episode> Episodes { get; set; }
		public int SeriesId { get; set; }
	}
}
