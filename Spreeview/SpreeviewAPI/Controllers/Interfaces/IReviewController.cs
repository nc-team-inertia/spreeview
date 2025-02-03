using CommonLibrary.DataClasses.ReviewModel;
using Microsoft.AspNetCore.Mvc;

namespace SpreeviewAPI.Controllers.Interfaces;
public interface IReviewController
{
    ActionResult Create(Review review);
    ActionResult Delete(int id);
    ActionResult Edit(int id, Review review);
    ActionResult GetById(int id);
    Task<ActionResult> Index();
}