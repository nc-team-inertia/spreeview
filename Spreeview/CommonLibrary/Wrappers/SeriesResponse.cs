using CommonLibrary.DataClasses.SeriesModel;

namespace SpreeviewAPI.Wrappers;

public class SeriesResponse
{
    public int Page { get; set; }
    public List<Series> Results { get; set; }
}
