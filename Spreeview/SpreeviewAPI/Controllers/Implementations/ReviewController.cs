using CommonLibrary.DataClasses.ReviewModel;
using Microsoft.AspNetCore.Mvc;
using SpreeviewAPI.Controllers.Interfaces;
using SpreeviewAPI.Services.Interfaces;

namespace SpreeviewAPI.Controllers.Implementations;

[ApiController]
[Route("api/[controller]")]
public class ReviewController : ControllerBase, IReviewController
{
    private readonly IReviewService _reviewService;
    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpGet]
    public ActionResult Index()
    {
        return null;
    }

    [HttpGet("{id}")]
    public ActionResult GetById(int id)
    {
        return null;
    }

    [HttpPost]
    public ActionResult Create(Review review)
    {
        return null;
    }

    [HttpPut("{id}")]
    public ActionResult Edit(int id, Review review)
    {
        return null;
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        return null;
    }
}
