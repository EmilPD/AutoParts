namespace CommonNews.Web.Tests.Controllers.Tests
{
    using Data.Models;
    using Identity;
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;
    using Moq;
    using NUnit.Framework;
    using Web.Controllers;

    [TestFixture]
    public class ManageControllerTests
    {
        [Test]
        public void Constructor_ShouldCreateInstance_WhenDefaultConstructorIsInvoked()
        {
            // Arrange & Act
            var manageController = new ManageController();

            // Assert
            Assert.IsInstanceOf<ManageController>(manageController);
        }

        [Test]
        public void Constructor_ShouldCreateInstance_WhenOverloadConstructorIsInvoked()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<ApplicationUser>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            // Act
            var manageController = new ManageController(mockedUserManager.Object, mockedSignInManager.Object);

            // Assert
            Assert.IsInstanceOf<ManageController>(manageController);
        }

        [Test]
        public void UserManagerGetter_ShouldReturn_InstanceOfApplicationUserManager()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<ApplicationUser>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            var manageController = new ManageController(mockedUserManager.Object, mockedSignInManager.Object);

            // Act
            var result = manageController.UserManager;

            // Assert
            Assert.IsInstanceOf<ApplicationUserManager>(result);
        }

        [Test]
        public void SignInManagerGetter_ShouldReturn_InstanceOfApplicationUserManager()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<ApplicationUser>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            var manageController = new ManageController(mockedUserManager.Object, mockedSignInManager.Object);

            // Act
            var result = manageController.SignInManager;

            // Assert
            Assert.IsInstanceOf<ApplicationSignInManager>(result);
        }
    }
}
