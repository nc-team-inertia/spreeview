using Microsoft.AspNetCore.Mvc;

namespace SpreeviewAPI.Controllers.Interfaces;

public interface IEpisodeController
{
    Task<ActionResult> GetEpisodeByIds(int seriesId, int seasonNumber, int episodeNumber);
}
