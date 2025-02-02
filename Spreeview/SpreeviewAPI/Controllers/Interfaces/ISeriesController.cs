using Microsoft.AspNetCore.Mvc;

namespace SpreeviewAPI.Controllers.Interfaces;

public interface ISeriesController
{
    Task<ActionResult> IndexPopular();
    Task<ActionResult> IndexTopRated();
    Task<ActionResult> GetById(int id);
    Task<ActionResult> GetByKeywords(string query);
}
