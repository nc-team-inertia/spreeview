using CommonLibrary.DataClasses.SeasonModel;

namespace CommonLibrary.DataClasses.SeriesModel
{
    public class SeriesGetDTO : IGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
		public DateOnly ReleaseDate { get; set; }
		public string Overview { get; set; }
		public string BannerPath { get; set; }
		public string CoverPath { get; set; }
        public string PosterPath { get; set; }
        public List<Season> Seasons { get; set; }
	}
}
