using Microsoft.AspNetCore.Mvc;

namespace SpreeviewAPI.Controllers.Interfaces;

public interface ISeriesController
{
    Task<ActionResult> GetById(int id);
    Task<ActionResult> IndexPopular();
    Task<ActionResult> GetByKeywords(string query);
}
