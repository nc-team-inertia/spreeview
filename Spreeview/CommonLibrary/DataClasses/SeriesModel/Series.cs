using System.ComponentModel;
using System.Text.Json.Serialization;
using CommonLibrary.DataClasses.SeasonModel;

namespace CommonLibrary.DataClasses.SeriesModel;

public class Series : IEntity
{
	[JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";
    [JsonPropertyName("first_air_date")]
    public DateOnly ReleaseDate { get; set; }
    [JsonPropertyName("overview")]
    public string Overview { get; set; } = "";
    [JsonPropertyName("backdrop_path")]
	public string BannerPath { get; set; } = "";
	[JsonPropertyName("cover_path")]
	public string CoverPath { get; set; } = "";
    public List<Season> Seasons { get; set; } = [];
}