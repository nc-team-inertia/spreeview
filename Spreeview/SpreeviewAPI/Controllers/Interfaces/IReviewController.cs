using CommonLibrary.DataClasses.ReviewModel;
using Microsoft.AspNetCore.Mvc;

namespace SpreeviewAPI.Controllers.Interfaces;
public interface IReviewController
{
    Task<ActionResult> Create(ReviewInsertDTO dto);
    ActionResult Delete(int id);
    ActionResult Edit(int id, Review review);
    Task<ActionResult> GetById(int id);
    Task<ActionResult> Index();
}