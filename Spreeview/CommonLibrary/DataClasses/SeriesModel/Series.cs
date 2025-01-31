using System.ComponentModel;
using CommonLibrary.DataClasses.SeasonModel;

namespace CommonLibrary.DataClasses.SeriesModel;

public class Series : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public DateOnly ReleaseDate { get; set; }
    public string Overview { get; set; } = "";
	public string BannerPath { get; set; } = "";
	public string CoverPath { get; set; } = "";
    public List<Season> Seasons { get; set; } = [];
}