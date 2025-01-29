using CommonLibrary.DataClasses.Entities;
using SpreeviewAPI.Services.Interfaces;

namespace SpreeviewAPI.Services.Implementations;

public class SeriesService : ISeriesService
{
    public IEnumerable<Series>? Index()
    {
        return new List<Series>();
    }

    public Series? GetById(int id)
    {
        return new Series();
    }

    public Series? Create(Series series)
    {
        return new Series();
    }

    public Series? Edit(int id, Series series)
    {
        return new Series();
    }

    public Series? Delete(int id)
    {
        return new Series();
    }
}
