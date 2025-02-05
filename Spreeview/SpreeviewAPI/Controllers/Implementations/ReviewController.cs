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
    public async Task<ActionResult> Index()
    {
        var response = await _reviewService.Index();
        if(response == null) return NotFound();
        var responseDto = _mapper.Map<List<ReviewGetDTO>>(response);
        return Ok(responseDto);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetById(int id)
    {
        var response = await _reviewService.GetById(id);
        if(response == null) return NotFound();
        var responseDto = _mapper.Map<ReviewGetDTO>(response);
        return Ok(responseDto);
    }
    
    [HttpGet("episode/{episodeId:int}")]
    public async Task<ActionResult> GetByEpisodeId(int episodeId)
    {
        var response = await _reviewService.GetByEpisodeId(episodeId);
        if (response == null) return NotFound();
        var responseDto = _mapper.Map<List<ReviewGetDTO>>(response);
        return Ok(responseDto);
    }

    [HttpGet("user/{userId:int}")]
    public async Task<ActionResult> GetByUserId(int userId)
    {
        var response = await _reviewService.GetByUserId(userId);
        if(response == null) return NotFound();
        var responseDto = _mapper.Map<List<ReviewGetDTO>>(response);
        return Ok(responseDto);
    }

    [HttpGet("series/{seriesId:int}")]
    public async Task<ActionResult> GetBySeriesId(int seriesId)
    {
        var response = await _reviewService.GetBySeriesId(seriesId);
        if(response == null) return NotFound();
        var responseDto = _mapper.Map<List<ReviewGetDTO>>(response);
        return Ok(responseDto);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult> Create(ReviewInsertDTO reviewDto)
    {
        if(!ModelState.IsValid) return BadRequest();
        
        // Get the current user
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Unauthorized();
        
        var review = _mapper.Map<Review>(reviewDto);
        
        // Set the user id from the current user
        review.UserId = user.Id;
        
        var response = await _reviewService.Create(review);
        if(response == null) return NotFound();
        return Ok(_mapper.Map<ReviewGetDTO>(response));
    }

    [Authorize]
    [HttpPut]
    public async Task<ActionResult> Edit(ReviewUpdateDTO reviewDto)
    {
        if(!ModelState.IsValid) return BadRequest();
        
        //TODO: Optimize this service / repository call path to avoid multiple database calls. 
        // We could do with check user owns review service method.
        
        //Get the review if exists
        var exists = await _reviewService.GetById(reviewDto.Id);
        if(exists == null) return NotFound();
        
        // Get the current user
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Unauthorized();
        
        // Check if user owns the review
        if (exists.UserId != user.Id) return Unauthorized();
        
        var response = await _reviewService.Edit(reviewDto);
        if(response == null) return NotFound();
        var responseDto = _mapper.Map<ReviewGetDTO>(response);
        return Ok(responseDto);
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        //TODO: Optimize this service / repository call path to avoid multiple database calls. 
        // We could do with check user owns review service method.
        
        //Get review if exists
        var exists = await _reviewService.GetById(id);
        if(exists == null) return NotFound();
        
        // Get the current user
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return Unauthorized();
        
        // Check if user owns the review
        if (exists.UserId != user.Id) return Unauthorized();
        
        var response = await _reviewService.Delete(id);
        return response ? NoContent() : NotFound();
    }
}
