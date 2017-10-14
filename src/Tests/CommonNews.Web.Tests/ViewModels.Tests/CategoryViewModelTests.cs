namespace CommonNews.Web.Tests.ViewModels.Tests
{
    using System.Collections.Generic;
    using Moq;
    using NUnit.Framework;
    using Web.ViewModels.Category;
    using Web.ViewModels.Post;

    [TestFixture]
    public class CategoryViewModelTests
    {
        [TestCase("str1")]
        [TestCase("str2")]
        [TestCase("str3")]
        public void CategoryViewModel_ShouldSet_Name(string str)
        {
            // Arrange
            var categoryViewModel = new CategoryViewModel();

            // Act
            categoryViewModel.Name = str;

            // Assert
            Assert.AreEqual(str, categoryViewModel.Name);
        }

        [Test]
        public void CategoryViewModel_ShouldSet_Posts()
        {
            // Arrange
            var mockList = new Mock<ICollection<PostViewModel>>();
            var categoryViewModel = new CategoryViewModel();

            // Act
            categoryViewModel.Posts = mockList.Object;

            // Assert
            Assert.AreEqual(mockList.Object, categoryViewModel.Posts);
        }

        [Test]
        public void CategoryViewModel_ShouldGet_Posts()
        {
            // Arrange
            var mockList = new Mock<ICollection<PostViewModel>>();
            var categoryViewModel = new CategoryViewModel();
            categoryViewModel.Posts = mockList.Object;

            // Act
            var result = categoryViewModel.Posts;

            // Assert
            Assert.AreEqual(mockList.Object, result);
        }
    }
}
