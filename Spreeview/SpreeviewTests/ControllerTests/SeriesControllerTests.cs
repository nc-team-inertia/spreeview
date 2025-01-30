using Moq;
using SpreeviewAPI.Controllers.Implementations;
using SpreeviewAPI.Services.Interfaces;

namespace SpreeviewTests.ControllerTests;

public class SeriesControllerTests
{
    Mock<ISeriesService> _mockSeriesService;
    SeriesController seriesController;

    [SetUp]
    public void Setup()
    {
        _mockSeriesService = new Mock<ISeriesService>();
        seriesController = new SeriesController(_mockSeriesService.Object);
    }

    [Test]
    public void GetSeriesById_DoesSomething()
    {
        Assert.Pass();
    }
}
