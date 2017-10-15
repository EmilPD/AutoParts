namespace CommonNews.Web.Tests.Controllers.Tests
{
    using AutoMapper;
    using Common.Contracts;
    using Data.Models;
    using Moq;
    using NUnit.Framework;
    using Services.Data.Common.Contracts;
    using Web.Controllers;

    [TestFixture]
    public class MyPostsControllerTests
    {
        [Test]
        public void Constructor_ShouldReturnObject()
        {
            // Arrange
            var postsServiceMock = new Mock<IDataService<Post>>();
            var paginationFactoryMock = new Mock<IPaginationFactory>();
            var mockedMapper = new Mock<IMapper>();

            // Act
            var controller = new MyPostsController(
                postsServiceMock.Object,
                paginationFactoryMock.Object,
                mockedMapper.Object);

            // Assert
            Assert.IsInstanceOf<MyPostsController>(controller);
        }
    }
}
