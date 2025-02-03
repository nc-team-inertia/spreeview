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
    public async Task<ActionResult> IndexPopular()
    {
        var response = await _seriesService.IndexPopularSeries();
        if (response == null) return NotFound();
        var dtoList = _mapper.Map<List<SeriesGetDTO>>(response);
        return Ok(dtoList);
    }

    [HttpGet("top")]
    public async Task<ActionResult> IndexTopRated()
    {
        var response = await _seriesService.IndexTopRatedSeries();
        if (response == null) return NotFound("There were no top-rated series found.");
        List<SeriesGetDTO> dtoList = _mapper.Map<List<SeriesGetDTO>>(response);
        return Ok(dtoList);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetById(int id)
    {
        var response = await _seriesService.FindSeriesById(id);
        if (response == null) return NotFound();
        var dto = _mapper.Map<SeriesGetDTO>(response);
        return Ok(dto);
    }

    [HttpGet("search")]
    public async Task<ActionResult> GetByKeywords([FromQuery] string query)
    {
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
