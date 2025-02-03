using AutoMapper;
using CommonLibrary.DataClasses.EpisodeModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SpreeviewAPI.Controllers.Implementations;
using SpreeviewAPI.MappingProfiles;
using SpreeviewAPI.Services.Interfaces;

namespace SpreeviewTests.ControllerTests;

public class EpisodeControllerTests
{
    Mock<IEpisodeService> _mockEpisodeService;

    EpisodeMappingProfile episodeMappingProfile;
    MapperConfiguration episodeMappingConfig;
    Mapper _mapper;

    EpisodeController episodeController;

    [SetUp]
    public void Setup()
    {
        _mockEpisodeService = new Mock<IEpisodeService>();

        episodeMappingProfile = new EpisodeMappingProfile();
        episodeMappingConfig = new MapperConfiguration(config => config.AddProfile(episodeMappingProfile));
        _mapper = new Mapper(episodeMappingConfig);

        episodeController = new EpisodeController(_mockEpisodeService.Object, _mapper);
    }

    #region GetEpisodeByIds method tests
    [Test]
    public async Task GetEpisodeByIds_CallsServiceMethodOnce()
    {
        // Arrange
        int testSeriesId = 1;
        int testSeasonNum = 2;
        int testEpisodeNum = 3;

        Episode expectedServiceReturn = new Episode() { Id = 1, Title = "TestEpisode" };

        _mockEpisodeService.Setup(mock => mock.FindEpisodeByIds(testSeriesId, testSeasonNum, testEpisodeNum))
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        await episodeController.GetEpisodeByIds(testSeriesId, testSeasonNum, testEpisodeNum);

        // Assert
        _mockEpisodeService.Verify(mock => mock.FindEpisodeByIds(testSeriesId, testSeasonNum, testEpisodeNum), Times.Once());
    }

    [Test]
    public async Task GetEpisodeByIds_OnValidRequest_ReturnsOkObjectResult()
    {
        // Arrange
        int testSeriesId = 1;
        int testSeasonNum = 2;
        int testEpisodeNum = 3;

        Episode expectedServiceReturn = new Episode() { Id = 1, Title = "TestEpisode" };

        _mockEpisodeService.Setup(mock => mock.FindEpisodeByIds(testSeriesId, testSeasonNum, testEpisodeNum))
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await episodeController.GetEpisodeByIds(testSeriesId, testSeasonNum, testEpisodeNum);

        // Assert
        Assert.That(resultObject, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public async Task GetEpisodeByIds_OnValidRequest_ReturnsMappedEpisode()
    {
        // Arrange
        int testSeriesId = 1;
        int testSeasonNum = 2;
        int testEpisodeNum = 3;

        Episode expectedServiceReturn = new Episode() { Id = 1, Title = "TestEpisode" };
        EpisodeGetDTO expectedControllerReturn = new EpisodeGetDTO() { Id = 1, Title = "TestEpisode" };

        _mockEpisodeService.Setup(mock => mock.FindEpisodeByIds(testSeriesId, testSeasonNum, testEpisodeNum))
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await episodeController.GetEpisodeByIds(testSeriesId, testSeasonNum, testEpisodeNum) as OkObjectResult;
        var resultValue = resultObject!.Value as EpisodeGetDTO;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(resultValue!.Id, Is.EqualTo(expectedControllerReturn.Id));
            Assert.That(resultValue.Title, Is.EqualTo(expectedControllerReturn.Title));
        });
    }

    [Test]
    public async Task GetEpisodeByIds_OnInvalidRequest_ReturnsNotFoundObjectResult()
    {
        // Arrange
        int testSeriesId = int.MaxValue;
        int testSeasonNum = int.MaxValue;
        int testEpisodeNum = int.MaxValue;

        Episode? expectedServiceReturn = null;

        _mockEpisodeService.Setup(mock => mock.FindEpisodeByIds(testSeriesId, testSeasonNum, testEpisodeNum))
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await episodeController.GetEpisodeByIds(testSeriesId, testSeasonNum, testEpisodeNum);

        // Assert
        Assert.That(resultObject, Is.TypeOf<NotFoundObjectResult>());
    }
    #endregion
}
