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
        var response = await _seriesService.IndexPopular();
        if (response == null) return NotFound();
        var dtoList = new List<SeriesGetDTO>();
        foreach (var series in response)
        {
            dtoList.Add(_mapper.Map<SeriesGetDTO>(series));
        }
        return Ok(dtoList);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetById(int id)
    {
        var response = await _seriesService.GetById(id);
        if (response == null) return NotFound();
        var dto = _mapper.Map<SeriesGetDTO>(response);
        return Ok(dto);
    }
}
