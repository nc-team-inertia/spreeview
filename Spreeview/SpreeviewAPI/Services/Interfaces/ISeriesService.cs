using CommonLibrary.DataClasses.SeriesModel;

namespace SpreeviewAPI.Services.Interfaces;

public interface ISeriesService
{
    Task<List<Series>?> IndexPopularSeries();
    Task<List<Series>?> IndexTopRatedSeries();
    Task<Series?> FindSeriesById(int id);
    Task<List<Series>?> FindSeriesByKeywords(string query);
    Task<List<Series>?> FindRecommendationsById(int seriesId);
}
