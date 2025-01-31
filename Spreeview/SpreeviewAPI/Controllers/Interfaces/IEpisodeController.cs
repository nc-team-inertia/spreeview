using CommonLibrary.DataClasses.EpisodeModel;
using Microsoft.AspNetCore.Mvc;

namespace SpreeviewAPI.Controllers.Interfaces;

public interface IEpisodeController
{
    Task<ActionResult> GetByIds(int seriesId, int seasonNumber, int episodeNumber);
}
