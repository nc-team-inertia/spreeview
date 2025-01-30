using CommonLibrary.DataClasses.EpisodeModel;

namespace SpreeviewAPI.Services.Interfaces;
public interface IEpisodeService
{
    Episode? Create(Episode episode);
    Episode? Delete(int id);
    Episode? Edit(int id, Episode episode);
    Episode? GetById(int id);
    IEnumerable<Episode>? Index();
}