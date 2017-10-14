namespace SociumApp.Tests.WebClient.Tests.ViewModels.Tests
{
    using CommonNews.Web.ViewModels.Manage;
    using NUnit.Framework;

    [TestFixture]
    public class ManageViewModelsTests
    {
        [Test]
        public void IndexViewModel_Constructor_Should_Return_Object()
        {
            // Arrange & Act
            IndexViewModel indexViewModel = new IndexViewModel();

            // Assert
            Assert.IsInstanceOf<IndexViewModel>(indexViewModel);
        }

        [TestCase("str1")]
        [TestCase("str2")]
        [TestCase("str3")]
        public void IndexViewModel_Should_Set_PhoneNumber(string str)
        {
            // Arrange
            IndexViewModel indexViewModel = new IndexViewModel();

            // Act
            indexViewModel.PhoneNumber = str;

            // Assert
            Assert.AreEqual(str, indexViewModel.PhoneNumber);
        }
    }
}
