using CommonLibrary.DataClasses.ReviewModel;
using Moq;
using SpreeviewAPI.Repository.Interfaces;
using SpreeviewAPI.Services.Implementations;

namespace SpreeviewTests.ServiceTests;

public class ReviewServiceTests
{
    Mock<IReviewRepository> _mockRepository;
    ReviewService reviewService;

    [SetUp]
    public void Setup()
    {
        _mockRepository = new Mock<IReviewRepository>();
        reviewService = new ReviewService(_mockRepository.Object);
    }

    #region IndexAllReviews method tests
    [Test]
    public async Task IndexAllReviews_CallsRepositoryMethodOnce()
    {
        // Arrange
        List<Review> expectedRepositoryReturn = new List<Review>() {
            new Review() { Id = 1, UserId = 1 },
            new Review() { Id = 2, UserId = 2 }
        };

        _mockRepository.Setup(mock => mock.IndexAllReviews())
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        await reviewService.IndexAllReviews();

        // Assert
        _mockRepository.Verify(mock => mock.IndexAllReviews(), Times.Once());
    }

    [Test]
    public async Task IndexAllReviews_OnValidRequest_ReturnsReviewListType()
    {
        // Arrange
        List<Review> expectedRepositoryReturn = new List<Review>() {
            new Review() { Id = 1, UserId = 1 },
            new Review() { Id = 2, UserId = 2 }
        };

        _mockRepository.Setup(mock => mock.IndexAllReviews())
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await reviewService.IndexAllReviews();

        // Assert
        Assert.That(result, Is.TypeOf<List<Review>>());
    }

    [Test]
    public async Task IndexAllReviews_OnInvalidRequest_ReturnsEmptyList()
    {
        // Arrange
        List<Review> expectedRepositoryReturn = new List<Review>();

        _mockRepository.Setup(mock => mock.IndexAllReviews())
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await reviewService.IndexAllReviews();

        // Assert
        Assert.That(result, Has.Count.EqualTo(0));
    }
    #endregion

    #region FindReviewById method tests
    [Test]
    public async Task FindReviewById_CallsRepositoryMethodOnce()
    {
        // Arrange
        int testReviewId = 1;

        Review expectedRepositoryReturn = new Review() { Id = 1, UserId = 1 };

        _mockRepository.Setup(mock => mock.FindReviewById(testReviewId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        await reviewService.FindReviewById(testReviewId);

        // Assert
        _mockRepository.Verify(mock => mock.FindReviewById(testReviewId), Times.Once());
    }

    [Test]
    public async Task FindReviewById_OnValidRequest_ReturnsReviewType()
    {
        // Arrange
        int testReviewId = 1;

        Review expectedRepositoryReturn = new Review() { Id = 1, UserId = 1 };

        _mockRepository.Setup(mock => mock.FindReviewById(testReviewId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await reviewService.FindReviewById(testReviewId);

        // Assert
        Assert.That(result, Is.TypeOf<Review>());
    }

    [Test]
    public async Task FindReviewById_OnInvalidRequest_ReturnsNull()
    {
        // Arrange
        int testReviewId = int.MaxValue;

        Review? expectedRepositoryReturn = null;

        _mockRepository.Setup(mock => mock.FindReviewById(testReviewId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await reviewService.FindReviewById(testReviewId);

        // Assert
        Assert.That(result, Is.EqualTo(expectedRepositoryReturn));
    }
    #endregion

    #region FindReviewsByUserId method tests
    [Test]
    public async Task FindReviewsByUserId_CallsRepositoryMethodOnce()
    {
        // Arrange
        int testUserId = 1;

        List<Review> expectedRepositoryReturn = new List<Review>()
        {
            new Review() { Id = 1, UserId = 1 },
            new Review() { Id = 2, UserId = 1 }
        };

        _mockRepository.Setup(mock => mock.FindReviewsByUserId(testUserId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        await reviewService.FindReviewsByUserId(testUserId);

        // Assert
        _mockRepository.Verify(mock => mock.FindReviewsByUserId(testUserId), Times.Once());
    }

    [Test]
    public async Task FindReviewsByUserId_OnValidRequest_ReturnsReviewListType()
    {
        // Arrange
        int testUserId = 1;

        List<Review> expectedRepositoryReturn = new List<Review>()
        {
            new Review() { Id = 1, UserId = 1 },
            new Review() { Id = 2, UserId = 1 }
        };

        _mockRepository.Setup(mock => mock.FindReviewsByUserId(testUserId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await reviewService.FindReviewsByUserId(testUserId);

        // Assert
        Assert.That(result, Is.TypeOf<List<Review>>());
    }

    [Test]
    public async Task FindReviewsByUserId_OnInvalidRequest_ReturnsEmptyList()
    {
        // Arrange
        int testUserId = int.MaxValue;

        List<Review> expectedRepositoryReturn = new List<Review>();

        _mockRepository.Setup(mock => mock.FindReviewsByUserId(testUserId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await reviewService.FindReviewsByUserId(testUserId);

        // Assert
        Assert.That(result, Has.Count.EqualTo(0));
    }
    #endregion

    #region FindReviewsBySeriesId method tests
    [Test]
    public async Task FindReviewsBySeriesId_CallsRepositoryMethodOnce()
    {
        // Arrange
        int testSeriesId = 1;

        List<Review> expectedRepositoryReturn = new List<Review>()
        {
            new Review() { Id = 1, SeriesId = 1 },
            new Review() { Id = 2, SeriesId = 1 }
        };

        _mockRepository.Setup(mock => mock.FindReviewsBySeriesId(testSeriesId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        await reviewService.FindReviewsBySeriesId(testSeriesId);

        // Assert
        _mockRepository.Verify(mock => mock.FindReviewsBySeriesId(testSeriesId), Times.Once());
    }

    [Test]
    public async Task FindReviewsBySeriesId_OnValidRequest_ReturnsReviewListType()
    {
        // Arrange
        int testSeriesId = 1;

        List<Review> expectedRepositoryReturn = new List<Review>()
        {
            new Review() { Id = 1, SeriesId = 1 },
            new Review() { Id = 2, SeriesId = 1 }
        };

        _mockRepository.Setup(mock => mock.FindReviewsBySeriesId(testSeriesId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await reviewService.FindReviewsBySeriesId(testSeriesId);

        // Assert
        Assert.That(result, Is.TypeOf<List<Review>>());
    }

    [Test]
    public async Task FindReviewsBySeriesId_OnInvalidRequest_ReturnsEmptyList()
    {
        // Arrange
        int testSeriesId = int.MaxValue;

        List<Review> expectedRepositoryReturn = new List<Review>();

        _mockRepository.Setup(mock => mock.FindReviewsBySeriesId(testSeriesId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await reviewService.FindReviewsBySeriesId(testSeriesId);

        // Assert
        Assert.That(result, Has.Count.EqualTo(0));
    }
    #endregion

    #region FindReviewsForSeriesSeason method tests
    [Test]
    public async Task FindReviewsForSeriesSeason_CallsRepositoryMethodOnce()
    {
        // Arrange
        int testSeriesId = 1;
        int testSeasonId = 1;

        List<Review> expectedRepositoryReturn = new List<Review>()
        {
            new Review() { Id = 1, SeriesId = 1, SeasonNumber = 1 },
            new Review() { Id = 2, SeriesId = 1, SeasonNumber = 1 }
        };

        _mockRepository.Setup(mock => mock.FindReviewsForSeriesSeason(testSeriesId, testSeasonId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        await reviewService.FindReviewsForSeriesSeason(testSeriesId, testSeasonId);

        // Assert
        _mockRepository.Verify(mock => mock.FindReviewsForSeriesSeason(testSeriesId, testSeasonId), Times.Once());
    }

    [Test]
    public async Task FindReviewsForSeriesSeason_OnValidRequest_ReturnsReviewListType()
    {
        // Arrange
        int testSeriesId = 1;
        int testSeasonId = 1;

        List<Review> expectedRepositoryReturn = new List<Review>()
        {
            new Review() { Id = 1, SeriesId = 1, SeasonNumber = 1 },
            new Review() { Id = 2, SeriesId = 1, SeasonNumber = 1 }
        };

        _mockRepository.Setup(mock => mock.FindReviewsForSeriesSeason(testSeriesId, testSeasonId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await reviewService.FindReviewsForSeriesSeason(testSeriesId, testSeasonId);

        // Assert
        Assert.That(result, Is.TypeOf<List<Review>>());
    }

    [Test]
    public async Task FindReviewsForSeriesSeason_OnInvalidRequest_ReturnsEmptyList()
    {
        // Arrange
        int testSeriesId = int.MaxValue;
        int testSeasonId = int.MaxValue;

        List<Review> expectedRepositoryReturn = new List<Review>();

        _mockRepository.Setup(mock => mock.FindReviewsForSeriesSeason(testSeriesId, testSeasonId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await reviewService.FindReviewsForSeriesSeason(testSeriesId, testSeasonId);

        // Assert
        Assert.That(result, Has.Count.EqualTo(0));
    }
    #endregion

    #region FindReviewsByEpisodeId method tests
    [Test]
    public async Task FindReviewsByEpisodeId_CallsRepositoryMethodOnce()
    {
        // Arrange
        int testEpisodeId = 1;

        List<Review> expectedRepositoryReturn = new List<Review>()
        {
            new Review() { Id = 1, EpisodeId = 1 },
            new Review() { Id = 2, EpisodeId = 1 }
        };

        _mockRepository.Setup(mock => mock.FindReviewsByEpisodeId(testEpisodeId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        await reviewService.FindReviewsByEpisodeId(testEpisodeId);

        // Assert
        _mockRepository.Verify(mock => mock.FindReviewsByEpisodeId(testEpisodeId), Times.Once());
    }

    [Test]
    public async Task FindReviewsByEpisodeId_OnValidRequest_ReturnsReviewListType()
    {
        // Arrange
        int testEpisodeId = 1;

        List<Review> expectedRepositoryReturn = new List<Review>()
        {
            new Review() { Id = 1, EpisodeId = 1 },
            new Review() { Id = 2, EpisodeId = 1 }
        };

        _mockRepository.Setup(mock => mock.FindReviewsByEpisodeId(testEpisodeId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await reviewService.FindReviewsByEpisodeId(testEpisodeId);

        // Assert
        Assert.That(result, Is.TypeOf<List<Review>>());
    }

    [Test]
    public async Task FindReviewsByEpisodeId_OnInvalidRequest_ReturnsEmptyList()
    {
        // Arrange
        int testEpisodeId = int.MaxValue;

        List<Review> expectedRepositoryReturn = new List<Review>();

        _mockRepository.Setup(mock => mock.FindReviewsByEpisodeId(testEpisodeId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await reviewService.FindReviewsByEpisodeId(testEpisodeId);

        // Assert
        Assert.That(result, Has.Count.EqualTo(0));
    }
    #endregion

    #region CreateReview method tests
    [Test]
    public async Task CreateReview_CallsRepositoryMethodOnce()
    {
        // Arrange
        Review inputReview = new Review() { UserId = 1 };

        Review expectedRepositoryReturn = new Review() { Id = 1, UserId = 1 };

        _mockRepository.Setup(mock => mock.CreateReview(inputReview))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        await reviewService.CreateReview(inputReview);

        // Assert
        _mockRepository.Verify(mock => mock.CreateReview(inputReview), Times.Once());
    }

    [Test]
    public async Task CreateReview_OnValidRequest_ReturnsReviewType()
    {
        // Arrange
        Review inputReview = new Review() { UserId = 1 };

        Review expectedRepositoryReturn = new Review() { Id = 1, UserId = 1 };

        _mockRepository.Setup(mock => mock.CreateReview(inputReview))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await reviewService.CreateReview(inputReview);

        // Assert
        Assert.That(result, Is.TypeOf<Review>());
    }

    [Test]
    public async Task CreateReview_OnInvalidRequest_ReturnsNull()
    {
        // Arrange
        int testUserId = int.MaxValue;
        Review inputReview = new Review() { UserId = testUserId };

        Review? expectedRepositoryReturn = null;

        _mockRepository.Setup(mock => mock.CreateReview(inputReview))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await reviewService.CreateReview(inputReview);

        // Assert
        Assert.That(result, Is.EqualTo(expectedRepositoryReturn));
    }
    #endregion

    #region UpdateReview method tests
    [Test]
    public async Task UpdateReview_CallsRepositoryMethodOnce()
    {
        // Arrange
        ReviewUpdateDTO inputReviewDto = new ReviewUpdateDTO() { Id = 1, Contents = "TestContents" };

        Review expectedRepositoryReturn = new Review() { Id = 1, Contents = "TestContents" };

        _mockRepository.Setup(mock => mock.UpdateReview(inputReviewDto))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        await reviewService.UpdateReview(inputReviewDto);

        // Assert
        _mockRepository.Verify(mock => mock.UpdateReview(inputReviewDto), Times.Once());
    }

    [Test]
    public async Task UpdateReview_OnValidRequest_ReturnsReviewType()
    {
        // Arrange
        ReviewUpdateDTO inputReviewDto = new ReviewUpdateDTO() { Id = 1, Contents = "TestContents" };

        Review expectedRepositoryReturn = new Review() { Id = 1, Contents = "TestContents" };

        _mockRepository.Setup(mock => mock.UpdateReview(inputReviewDto))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await reviewService.UpdateReview(inputReviewDto);

        // Assert
        Assert.That(result, Is.TypeOf<Review>());
    }

    [Test]
    public async Task UpdateReview_OnInvalidRequest_ReturnsNull()
    {
        // Arrange
        int testReviewId = int.MaxValue;
        ReviewUpdateDTO inputReviewDto = new ReviewUpdateDTO() { Id = testReviewId, Contents = "TestContents" };

        Review? expectedRepositoryReturn = null;

        _mockRepository.Setup(mock => mock.UpdateReview(inputReviewDto))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await reviewService.UpdateReview(inputReviewDto);

        // Assert
        Assert.That(result, Is.EqualTo(expectedRepositoryReturn));
    }
    #endregion

    #region DeleteReview method tests
    [Test]
    public async Task DeleteReview_CallsRepositoryMethodOnce()
    {
        // Arrange
        int testReviewId = 1;

        bool expectedRepositoryReturn = true;

        _mockRepository.Setup(mock => mock.DeleteReview(testReviewId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        await reviewService.DeleteReview(testReviewId);

        // Assert
        _mockRepository.Verify(mock => mock.DeleteReview(testReviewId), Times.Once());
    }

    [Test]
    public async Task DeleteReview_OnValidRequest_ReturnsTrue()
    {
        // Arrange
        int testReviewId = 1;

        bool expectedRepositoryReturn = true;

        _mockRepository.Setup(mock => mock.DeleteReview(testReviewId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await reviewService.DeleteReview(testReviewId);

        // Assert
        Assert.That(result, Is.EqualTo(expectedRepositoryReturn));
    }

    [Test]
    public async Task DeleteReview_OnInvalidRequest_ReturnsNull()
    {
        // Arrange
        int testReviewId = int.MaxValue;

        bool expectedRepositoryReturn = false;

        _mockRepository.Setup(mock => mock.DeleteReview(testReviewId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await reviewService.DeleteReview(testReviewId);

        // Assert
        Assert.That(result, Is.EqualTo(expectedRepositoryReturn));
    }
    #endregion
}
