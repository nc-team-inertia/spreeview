using CommonLibrary.DataClasses.Entities;
using SpreeviewAPI.Services.Interfaces;

namespace SpreeviewAPI.Services.Implementations;

public class EpisodeService : IEpisodeService
{
    public IEnumerable<Episode>? Index()
    {
        return new List<Episode>();
    }

    public Episode? GetById(int id)
    {
        return new Episode();
    }

    public Episode? Create(Episode episode)
    {
        return new Episode();
    }

    public Episode? Edit(int id, Episode episode)
    {
        return new Episode();
    }

    public Episode? Delete(int id)
    {
        return new Episode();
    }
}
