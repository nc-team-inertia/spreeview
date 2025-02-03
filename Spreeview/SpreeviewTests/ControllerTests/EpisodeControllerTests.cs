using AutoMapper;
using Moq;
using SpreeviewAPI.Controllers.Implementations;
using SpreeviewAPI.Services.Interfaces;

namespace SpreeviewTests.ControllerTests;

public class EpisodeControllerTests
{
    Mock<IEpisodeService> _mockEpisodeService;
    Mock<IMapper> _mockMapper;
    EpisodeController episodeController;

    [SetUp]
    public void Setup()
    {
        _mockEpisodeService = new Mock<IEpisodeService>();
        episodeController = new EpisodeController(_mockEpisodeService.Object, _mockMapper.Object);
    }

    [Test]
    public void GetEpisodeById_DoesSomething()
    {
        Assert.Pass();
    }
}
