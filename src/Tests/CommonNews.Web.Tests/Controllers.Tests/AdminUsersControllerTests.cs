namespace CommonNews.Web.Tests.Controllers.Tests
{
    using System;
    using System.Web.Mvc;
    using Areas.Admin.Controllers;
    using Areas.Admin.Models;
    using AutoMapper;
    using Common.Contracts;
    using Data.Models;
    using Moq;
    using NUnit.Framework;
    using Services.Data.Common.Contracts;

    [TestFixture]
    public class AdminUsersControllerTests
    {
        [Test]
        public void Constructor_ShouldCreateInstance_WhenAllParametersArePassedCorrectly()
        {
            // Arrange
            var mockedUserService = new Mock<IDataService<ApplicationUser>>();
            var mockedPaginationFactory = new Mock<IPaginationFactory>();
            var mockedMapper = new Mock<IMapper>();

            // Act
            var usersController = new UsersController(
                mockedUserService.Object, mockedPaginationFactory.Object, mockedMapper.Object);

            // Assert
            Assert.IsInstanceOf<UsersController>(usersController);
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenParameterUserServiceIsNullable()
        {
            // Arrange
            IDataService<ApplicationUser> mockedUserService = null;
            var mockedPaginationFactory = new Mock<IPaginationFactory>();
            var mockedMapper = new Mock<IMapper>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(()
                => new UsersController(mockedUserService, mockedPaginationFactory.Object, mockedMapper.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenParameterPagerFactoryIsNullable()
        {
            // Arrange
            var mockedUserService = new Mock<IDataService<ApplicationUser>>();
            IPaginationFactory mockedPaginationFactory = null;
            var mockedMapper = new Mock<IMapper>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(()
                => new UsersController(mockedUserService.Object, mockedPaginationFactory, mockedMapper.Object));
        }

        [Test]
        public void Delete_ShouldReturnViewResult_WhenIdIsCorrect()
        {
            // Arrange
            var mockedUserService = new Mock<IDataService<ApplicationUser>>();
            var mockedPagerFactory = new Mock<IPaginationFactory>();
            var mockedMapper = new Mock<IMapper>();

            var userController = new UsersController(
                mockedUserService.Object, mockedPagerFactory.Object, mockedMapper.Object);

            var id = Guid.NewGuid();
            mockedUserService.Setup(x => x.GetById(id.ToString()))
                .Returns(new ApplicationUser() { Id = id.ToString() });

            // Act & Assert
            Assert.IsInstanceOf<ViewResult>(userController
                .Delete(id, new ApplicationUser() { Id = id.ToString() }));
        }

        [Test]
        public void Delete_ShouldReturnHttpNotFoundResult_WhenEmployeeIsNull()
        {
            // Arrange
            var mockedUserService = new Mock<IDataService<ApplicationUser>>();
            var mockedPaginationFactory = new Mock<IPaginationFactory>();
            var mockedMapper = new Mock<IMapper>();

            var userController = new UsersController(
                mockedUserService.Object, mockedPaginationFactory.Object, mockedMapper.Object);

            var id = Guid.NewGuid();
            ApplicationUser user = null;
            mockedUserService.Setup(x => x.GetById(id.ToString())).Returns(user);

            // Act & Assert
            Assert.IsInstanceOf<HttpNotFoundResult>(userController.Delete(id, user));
        }

        [Test]
        public void Delete_ShouldReturnRedirectToRouteResult_WhenIdIsCorrect()
        {
            // Arrange
            var mockedUserService = new Mock<IDataService<ApplicationUser>>();
            var mockedPaginationFactory = new Mock<IPaginationFactory>();
            var mockedMapper = new Mock<IMapper>();

            var userController = new UsersController(
                mockedUserService.Object, mockedPaginationFactory.Object, mockedMapper.Object);

            var id = Guid.NewGuid();
            mockedUserService.Setup(x => x.Delete(id.ToString())).Verifiable();

            // Act & Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(userController
                .DeleteConfirmed(id, new UsersViewModel() { Id = id.ToString() }));
        }
    }
}
