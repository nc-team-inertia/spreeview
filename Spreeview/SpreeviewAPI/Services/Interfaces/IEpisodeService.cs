using CommonLibrary.DataClasses.EpisodeModel;

namespace SpreeviewAPI.Services.Interfaces;

public interface IEpisodeService
{
    Task<Episode?> FindByIds(int seriesId, int seasonId, int episodeId);
}
