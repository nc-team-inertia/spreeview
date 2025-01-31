using CommonLibrary.DataClasses.EpisodeModel;
using System.ComponentModel;

namespace CommonLibrary.DataClasses.SeriesModel;

public class Season : IEntity
{
	public int Id { get; set; }
	public int SeasonNumber { get; set; }
	public DateOnly ReleaseDate { get; set; }
	public string PosterPath { get; set; } = "";
	public List<Episode> Episodes { get; set; } = [];
	public int SeriesId { get; set; }

}
