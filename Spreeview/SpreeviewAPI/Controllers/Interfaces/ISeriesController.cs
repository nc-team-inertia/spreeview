using Microsoft.AspNetCore.Mvc;

namespace SpreeviewAPI.Controllers.Interfaces;

public interface ISeriesController
{
    Task<ActionResult> IndexPopularSeries();
    Task<ActionResult> IndexTopRatedSeries();
    Task<ActionResult> GetSeriesById(int seriesId);
    Task<ActionResult> GetSeriesByKeywords(string query);
    Task<ActionResult> GetRecommendationsById(int seriesId);
}
