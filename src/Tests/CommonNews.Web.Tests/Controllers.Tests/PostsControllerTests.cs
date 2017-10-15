namespace CommonNews.Web.Tests.Controllers.Tests
{
    using AutoMapper;
    using Data.Models;
    using Moq;
    using NUnit.Framework;
    using Services.Data.Common.Contracts;
    using System.Web.Mvc;
    using System.Linq;
    using TestStack.FluentMVCTesting;
    using Web.Controllers;
    using Web.ViewModels.Comment;
    using System.Collections.Generic;
    using Data.Tests.Mock;
    using Data.Common;
    using Data.Common.Contracts;
    using Web.ViewModels.Post;
    [TestFixture]
    public class PostsControllerTests
    {
        [Test]
        public void Constructor_ShouldReturnObject()
        {
            // Arrange
            var postsServiceMock = new Mock<IDataService<Post>>();
            var categoriesServiceMock = new Mock<IDataService<PostCategory>>();
            var usersServiceMock = new Mock<IDataService<ApplicationUser>>();
            var commentsServiceMock = new Mock<IDataService<Comment>>();
            var mockedMapper = new Mock<IMapper>();

            // Act
            var controller = new PostsController(
                postsServiceMock.Object,
                categoriesServiceMock.Object,
                usersServiceMock.Object,
                commentsServiceMock.Object,
                mockedMapper.Object);

            // Assert
            Assert.IsInstanceOf<PostsController>(controller);
        }

        [Test]
        public void Index_ShouldReturnInstanceOfViewResult_WhenPostServiceReturnValidPosts()
        {
            // Arrange
            var postsServiceMock = new Mock<IDataService<Post>>();
            var categoriesServiceMock = new Mock<IDataService<PostCategory>>();
            var usersServiceMock = new Mock<IDataService<ApplicationUser>>();
            var commentsServiceMock = new Mock<IDataService<Comment>>();
            var mockedMapper = new Mock<IMapper>();

            var controller = new PostsController(
                postsServiceMock.Object,
                categoriesServiceMock.Object,
                usersServiceMock.Object,
                commentsServiceMock.Object,
                mockedMapper.Object);

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        //[Test]
        //public void Details_ShouldReturnInstanceOfViewResult_WhenPostServiceReturnValidPost()
        //{
        //    // Arrange
        //    var posts = new List<Post>
        //    {
        //        new Post() { Id = 1, Title = "post", Content = "content" },
        //        new Post() { Id = 2, Title = "post", Content = "content" }
        //    };

        //    var mockedPostSet = QueryableDbSetMock.GetQueryableMockDbSet<Post>(posts);

        //    var context = new MsSqlDbContext();
        //    context.Posts = mockedPostSet;

        //    var mockedRepo = new Mock<EfRepository<Post>>(context);
        //    var mockedSaveContext = new Mock<ISaveContext>();

        //    var postsServiceMock = new Mock<IDataService<Post>>(mockedRepo.Object, mockedSaveContext.Object);

        //    var categoriesServiceMock = new Mock<IDataService<PostCategory>>();
        //    var usersServiceMock = new Mock<IDataService<ApplicationUser>>();
        //    var commentsServiceMock = new Mock<IDataService<Comment>>();
        //    var mockedMapper = new Mock<IMapper>();

        //    // Act
        //    var controller = new PostsController(
        //        postsServiceMock.Object,
        //        categoriesServiceMock.Object,
        //        usersServiceMock.Object,
        //        commentsServiceMock.Object,
        //        mockedMapper.Object);

        //    // Act
        //    var result = controller.Details(1);

        //    // Assert
        //    Assert.IsInstanceOf<ViewResult>(result);
        //}

        [Test]
        public void Create_ShouldReturnInstanceOfViewResult_WhenPostServiceReturnValidPost()
        {
            // Arrange
            var postsServiceMock = new Mock<IDataService<Post>>();
            var categoriesServiceMock = new Mock<IDataService<PostCategory>>();
            var usersServiceMock = new Mock<IDataService<ApplicationUser>>();
            var commentsServiceMock = new Mock<IDataService<Comment>>();
            var mockedMapper = new Mock<IMapper>();

            var controller = new PostsController(
                postsServiceMock.Object,
                categoriesServiceMock.Object,
                usersServiceMock.Object,
                commentsServiceMock.Object,
                mockedMapper.Object);

            // Act
            var result = controller.Create();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        //[Test]
        //public void EditPOST_ShouldRedirectToIndex_WhenModelIsValid()
        //{
        //    // Arrange
        //    var post = new Post { Id = 1 };

        //    var postsServiceMock = new Mock<IDataService<Post>>();
        //    postsServiceMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(post);

        //    var postViewModelMock = new Mock<PostViewModel>();
        //    postViewModelMock.Setup(x => x.Id).Returns(1);

        //    var postFormViewModelMock = new Mock<PostFormViewModel>();
        //    postFormViewModelMock.Setup(x => x.Post).Returns(postViewModelMock.Object);

        //    var categoriesServiceMock = new Mock<IDataService<PostCategory>>();
        //    var usersServiceMock = new Mock<IDataService<ApplicationUser>>();
        //    var commentsServiceMock = new Mock<IDataService<Comment>>();
        //    var mockedMapper = new Mock<IMapper>();

        //    // Act
        //    var controller = new PostsController(
        //        postsServiceMock.Object,
        //        categoriesServiceMock.Object,
        //        usersServiceMock.Object,
        //        commentsServiceMock.Object,
        //        mockedMapper.Object);

        //    // Act
        //    var result = controller.Create(postFormViewModelMock.Object);

        //    // Assert
        //    Assert.IsInstanceOf<ViewResult>(result);
        //}

        [Test]
        public void Delete_ShouldReturnInstanceHttpNotFoundResult_WhenPostServiceCantFindPost()
        {
            // Arrange
            var postsServiceMock = new Mock<IDataService<Post>>();
            var categoriesServiceMock = new Mock<IDataService<PostCategory>>();
            var usersServiceMock = new Mock<IDataService<ApplicationUser>>();
            var commentsServiceMock = new Mock<IDataService<Comment>>();
            var mockedMapper = new Mock<IMapper>();

            var controller = new PostsController(
                postsServiceMock.Object,
                categoriesServiceMock.Object,
                usersServiceMock.Object,
                commentsServiceMock.Object,
                mockedMapper.Object);

            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOf<HttpNotFoundResult>(result);
        }

        [Test]
        public void Delete_ShouldReturnInstanceOfViewResult_WhenPostServiceReturnValidPost()
        {
            // Arrange
            var postsServiceMock = new Mock<IDataService<Post>>();
            postsServiceMock.Setup(x => x.GetById(It.IsAny<object>())).Returns(new Post { Id = 1 });
            var categoriesServiceMock = new Mock<IDataService<PostCategory>>();
            var usersServiceMock = new Mock<IDataService<ApplicationUser>>();
            var commentsServiceMock = new Mock<IDataService<Comment>>();
            var mockedMapper = new Mock<IMapper>();

            var controller = new PostsController(
                postsServiceMock.Object,
                categoriesServiceMock.Object,
                usersServiceMock.Object,
                commentsServiceMock.Object,
                mockedMapper.Object);

            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void DeleteConfirmed_ShouldShouldRedirectToIndex_WhenPostServiceCantFindPost()
        {
            // Arrange
            var postsServiceMock = new Mock<IDataService<Post>>();
            postsServiceMock.Setup(x => x.GetById(It.IsAny<object>())).Returns(new Post { Id = 1 });
            var categoriesServiceMock = new Mock<IDataService<PostCategory>>();
            var usersServiceMock = new Mock<IDataService<ApplicationUser>>();
            var commentsServiceMock = new Mock<IDataService<Comment>>();
            var mockedMapper = new Mock<IMapper>();

            var controller = new PostsController(
                postsServiceMock.Object,
                categoriesServiceMock.Object,
                usersServiceMock.Object,
                commentsServiceMock.Object,
                mockedMapper.Object);

            // Act
            var result = controller.WithCallTo(c => c.DeleteConfirmed(1))
                .ShouldRedirectTo<PostsController>(typeof(PostsController).GetMethod("Index"));
        }
    }
}
