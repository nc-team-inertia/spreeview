using AutoMapper;
using CommonLibrary.DataClasses.SeriesModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SpreeviewAPI.Controllers.Implementations;
using SpreeviewAPI.MappingProfiles;
using SpreeviewAPI.Services.Interfaces;

namespace SpreeviewTests.ControllerTests;

public class SeriesControllerTests
{
    Mock<ISeriesService> _mockSeriesService;

    SeriesMappingProfile seriesMappingProfile;
    MapperConfiguration seriesMappingConfig;
    Mapper _mapper;

    SeriesController seriesController;

    [SetUp]
    public void Setup()
    {
        _mockSeriesService = new Mock<ISeriesService>();

        seriesMappingProfile = new SeriesMappingProfile();
        seriesMappingConfig = new MapperConfiguration(config => config.AddProfile(seriesMappingProfile));
        _mapper = new Mapper(seriesMappingConfig);

        seriesController = new SeriesController(_mockSeriesService.Object, _mapper);
    }

    #region GetSeriesById method tests
    [Test]
    public async Task GetSeriesById_CallsServiceMethodOnce()
    {
        // Arrange
        int testSeriesId = 1;

        Series expectedServiceReturn = new Series() { Id = 1, Name = "TestSeries" };

        _mockSeriesService.Setup(mock => mock.FindSeriesById(testSeriesId))
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        await seriesController.GetSeriesById(testSeriesId);

        // Assert
        _mockSeriesService.Verify(mock => mock.FindSeriesById(testSeriesId), Times.Once());
    }

    [Test]
    public async Task GetSeriesById_OnValidRequest_ReturnsOkObjectResult()
    {
        // Arrange
        int testSeriesId = 1;

        Series expectedServiceReturn = new Series() { Id = 1, Name = "TestSeries" };

        _mockSeriesService.Setup(mock => mock.FindSeriesById(testSeriesId))
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await seriesController.GetSeriesById(testSeriesId);

        // Assert
        Assert.That(resultObject, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public async Task GetSeriesByIds_OnValidRequest_ReturnsMappedSeries()
    {
        // Arrange
        int testSeriesId = 1;

        Series expectedServiceReturn = new Series() { Id = 1, Name = "TestSeries" };
        SeriesGetDTO expectedControllerReturn = new SeriesGetDTO() { Id = 1, Name = "TestSeries" };

        _mockSeriesService.Setup(mock => mock.FindSeriesById(testSeriesId))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await seriesController.GetSeriesById(testSeriesId) as OkObjectResult;
        var resultValue = resultObject!.Value as SeriesGetDTO;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(resultValue!.Id, Is.EqualTo(expectedControllerReturn.Id));
            Assert.That(resultValue.Name, Is.EqualTo(expectedControllerReturn.Name));
        });
    }

    [Test]
    public async Task GetSeriesById_OnInvalidRequest_ReturnsNotFoundObjectResult()
    {
        // Arrange
        int testSeriesId = int.MaxValue;

        Series? expectedServiceReturn = null;

        _mockSeriesService.Setup(mock => mock.FindSeriesById(testSeriesId))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await seriesController.GetSeriesById(testSeriesId);

        // Assert
        Assert.That(resultObject, Is.TypeOf<NotFoundObjectResult>());
    }
    #endregion

    #region IndexPopularSeries method tests
    [Test]
    public async Task IndexPopularSeries_CallsServiceMethodOnce()
    {
        // Arrange
        List<Series> expectedServiceReturn = new List<Series>() {
            new Series() { Id = 1, Name = "TestSeries1" },
            new Series() { Id = 2, Name = "TestSeries2" }
        };

        _mockSeriesService.Setup(mock => mock.IndexPopularSeries())
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        await seriesController.IndexPopularSeries();

        // Assert
        _mockSeriesService.Verify(mock => mock.IndexPopularSeries(), Times.Once());
    }

    [Test]
    public async Task IndexPopularSeries_OnValidRequest_ReturnsOkObjectResult()
    {
        // Arrange
        List<Series> expectedServiceReturn = new List<Series>() {
            new Series() { Id = 1, Name = "TestSeries1" },
            new Series() { Id = 2, Name = "TestSeries2" }
        };

        _mockSeriesService.Setup(mock => mock.IndexPopularSeries())
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await seriesController.IndexPopularSeries();

        // Assert
        Assert.That(resultObject, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public async Task IndexPopularSeries_OnValidRequest_ReturnsMappedSeriesList()
    {
        // Arrange
        List<Series> expectedServiceReturn = new List<Series>() {
            new Series() { Id = 1, Name = "TestSeries1" },
            new Series() { Id = 2, Name = "TestSeries2" }
        };

        List<SeriesGetDTO> expectedControllerReturn = new List<SeriesGetDTO>() {
            new SeriesGetDTO() { Id = 1, Name = "TestSeries1" },
            new SeriesGetDTO() { Id = 2, Name = "TestSeries2" }
        };

        _mockSeriesService.Setup(mock => mock.IndexPopularSeries())
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await seriesController.IndexPopularSeries() as OkObjectResult;
        var resultValue = resultObject!.Value as List<SeriesGetDTO>;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(resultValue![0].Id, Is.EqualTo(expectedControllerReturn[0].Id));
            Assert.That(resultValue[0].Name, Is.EqualTo(expectedControllerReturn[0].Name));
            Assert.That(resultValue![1].Id, Is.EqualTo(expectedControllerReturn[1].Id));
            Assert.That(resultValue[1].Name, Is.EqualTo(expectedControllerReturn[1].Name));
        });
    }

    [Test]
    public async Task IndexPopularSeries_OnInvalidRequest_ReturnsNotFoundObjectResult()
    {
        // Arrange
        List<Series>? expectedServiceReturn = null;

        _mockSeriesService.Setup(mock => mock.IndexPopularSeries())
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await seriesController.IndexPopularSeries();

        // Assert
        Assert.That(resultObject, Is.TypeOf<NotFoundObjectResult>());
    }
    #endregion

    #region IndexTopRatedSeries method tests
    [Test]
    public async Task IndexTopRatedSeries_CallsServiceMethodOnce()
    {
        // Arrange
        List<Series> expectedServiceReturn = new List<Series>() {
            new Series() { Id = 1, Name = "TestSeries1" },
            new Series() { Id = 2, Name = "TestSeries2" }
        };

        _mockSeriesService.Setup(mock => mock.IndexTopRatedSeries())
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        await seriesController.IndexTopRatedSeries();

        // Assert
        _mockSeriesService.Verify(mock => mock.IndexTopRatedSeries(), Times.Once());
    }

    [Test]
    public async Task IndexTopRatedSeries_OnValidRequest_ReturnsOkObjectResult()
    {
        // Arrange
        List<Series> expectedServiceReturn = new List<Series>() {
            new Series() { Id = 1, Name = "TestSeries1" },
            new Series() { Id = 2, Name = "TestSeries2" }
        };

        _mockSeriesService.Setup(mock => mock.IndexTopRatedSeries())
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await seriesController.IndexTopRatedSeries();

        // Assert
        Assert.That(resultObject, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public async Task IndexTopRatedSeries_OnValidRequest_ReturnsMappedSeriesList()
    {
        // Arrange
        List<Series> expectedServiceReturn = new List<Series>() {
            new Series() { Id = 1, Name = "TestSeries1" },
            new Series() { Id = 2, Name = "TestSeries2" }
        };

        List<SeriesGetDTO> expectedControllerReturn = new List<SeriesGetDTO>() {
            new SeriesGetDTO() { Id = 1, Name = "TestSeries1" },
            new SeriesGetDTO() { Id = 2, Name = "TestSeries2" }
        };

        _mockSeriesService.Setup(mock => mock.IndexTopRatedSeries())
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await seriesController.IndexTopRatedSeries() as OkObjectResult;
        var resultValue = resultObject!.Value as List<SeriesGetDTO>;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(resultValue![0].Id, Is.EqualTo(expectedControllerReturn[0].Id));
            Assert.That(resultValue[0].Name, Is.EqualTo(expectedControllerReturn[0].Name));
            Assert.That(resultValue![1].Id, Is.EqualTo(expectedControllerReturn[1].Id));
            Assert.That(resultValue[1].Name, Is.EqualTo(expectedControllerReturn[1].Name));
        });
    }

    [Test]
    public async Task IndexTopRatedSeries_OnInvalidRequest_ReturnsNotFoundObjectResult()
    {
        // Arrange
        List<Series>? expectedServiceReturn = null;

        _mockSeriesService.Setup(mock => mock.IndexTopRatedSeries())
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await seriesController.IndexTopRatedSeries();

        // Assert
        Assert.That(resultObject, Is.TypeOf<NotFoundObjectResult>());
    }
    #endregion

    #region GetSeriesByKeywords method tests
    [Test]
    public async Task GetSeriesByKeywords_CallsServiceMethodOnce()
    {
        // Arrange
        string testQuery = "test";

        List<Series>? expectedServiceReturn = new List<Series>() {
            new Series() { Id = 1, Name = "TestSeries1" },
            new Series() { Id = 2, Name = "TestSeries2" },
        };

        _mockSeriesService.Setup(mock => mock.FindSeriesByKeywords(testQuery))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        await seriesController.GetSeriesByKeywords(testQuery);

        // Assert
        _mockSeriesService.Verify(mock => mock.FindSeriesByKeywords(testQuery), Times.Once());
    }

    [Test]
    public async Task GetSeriesByKeywords_OnValidRequest_ReturnsOkObjectResult()
    {
        // Arrange
        string testQuery = "test";

        List<Series>? expectedServiceReturn = new List<Series>() {
            new Series() { Id = 1, Name = "TestSeries1" },
            new Series() { Id = 2, Name = "TestSeries2" },
        };

        _mockSeriesService.Setup(mock => mock.FindSeriesByKeywords(testQuery))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await seriesController.GetSeriesByKeywords(testQuery);

        // Assert
        Assert.That(resultObject, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public async Task GetSeriesByKeywords_OnValidRequest_ReturnsMappedSeriesList()
    {
        // Arrange
        string testQuery = "test";

        List<Series>? expectedServiceReturn = new List<Series>() {
            new Series() { Id = 1, Name = "TestSeries1" },
            new Series() { Id = 2, Name = "TestSeries2" },
        };

        List<SeriesGetDTO>? expectedControllerReturn = new List<SeriesGetDTO>() {
            new SeriesGetDTO() { Id = 1, Name = "TestSeries1" },
            new SeriesGetDTO() { Id = 2, Name = "TestSeries2" },
        };

        _mockSeriesService.Setup(mock => mock.FindSeriesByKeywords(testQuery))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await seriesController.GetSeriesByKeywords(testQuery) as OkObjectResult;
        var resultValue = resultObject!.Value as List<SeriesGetDTO>;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(resultValue![0].Id, Is.EqualTo(expectedControllerReturn[0].Id));
            Assert.That(resultValue[0].Name, Is.EqualTo(expectedControllerReturn[0].Name));
            Assert.That(resultValue![1].Id, Is.EqualTo(expectedControllerReturn[1].Id));
            Assert.That(resultValue[1].Name, Is.EqualTo(expectedControllerReturn[1].Name));
        });
    }

    [Test]
    public async Task GetSeriesByKeywords_OnNoMatches_ReturnsNotFoundObjectResult()
    {
        // Arrange
        string testQuery = "Test Fail";

        List<Series>? expectedServiceReturn = null;

        _mockSeriesService.Setup(mock => mock.FindSeriesByKeywords(testQuery))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await seriesController.GetSeriesByKeywords(testQuery);

        // Assert
        Assert.That(resultObject, Is.TypeOf<NotFoundObjectResult>());
    }

    [Test]
    public async Task GetSeriesByKeywords_OnEmptyInput_ReturnsBadRequestObjectResult()
    {
        // Arrange
        string testQuery = "";

        // Act
        var resultObject = await seriesController.GetSeriesByKeywords(testQuery);

        // Assert
        Assert.That(resultObject, Is.TypeOf<BadRequestObjectResult>());
    }
    #endregion

    #region GetRecommendationsById method tests
    [Test]
    public async Task GetRecommendationsById_CallsServiceMethodOnce()
    {
        // Arrange
        int testSeriesId = 1;

        List<Series> expectedServiceReturn = new List<Series>() {
            new Series() { Id = 1, Name = "TestSeries1" },
            new Series() { Id = 2, Name = "TestSeries2" }
        };

        _mockSeriesService.Setup(mock => mock.FindRecommendationsById(testSeriesId))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        await seriesController.GetRecommendationsById(testSeriesId);

        // Assert
        _mockSeriesService.Verify(mock => mock.FindRecommendationsById(testSeriesId), Times.Once());
    }

    [Test]
    public async Task GetRecommendationsById_OnValidRequest_ReturnsOkObjectResult()
    {
        // Arrange
        int testSeriesId = 1;

        List<Series> expectedServiceReturn = new List<Series>() {
            new Series() { Id = 1, Name = "TestSeries1" },
            new Series() { Id = 2, Name = "TestSeries2" }
        };

        _mockSeriesService.Setup(mock => mock.FindRecommendationsById(testSeriesId))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await seriesController.GetRecommendationsById(testSeriesId);

        // Assert
        Assert.That(resultObject, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public async Task GetRecommendationsById_OnValidRequest_ReturnsMappedSeriesList()
    {
        // Arrange
        int testSeriesId = 1;

        List<Series> expectedServiceReturn = new List<Series>() {
            new Series() { Id = 1, Name = "TestSeries1" },
            new Series() { Id = 2, Name = "TestSeries2" }
        };

        List<SeriesGetDTO> expectedControllerReturn = new List<SeriesGetDTO>() {
            new SeriesGetDTO() { Id = 1, Name = "TestSeries1" },
            new SeriesGetDTO() { Id = 2, Name = "TestSeries2" }
        };

        _mockSeriesService.Setup(mock => mock.FindRecommendationsById(testSeriesId))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await seriesController.GetRecommendationsById(testSeriesId) as OkObjectResult;
        var resultValue = resultObject!.Value as List<SeriesGetDTO>;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(resultValue![0].Id, Is.EqualTo(expectedControllerReturn[0].Id));
            Assert.That(resultValue[0].Name, Is.EqualTo(expectedControllerReturn[0].Name));
            Assert.That(resultValue![1].Id, Is.EqualTo(expectedControllerReturn[1].Id));
            Assert.That(resultValue[1].Name, Is.EqualTo(expectedControllerReturn[1].Name));
        });
    }

    [Test]
    public async Task GetRecommendationsById_OnInvalidRequest_ReturnsNotFoundObjectResult()
    {
        // Arrange
        int testSeriesId = int.MaxValue;

        List<Series>? expectedServiceReturn = null;

        _mockSeriesService.Setup(mock => mock.FindRecommendationsById(testSeriesId))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await seriesController.GetRecommendationsById(testSeriesId);

        // Assert
        Assert.That(resultObject, Is.TypeOf<NotFoundObjectResult>());
    }
    #endregion
}
