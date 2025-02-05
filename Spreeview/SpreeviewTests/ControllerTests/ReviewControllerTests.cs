using AutoMapper;
using CommonLibrary.DataClasses.ReviewModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SpreeviewAPI.Controllers.Implementations;
using SpreeviewAPI.MappingProfiles;
using SpreeviewAPI.Services.Interfaces;

namespace SpreeviewTests.ControllerTests;

public class ReviewControllerTests
{
    Mock<IReviewService> _mockReviewService;

    ReviewMappingProfile reviewMappingProfile;
    MapperConfiguration reviewMappingConfig;
    Mapper _mapper;

    ReviewController reviewController;

    [SetUp]
    public void Setup()
    {
        _mockReviewService = new Mock<IReviewService>();

        reviewMappingProfile = new ReviewMappingProfile();
        reviewMappingConfig = new MapperConfiguration(config => config.AddProfile(reviewMappingProfile));
        _mapper = new Mapper(reviewMappingConfig);

        reviewController = new ReviewController(_mockReviewService.Object, _mapper);
    }

    #region IndexAllReviews method tests
    [Test]
    public async Task IndexAllReviews_CallsServiceMethodOnce()
    {
        // Arrange
        List<Review> expectedServiceReturn = new List<Review>() {
            new Review() { Id = 1, UserId = 1 },
            new Review() { Id = 2, UserId = 2 }
        };

        _mockReviewService.Setup(mock => mock.IndexAllReviews())
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        await reviewController.IndexAllReviews();

        // Assert
        _mockReviewService.Verify(mock => mock.IndexAllReviews(), Times.Once());
    }

    [Test]
    public async Task IndexAllReviews_OnValidRequest_ReturnsOkObjectResult()
    {
        // Arrange
        List<Review> expectedServiceReturn = new List<Review>() {
            new Review() { Id = 1, UserId = 1 },
            new Review() { Id = 2, UserId = 2 }
        };

        _mockReviewService.Setup(mock => mock.IndexAllReviews())
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await reviewController.IndexAllReviews();

        // Assert
        Assert.That(resultObject, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public async Task IndexAllReviews_OnValidRequest_ReturnsMappedReviewList()
    {
        // Arrange
        List<Review> expectedServiceReturn = new List<Review>() {
            new Review() { Id = 1, UserId = 1 },
            new Review() { Id = 2, UserId = 2 }
        };

        List<ReviewGetDTO> expectedControllerReturn = new List<ReviewGetDTO>() {
            new ReviewGetDTO() { Id = 1, UserId = 1 },
            new ReviewGetDTO() { Id = 2, UserId = 2 }
        };

        _mockReviewService.Setup(mock => mock.IndexAllReviews())
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await reviewController.IndexAllReviews() as OkObjectResult;
        var resultValue = resultObject!.Value as List<ReviewGetDTO>;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(resultValue![0].Id, Is.EqualTo(expectedControllerReturn[0].Id));
            Assert.That(resultValue[0].UserId, Is.EqualTo(expectedControllerReturn[0].UserId));
            Assert.That(resultValue![1].Id, Is.EqualTo(expectedControllerReturn[1].Id));
            Assert.That(resultValue[1].UserId, Is.EqualTo(expectedControllerReturn[1].UserId));
        });
    }

    [Test]
    public async Task IndexAllReviews_OnInvalidRequest_ReturnsNotFoundObjectResult()
    {
        // Arrange
        List<Review>? expectedServiceReturn = null;

        _mockReviewService.Setup(mock => mock.IndexAllReviews())
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await reviewController.IndexAllReviews();

        // Assert
        Assert.That(resultObject, Is.TypeOf<NotFoundObjectResult>());
    }
    #endregion

    #region GetReviewById method tests
    [Test]
    public async Task GetReviewById_CallsServiceMethodOnce()
    {
        // Arrange
        int testReviewId = 1;

        Review expectedServiceReturn = new Review() { Id = 1, UserId = 1 };

        _mockReviewService.Setup(mock => mock.FindReviewById(testReviewId))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        await reviewController.GetReviewById(testReviewId);

        // Assert
        _mockReviewService.Verify(mock => mock.FindReviewById(testReviewId), Times.Once());
    }

    [Test]
    public async Task GetReviewById_OnValidRequest_ReturnsOkObjectResult()
    {
        // Arrange
        int testReviewId = 1;

        Review expectedServiceReturn = new Review() { Id = 1, UserId = 1 };

        _mockReviewService.Setup(mock => mock.FindReviewById(testReviewId))
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await reviewController.GetReviewById(testReviewId);

        // Assert
        Assert.That(resultObject, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public async Task GetReviewById_OnValidRequest_ReturnsMappedReview()
    {
        // Arrange
        int testReviewId = 1;

        Review expectedServiceReturn = new Review() { Id = 1, UserId = 1 };
        ReviewGetDTO expectedControllerReturn = new ReviewGetDTO() { Id = 1, UserId = 1 };

        _mockReviewService.Setup(mock => mock.FindReviewById(testReviewId))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await reviewController.GetReviewById(testReviewId) as OkObjectResult;
        var resultValue = resultObject!.Value as ReviewGetDTO;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(resultValue!.Id, Is.EqualTo(expectedControllerReturn.Id));
            Assert.That(resultValue.UserId, Is.EqualTo(expectedControllerReturn.UserId));
        });
    }

    [Test]
    public async Task GetReviewById_OnInvalidRequest_ReturnsNotFoundObjectResult()
    {
        // Arrange
        int testReviewId = int.MaxValue;

        Review? expectedServiceReturn = null;

        _mockReviewService.Setup(mock => mock.FindReviewById(testReviewId))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await reviewController.GetReviewById(testReviewId);

        // Assert
        Assert.That(resultObject, Is.TypeOf<NotFoundObjectResult>());
    }
    #endregion

    #region GetReviewsByEpisodeId method tests
    [Test]
    public async Task GetReviewsByEpisodeId_CallsServiceMethodOnce()
    {
        // Arrange
        int testEpisodeId = 1;

        List<Review> expectedServiceReturn = new List<Review>() {
            new Review() { Id = 1, UserId = 1, EpisodeId = 1 },
            new Review() { Id = 2, UserId = 2, EpisodeId = 1 }
        };

        _mockReviewService.Setup(mock => mock.FindReviewsByEpisodeId(testEpisodeId))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        await reviewController.GetReviewsByEpisodeId(testEpisodeId);

        // Assert
        _mockReviewService.Verify(mock => mock.FindReviewsByEpisodeId(testEpisodeId), Times.Once());
    }

    [Test]
    public async Task GetReviewsByEpisodeId_OnValidRequest_ReturnsOkObjectResult()
    {
        // Arrange
        int testEpisodeId = 1;

        List<Review> expectedServiceReturn = new List<Review>() {
            new Review() { Id = 1, UserId = 1, EpisodeId = 1 },
            new Review() { Id = 2, UserId = 2, EpisodeId = 1 }
        };

        _mockReviewService.Setup(mock => mock.FindReviewsByEpisodeId(testEpisodeId))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await reviewController.GetReviewsByEpisodeId(testEpisodeId);

        // Assert
        Assert.That(resultObject, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public async Task GetReviewsByEpisodeId_OnValidRequest_ReturnsMappedReviewList()
    {
        // Arrange
        int testEpisodeId = 1;

        List<Review> expectedServiceReturn = new List<Review>() {
            new Review() { Id = 1, UserId = 1, EpisodeId = 1 },
            new Review() { Id = 2, UserId = 2, EpisodeId = 1 }
        };

        List<ReviewGetDTO> expectedControllerReturn = new List<ReviewGetDTO>() {
            new ReviewGetDTO() { Id = 1, UserId = 1, EpisodeId = 1 },
            new ReviewGetDTO() { Id = 2, UserId = 2, EpisodeId = 1 }
        };

        _mockReviewService.Setup(mock => mock.FindReviewsByEpisodeId(testEpisodeId))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await reviewController.GetReviewsByEpisodeId(testEpisodeId) as OkObjectResult;
        var resultValue = resultObject!.Value as List<ReviewGetDTO>;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(resultValue![0].Id, Is.EqualTo(expectedControllerReturn[0].Id));
            Assert.That(resultValue[0].UserId, Is.EqualTo(expectedControllerReturn[0].UserId));
            Assert.That(resultValue[0].EpisodeId, Is.EqualTo(expectedControllerReturn[0].EpisodeId));
            Assert.That(resultValue![1].Id, Is.EqualTo(expectedControllerReturn[1].Id));
            Assert.That(resultValue[1].UserId, Is.EqualTo(expectedControllerReturn[1].UserId));
            Assert.That(resultValue[1].EpisodeId, Is.EqualTo(expectedControllerReturn[1].EpisodeId));
        });
    }

    [Test]
    public async Task GetReviewsByEpisodeId_OnInvalidRequest_ReturnsNotFoundObjectResult()
    {
        // Arrange
        int testEpisodeId = int.MaxValue;

        List<Review>? expectedServiceReturn = null;

        _mockReviewService.Setup(mock => mock.FindReviewsByEpisodeId(testEpisodeId))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await reviewController.GetReviewsByEpisodeId(testEpisodeId);

        // Assert
        Assert.That(resultObject, Is.TypeOf<NotFoundObjectResult>());
    }
    #endregion

    #region GetReviewsByUserId method tests
    [Test]
    public async Task GetReviewsByUserId_CallsServiceMethodOnce()
    {
        // Arrange
        int testUserId = 1;

        List<Review> expectedServiceReturn = new List<Review>() {
            new Review() { Id = 1, UserId = 1, },
            new Review() { Id = 2, UserId = 1, }
        };

        _mockReviewService.Setup(mock => mock.FindReviewsByUserId(testUserId))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        await reviewController.GetReviewsByUserId(testUserId);

        // Assert
        _mockReviewService.Verify(mock => mock.FindReviewsByUserId(testUserId), Times.Once());
    }

    [Test]
    public async Task GetReviewsByUserId_OnValidRequest_ReturnsOkObjectResult()
    {
        // Arrange
        int testUserId = 1;

        List<Review> expectedServiceReturn = new List<Review>() {
            new Review() { Id = 1, UserId = 1 },
            new Review() { Id = 2, UserId = 1 }
        };

        _mockReviewService.Setup(mock => mock.FindReviewsByUserId(testUserId))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await reviewController.GetReviewsByUserId(testUserId);

        // Assert
        Assert.That(resultObject, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public async Task GetReviewsByUserId_OnValidRequest_ReturnsMappedReviewList()
    {
        // Arrange
        int testUserId = 1;

        List<Review> expectedServiceReturn = new List<Review>() {
            new Review() { Id = 1, UserId = 1, },
            new Review() { Id = 2, UserId = 1, }
        };

        List<ReviewGetDTO> expectedControllerReturn = new List<ReviewGetDTO>() {
            new ReviewGetDTO() { Id = 1, UserId = 1 },
            new ReviewGetDTO() { Id = 2, UserId = 1 }
        };

        _mockReviewService.Setup(mock => mock.FindReviewsByUserId(testUserId))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await reviewController.GetReviewsByUserId(testUserId) as OkObjectResult;
        var resultValue = resultObject!.Value as List<ReviewGetDTO>;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(resultValue![0].Id, Is.EqualTo(expectedControllerReturn[0].Id));
            Assert.That(resultValue[0].UserId, Is.EqualTo(expectedControllerReturn[0].UserId));
            Assert.That(resultValue![1].Id, Is.EqualTo(expectedControllerReturn[1].Id));
            Assert.That(resultValue[1].UserId, Is.EqualTo(expectedControllerReturn[1].UserId));
        });
    }

    [Test]
    public async Task GetReviewsByUserId_OnInvalidRequest_ReturnsNotFoundObjectResult()
    {
        // Arrange
        int testUserId = int.MaxValue;

        List<Review>? expectedServiceReturn = null;

        _mockReviewService.Setup(mock => mock.FindReviewsByUserId(testUserId))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await reviewController.GetReviewsByUserId(testUserId);

        // Assert
        Assert.That(resultObject, Is.TypeOf<NotFoundObjectResult>());
    }
    #endregion

    #region GetReviewsBySeriesId method tests
    [Test]
    public async Task GetReviewsBySeriesId_CallsServiceMethodOnce()
    {
        // Arrange
        int testSeriesId = 1;

        List<Review> expectedServiceReturn = new List<Review>() {
            new Review() { Id = 1, UserId = 1, SeriesId = 1 },
            new Review() { Id = 2, UserId = 2, SeriesId = 1 }
        };

        _mockReviewService.Setup(mock => mock.FindReviewsBySeriesId(testSeriesId))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        await reviewController.GetReviewsBySeriesId(testSeriesId);

        // Assert
        _mockReviewService.Verify(mock => mock.FindReviewsBySeriesId(testSeriesId), Times.Once());
    }

    [Test]
    public async Task GetReviewsBySeriesId_OnValidRequest_ReturnsOkObjectResult()
    {
        // Arrange
        int testSeriesId = 1;

        List<Review> expectedServiceReturn = new List<Review>() {
            new Review() { Id = 1, UserId = 1, SeriesId = 1 },
            new Review() { Id = 2, UserId = 2, SeriesId = 1 }
        };

        _mockReviewService.Setup(mock => mock.FindReviewsBySeriesId(testSeriesId))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await reviewController.GetReviewsBySeriesId(testSeriesId);

        // Assert
        Assert.That(resultObject, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public async Task GetReviewsBySeriesId_OnValidRequest_ReturnsMappedReviewList()
    {
        // Arrange
        int testSeriesId = 1;

        List<Review> expectedServiceReturn = new List<Review>() {
            new Review() { Id = 1, UserId = 1, SeriesId = 1 },
            new Review() { Id = 2, UserId = 2, SeriesId = 1 }
        };

        List<ReviewGetDTO> expectedControllerReturn = new List<ReviewGetDTO>() {
            new ReviewGetDTO() { Id = 1, UserId = 1, SeriesId = 1 },
            new ReviewGetDTO() { Id = 2, UserId = 2, SeriesId = 1 }
        };

        _mockReviewService.Setup(mock => mock.FindReviewsBySeriesId(testSeriesId))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await reviewController.GetReviewsBySeriesId(testSeriesId) as OkObjectResult;
        var resultValue = resultObject!.Value as List<ReviewGetDTO>;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(resultValue![0].Id, Is.EqualTo(expectedControllerReturn[0].Id));
            Assert.That(resultValue[0].UserId, Is.EqualTo(expectedControllerReturn[0].UserId));
            Assert.That(resultValue[0].SeriesId, Is.EqualTo(expectedControllerReturn[0].SeriesId));
            Assert.That(resultValue![1].Id, Is.EqualTo(expectedControllerReturn[1].Id));
            Assert.That(resultValue[1].UserId, Is.EqualTo(expectedControllerReturn[1].UserId));
            Assert.That(resultValue[1].SeriesId, Is.EqualTo(expectedControllerReturn[1].SeriesId));
        });
    }

    [Test]
    public async Task GetReviewsBySeriesId_OnInvalidRequest_ReturnsNotFoundObjectResult()
    {
        // Arrange
        int testSeriesId = int.MaxValue;

        List<Review>? expectedServiceReturn = null;

        _mockReviewService.Setup(mock => mock.FindReviewsBySeriesId(testSeriesId))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await reviewController.GetReviewsBySeriesId(testSeriesId);

        // Assert
        Assert.That(resultObject, Is.TypeOf<NotFoundObjectResult>());
    }
    #endregion

    #region PostReview method tests
    [Test]
    public async Task PostReview_CallsServiceMethodOnce()
    {
        // Arrange
        ReviewInsertDTO inputReviewDto = new ReviewInsertDTO() { UserId = 1 };

        Review expectedServiceInput = new Review() { UserId = 1 };
        Review expectedServiceReturn = new Review() { Id = 1, UserId = 1 };

        _mockReviewService.Setup(mock => mock.CreateReview(It.Is<Review>(r =>
            r.UserId == expectedServiceInput.UserId)))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        await reviewController.PostReview(inputReviewDto);

        // Assert
        _mockReviewService.Verify(mock => mock.CreateReview(It.Is<Review>(r =>
            r.UserId == expectedServiceInput.UserId)), Times.Once());
    }

    [Test]
    public async Task PostReview_OnValidRequest_ReturnsOkObjectResult()
    {
        // Arrange
        ReviewInsertDTO inputReviewDto = new ReviewInsertDTO() { UserId = 1 };

        Review expectedServiceInput = new Review() { UserId = 1 };
        Review expectedServiceReturn = new Review() { Id = 1, UserId = 1 };

        _mockReviewService.Setup(mock => mock.CreateReview(It.Is<Review>(r =>
            r.UserId == expectedServiceInput.UserId)))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await reviewController.PostReview(inputReviewDto);

        // Assert
        Assert.That(resultObject, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public async Task PostReview_OnValidRequest_ReturnsMappedReview()
    {
        // Arrange
        ReviewInsertDTO inputReviewDto = new ReviewInsertDTO() { UserId = 1 };

        Review expectedServiceInput = new Review() { UserId = 1 };
        Review expectedServiceReturn = new Review() { Id = 1, UserId = 1 };

        _mockReviewService.Setup(mock => mock.CreateReview(It.Is<Review>(r =>
            r.UserId == expectedServiceInput.UserId)))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await reviewController.PostReview(inputReviewDto) as OkObjectResult;
        var resultValue = resultObject!.Value as ReviewGetDTO;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(resultValue!.Id, Is.EqualTo(expectedServiceReturn.Id));
            Assert.That(resultValue.UserId, Is.EqualTo(expectedServiceReturn.UserId));
        });
    }

    [Test]
    public async Task PostReview_OnInvalidModel_ReturnsBadRequestObjectResult()
    {
        // Arrange
        reviewController.ModelState.AddModelError("Contents", "Required");
        var inputReviewDto = new ReviewInsertDTO() { UserId = 1, SeriesId = 2, EpisodeId = 3, Rating = 4 };

        // Act
        var resultObject = await reviewController.PostReview(inputReviewDto);

        // Assert
        Assert.That(resultObject, Is.TypeOf<BadRequestObjectResult>());
    }
    #endregion

    #region PutReview method tests
    [Test]
    public async Task PutReview_CallsBothServiceMethodsOnce()
    {
        // Arrange
        ReviewUpdateDTO inputReviewDto = new ReviewUpdateDTO() { Id = 1, Contents = "TestContents" };

        int expectedFirstServiceInput = inputReviewDto.Id;
        Review expectedFirstServiceReturn = new Review() { Id = 1, UserId = 1, Contents = "NotTestContents" };

        ReviewUpdateDTO expectedSecondServiceInput = inputReviewDto;
        Review expectedSecondServiceReturn = new Review() { Id = 1, UserId = 1, Contents = "TestContents" };

        _mockReviewService.Setup(mock => mock.FindReviewById(expectedFirstServiceInput))
                          .ReturnsAsync(expectedFirstServiceReturn);

        _mockReviewService.Setup(mock => mock.UpdateReview(It.Is<ReviewUpdateDTO>(r =>
            r.Id == expectedSecondServiceInput.Id &&
            r.Contents == expectedSecondServiceInput.Contents)))
                          .ReturnsAsync(expectedSecondServiceReturn);

        // Act
        await reviewController.PutReview(inputReviewDto);

        // Assert
        _mockReviewService.Verify(mock => mock.FindReviewById(expectedFirstServiceInput), Times.Once());

        _mockReviewService.Verify(mock => mock.UpdateReview(It.Is<ReviewUpdateDTO>(r =>
            r.Id == expectedSecondServiceInput.Id &&
            r.Contents == expectedSecondServiceInput.Contents)), Times.Once());
    }

    [Test]
    public async Task PutReview_OnValidRequest_ReturnsOkObjectResult()
    {
        // Arrange
        ReviewUpdateDTO inputReviewDto = new ReviewUpdateDTO() { Id = 1, Contents = "TestContents" };

        int expectedFirstServiceInput = inputReviewDto.Id;
        Review expectedFirstServiceReturn = new Review() { Id = 1, UserId = 1, Contents = "NotTestContents" };

        ReviewUpdateDTO expectedSecondServiceInput = inputReviewDto;
        Review expectedSecondServiceReturn = new Review() { Id = 1, UserId = 1, Contents = "TestContents" };

        _mockReviewService.Setup(mock => mock.FindReviewById(expectedFirstServiceInput))
                          .ReturnsAsync(expectedFirstServiceReturn);

        _mockReviewService.Setup(mock => mock.UpdateReview(It.Is<ReviewUpdateDTO>(r =>
            r.Id == expectedSecondServiceInput.Id &&
            r.Contents == expectedSecondServiceInput.Contents)))
                          .ReturnsAsync(expectedSecondServiceReturn);

        // Act
        var resultObject = await reviewController.PutReview(inputReviewDto);

        // Assert
        Assert.That(resultObject, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public async Task PutReview_OnValidRequest_ReturnsMappedReview()
    {
        // Arrange
        ReviewUpdateDTO inputReviewDto = new ReviewUpdateDTO() { Id = 1, Contents = "TestContents" };

        int expectedFirstServiceInput = inputReviewDto.Id;
        Review expectedFirstServiceReturn = new Review() { Id = 1, UserId = 1, Contents = "NotTestContents" };

        ReviewUpdateDTO expectedSecondServiceInput = inputReviewDto;
        Review expectedSecondServiceReturn = new Review() { Id = 1, UserId = 1, Contents = "TestContents" };

        _mockReviewService.Setup(mock => mock.FindReviewById(expectedFirstServiceInput))
                          .ReturnsAsync(expectedFirstServiceReturn);

        _mockReviewService.Setup(mock => mock.UpdateReview(It.Is<ReviewUpdateDTO>(r =>
            r.Id == expectedSecondServiceInput.Id &&
            r.Contents == expectedSecondServiceInput.Contents)))
                          .ReturnsAsync(expectedSecondServiceReturn);

        // Act
        var resultObject = await reviewController.PutReview(inputReviewDto) as OkObjectResult;
        var resultValue = resultObject!.Value as ReviewGetDTO;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(resultValue!.Id, Is.EqualTo(expectedSecondServiceReturn.Id));
            Assert.That(resultValue.UserId, Is.EqualTo(expectedSecondServiceReturn.UserId));
            Assert.That(resultValue.Contents, Is.EqualTo(expectedSecondServiceReturn.Contents));
        });
    }

    [Test]
    public async Task PutReview_OnInvalidId_ReturnsNotFoundObjectResult()
    {
        // Arrange
        int testUserId = int.MaxValue;
        ReviewUpdateDTO inputReviewDto = new ReviewUpdateDTO() { Id = testUserId };

        ReviewUpdateDTO expectedServiceInput = new ReviewUpdateDTO() { Id = testUserId };
        Review? expectedServiceReturn = null;

        _mockReviewService.Setup(mock => mock.FindReviewById(expectedServiceInput.Id))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await reviewController.PutReview(inputReviewDto);

        // Assert
        Assert.That(resultObject, Is.TypeOf<NotFoundObjectResult>());
    }

    [Test]
    public async Task PutReview_OnInvalidModel_ReturnsBadRequestObjectResult()
    {
        // Arrange
        reviewController.ModelState.AddModelError("Contents", "Required");
        ReviewUpdateDTO inputReviewDto = new ReviewUpdateDTO() { Id = 1 };

        // Act
        var resultObject = await reviewController.PutReview(inputReviewDto);

        // Assert
        Assert.That(resultObject, Is.TypeOf<BadRequestObjectResult>());
    }
    #endregion

    #region DeleteReview method tests
    [Test]
    public async Task DeleteReview_CallsServiceMethodOnce()
    {
        // Arrange
        int testReviewId = 1;

        bool expectedServiceReturn = true;

        _mockReviewService.Setup(mock => mock.DeleteReview(testReviewId))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        await reviewController.DeleteReview(testReviewId);

        // Assert
        _mockReviewService.Verify(mock => mock.DeleteReview(testReviewId), Times.Once());
    }

    [Test]
    public async Task DeleteReview_OnValidRequest_ReturnsNoContentResult()
    {
        // Arrange
        int testReviewId = 1;

        bool expectedServiceReturn = true;

        _mockReviewService.Setup(mock => mock.DeleteReview(testReviewId))
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        var result = await reviewController.DeleteReview(testReviewId);

        // Assert
        Assert.That(result, Is.TypeOf<NoContentResult>());
    }

    [Test]
    public async Task DeleteReview_OnInvalidRequest_ReturnsNotFoundObjectResult()
    {
        // Arrange
        int testReviewId = int.MaxValue;

        bool expectedServiceReturn = false;

        _mockReviewService.Setup(mock => mock.DeleteReview(testReviewId))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await reviewController.DeleteReview(testReviewId);

        // Assert
        Assert.That(resultObject, Is.TypeOf<NotFoundObjectResult>());
    }
    #endregion
}
