using CommonLibrary.DataClasses.EpisodeModel;
using Microsoft.AspNetCore.Mvc;
using SpreeviewAPI.Controllers.Interfaces;
using SpreeviewAPI.Services.Interfaces;

namespace SpreeviewAPI.Controllers.Implementations;

[ApiController]
[Route("api/[controller]")]
public class EpisodeController : ControllerBase, IEpisodeController
{
    private readonly IEpisodeService _episodeService;
    public EpisodeController(IEpisodeService episodeService)
    {
        _episodeService = episodeService;
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
    public ActionResult Create(Episode episode)
    {
        return null;
    }

    [HttpPut("{id}")]
    public ActionResult Edit(int id, Episode episode)
    {
        return null;
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        return null;
    }
}
