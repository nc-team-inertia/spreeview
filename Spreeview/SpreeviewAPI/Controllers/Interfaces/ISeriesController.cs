using CommonLibrary.DataClasses.SeriesModel;
using Microsoft.AspNetCore.Mvc;

namespace SpreeviewAPI.Controllers.Interfaces;
public interface ISeriesController
{
    ActionResult Details(int id);
    ActionResult Index();
}