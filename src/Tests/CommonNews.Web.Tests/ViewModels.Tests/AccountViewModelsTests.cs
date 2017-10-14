namespace SociumApp.Tests.WebClient.Tests.ViewModels.Tests
{
    using CommonNews.Web.ViewModels.Account;
    using NUnit.Framework;

    [TestFixture]
    public class AccountViewModelsTests
    {
        [TestCase("str1")]
        [TestCase("str2")]
        [TestCase("str3")]
        public void LoginModel_Should_Set_Username(string str)
        {
            // Arrange
            LoginViewModel loginViewModel = new LoginViewModel();

            // Act
            loginViewModel.Username = str;

            // Assert
            Assert.AreEqual(loginViewModel.Username, str);
        }

        [TestCase("str1")]
        [TestCase("str2")]
        [TestCase("str3")]
        public void LoginModel_Should_Set_Password(string str)
        {
            // Arrange
            LoginViewModel loginViewModel = new LoginViewModel();

            // Act
            loginViewModel.Password = str;

            // Assert
            Assert.AreEqual(loginViewModel.Password, str);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void LoginModel_Should_Set_RememberMe(bool val)
        {
            // Arrange
            LoginViewModel loginViewModel = new LoginViewModel();

            // Act
            loginViewModel.RememberMe = val;

            // Assert
            Assert.AreEqual(loginViewModel.RememberMe, val);
        }

        [TestCase("str1")]
        [TestCase("str2")]
        [TestCase("str3")]
        public void RegisterViewModel_Should_Set_Email(string str)
        {
            // Arrange
            RegisterViewModel registerViewModel = new RegisterViewModel();

            // Act
            registerViewModel.Email = str;

            // Assert
            Assert.AreEqual(registerViewModel.Email, str);
        }

        [TestCase("str1")]
        [TestCase("str2")]
        [TestCase("str3")]
        public void RegisterViewModel_Should_Set_Password(string str)
        {
            // Arrange
            RegisterViewModel registerViewModel = new RegisterViewModel();

            // Act
            registerViewModel.Password = str;

            // Assert
            Assert.AreEqual(registerViewModel.Password, str);
        }

        [TestCase("str1")]
        [TestCase("str2")]
        [TestCase("str3")]
        public void RegisterViewModel_Should_Set_ConfirmPassword(string str)
        {
            // Arrange
            RegisterViewModel registerViewModel = new RegisterViewModel();

            // Act
            registerViewModel.ConfirmPassword = str;

            // Assert
            Assert.AreEqual(registerViewModel.ConfirmPassword, str);
        }
    }
}
