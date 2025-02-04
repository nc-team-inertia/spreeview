using CommonLibrary.DataClasses.SeriesModel;
using Moq;
using SpreeviewAPI.Services.Implementations;
using SpreeviewAPI.Utilities;
using SpreeviewAPI.Wrappers;

namespace SpreeviewTests.ServiceTests;

public class SeriesServiceTests
{
    Mock<IRequestManager> _mockRequestManager;
    SeriesService seriesService;

    [SetUp]
    public void Setup()
    {
        _mockRequestManager = new Mock<IRequestManager>();
        seriesService = new SeriesService(_mockRequestManager.Object);
    }

    #region FindSeriesById method tests
    [Test]
    public async Task FindSeriesById_CallsUtilityMethodOnce()
    {
        // Arrange
        int testSeriesId = 1;

        string urlSuffix = $"tv/{testSeriesId}";

        Series expectedUtilityReturn = new Series() { Id = 1, Name = "TestSeries" };

        _mockRequestManager.Setup(mock => mock.TmdbGetAsync<Series>(urlSuffix))
                           .ReturnsAsync(expectedUtilityReturn);

        // Act
        await seriesService.FindSeriesById(testSeriesId);

        // Assert
        _mockRequestManager.Verify(mock => mock.TmdbGetAsync<Series>(urlSuffix), Times.Once());
    }

    [Test]
    public async Task FindSeriesByIds_OnValidRequest_ReturnsSeriesType()
    {
        // Arrange
        int testSeriesId = 1;

        string urlSuffix = $"tv/{testSeriesId}";

        Series expectedUtilityReturn = new Series() { Id = 1, Name = "TestSeries" };

        _mockRequestManager.Setup(mock => mock.TmdbGetAsync<Series>(urlSuffix))
                           .ReturnsAsync(expectedUtilityReturn);

        // Act
        var result = await seriesService.FindSeriesById(testSeriesId);

        // Assert
        Assert.That(result, Is.TypeOf<Series>());
    }

    [Test]
    public async Task FindSeriesById_OnInvalidRequest_ReturnsNull()
    {
        // Arrange
        int testSeriesId = int.MaxValue;

        string urlSuffix = $"tv/{testSeriesId}";

        Series? expectedUtilityReturn = null;

        _mockRequestManager.Setup(mock => mock.TmdbGetAsync<Series>(urlSuffix))
                           .ReturnsAsync(expectedUtilityReturn);

        // Act
        var result = await seriesService.FindSeriesById(testSeriesId);

        // Assert
        Assert.That(result, Is.Null);
    }
    #endregion

    #region IndexPopularSeries method tests
    [Test]
    public async Task IndexPopularSeries_CallsUtilityMethodOnce()
    {
        // Arrange
        string urlSuffix = $"trending/tv/week";

        List<Series> expectedUtilityResults = new List<Series>()
        {
            new Series() { Id = 1, Name = "TestSeries1" },
            new Series() { Id = 2, Name = "TestSeries2" }
        };

        SeriesResponse expectedUtilityResponse = new SeriesResponse() { Results = expectedUtilityResults };

        _mockRequestManager.Setup(mock => mock.TmdbGetAsync<SeriesResponse>(urlSuffix))
                           .ReturnsAsync(expectedUtilityResponse);

        // Act
        await seriesService.IndexPopularSeries();

        // Assert
        _mockRequestManager.Verify(mock => mock.TmdbGetAsync<SeriesResponse>(urlSuffix), Times.Once());
    }

    [Test]
    public async Task IndexPopularSeries_OnValidRequest_ReturnsSeriesListType()
    {
        string urlSuffix = $"trending/tv/week";

        List<Series> expectedUtilityResults = new List<Series>()
        {
            new Series() { Id = 1, Name = "TestSeries1" },
            new Series() { Id = 2, Name = "TestSeries2" }
        };

        SeriesResponse expectedUtilityResponse = new SeriesResponse() { Results = expectedUtilityResults };

        _mockRequestManager.Setup(mock => mock.TmdbGetAsync<SeriesResponse>(urlSuffix))
                           .ReturnsAsync(expectedUtilityResponse);

        // Act
        var result = await seriesService.IndexPopularSeries();

        // Assert
        Assert.That(result, Is.TypeOf<List<Series>>());
    }

    [Test]
    public async Task IndexPopularSeries_OnInvalidRequest_ReturnsNull()
    {
        // Arrange
        string urlSuffix = $"trending/tv/week";

        SeriesResponse? expectedUtilityResponse = null;

        _mockRequestManager.Setup(mock => mock.TmdbGetAsync<SeriesResponse>(urlSuffix))
                           .ReturnsAsync(expectedUtilityResponse);

        // Act
        var result = await seriesService.IndexPopularSeries();

        // Assert
        Assert.That(result, Is.Null);
    }
    #endregion

    #region IndexTopRatedSeries method tests
    [Test]
    public async Task IndexTopRatedSeries_CallsUtilityMethodOnce()
    {
        // Arrange
        string urlSuffix = $"tv/top_rated";

        List<Series> expectedUtilityResults = new List<Series>()
        {
            new Series() { Id = 1, Name = "TestSeries1" },
            new Series() { Id = 2, Name = "TestSeries2" }
        };

        SeriesResponse expectedUtilityResponse = new SeriesResponse() { Results = expectedUtilityResults };

        _mockRequestManager.Setup(mock => mock.TmdbGetAsync<SeriesResponse>(urlSuffix))
                           .ReturnsAsync(expectedUtilityResponse);

        // Act
        await seriesService.IndexTopRatedSeries();

        // Assert
        _mockRequestManager.Verify(mock => mock.TmdbGetAsync<SeriesResponse>(urlSuffix), Times.Once());
    }

    [Test]
    public async Task IndexTopRatedSeries_OnValidRequest_ReturnsSeriesListType()
    {
        string urlSuffix = $"tv/top_rated";

        List<Series> expectedUtilityResults = new List<Series>()
        {
            new Series() { Id = 1, Name = "TestSeries1" },
            new Series() { Id = 2, Name = "TestSeries2" }
        };

        SeriesResponse expectedUtilityResponse = new SeriesResponse() { Results = expectedUtilityResults };

        _mockRequestManager.Setup(mock => mock.TmdbGetAsync<SeriesResponse>(urlSuffix))
                           .ReturnsAsync(expectedUtilityResponse);

        // Act
        var result = await seriesService.IndexTopRatedSeries();

        // Assert
        Assert.That(result, Is.TypeOf<List<Series>>());
    }

    [Test]
    public async Task IndexTopRatedSeries_OnInvalidRequest_ReturnsNull()
    {
        // Arrange
        string urlSuffix = $"tv/top_rated";

        SeriesResponse? expectedUtilityResponse = null;

        _mockRequestManager.Setup(mock => mock.TmdbGetAsync<SeriesResponse>(urlSuffix))
                           .ReturnsAsync(expectedUtilityResponse);

        // Act
        var result = await seriesService.IndexTopRatedSeries();

        // Assert
        Assert.That(result, Is.Null);
    }
    #endregion

    #region FindSeriesByKeywords method tests
    [Test]
    public async Task FindSeriesByKeywords_CallsUtilityMethodOnce()
    {
        // Arrange
        string testQuery = "test";

        string urlSuffix = $"search/tv?query={testQuery}";

        List<Series> expectedUtilityResults = new List<Series>()
        {
            new Series() { Id = 1, Name = "TestSeries1" },
            new Series() { Id = 2, Name = "TestSeries2" }
        };

        SeriesResponse expectedUtilityResponse = new SeriesResponse() { Results = expectedUtilityResults };

        _mockRequestManager.Setup(mock => mock.TmdbGetAsync<SeriesResponse>(urlSuffix))
                           .ReturnsAsync(expectedUtilityResponse);

        // Act
        await seriesService.FindSeriesByKeywords(testQuery);

        // Assert
        _mockRequestManager.Verify(mock => mock.TmdbGetAsync<SeriesResponse>(urlSuffix), Times.Once());
    }

    [Test]
    public async Task FindSeriesByKeywords_OnValidRequest_ReturnsSeriesListType()
    {
        // Arrange
        string testQuery = "test";

        string urlSuffix = $"search/tv?query={testQuery}";

        List<Series> expectedUtilityResults = new List<Series>()
        {
            new Series() { Id = 1, Name = "TestSeries1" },
            new Series() { Id = 2, Name = "TestSeries2" }
        };

        SeriesResponse expectedUtilityResponse = new SeriesResponse() { Results = expectedUtilityResults };

        _mockRequestManager.Setup(mock => mock.TmdbGetAsync<SeriesResponse>(urlSuffix))
                           .ReturnsAsync(expectedUtilityResponse);

        // Act
        var result = await seriesService.FindSeriesByKeywords(testQuery);

        // Assert
        Assert.That(result, Is.TypeOf<List<Series>>());
    }

    [Test]
    public async Task FindSeriesByKeywords_OnInvalidRequest_ReturnsNull()
    {
        // Arrange
        string testQuery = "test";

        string urlSuffix = $"search/tv?query={testQuery}";

        SeriesResponse? expectedUtilityResponse = null;

        _mockRequestManager.Setup(mock => mock.TmdbGetAsync<SeriesResponse>(urlSuffix))
                           .ReturnsAsync(expectedUtilityResponse);

        // Act
        var result = await seriesService.FindSeriesByKeywords(testQuery);

        // Assert
        Assert.That(result, Is.Null);
    }
    #endregion

    #region FindRecommendationsById method tests
    [Test]
    public async Task FindRecommendationsById_CallsUtilityMethodOnce()
    {
        // Arrange
        int testSeriesId = 1;

        string urlSuffix = $"tv/{testSeriesId}/recommendations";

        List<Series> expectedUtilityResults = new List<Series>()
        {
            new Series() { Id = 1, Name = "TestSeries1" },
            new Series() { Id = 2, Name = "TestSeries2" }
        };

        SeriesResponse expectedUtilityResponse = new SeriesResponse() { Results = expectedUtilityResults };

        _mockRequestManager.Setup(mock => mock.TmdbGetAsync<SeriesResponse>(urlSuffix))
                           .ReturnsAsync(expectedUtilityResponse);

        // Act
        await seriesService.FindRecommendationsById(testSeriesId);

        // Assert
        _mockRequestManager.Verify(mock => mock.TmdbGetAsync<SeriesResponse>(urlSuffix), Times.Once());
    }

    [Test]
    public async Task FindRecommendationsById_OnValidRequest_ReturnsSeriesListType()
    {
        // Arrange
        int testSeriesId = 1;

        string urlSuffix = $"tv/{testSeriesId}/recommendations";

        List<Series> expectedUtilityResults = new List<Series>()
        {
            new Series() { Id = 1, Name = "TestSeries1" },
            new Series() { Id = 2, Name = "TestSeries2" }
        };

        SeriesResponse expectedUtilityResponse = new SeriesResponse() { Results = expectedUtilityResults };

        _mockRequestManager.Setup(mock => mock.TmdbGetAsync<SeriesResponse>(urlSuffix))
                           .ReturnsAsync(expectedUtilityResponse);

        // Act
        var result = await seriesService.FindRecommendationsById(testSeriesId);

        // Assert
        Assert.That(result, Is.TypeOf<List<Series>>());
    }

    [Test]
    public async Task FindRecommendationsById_OnInvalidRequest_ReturnsNull()
    {
        // Arrange
        int testSeriesId = int.MaxValue;

        string urlSuffix = $"tv/{testSeriesId}/recommendations";

        SeriesResponse? expectedUtilityResponse = null;

        _mockRequestManager.Setup(mock => mock.TmdbGetAsync<SeriesResponse>(urlSuffix))
                           .ReturnsAsync(expectedUtilityResponse);

        // Act
        var result = await seriesService.FindRecommendationsById(testSeriesId);

        // Assert
        Assert.That(result, Is.Null);
    }
    #endregion
}
