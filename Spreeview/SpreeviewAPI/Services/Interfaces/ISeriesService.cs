using CommonLibrary.DataClasses.SeriesModel;

namespace SpreeviewAPI.Services.Interfaces;

public interface ISeriesService
{
    Task<IEnumerable<Series>?> IndexPopular();
    Task<List<Series>?> IndexTopRated();
    Task<Series?> GetById(int id);
    Task<List<Series>?> FindByKeywords(string query);
    Task<List<Series>?> FindRecommendationsById(int seriesId);
}
