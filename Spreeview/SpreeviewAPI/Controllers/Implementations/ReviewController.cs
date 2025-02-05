using System.Security.Claims;
using AutoMapper;
using Azure.Core;
using CommonLibrary.DataClasses.ReviewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpreeviewAPI.Controllers.Interfaces;
using SpreeviewAPI.Models;
using SpreeviewAPI.Services.Interfaces;

namespace SpreeviewAPI.Controllers.Implementations;

[ApiController]
[Route("api/[controller]")]
public class ReviewController : ControllerBase, IReviewController
{
    private readonly IMapper _mapper;
    private readonly IReviewService _reviewService;
    private readonly UserManager<ApplicationUser> _userManager;
    
    public ReviewController(IReviewService reviewService, IMapper mapper, UserManager<ApplicationUser> userManager)
    {
        _mapper = mapper;
        _reviewService = reviewService;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<ActionResult> IndexAllReviews()
    {
        var response = await _reviewService.IndexAllReviews();
        if(response == null) return NotFound("There were no reviews found.");
        var responseDto = _mapper.Map<List<ReviewGetDTO>>(response);
        return Ok(responseDto);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetReviewById(int id)
    {
        var response = await _reviewService.FindReviewById(id);
        if(response == null) return NotFound("There is no review with the associated ID.");
        var responseDto = _mapper.Map<ReviewGetDTO>(response);
        return Ok(responseDto);
    }
    
    [HttpGet("episode/{episodeId:int}")]
    public async Task<ActionResult> GetReviewsByEpisodeId(int episodeId)
    {
        var response = await _reviewService.FindReviewsByEpisodeId(episodeId);
        if (response == null) return NotFound("There were no reviews with the associated episode ID.");
        var responseDto = _mapper.Map<List<ReviewGetDTO>>(response);
        return Ok(responseDto);
    }

    [HttpGet("user/{userId:int}")]
    public async Task<ActionResult> GetReviewsByUserId(int userId)
    {
        var response = await _reviewService.FindReviewsByUserId(userId);
        if(response == null) return NotFound("There were no reviews with the associated user ID.");
        var responseDto = _mapper.Map<List<ReviewGetDTO>>(response);
        return Ok(responseDto);
    }

    [HttpGet("series/{seriesId:int}")]
    public async Task<ActionResult> GetReviewsBySeriesId(int seriesId)
    {
        var response = await _reviewService.FindReviewsBySeriesId(seriesId);
        if(response == null) return NotFound("There were no reviews with the associated series ID.");
        var responseDto = _mapper.Map<List<ReviewGetDTO>>(response);
        return Ok(responseDto);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult> PostReview(ReviewInsertDTO reviewDto)
    {
        if(!ModelState.IsValid) return BadRequest("There are missing fields from the provided review information.");
        
        // Get the current user
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Unauthorized();
        
        var review = _mapper.Map<Review>(reviewDto);
        
        // Set the user id from the current user
        review.UserId = user.Id;
        
        var response = await _reviewService.CreateReview(review);
        if(response == null) return NotFound();
        return Ok(_mapper.Map<ReviewGetDTO>(response));
    }

    [Authorize]
    [HttpPut]
    public async Task<ActionResult> PutReview(ReviewUpdateDTO reviewDto)
    {
        if(!ModelState.IsValid) return BadRequest("There are missing fields from the provided review information.");
        
        //TODO: Optimize this service / repository call path to avoid multiple database calls. 
        // We could do with check user owns review service method.
        
        //Get the review if exists
        var exists = await _reviewService.FindReviewById(reviewDto.Id);
        if (exists == null) return NotFound("There is no review with the associated ID.");
        
        // Get the current user
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Unauthorized();
        
        // Check if user owns the review
        if (exists.UserId != user.Id) return Unauthorized();
        
        var response = await _reviewService.UpdateReview(reviewDto);
        var responseDto = _mapper.Map<ReviewGetDTO>(response);
        return Ok(responseDto);
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteReview(int id)
    {
        //TODO: Optimize this service / repository call path to avoid multiple database calls. 
        // We could do with check user owns review service method.
        
        //Get review if exists
        var exists = await _reviewService.FindReviewById(id);
        if (exists == null) return NotFound("There is no review with the associated ID.");
        
        // Get the current user
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Unauthorized();
        
        // Check if user owns the review
        if (exists.UserId != user.Id) return Unauthorized();
        
        var response = await _reviewService.DeleteReview(id);
        return response ? NoContent() : NotFound("There is no review with the associated ID.");
    }
}
