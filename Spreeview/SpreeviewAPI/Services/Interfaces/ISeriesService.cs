using CommonLibrary.DataClasses.SeriesModel;

namespace SpreeviewAPI.Services.Interfaces;
public interface ISeriesService
{
    Task<Series?> GetById(int id);
    IEnumerable<Series>? Index();
}