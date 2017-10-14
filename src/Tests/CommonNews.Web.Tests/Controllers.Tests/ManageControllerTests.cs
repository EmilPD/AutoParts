namespace CommonNews.Web.Tests.Controllers.Tests
{
    using System.Web.Mvc;
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
            ManageController manageController = new ManageController(mockedUserManager.Object, mockedSignInManager.Object);

            // Assert
            Assert.IsInstanceOf<ManageController>(manageController);
        }

        //[Test]
        //public void ChangePassword_ShouldReturnViewResult_WhenIsCalled()
        //{
        //    // Arrange
        //    ManageController manageController = new ManageController();

        //    // Act
        //    var result = manageController.ChangePassword() as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}

        //[Test]
        //public void ChangePassword_ShouldReturnChangePasswordViewModel_WhenModelStateIsNotValid()
        //{
        //    // Arrange
        //    var mockedUserManager = new Mock<ApplicationUserManager>();
        //    var mockedSignInManager = new Mock<ApplicationSignInManager>();

        //    var mockedViewModel = new Mock<ChangePasswordViewModel>();
        //    ManageController manageController = new ManageController(mockedUserManager.Object, mockedSignInManager.Object);
        //    manageController.ModelState.AddModelError("invalid", "invalid");

        //    // Act
        //    var actionResultTask = manageController.ChangePassword(mockedViewModel.Object);
        //    actionResultTask.Wait();
        //    var viewResult = actionResultTask.Result as ViewResult;

        //    // Assert
        //    Assert.IsInstanceOf<ChangePasswordViewModel>(viewResult.Model);
        //}

        //[Test]
        //public void ReturnViewResult_WhenRegisterIsCalled()
        //{
        //    // Arrange
        //    ManageController manageController = new ManageController();

        //    // Act
        //    ViewResult result = manageController.AddPhoneNumber() as ViewResult;

        //    // Assert
        //    Assert.IsNotNull(result);
        //}

        //[Test]
        //public void ReturnAddPhoneNumberViewModel_WhenModelStateIsNotValid()
        //{
        //    // Arrange
        //    var mockedStore = new Mock<IUserStore<ApplicationUser>>();
        //    var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

        //    var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
        //    var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

        //    var mockedViewModel = new Mock<AddPhoneNumberViewModel>();
        //    ManageController manageController = new ManageController(mockedUserManager.Object, mockedSignInManager.Object);
        //    manageController.ModelState.AddModelError("invalid", "invalid");

        //    // Act
        //    var actionResultTask = manageController.AddPhoneNumber(mockedViewModel.Object);
        //    actionResultTask.Wait();
        //    var viewResult = actionResultTask.Result as ViewResult;

        //    // Assert
        //    Assert.IsInstanceOf<AddPhoneNumberViewModel>(viewResult.Model);
        //}

        //[Test]
        //public void ReturnAddPhoneNumberViewModel_WhenModelStateIsValid()
        //{
        //    // Arrange
        //    var mockedStore = new Mock<IUserStore<ApplicationUser>>();
        //    var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

        //    var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
        //    var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

        //    var mockedViewModel = new Mock<AddPhoneNumberViewModel>();
        //    ManageController manageController = new ManageController(mockedUserManager.Object, mockedSignInManager.Object);
        //    string code = "testcode";
        //    mockedUserManager.Setup(x => x.GenerateChangePhoneNumberTokenAsync(null, null)).ReturnsAsync(code).Verifiable();

        //    // Act
        //    var actionResultTask = manageController.AddPhoneNumber(mockedViewModel.Object);

        //    // Assert
        //    mockedUserManager.Verify(x => x.GenerateChangePhoneNumberTokenAsync("111", "0888112233"), Times.AtMostOnce);
        //}
    }
}
