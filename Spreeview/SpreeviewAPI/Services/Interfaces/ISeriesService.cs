using CommonLibrary.DataClasses.SeriesModel;

namespace SpreeviewAPI.Services.Interfaces;

public interface ISeriesService
{
    Task<IEnumerable<SeriesDTO>?> IndexPopular();
    Task<List<SeriesDTO>?> IndexTopRated();
    Task<SeriesDTO?> GetById(int id);
    Task<List<SeriesDTO>?> FindByKeywords(string query);
    Task<List<SeriesDTO>?> FindRecommendationsById(int seriesId);
}
