using CommonLibrary.DataClasses.ReviewModel;
using Microsoft.AspNetCore.Mvc;

namespace SpreeviewAPI.Controllers.Interfaces;
public interface IReviewController
{
    Task<ActionResult> Create(ReviewInsertDTO dto);
    Task<ActionResult> Delete(int id);
    Task<ActionResult> Edit(ReviewUpdateDTO dto);
    Task<ActionResult> GetByEpisodeId(int episodeId);
    Task<ActionResult> GetBySeriesId(int seriesId);
    Task<ActionResult> GetByUserId(int userId);
    Task<ActionResult> GetById(int id);
    Task<ActionResult> Index();
}