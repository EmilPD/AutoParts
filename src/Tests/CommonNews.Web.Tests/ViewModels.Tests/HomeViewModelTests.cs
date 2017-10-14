namespace CommonNews.Web.Tests.ViewModels.Tests
{
    using System.Collections.Generic;
    using Moq;
    using NUnit.Framework;
    using Web.ViewModels.Home;
    using Web.ViewModels.Post;

    [TestFixture]
    public class HomeViewModelTests
    {
        [Test]
        public void HomeViewModel_ShouldSet_Posts()
        {
            // Arrange
            var mockList = new Mock<ICollection<PostViewModel>>();
            var homeViewModel = new HomeViewModel();

            // Act
            homeViewModel.Posts = mockList.Object;

            // Assert
            Assert.AreEqual(mockList.Object, homeViewModel.Posts);
        }

        [Test]
        public void HomeViewModel_ShouldGet_Posts()
        {
            // Arrange
            var mockList = new Mock<ICollection<PostViewModel>>();
            var homeViewModel = new HomeViewModel();
            homeViewModel.Posts = mockList.Object;

            // Act
            var result = homeViewModel.Posts;

            // Assert
            Assert.AreEqual(mockList.Object, result);
        }
    }
}
