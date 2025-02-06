using AutoMapper;
using CommonLibrary.DataClasses.CommentModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SpreeviewAPI.Controllers.Implementations;
using SpreeviewAPI.MappingProfiles;
using SpreeviewAPI.Models;
using SpreeviewAPI.Services.Implementations;

namespace SpreeviewTests.ControllerTests;

internal class CommentControllerTests
{
    Mock<ICommentService> _mockCommentService;

    CommentMappingProfile commentMappingProfile;
    MapperConfiguration commentMappingConfig;
    Mapper _mapper;

    Mock<IUserStore<ApplicationUser>> _mockUserStore;
    Mock<UserManager<ApplicationUser>> _mockUserManager;

    CommentController commentController;

    [SetUp]
    public void Setup()
    {
        _mockCommentService = new Mock<ICommentService>();

        commentMappingProfile = new CommentMappingProfile();
        commentMappingConfig = new MapperConfiguration(config => config.AddProfile(commentMappingProfile));
        _mapper = new Mapper(commentMappingConfig);

        _mockUserStore = new Mock<IUserStore<ApplicationUser>>();
        _mockUserManager = new Mock<UserManager<ApplicationUser>>(_mockUserStore.Object, null!, null!, null!, null!, null!, null!, null!, null!);

        commentController = new CommentController(_mockCommentService.Object, _mapper, _mockUserManager.Object);

        var applicationUser = new ApplicationUser
        {
            Id = 1,
            UserName = "testUser",
            Email = "test@email.com"
        };

        _mockUserManager.Setup(mock => mock.GetUserAsync(It.IsAny<System.Security.Claims.ClaimsPrincipal>()))
                        .ReturnsAsync(applicationUser);
    }

    #region IndexAllComments method tests
    [Test]
    public async Task IndexAllComments_CallsServiceMethodOnce()
    {
        // Arrange
        List<Comment> expectedServiceReturn = new List<Comment>() {
            new Comment() { Id = 1, UserId = 1 },
            new Comment() { Id = 2, UserId = 2 }
        };

        _mockCommentService.Setup(mock => mock.IndexAllComments())
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        await commentController.IndexAllComments();

        // Assert
        _mockCommentService.Verify(mock => mock.IndexAllComments(), Times.Once());
    }

    [Test]
    public async Task IndexAllComment_OnValidRequest_ReturnsOkObjectResult()
    {
        // Arrange
        List<Comment> expectedServiceReturn = new List<Comment>() {
            new Comment() { Id = 1, UserId = 1 },
            new Comment() { Id = 2, UserId = 2 }
        };

        _mockCommentService.Setup(mock => mock.IndexAllComments())
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await commentController.IndexAllComments();

        // Assert
        Assert.That(resultObject, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public async Task IndexAllComments_OnValidRequest_ReturnsMappedCommentList()
    {
        // Arrange
        List<Comment> expectedServiceReturn = new List<Comment>() {
            new Comment() { Id = 1, UserId = 1 },
            new Comment() { Id = 2, UserId = 2 }
        };

        List<CommentGetDTO> expectedControllerReturn = new List<CommentGetDTO>() {
            new CommentGetDTO() { Id = 1, UserId = 1 },
            new CommentGetDTO() { Id = 2, UserId = 2 }
        };

        _mockCommentService.Setup(mock => mock.IndexAllComments())
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await commentController.IndexAllComments() as OkObjectResult;
        var resultValue = resultObject!.Value as List<CommentGetDTO>;

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
    public async Task IndexAllComments_OnInvalidRequest_ReturnsNotFoundObjectResult()
    {
        // Arrange
        List<Comment>? expectedServiceReturn = null;

        _mockCommentService.Setup(mock => mock.IndexAllComments())
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await commentController.IndexAllComments();

        // Assert
        Assert.That(resultObject, Is.TypeOf<NotFoundObjectResult>());
    }
    #endregion

    #region GetCommentById method tests
    [Test]
    public async Task GetCommentById_CallsServiceMethodOnce()
    {
        // Arrange
        int testCommentId = 1;

        Comment expectedServiceReturn = new Comment() { Id = 1, UserId = 1 };

        _mockCommentService.Setup(mock => mock.FindCommentById(testCommentId))
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        await commentController.GetCommentById(testCommentId);

        // Assert
        _mockCommentService.Verify(mock => mock.FindCommentById(testCommentId), Times.Once());
    }

    [Test]
    public async Task GetCommentById_OnValidRequest_ReturnsOkObjectResult()
    {
        // Arrange
        int testCommentId = 1;

        Comment expectedServiceReturn = new Comment() { Id = 1, UserId = 1 };

        _mockCommentService.Setup(mock => mock.FindCommentById(testCommentId))
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await commentController.GetCommentById(testCommentId);

        // Assert
        Assert.That(resultObject, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public async Task GetCommentById_OnValidRequest_ReturnsMappedComment()
    {
        // Arrange
        int testCommentId = 1;

        Comment expectedServiceReturn = new Comment() { Id = 1, UserId = 1 };
        CommentGetDTO expectedControllerReturn = new CommentGetDTO() { Id = 1, UserId = 1 };

        _mockCommentService.Setup(mock => mock.FindCommentById(testCommentId))
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await commentController.GetCommentById(testCommentId) as OkObjectResult;
        var resultValue = resultObject!.Value as CommentGetDTO;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(resultValue!.Id, Is.EqualTo(expectedControllerReturn.Id));
            Assert.That(resultValue.UserId, Is.EqualTo(expectedControllerReturn.UserId));
        });
    }

    [Test]
    public async Task GetCommentById_OnInvalidRequest_ReturnsNotFoundObjectResult()
    {
        // Arrange
        int testCommentId = int.MaxValue;

        Comment? expectedServiceReturn = null;

        _mockCommentService.Setup(mock => mock.FindCommentById(testCommentId))
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await commentController.GetCommentById(testCommentId);

        // Assert
        Assert.That(resultObject, Is.TypeOf<NotFoundObjectResult>());
    }
    #endregion

    #region GetCommentsByUserId method tests
    [Test]
    public async Task GetCommentsByUserId_CallsServiceMethodOnce()
    {
        // Arrange
        int testUserId = 1;

        List<Comment> expectedServiceReturn = new List<Comment>() {
            new Comment() { Id = 1, UserId = 1, },
            new Comment() { Id = 2, UserId = 1, }
        };

        _mockCommentService.Setup(mock => mock.FindCommentsByUserId(testUserId))
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        await commentController.GetCommentsByUserId(testUserId);

        // Assert
        _mockCommentService.Verify(mock => mock.FindCommentsByUserId(testUserId), Times.Once());
    }

    [Test]
    public async Task GetCommentsByUserId_OnValidRequest_ReturnsOkObjectResult()
    {
        // Arrange
        int testUserId = 1;

        List<Comment> expectedServiceReturn = new List<Comment>() {
            new Comment() { Id = 1, UserId = 1 },
            new Comment() { Id = 2, UserId = 1 }
        };

        _mockCommentService.Setup(mock => mock.FindCommentsByUserId(testUserId))
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await commentController.GetCommentsByUserId(testUserId);

        // Assert
        Assert.That(resultObject, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public async Task GetCommentsByUserId_OnValidRequest_ReturnsMappedCommentList()
    {
        // Arrange
        int testUserId = 1;

        List<Comment> expectedServiceReturn = new List<Comment>() {
            new Comment() { Id = 1, UserId = 1, },
            new Comment() { Id = 2, UserId = 1, }
        };

        List<CommentGetDTO> expectedControllerReturn = new List<CommentGetDTO>() {
            new CommentGetDTO() { Id = 1, UserId = 1 },
            new CommentGetDTO() { Id = 2, UserId = 1 }
        };

        _mockCommentService.Setup(mock => mock.FindCommentsByUserId(testUserId))
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await commentController.GetCommentsByUserId(testUserId) as OkObjectResult;
        var resultValue = resultObject!.Value as List<CommentGetDTO>;

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
    public async Task GetCommentsByUserId_OnInvalidRequest_ReturnsNotFoundObjectResult()
    {
        // Arrange
        int testUserId = int.MaxValue;

        List<Comment>? expectedServiceReturn = null;

        _mockCommentService.Setup(mock => mock.FindCommentsByUserId(testUserId))
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await commentController.GetCommentsByUserId(testUserId);

        // Assert
        Assert.That(resultObject, Is.TypeOf<NotFoundObjectResult>());
    }
    #endregion

    #region GetCommentsByReviewId method tests
    [Test]
    public async Task GetCommentsByReviewId_CallsServiceMethodOnce()
    {
        // Arrange
        int testReviewId = 1;

        List<Comment> expectedServiceReturn = new List<Comment>() {
            new Comment() { Id = 1, UserId = 1, ReviewId = 1 },
            new Comment() { Id = 2, UserId = 2, ReviewId = 1 }
        };

        _mockCommentService.Setup(mock => mock.FindCommentsByReviewId(testReviewId))
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        await commentController.GetCommentsByReviewId(testReviewId);

        // Assert
        _mockCommentService.Verify(mock => mock.FindCommentsByReviewId(testReviewId), Times.Once());
    }

    [Test]
    public async Task GetCommentsByReviewId_OnValidRequest_ReturnsOkObjectResult()
    {
        // Arrange
        int testReviewId = 1;

        List<Comment> expectedServiceReturn = new List<Comment>() {
            new Comment() { Id = 1, UserId = 1, ReviewId = 1 },
            new Comment() { Id = 2, UserId = 2, ReviewId = 1 }
        };

        _mockCommentService.Setup(mock => mock.FindCommentsByReviewId(testReviewId))
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await commentController.GetCommentsByReviewId(testReviewId);

        // Assert
        Assert.That(resultObject, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public async Task GetCommentsByReviewId_OnValidRequest_ReturnsMappedCommentList()
    {
        // Arrange
        int testReviewId = 1;

        List<Comment> expectedServiceReturn = new List<Comment>() {
            new Comment() { Id = 1, UserId = 1, ReviewId = 1 },
            new Comment() { Id = 2, UserId = 2, ReviewId = 1 }
        };

        List<CommentGetDTO> expectedControllerReturn = new List<CommentGetDTO>() {
            new CommentGetDTO() { Id = 1, UserId = 1 },
            new CommentGetDTO() { Id = 2, UserId = 2 }
        };

        _mockCommentService.Setup(mock => mock.FindCommentsByReviewId(testReviewId))
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await commentController.GetCommentsByReviewId(testReviewId) as OkObjectResult;
        var resultValue = resultObject!.Value as List<CommentGetDTO>;

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
    public async Task GetCommentsByReviewId_OnInvalidRequest_ReturnsNotFoundObjectResult()
    {
        // Arrange
        int testReviewId = int.MaxValue;

        List<Comment>? expectedServiceReturn = null;

        _mockCommentService.Setup(mock => mock.FindCommentsByReviewId(testReviewId))
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await commentController.GetCommentsByReviewId(testReviewId);

        // Assert
        Assert.That(resultObject, Is.TypeOf<NotFoundObjectResult>());
    }
    #endregion

    #region PostComment method tests
    [Test]
    public async Task PostComment_CallsServiceMethodOnce()
    {
        // Arrange
        CommentInsertDTO inputCommentDto = new CommentInsertDTO() { ReviewId = 1 };

        Comment expectedServiceInput = new Comment() { UserId = 1, ReviewId = 1 };
        Comment expectedServiceReturn = new Comment() { Id = 1, UserId = 1, ReviewId = 1 };

        _mockCommentService.Setup(mock => mock.CreateComment(It.Is<Comment>(r =>
            r.UserId == expectedServiceInput.UserId)))
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        await commentController.PostComment(inputCommentDto);

        // Assert
        _mockCommentService.Verify(mock => mock.CreateComment(It.Is<Comment>(r =>
            r.UserId == expectedServiceInput.UserId)), Times.Once());
    }

    [Test]
    public async Task PostComment_OnValidRequest_ReturnsOkObjectResult()
    {
        // Arrange
        CommentInsertDTO inputCommentDto = new CommentInsertDTO() { ReviewId = 1 };

        Comment expectedServiceInput = new Comment() { UserId = 1, ReviewId = 1 };
        Comment expectedServiceReturn = new Comment() { Id = 1, UserId = 1, ReviewId = 1 };

        _mockCommentService.Setup(mock => mock.CreateComment(It.Is<Comment>(r =>
            r.UserId == expectedServiceInput.UserId)))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await commentController.PostComment(inputCommentDto);

        // Assert
        Assert.That(resultObject, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public async Task PostComment_OnValidRequest_ReturnsMappedComment()
    {
        // Arrange
        CommentInsertDTO inputCommentDto = new CommentInsertDTO() { ReviewId = 1 };

        Comment expectedServiceInput = new Comment() { UserId = 1, ReviewId = 1 };
        Comment expectedServiceReturn = new Comment() { Id = 1, UserId = 1, ReviewId = 1 };

        _mockCommentService.Setup(mock => mock.CreateComment(It.Is<Comment>(r =>
            r.UserId == expectedServiceInput.UserId)))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await commentController.PostComment(inputCommentDto) as OkObjectResult;
        var resultValue = resultObject!.Value as CommentGetDTO;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(resultValue!.Id, Is.EqualTo(expectedServiceReturn.Id));
            Assert.That(resultValue.UserId, Is.EqualTo(expectedServiceReturn.UserId));
        });
    }

    [Test]
    public async Task PostComment_OnInvalidModel_ReturnsBadRequestObjectResult()
    {
        // Arrange
        commentController.ModelState.AddModelError("Contents", "Required");
        var inputCommentDto = new CommentInsertDTO() { ReviewId = 1 };

        // Act
        var resultObject = await commentController.PostComment(inputCommentDto);

        // Assert
        Assert.That(resultObject, Is.TypeOf<BadRequestObjectResult>());
    }
    #endregion

    #region PutComment method tests
    [Test]
    public async Task PutComment_CallsBothServiceMethodsOnce()
    {
        // Arrange
        CommentUpdateDTO inputCommentDto = new CommentUpdateDTO() { Id = 1, Contents = "TestContents" };

        int expectedFirstServiceInput = inputCommentDto.Id;
        Comment expectedFirstServiceReturn = new Comment() { Id = 1, UserId = 1, Contents = "NotTestContents" };

        CommentUpdateDTO expectedSecondServiceInput = inputCommentDto;
        Comment expectedSecondServiceReturn = new Comment() { Id = 1, UserId = 1, Contents = "TestContents" };

        _mockCommentService.Setup(mock => mock.FindCommentById(expectedFirstServiceInput))
                           .ReturnsAsync(expectedFirstServiceReturn);

        _mockCommentService.Setup(mock => mock.UpdateComment(It.Is<CommentUpdateDTO>(r =>
            r.Id == expectedSecondServiceInput.Id &&
            r.Contents == expectedSecondServiceInput.Contents)))
                           .ReturnsAsync(expectedSecondServiceReturn);

        // Act
        await commentController.PutComment(inputCommentDto);

        // Assert
        _mockCommentService.Verify(mock => mock.FindCommentById(expectedFirstServiceInput), Times.Once());

        _mockCommentService.Verify(mock => mock.UpdateComment(It.Is<CommentUpdateDTO>(r =>
            r.Id == expectedSecondServiceInput.Id &&
            r.Contents == expectedSecondServiceInput.Contents)), Times.Once());
    }

    [Test]
    public async Task PutComment_OnValidRequest_ReturnsOkObjectResult()
    {
        // Arrange
        CommentUpdateDTO inputCommentDto = new CommentUpdateDTO() { Id = 1, Contents = "TestContents" };

        int expectedFirstServiceInput = inputCommentDto.Id;
        Comment expectedFirstServiceReturn = new Comment() { Id = 1, UserId = 1, Contents = "NotTestContents" };

        CommentUpdateDTO expectedSecondServiceInput = inputCommentDto;
        Comment expectedSecondServiceReturn = new Comment() { Id = 1, UserId = 1, Contents = "TestContents" };

        _mockCommentService.Setup(mock => mock.FindCommentById(expectedFirstServiceInput))
                           .ReturnsAsync(expectedFirstServiceReturn);

        _mockCommentService.Setup(mock => mock.UpdateComment(It.Is<CommentUpdateDTO>(r =>
            r.Id == expectedSecondServiceInput.Id &&
            r.Contents == expectedSecondServiceInput.Contents)))
                          .ReturnsAsync(expectedSecondServiceReturn);

        // Act
        var resultObject = await commentController.PutComment(inputCommentDto);

        // Assert
        Assert.That(resultObject, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public async Task PutComment_OnValidRequest_ReturnsMappedComment()
    {
        // Arrange
        CommentUpdateDTO inputCommentDto = new CommentUpdateDTO() { Id = 1, Contents = "TestContents" };

        int expectedFirstServiceInput = inputCommentDto.Id;
        Comment expectedFirstServiceReturn = new Comment() { Id = 1, UserId = 1, Contents = "NotTestContents" };

        CommentUpdateDTO expectedSecondServiceInput = inputCommentDto;
        Comment expectedSecondServiceReturn = new Comment() { Id = 1, UserId = 1, Contents = "TestContents" };

        _mockCommentService.Setup(mock => mock.FindCommentById(expectedFirstServiceInput))
                           .ReturnsAsync(expectedFirstServiceReturn);

        _mockCommentService.Setup(mock => mock.UpdateComment(It.Is<CommentUpdateDTO>(r =>
            r.Id == expectedSecondServiceInput.Id &&
            r.Contents == expectedSecondServiceInput.Contents)))
                          .ReturnsAsync(expectedSecondServiceReturn);

        // Act
        var resultObject = await commentController.PutComment(inputCommentDto) as OkObjectResult;
        var resultValue = resultObject!.Value as CommentGetDTO;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(resultValue!.Id, Is.EqualTo(expectedSecondServiceReturn.Id));
            Assert.That(resultValue.UserId, Is.EqualTo(expectedSecondServiceReturn.UserId));
            Assert.That(resultValue.Contents, Is.EqualTo(expectedSecondServiceReturn.Contents));
        });
    }

    [Test]
    public async Task PutComment_OnInvalidId_ReturnsNotFoundObjectResult()
    {
        // Arrange
        int testUserId = int.MaxValue;
        CommentUpdateDTO inputCommentDto = new CommentUpdateDTO() { Id = testUserId };

        CommentUpdateDTO expectedServiceInput = new CommentUpdateDTO() { Id = testUserId };
        Comment? expectedServiceReturn = null;

        _mockCommentService.Setup(mock => mock.FindCommentById(expectedServiceInput.Id))
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await commentController.PutComment(inputCommentDto);

        // Assert
        Assert.That(resultObject, Is.TypeOf<NotFoundObjectResult>());
    }

    [Test]
    public async Task PutComment_OnInvalidModel_ReturnsBadRequestObjectResult()
    {
        // Arrange
        commentController.ModelState.AddModelError("Contents", "Required");
        CommentUpdateDTO inputCommentDto = new CommentUpdateDTO() { Id = 1 };

        // Act
        var resultObject = await commentController.PutComment(inputCommentDto);

        // Assert
        Assert.That(resultObject, Is.TypeOf<BadRequestObjectResult>());
    }
    #endregion

    #region DeleteComment method tests
    [Test]
    public async Task DeleteComment_CallsBothServiceMethodsOnce()
    {
        // Arrange
        int testCommentId = 1;

        bool expectedServiceReturn = true;

        Comment expectedFirstServiceReturn = new Comment() { UserId = 1 };

        _mockCommentService.Setup(mock => mock.FindCommentById(testCommentId))
                           .ReturnsAsync(expectedFirstServiceReturn);

        _mockCommentService.Setup(mock => mock.DeleteComment(testCommentId))
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        await commentController.DeleteComment(testCommentId);

        // Assert
        _mockCommentService.Verify(mock => mock.FindCommentById(testCommentId), Times.Once());

        _mockCommentService.Verify(mock => mock.DeleteComment(testCommentId), Times.Once());
    }

    [Test]
    public async Task DeleteComment_OnValidRequest_ReturnsNoContentResult()
    {
        // Arrange
        int testCommentId = 1;

        bool expectedServiceReturn = true;

        Comment expectedFirstServiceReturn = new Comment() { UserId = 1 };

        _mockCommentService.Setup(mock => mock.FindCommentById(testCommentId))
                          .ReturnsAsync(expectedFirstServiceReturn);

        _mockCommentService.Setup(mock => mock.DeleteComment(testCommentId))
                          .ReturnsAsync(expectedServiceReturn);

        // Act
        var result = await commentController.DeleteComment(testCommentId);

        // Assert
        Assert.That(result, Is.TypeOf<NoContentResult>());
    }

    [Test]
    public async Task DeleteComment_OnInvalidRequest_ReturnsNotFoundObjectResult()
    {
        // Arrange
        int testCommentId = int.MaxValue;

        bool expectedServiceReturn = false;

        _mockCommentService.Setup(mock => mock.DeleteComment(testCommentId))
                           .ReturnsAsync(expectedServiceReturn);

        // Act
        var resultObject = await commentController.DeleteComment(testCommentId);

        // Assert
        Assert.That(resultObject, Is.TypeOf<NotFoundObjectResult>());
    }
    #endregion
}
