using CommonLibrary.DataClasses.EpisodeModel;
using Moq;
using SpreeviewAPI.Services.Implementations;
using SpreeviewAPI.Utilities;

namespace SpreeviewTests.ControllerTests;

public class EpisodeServiceTests
{
    Mock<IRequestManager> _mockRequestManager;
    EpisodeService episodeService;

    [SetUp]
    public void Setup()
    {
        _mockRequestManager = new Mock<IRequestManager>();
        episodeService = new EpisodeService(_mockRequestManager.Object);
    }

    #region FindEpisodeByIds method tests
    [Test]
    public async Task FindEpisodeByIds_CallsUtilityMethodOnce()
    {
        // Arrange
        int testSeriesId = 1;
        int testSeasonNum = 2;
        int testEpisodeNum = 3;

        string urlSuffix = $"tv/{testSeriesId}/season/{testSeasonNum}/episode/{testEpisodeNum}";

        Episode expectedUtilityReturn = new Episode() { Id = 1, Title = "TestEpisode" };

        _mockRequestManager.Setup(mock => mock.TmdbGetAsync<Episode>(urlSuffix))
                           .ReturnsAsync(expectedUtilityReturn);

        // Act
        await episodeService.FindEpisodeByIds(testSeriesId, testSeasonNum, testEpisodeNum);

        // Assert
        _mockRequestManager.Verify(mock => mock.TmdbGetAsync<Episode>(urlSuffix), Times.Once());
    }

    [Test]
    public async Task FindEpisodeByIds_OnValidRequest_ReturnsEpisodeType()
    {
        // Arrange
        int testSeriesId = 1;
        int testSeasonNum = 2;
        int testEpisodeNum = 3;

        string urlSuffix = $"tv/{testSeriesId}/season/{testSeasonNum}/episode/{testEpisodeNum}";

        Episode expectedUtilityReturn = new Episode() { Id = 1, Title = "TestEpisode" };

        _mockRequestManager.Setup(mock => mock.TmdbGetAsync<Episode>(urlSuffix))
                           .ReturnsAsync(expectedUtilityReturn);

        // Act
        var result = await episodeService.FindEpisodeByIds(testSeriesId, testSeasonNum, testEpisodeNum);

        // Assert
        Assert.That(result, Is.TypeOf<Episode>());
    }

    [Test]
    public async Task FindEpisodeByIds_OnInvalidRequest_ReturnsNull()
    {
        // Arrange
        int testSeriesId = int.MaxValue;
        int testSeasonNum = int.MaxValue;
        int testEpisodeNum = int.MaxValue;

        string urlSuffix = $"tv/{testSeriesId}/season/{testSeasonNum}/episode/{testEpisodeNum}";

        Episode? expectedUtilityReturn = null;

        _mockRequestManager.Setup(mock => mock.TmdbGetAsync<Episode>(urlSuffix))
                           .ReturnsAsync(expectedUtilityReturn);

        // Act
        var result = await episodeService.FindEpisodeByIds(testSeriesId, testSeasonNum, testEpisodeNum);

        // Assert
        Assert.That(result, Is.Null);
    }
    #endregion
}
