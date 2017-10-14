namespace CommonNews.Web.Tests.ViewModels.Tests
{
    using System.Collections.Generic;
    using Data.Models;
    using Moq;
    using NUnit.Framework;
    using Web.ViewModels.Post;

    [TestFixture]
    public class PostFormViewModelTests
    {
        [Test]
        public void PostFormViewModel_ShouldSet_Items()
        {
            // Arrange
            var mockList = new Mock<IEnumerable<PostCategory>>();
            var postFormViewModel = new PostFormViewModel();

            // Act
            postFormViewModel.Categories = mockList.Object;

            // Assert
            Assert.AreEqual(mockList.Object, postFormViewModel.Categories);
        }

        [Test]
        public void PostFormViewModel_ShouldSet_Post()
        {
            // Arrange
            var mockPost = new Mock<PostViewModel>();
            var postFormViewModel = new PostFormViewModel();

            // Act
            postFormViewModel.Post = mockPost.Object;

            // Assert
            Assert.AreEqual(mockPost.Object, postFormViewModel.Post);
        }
    }
}
