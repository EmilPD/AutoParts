namespace CommonNews.Web.Tests.Controllers.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.Models;
    using Moq;
    using NUnit.Framework;
    using Services.Data.Common.Contracts;
    using Web.Controllers;
    using Web.ViewModels.Post;

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

        [Test]
        public void IndexAction_ShouldReturnView()
        {
            // Arrange
            var categoryName = "Fashion";
            var postViewModelMock = new Mock<PostViewModel>();
            var postCategoryMock = new PostCategory { Name = categoryName };

            var listOfCategories = new List<PostCategory>();
            listOfCategories.Add(postCategoryMock);

            var postCategoryServiceMock = new Mock<IDataService<PostCategory>>();
            postCategoryServiceMock.Setup(x => x.GetAll()).Returns(listOfCategories.AsQueryable());

            var mockedMapper = new Mock<IMapper>();
            mockedMapper
                .Setup(x => x.Map<Post, PostViewModel>(It.IsAny<Post>()))
                .Returns(postViewModelMock.Object);

            var controller = new CategoriesController(
                postCategoryServiceMock.Object, mockedMapper.Object);

            // Act
            var result = controller.Index(categoryName) as ViewResult;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}
