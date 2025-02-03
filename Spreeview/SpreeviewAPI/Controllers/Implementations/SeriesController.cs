using CommonLibrary.DataClasses.SeriesModel;
using Microsoft.AspNetCore.Mvc;
using SpreeviewAPI.Controllers.Interfaces;
using SpreeviewAPI.Services.Interfaces;
using AutoMapper;

namespace SpreeviewAPI.Controllers.Implementations;

[ApiController]
[Route("api/[controller]")]
public class SeriesController : ControllerBase, ISeriesController
{
    private readonly IMapper _mapper;
    private readonly ISeriesService _seriesService;
    public SeriesController(ISeriesService seriesService, IMapper mapper)
    {
        _seriesService = seriesService;
        _mapper = mapper;
    }

    [HttpGet("trending")]
    public async Task<ActionResult> IndexPopularSeries()
    {
        var response = await _seriesService.IndexPopularSeries();
        if (response == null) return NotFound("There were no popular series found.");
        var dtoList = _mapper.Map<List<SeriesGetDTO>>(response);
        return Ok(dtoList);
    }

    [HttpGet("top")]
    public async Task<ActionResult> IndexTopRatedSeries()
    {
        var response = await _seriesService.IndexTopRatedSeries();
        if (response == null) return NotFound("There were no top-rated series found.");
        List<SeriesGetDTO> dtoList = _mapper.Map<List<SeriesGetDTO>>(response);
        return Ok(dtoList);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetSeriesById(int seriesId)
    {
        var response = await _seriesService.FindSeriesById(seriesId);
        if (response == null) return NotFound("There is no series with the associated ID.");
        var dto = _mapper.Map<SeriesGetDTO>(response);
        return Ok(dto);
    }

    [HttpGet("search")]
    public async Task<ActionResult> GetSeriesByKeywords([FromQuery] string query)
    {
        if (String.IsNullOrWhiteSpace(query)) return BadRequest("Please enter a valid query.");
        List<Series>? response = await _seriesService.FindSeriesByKeywords(query);
        if (response == null) return NotFound("There were no series found from the given query.");
        List<SeriesGetDTO> dtoList = _mapper.Map<List<SeriesGetDTO>>(response);
        return Ok(dtoList);
    }

    [HttpGet("recommendations/{seriesId:int}")]
    public async Task<ActionResult> GetRecommendationsById(int seriesId)
    {
        List<Series>? response = await _seriesService.FindRecommendationsById(seriesId);
        if (response == null) return NotFound("There were no recommendations found for the given series ID.");
        List<SeriesGetDTO> dtoList = _mapper.Map<List<SeriesGetDTO>>(response);
        return Ok(dtoList);
    }
}
