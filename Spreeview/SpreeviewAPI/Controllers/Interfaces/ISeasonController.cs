using Microsoft.AspNetCore.Mvc;

namespace SpreeviewAPI.Controllers.Interfaces
{
    public interface ISeasonController
    {
        Task<ActionResult> GetSeason(int seriesId, int seasonNumber);
    }
}