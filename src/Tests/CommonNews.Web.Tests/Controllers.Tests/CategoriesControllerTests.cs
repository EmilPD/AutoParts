namespace CommonNews.Web.Tests.Controllers.Tests
{
    using System.Web.Mvc;
    using AutoMapper;
    using Data.Models;
    using Moq;
    using NUnit.Framework;
    using Services.Data.Common.Contracts;
    using Web.Controllers;

    [TestFixture]
    public class CategoriesControllerTests
    {
        [Test]
        public void Constructor_ShouldReturnObject()
        {
            // Arrange
            var postCategorServiceMock = new Mock<IDataService<PostCategory>>();
            var mockedMapper = new Mock<IMapper>();

            // Act
            var controller = new CategoriesController(postCategorServiceMock.Object, mockedMapper.Object);

            // Assert
            Assert.IsInstanceOf<CategoriesController>(controller);
        }

        //[Test]
        //public void IndexAction_ShouldReturnView()
        //{
        //    // Arrange
        //    var postCategoryServiceMock = new Mock<IDataService<PostCategory>>();
        //    var mockedMapper = new Mock<IMapper>();
        //    var controller = new CategoriesController(postCategoryServiceMock.Object, mockedMapper.Object);
        //    var categoryName = "Fashion";

        //    // Act
        //    var result = controller.Index(categoryName) as ViewResult;

        //    // Assert
        //    Assert.IsInstanceOf<ViewResult>(result);
        //}
    }
}
