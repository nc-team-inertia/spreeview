using AutoMapper;
using CommonLibrary.DataClasses.ReviewModel;
using Microsoft.AspNetCore.Mvc;
using SpreeviewAPI.Controllers.Interfaces;
using SpreeviewAPI.Services.Interfaces;

namespace SpreeviewAPI.Controllers.Implementations;

[ApiController]
[Route("api/[controller]")]
public class ReviewController : ControllerBase, IReviewController
{
    private readonly IMapper _mapper;
    private readonly IReviewService _reviewService;
    public ReviewController(IReviewService reviewService, IMapper mapper)
    {
        _mapper = mapper;
        _reviewService = reviewService;
    }

    [HttpGet]
    public async Task<ActionResult> Index()
    {
        var response = await _reviewService.Index();
        if(response == null) return NotFound();
        return Ok(response);
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
