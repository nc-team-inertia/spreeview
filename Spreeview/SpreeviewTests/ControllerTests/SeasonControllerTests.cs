using AutoMapper;
using CommonLibrary.DataClasses.SeasonModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SpreeviewAPI.Controllers.Implementations;
using SpreeviewAPI.MappingProfiles;
using SpreeviewAPI.Services.Interfaces;

namespace SpreeviewTests.ControllerTests;

public class SeasonControllerTests
{
    Mock<ISeasonService> _mockSeasonService;

    SeasonMappingProfile seasonMappingProfile;
    MapperConfiguration seasonMappingConfig;
    Mapper _mapper;

    SeasonController seasonController;

    [SetUp]
    public void Setup()
    {
        _mockSeasonService = new Mock<ISeasonService>();

        seasonMappingProfile = new SeasonMappingProfile();
        seasonMappingConfig = new MapperConfiguration(config => config.AddProfile(seasonMappingProfile));
        _mapper = new Mapper(seasonMappingConfig);

        seasonController = new SeasonController(_mockSeasonService.Object, _mapper);
    }

    #region GetSeasonByIds method tests
    [Test]
    public async Task GetSeasonByIds_CallsServiceMethodOnce()
    {
        // Arrange
        int testSeriesId = 1;
        int testSeasonNum = 2;

        Season expectedServiceReturn = new Season() { Id = 1, SeasonNumber = 2 };

        _mockSeasonService.Setup(mock => mock.FindSeasonByIds(testSeriesId, testSeasonNum))
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        await seasonController.GetSeasonByIds(testSeriesId, testSeasonNum);

        // Assert
        _mockSeasonService.Verify(mock => mock.FindSeasonByIds(testSeriesId, testSeasonNum), Times.Once());
    }

    [Test]
    public async Task GetSeasonByIds_OnValidRequest_ReturnsOkObjectResult()
    {
        // Arrange
        int testSeriesId = 1;
        int testSeasonNum = 2;

        Season expectedServiceReturn = new Season() { Id = 1, SeasonNumber = 2 };

        _mockSeasonService.Setup(mock => mock.FindSeasonByIds(testSeriesId, testSeasonNum))
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await seasonController.GetSeasonByIds(testSeriesId, testSeasonNum);

        // Assert
        Assert.That(resultObject, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public async Task GetSeasonByIds_OnValidRequest_ReturnsMappedSeason()
    {
        // Arrange
        int testSeriesId = 1;
        int testSeasonNum = 2;

        Season expectedServiceReturn = new Season() { Id = 1, SeasonNumber = 2 };
        SeasonGetDTO expectedControllerReturn = new SeasonGetDTO() { Id = 1, SeasonNumber = 2 };

        _mockSeasonService.Setup(mock => mock.FindSeasonByIds(testSeriesId, testSeasonNum))
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await seasonController.GetSeasonByIds(testSeriesId, testSeasonNum) as OkObjectResult;
        var resultValue = resultObject!.Value as SeasonGetDTO;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(resultValue!.Id, Is.EqualTo(expectedControllerReturn.Id));
            Assert.That(resultValue.SeasonNumber, Is.EqualTo(expectedControllerReturn.SeasonNumber));
        });
    }

    [Test]
    public async Task GetSeasonByIds_OnInvalidRequest_ReturnsNotFoundObjectResult()
    {
        // Arrange
        int testSeriesId = int.MaxValue;
        int testSeasonNum = int.MaxValue;

        Season? expectedServiceReturn = null;

        _mockSeasonService.Setup(mock => mock.FindSeasonByIds(testSeriesId, testSeasonNum))
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await seasonController.GetSeasonByIds(testSeriesId, testSeasonNum);

        // Assert
        Assert.That(resultObject, Is.TypeOf<NotFoundObjectResult>());
    }
    #endregion
}
