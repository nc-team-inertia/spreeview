using CommonLibrary.DataClasses.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SpreeviewAPI.Controllers.Interfaces;
public interface IEpisodeController
{
    ActionResult Create(Episode episode);
    ActionResult Delete(int id);
    ActionResult Edit(int id, Episode episode);
    ActionResult GetById(int id);
    ActionResult Index();
}