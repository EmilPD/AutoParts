namespace CommonNews.Web.Tests.Controllers.Tests
{
    using System.Web.Mvc;
    using Data.Models;
    using Moq;
    using NUnit.Framework;
    using Services.Data.Common.Contracts;
    using Web.Controllers;

    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void Constructor_ShouldReturnObject()
        {
            // Arrange
            var postServiceMock = new Mock<IDataService<Post>>();

            // Act
            var controller = new HomeController(postServiceMock.Object);

            // Assert
            Assert.IsInstanceOf<HomeController>(controller);
        }

        [Test]
        public void IndexAction_ShouldReturnView()
        {
            // Arrange
            var postServiceMock = new Mock<IDataService<Post>>();
            var controller = new HomeController(postServiceMock.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}
