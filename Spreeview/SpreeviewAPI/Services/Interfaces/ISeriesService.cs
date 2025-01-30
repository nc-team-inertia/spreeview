using CommonLibrary.DataClasses.SeriesModel;

namespace SpreeviewAPI.Services.Interfaces;
public interface ISeriesService
{
    Series? Create(Series series);
    Series? Delete(int id);
    Series? Edit(int id, Series series);
    Series? GetById(int id);
    IEnumerable<Series>? Index();
}