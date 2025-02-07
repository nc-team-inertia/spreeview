using CommonLibrary.DataClasses.CommentModel;
using Moq;
using SpreeviewAPI.Repository.Interfaces;
using SpreeviewAPI.Services.Implementations;

namespace SpreeviewTests.ServiceTests;

internal class CommentServiceTests
{
    Mock<ICommentRepository> _mockRepository;
    CommentService commentService;

    [SetUp]
    public void Setup()
    {
        _mockRepository = new Mock<ICommentRepository>();
        commentService = new CommentService(_mockRepository.Object);
    }

    #region IndexAllComments method tests
    [Test]
    public async Task IndexAllComment_CallsRepositoryMethodOnce()
    {
        // Arrange
        List<Comment> expectedRepositoryReturn = new List<Comment>() {
            new Comment() { Id = 1, UserId = 1 },
            new Comment() { Id = 2, UserId = 2 }
        };

        _mockRepository.Setup(mock => mock.IndexAllComments())
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        await commentService.IndexAllComments();

        // Assert
        _mockRepository.Verify(mock => mock.IndexAllComments(), Times.Once());
    }

    [Test]
    public async Task IndexAllComments_OnValidRequest_ReturnsCommentListType()
    {
        // Arrange
        List<Comment> expectedRepositoryReturn = new List<Comment>() {
            new Comment() { Id = 1, UserId = 1 },
            new Comment() { Id = 2, UserId = 2 }
        };

        _mockRepository.Setup(mock => mock.IndexAllComments())
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await commentService.IndexAllComments();

        // Assert
        Assert.That(result, Is.TypeOf<List<Comment>>());
    }

    [Test]
    public async Task IndexAllComments_OnInvalidRequest_ReturnsEmptyList()
    {
        // Arrange
        List<Comment> expectedRepositoryReturn = new List<Comment>();

        _mockRepository.Setup(mock => mock.IndexAllComments())
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await commentService.IndexAllComments();

        // Assert
        Assert.That(result, Has.Count.EqualTo(0));
    }
    #endregion

    #region FindCommentById method tests
    [Test]
    public async Task FindCommentById_CallsRepositoryMethodOnce()
    {
        // Arrange
        int testCommentId = 1;

        Comment expectedRepositoryReturn = new Comment() { Id = 1, UserId = 1 };

        _mockRepository.Setup(mock => mock.FindCommentById(testCommentId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        await commentService.FindCommentById(testCommentId);

        // Assert
        _mockRepository.Verify(mock => mock.FindCommentById(testCommentId), Times.Once());
    }

    [Test]
    public async Task FindCommentById_OnValidRequest_ReturnsCommentType()
    {
        // Arrange
        int testCommentId = 1;

        Comment expectedRepositoryReturn = new Comment() { Id = 1, UserId = 1 };

        _mockRepository.Setup(mock => mock.FindCommentById(testCommentId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await commentService.FindCommentById(testCommentId);

        // Assert
        Assert.That(result, Is.TypeOf<Comment>());
    }

    [Test]
    public async Task FindCommentById_OnInvalidRequest_ReturnsNull()
    {
        // Arrange
        int testCommentId = int.MaxValue;

        Comment? expectedRepositoryReturn = null;

        _mockRepository.Setup(mock => mock.FindCommentById(testCommentId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await commentService.FindCommentById(testCommentId);

        // Assert
        Assert.That(result, Is.EqualTo(expectedRepositoryReturn));
    }
    #endregion

    #region FindCommentsByUserId method tests
    [Test]
    public async Task FindCommentsByUserId_CallsRepositoryMethodOnce()
    {
        // Arrange
        int testUserId = 1;

        List<Comment> expectedRepositoryReturn = new List<Comment>()
        {
            new Comment() { Id = 1, UserId = 1 },
            new Comment() { Id = 2, UserId = 1 }
        };

        _mockRepository.Setup(mock => mock.FindCommentsByUserId(testUserId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        await commentService.FindCommentsByUserId(testUserId);

        // Assert
        _mockRepository.Verify(mock => mock.FindCommentsByUserId(testUserId), Times.Once());
    }

    [Test]
    public async Task FindCommentsByUserId_OnValidRequest_ReturnsCommentListType()
    {
        // Arrange
        int testUserId = 1;

        List<Comment> expectedRepositoryReturn = new List<Comment>()
        {
            new Comment() { Id = 1, UserId = 1 },
            new Comment() { Id = 2, UserId = 1 }
        };

        _mockRepository.Setup(mock => mock.FindCommentsByUserId(testUserId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await commentService.FindCommentsByUserId(testUserId);

        // Assert
        Assert.That(result, Is.TypeOf<List<Comment>>());
    }

    [Test]
    public async Task FindCommentsByUserId_OnInvalidRequest_ReturnsEmptyList()
    {
        // Arrange
        int testUserId = int.MaxValue;

        List<Comment> expectedRepositoryReturn = new List<Comment>();

        _mockRepository.Setup(mock => mock.FindCommentsByUserId(testUserId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await commentService.FindCommentsByUserId(testUserId);

        // Assert
        Assert.That(result, Has.Count.EqualTo(0));
    }
    #endregion

    #region FindCommentsByReviewId method tests
    [Test]
    public async Task FindCommentsByReviewId_CallsRepositoryMethodOnce()
    {
        // Arrange
        int testReviewId = 1;

        List<Comment> expectedRepositoryReturn = new List<Comment>()
        {
            new Comment() { Id = 1, ReviewId = 1 },
            new Comment() { Id = 2, ReviewId = 1 }
        };

        _mockRepository.Setup(mock => mock.FindCommentsByReviewId(testReviewId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        await commentService.FindCommentsByReviewId(testReviewId);

        // Assert
        _mockRepository.Verify(mock => mock.FindCommentsByReviewId(testReviewId), Times.Once());
    }

    [Test]
    public async Task FindCommentsByReviewId_OnValidRequest_ReturnsCommentListType()
    {
        // Arrange
        int testReviewId = 1;

        List<Comment> expectedRepositoryReturn = new List<Comment>()
        {
            new Comment() { Id = 1, ReviewId = 1 },
            new Comment() { Id = 2, ReviewId = 1 }
        };

        _mockRepository.Setup(mock => mock.FindCommentsByReviewId(testReviewId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await commentService.FindCommentsByReviewId(testReviewId);

        // Assert
        Assert.That(result, Is.TypeOf<List<Comment>>());
    }

    [Test]
    public async Task FindCommentsByReviewId_OnInvalidRequest_ReturnsEmptyList()
    {
        // Arrange
        int testReviewId = int.MaxValue;

        List<Comment> expectedRepositoryReturn = new List<Comment>();

        _mockRepository.Setup(mock => mock.FindCommentsByReviewId(testReviewId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await commentService.FindCommentsByReviewId(testReviewId);

        // Assert
        Assert.That(result, Has.Count.EqualTo(0));
    }
    #endregion

    #region CreateComment method tests
    [Test]
    public async Task CreateComment_CallsRepositoryMethodOnce()
    {
        // Arrange
        Comment inputComment = new Comment() { UserId = 1 };

        Comment expectedRepositoryReturn = new Comment() { Id = 1, UserId = 1 };

        _mockRepository.Setup(mock => mock.CreateComment(inputComment))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        await commentService.CreateComment(inputComment);

        // Assert
        _mockRepository.Verify(mock => mock.CreateComment(inputComment), Times.Once());
    }

    [Test]
    public async Task CreateComment_OnValidRequest_ReturnsCommentType()
    {
        // Arrange
        Comment inputComment = new Comment() { UserId = 1 };

        Comment expectedRepositoryReturn = new Comment() { Id = 1, UserId = 1 };

        _mockRepository.Setup(mock => mock.CreateComment(inputComment))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await commentService.CreateComment(inputComment);

        // Assert
        Assert.That(result, Is.TypeOf<Comment>());
    }

    [Test]
    public async Task CreateComment_OnInvalidRequest_ReturnsNull()
    {
        // Arrange
        int testUserId = int.MaxValue;
        Comment inputComment = new Comment() { UserId = testUserId };

        Comment? expectedRepositoryReturn = null;

        _mockRepository.Setup(mock => mock.CreateComment(inputComment))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await commentService.CreateComment(inputComment);

        // Assert
        Assert.That(result, Is.EqualTo(expectedRepositoryReturn));
    }
    #endregion

    #region UpdateComment method tests
    [Test]
    public async Task UpdateComment_CallsRepositoryMethodOnce()
    {
        // Arrange
        CommentUpdateDTO inputCommentDto = new CommentUpdateDTO() { Id = 1, Contents = "TestContents" };

        Comment expectedRepositoryReturn = new Comment() { Id = 1, Contents = "TestContents" };

        _mockRepository.Setup(mock => mock.UpdateComment(inputCommentDto))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        await commentService.UpdateComment(inputCommentDto);

        // Assert
        _mockRepository.Verify(mock => mock.UpdateComment(inputCommentDto), Times.Once());
    }

    [Test]
    public async Task UpdateComment_OnValidRequest_ReturnsCommentType()
    {
        // Arrange
        CommentUpdateDTO inputCommentDto = new CommentUpdateDTO() { Id = 1, Contents = "TestContents" };

        Comment expectedRepositoryReturn = new Comment() { Id = 1, Contents = "TestContents" };

        _mockRepository.Setup(mock => mock.UpdateComment(inputCommentDto))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await commentService.UpdateComment(inputCommentDto);

        // Assert
        Assert.That(result, Is.TypeOf<Comment>());
    }

    [Test]
    public async Task UpdateComment_OnInvalidRequest_ReturnsNull()
    {
        // Arrange
        int testCommentId = int.MaxValue;
        CommentUpdateDTO inputCommentDto = new CommentUpdateDTO() { Id = testCommentId, Contents = "TestContents" };

        Comment? expectedRepositoryReturn = null;

        _mockRepository.Setup(mock => mock.UpdateComment(inputCommentDto))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await commentService.UpdateComment(inputCommentDto);

        // Assert
        Assert.That(result, Is.EqualTo(expectedRepositoryReturn));
    }
    #endregion

    #region DeleteComment method tests
    [Test]
    public async Task DeleteComment_CallsRepositoryMethodOnce()
    {
        // Arrange
        int testCommentId = 1;

        bool expectedRepositoryReturn = true;

        _mockRepository.Setup(mock => mock.DeleteComment(testCommentId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        await commentService.DeleteComment(testCommentId);

        // Assert
        _mockRepository.Verify(mock => mock.DeleteComment(testCommentId), Times.Once());
    }

    [Test]
    public async Task DeleteComment_OnValidRequest_ReturnsTrue()
    {
        // Arrange
        int testCommentId = 1;

        bool expectedRepositoryReturn = true;

        _mockRepository.Setup(mock => mock.DeleteComment(testCommentId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await commentService.DeleteComment(testCommentId);

        // Assert
        Assert.That(result, Is.EqualTo(expectedRepositoryReturn));
    }

    [Test]
    public async Task DeleteComment_OnInvalidRequest_ReturnsNull()
    {
        // Arrange
        int testCommentId = int.MaxValue;

        bool expectedRepositoryReturn = false;

        _mockRepository.Setup(mock => mock.DeleteComment(testCommentId))
                       .ReturnsAsync(expectedRepositoryReturn);

        // Act
        var result = await commentService.DeleteComment(testCommentId);

        // Assert
        Assert.That(result, Is.EqualTo(expectedRepositoryReturn));
    }
    #endregion
}
