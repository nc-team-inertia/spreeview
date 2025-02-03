using Microsoft.AspNetCore.Mvc;

namespace SpreeviewAPI.Controllers.Interfaces;

public interface ISeasonController
{
    Task<ActionResult> GetSeasonByIds(int seriesId, int seasonNumber);
}
