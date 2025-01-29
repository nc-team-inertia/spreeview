using CommonLibrary.DataClasses.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SpreeviewAPI.Controllers.Interfaces;
public interface ISeriesController
{
    ActionResult Create(Series series);
    ActionResult Delete(int id);
    ActionResult Details(int id);
    ActionResult Edit(int id, Series series);
    ActionResult Index();
}