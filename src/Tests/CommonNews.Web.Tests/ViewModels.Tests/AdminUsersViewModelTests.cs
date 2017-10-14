namespace CommonNews.Web.Tests.ViewModels.Tests
{
    using Areas.Admin.Models;
    using NUnit.Framework;

    [TestFixture]
    public class AdminUsersViewModelTests
    {
        [TestCase("str1")]
        [TestCase("str2")]
        [TestCase("str3")]
        public void AdminUsersViewModel_ShouldSet_Id(string id)
        {
            // Arrange
            var adminUsersViewModel = new UsersViewModel();

            // Act
            adminUsersViewModel.Id = id;

            // Assert
            Assert.AreEqual(id, adminUsersViewModel.Id);
        }

        [TestCase("str1")]
        [TestCase("str2")]
        [TestCase("str3")]
        public void AdminUsersViewModel_ShouldSet_Email(string email)
        {
            // Arrange
            var adminUsersViewModel = new UsersViewModel();

            // Act
            adminUsersViewModel.Email = email;

            // Assert
            Assert.AreEqual(email, adminUsersViewModel.Email);
        }

        [TestCase("str1")]
        [TestCase("str2")]
        [TestCase("str3")]
        public void AdminUsersViewModel_ShouldSet_UserName(string userName)
        {
            // Arrange
            var adminUsersViewModel = new UsersViewModel();

            // Act
            adminUsersViewModel.UserName = userName;

            // Assert
            Assert.AreEqual(userName, adminUsersViewModel.UserName);
        }
    }
}
