using CommonLibrary.DataClasses.SeriesModel;
using Microsoft.AspNetCore.Mvc;
using SpreeviewAPI.Controllers.Interfaces;
using SpreeviewAPI.Services.Interfaces;

namespace SpreeviewAPI.Controllers.Implementations;

[ApiController]
[Route("api/[controller]")]
public class SeriesController : ControllerBase, ISeriesController
{
    private readonly ISeriesService _seriesService;
    public SeriesController(ISeriesService seriesService)
    {
        _seriesService = seriesService;
    }

    [HttpGet]
    public ActionResult Index()
    {
        return null;
    }

    [HttpGet("{id}")]
    public ActionResult Details(int id)
    {
        return null;
    }

    [HttpPost]
    public ActionResult Create(Series series)
    {
        return null;
    }

    [HttpPut("{id}")]
    public ActionResult Edit(int id, Series series)
    {
        return null;
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        return null;
    }
}
