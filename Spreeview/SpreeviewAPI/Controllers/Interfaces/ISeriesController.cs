using CommonLibrary.DataClasses.SeriesModel;
using Microsoft.AspNetCore.Mvc;

namespace SpreeviewAPI.Controllers.Interfaces;
public interface ISeriesController
{
    Task<ActionResult> GetById(int id);
    ActionResult Index();
}
