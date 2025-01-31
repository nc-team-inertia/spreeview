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

    [HttpGet]
    public ActionResult Index()
    {
        var response = _seriesService.Index();
        return response != null ? Ok(response) : NotFound();
    }

    [HttpGet("{id:int}")]
    public ActionResult Details(int id)
    {
        var response = _seriesService.GetById(id);
        if (response == null) return NotFound();
        var dto = _mapper.Map<SeriesGetDTO>(response);
        return Ok(dto);
    }
}
