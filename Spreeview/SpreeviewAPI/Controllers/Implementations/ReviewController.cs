﻿using AutoMapper;
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

    [HttpPost]
    public async Task<ActionResult> Create(ReviewInsertDTO reviewDto)
    {
        if(!ModelState.IsValid) return BadRequest();
        var review = _mapper.Map<Review>(reviewDto);
        var response = await _reviewService.Create(review);
        if(response == null) return NotFound();
        return Ok(_mapper.Map<ReviewGetDTO>(response));
    }

    [HttpPut]
    public async Task<ActionResult> Edit(ReviewUpdateDTO reviewDto)
    {
        if(!ModelState.IsValid) return BadRequest();
        var exists = await _reviewService.GetById(reviewDto.Id);
        if(exists == null) return NotFound();
        var response = await _reviewService.Edit(reviewDto);
        if(response == null) return NotFound();
        var responseDto = _mapper.Map<ReviewGetDTO>(response);
        return Ok(responseDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var response = await _reviewService.Delete(id);
        return response ? NoContent() : NotFound();
    }
}
