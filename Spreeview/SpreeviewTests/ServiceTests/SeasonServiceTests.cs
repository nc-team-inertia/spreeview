using CommonLibrary.DataClasses.SeasonModel;
using Moq;
using SpreeviewAPI.Services.Implementations;
using SpreeviewAPI.Utilities;

namespace SpreeviewTests.ServiceTests;

internal class SeasonServiceTests
{
    Mock<IRequestManager> _mockRequestManager;
    SeasonService seasonService;

    [SetUp]
    public void Setup()
    {
        _mockRequestManager = new Mock<IRequestManager>();
        seasonService = new SeasonService(_mockRequestManager.Object);
    }

    #region FindSeasonByIds method tests
    [Test]
    public async Task FindSeasonByIds_CallsUtilityMethodOnce()
    {
        // Arrange
        int testSeriesId = 1;
        int testSeasonNum = 2;

        string urlSuffix = $"tv/{testSeriesId}/season/{testSeasonNum}";

        Season expectedUtilityReturn = new Season() { Id = 1, SeasonNumber = 2 };

        _mockRequestManager.Setup(mock => mock.TmdbGetAsync<Season>(urlSuffix))
                           .ReturnsAsync(expectedUtilityReturn);

        // Act
        await seasonService.FindSeasonByIds(testSeriesId, testSeasonNum);

        // Assert
        _mockRequestManager.Verify(mock => mock.TmdbGetAsync<Season>(urlSuffix), Times.Once());
    }

    [Test]
    public async Task FindSeasonByIds_OnValidRequest_ReturnsSeasonType()
    {
        // Arrange
        int testSeriesId = 1;
        int testSeasonNum = 2;

        string urlSuffix = $"tv/{testSeriesId}/season/{testSeasonNum}";

        Season expectedUtilityReturn = new Season() { Id = 1, SeasonNumber = 2 };

        _mockRequestManager.Setup(mock => mock.TmdbGetAsync<Season>(urlSuffix))
                           .ReturnsAsync(expectedUtilityReturn);

        // Act
        var result = await seasonService.FindSeasonByIds(testSeriesId, testSeasonNum);

        // Assert
        Assert.That(result, Is.TypeOf<Season>());
    }

    [Test]
    public async Task FindSeasonByIds_OnInvalidRequest_ReturnsNull()
    {
        // Arrange
        int testSeriesId = int.MaxValue;
        int testSeasonNum = int.MaxValue;

        string urlSuffix = $"tv/{testSeriesId}/season/{testSeasonNum}";

        Season? expectedUtilityReturn = null;

        _mockRequestManager.Setup(mock => mock.TmdbGetAsync<Season>(urlSuffix))
                           .ReturnsAsync(expectedUtilityReturn);

        // Act
        var result = await seasonService.FindSeasonByIds(testSeriesId, testSeasonNum);

        // Assert
        Assert.That(result, Is.Null);
    }
    #endregion
}
