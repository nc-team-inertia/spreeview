using AutoMapper;
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
    private readonly IMapper _mapper;

    public EpisodeController(IEpisodeService episodeService, IMapper mapper)
    {
        _episodeService = episodeService;
        _mapper = mapper;
    }

    [HttpGet("{seriesId}/{seasonNumber}/{episodeNumber}")]
    public async Task<ActionResult> GetByIds(int seriesId, int seasonNumber, int episodeNumber)
    {
        Episode? episode = await _episodeService.FindByIds(seriesId, seasonNumber, episodeNumber);

        EpisodeGetDTO episodeGetDto = _mapper.Map<EpisodeGetDTO>(episode);

        if (episode == null)
            return NotFound("There is no episode with the associated values.");

        return Ok(episodeGetDto);
    }
}
