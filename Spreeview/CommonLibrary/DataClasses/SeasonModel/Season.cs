using CommonLibrary.DataClasses.EpisodeModel;
using System.Text.Json.Serialization;

namespace CommonLibrary.DataClasses.SeasonModel;

public class Season : IEntity
{
	public int Id { get; set; }

	[JsonPropertyName("name")]
	public string SeasonName { get; set; }

	[JsonPropertyName("season_number")]
	public int SeasonNumber { get; set; }

	[JsonPropertyName("air_date")]
	public DateOnly ReleaseDate { get; set; }

	[JsonPropertyName("poster_path")]
	public string PosterPath { get; set; }

	public List<Episode> Episodes { get; set; }

	public int SeriesId { get; set; }
}
