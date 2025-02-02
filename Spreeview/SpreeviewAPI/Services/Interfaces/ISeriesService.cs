using CommonLibrary.DataClasses.SeriesModel;

namespace SpreeviewAPI.Services.Interfaces;
public interface ISeriesService
{
    Task<List<Series>?> FindByKeywords(string query);
    Task<Series?> GetById(int id);
    Task<IEnumerable<Series>?> IndexPopular();
}