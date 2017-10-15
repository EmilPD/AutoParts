namespace CommonNews.Web.Tests.Controllers.Tests
{
    using System.Web.Mvc;
    using Data.Models;
    using Identity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;
    using Moq;
    using NUnit.Framework;
    using TestStack.FluentMVCTesting;
    using Web.Controllers;
    using Web.ViewModels.Account;

    [TestFixture]
    public class AccountControllerTests
    {
        [Test]
        public void Constructor_ShouldReturnObject()
        {
            // Arrange & Act
            var controller = new AccountController();

            // Assert
            Assert.IsInstanceOf<AccountController>(controller);
        }

        [Test]
        public void LoginGET_ShouldReturnView()
        {
            // Arrange
            var controller = new AccountController();

            // Act
            var result = controller.Login(null) as ViewResult;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [TestCase("str1")]
        [TestCase("str2")]
        [TestCase("str3")]
        public void LoginGET_ShouldSetViewBagUrl(string returnUrl)
        {
            // Arrange
            var controller = new AccountController();

            // Act
            var result = controller.Login(returnUrl) as ViewResult;

            // Assert
            Assert.AreEqual(returnUrl, result.ViewBag.ReturnUrl);
        }

        [Test]
        public void Constructor2_ShouldReturnObject()
        {
            // Arrange & Act
            var mockedStore = new Mock<IUserStore<ApplicationUser>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            var controller = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);

            // Assert
            Assert.IsInstanceOf<AccountController>(controller);
        }

        [Test]
        public void RegisterGet_ShouldReturnView()
        {
            // Arrange
            var controller = new AccountController();

            // Act
            var result = controller.Register() as ViewResult;

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void Constructor_ShouldCreateInstance_WhenDefaultConstructorIsInvoked()
        {
            // Arrange & Act
            var accController = new AccountController();

            // Assert
            Assert.IsInstanceOf<AccountController>(accController);
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
            var accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);

            // Assert
            Assert.IsInstanceOf<AccountController>(accController);
        }

        [TestCase("http://localhost:2500/Account/Login")]
        public void LoginShould_ReturnViewResult_WhenUrlIsSet(string url)
        {
            // Arrange
            var accController = new AccountController();

            // Act
            var result = accController.Login(url) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestCase("http://localhost:2500/Account/Login")]
        public void LoginShould_ReturnViewBagResult_WithProvidedUrl(string url)
        {
            // Arrange
            var accController = new AccountController();

            // Act
            var result = accController.Login(url) as ViewResult;

            // Assert
            Assert.AreEqual(url, result.ViewBag.ReturnUrl);
        }

        [Test]
        public void Login_ShouldReturnLoginViewModel_WhenModelStateIsNotValid()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<ApplicationUser>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            var mockedViewModel = new Mock<LoginViewModel>();
            var url = "http://localhost:2500/Account/Login";
            var accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);
            accController.ModelState.AddModelError("invalid", "invalid");

            // Act
            var actionResultTask = accController.Login(mockedViewModel.Object, url);
            actionResultTask.Wait();
            var viewResult = actionResultTask.Result as ViewResult;

            // Assert
            Assert.IsInstanceOf<LoginViewModel>(viewResult.Model);
        }

        [Test]
        public void Login_ShouldReturnActionResult_WhenPasswordSignInAsyncIsSuccess()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<ApplicationUser>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            mockedSignInManager.Setup(x => x.PasswordSignInAsync("gosho", "123456", true, false)).Verifiable();

            var mockedViewModel = new Mock<LoginViewModel>();
            var url = "http://localhost:2500/Account/Login";
            var accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);

            // Act
            var actionResultTask = accController.Login(mockedViewModel.Object, url);

            // Assert
            Assert.IsNotNull(actionResultTask);
        }

        [Test]
        public void Login_ShouldReturnActionResult_WhenPasswordSignInAsyncIsLockedOut()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<ApplicationUser>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            mockedSignInManager.Setup(x => x.PasswordSignInAsync(null, null, false, false)).ReturnsAsync(SignInStatus.LockedOut).Verifiable();

            var mockedViewModel = new Mock<LoginViewModel>();
            var url = "http://localhost:2500/Account/Login";
            var accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);

            // Act
            var actionResultTask = accController.Login(mockedViewModel.Object, url);

            // Assert
            Assert.IsNotNull(actionResultTask.Result);
        }

        [Test]
        public void Login_ShouldReturnActionResult_WhenPasswordSignInAsyncIsRequiresVerification()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<ApplicationUser>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            mockedSignInManager.Setup(x => x.PasswordSignInAsync(null, null, false, false)).ReturnsAsync(SignInStatus.RequiresVerification).Verifiable();

            var mockedViewModel = new Mock<LoginViewModel>();
            var url = "http://localhost:2500/Account/Login";
            var accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);

            // Act
            var actionResultTask = accController.Login(mockedViewModel.Object, url);

            // Assert
            Assert.IsNotNull(actionResultTask.Result);
        }

        [Test]
        public void Login_ShouldReturnActionResult_WhenPasswordSignInAsyncIsFailure()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<ApplicationUser>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            mockedSignInManager.Setup(x => x.PasswordSignInAsync(null, null, false, false)).ReturnsAsync(SignInStatus.Failure).Verifiable();

            var mockedViewModel = new Mock<LoginViewModel>();
            var url = "http://localhost:2500/Account/Login";
            var accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);

            // Act
            var actionResultTask = accController.Login(mockedViewModel.Object, url);
            actionResultTask.Wait();
            var viewResult = actionResultTask.Result as ViewResult;

            // Assert
            Assert.IsInstanceOf<LoginViewModel>(viewResult.Model);
        }

        [Test]
        public void Properties_ShouldSetSignInManagerProperty_WhenOverloadConstructorIsInvoked()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<ApplicationUser>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            // Act
            AccountController accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);

            // Assert
            Assert.AreEqual(mockedSignInManager.Object, accController.SignInManager);
        }

        [Test]
        public void Properties_ShouldSetUserManagerProperty_WhenOverloadConstructorIsInvoked()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<ApplicationUser>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            // Act
            var accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);

            // Assert
            Assert.AreEqual(mockedUserManager.Object, accController.UserManager);
        }

        [Test]
        public void RegisterShould_ReturnViewResult_WhenRegisterIsCalled()
        {
            // Arrange
            var accController = new AccountController();

            // Act
            var result = accController.Register() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void RegisterShould_ReturnRegisterViewModel_WhenModelStateIsNotValid()
        {
            // Arrange
            var mockedUserManager = new Mock<ApplicationUserManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>();

            var mockedViewModel = new Mock<RegisterViewModel>();
            AccountController accController = new AccountController();
            accController.ModelState.AddModelError("invalid", "invalid");

            // Act
            var actionResultTask = accController.Register(mockedViewModel.Object);
            actionResultTask.Wait();
            var viewResult = actionResultTask.Result as ViewResult;

            // Assert
            Assert.IsInstanceOf<RegisterViewModel>(viewResult.Model);
        }

        [Test]
        public void Register_ShouldReturnViewResult_WhenRegisterIsCalled()
        {
            // Arrange
            var accController = new AccountController();

            // Act
            var result = accController.Register() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Register_ShouldReturnRegisterViewModel_WhenModelStateIsNotValid()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<ApplicationUser>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            var mockedViewModel = new Mock<RegisterViewModel>();
            var accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);
            accController.ModelState.AddModelError("invalid", "invalid");

            // Act
            var actionResultTask = accController.Register(mockedViewModel.Object);
            actionResultTask.Wait();
            var viewResult = actionResultTask.Result as ViewResult;

            // Assert
            Assert.IsInstanceOf<RegisterViewModel>(viewResult.Model);
        }

        [Test]
        public void LogOffShould_ShouldRedirectToMainPage()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<ApplicationUser>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            mockedAuthenticationManager.Setup(am => am.SignOut());
            mockedAuthenticationManager.Setup(am => am.SignIn());

            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            var mockedViewModel = new Mock<RegisterViewModel>();
            var accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);
            accController.AuthenticationManager = mockedAuthenticationManager.Object;

            // Act & Assert
            accController.WithCallTo(c => c.LogOff())
                .ShouldRedirectTo<HomeController>(typeof(HomeController).GetMethod("Index"));
        }

        [Test]
        public void CallSignOutMethodOfAuthManager()
        {
            // Arrange
            var mockedStore = new Mock<IUserStore<ApplicationUser>>();
            var mockedUserManager = new Mock<ApplicationUserManager>(mockedStore.Object);

            var mockedAuthenticationManager = new Mock<IAuthenticationManager>();
            mockedAuthenticationManager.Setup(am => am.SignOut());
            mockedAuthenticationManager.Setup(am => am.SignIn());

            var mockedSignInManager = new Mock<ApplicationSignInManager>(mockedUserManager.Object, mockedAuthenticationManager.Object);

            var mockedViewModel = new Mock<RegisterViewModel>();
            var accController = new AccountController(mockedUserManager.Object, mockedSignInManager.Object);
            accController.AuthenticationManager = mockedAuthenticationManager.Object;

            // Act
            accController.LogOff();

            // Assert
            mockedAuthenticationManager
                .Verify(m => m.SignOut(It.IsAny<string>()), Times.Once());
        }
    }
}
