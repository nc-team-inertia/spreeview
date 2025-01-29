using Moq;
using SpreeviewAPI.Controllers;

namespace ProjectTest
{
    public class Tests
    {
        Mock<IAlbumService> mock;
        //TODO AlbumController core;

        [SetUp]
        public void Setup()
        {
            mock = new();

            core = new(mock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            //Optional
        }

        [Test]
        public void GetAllAlbums_Success()
        {
            //ARRANGE
            /*mock.Setup(
            //ms => ms).Returns("")
            );*/

            //ACT

            //var result = core.GetallAlbums();

            //ASSERT

            //Assert.That(result, Is.TypeOf<OkObjectResult>());
        }
    }
}