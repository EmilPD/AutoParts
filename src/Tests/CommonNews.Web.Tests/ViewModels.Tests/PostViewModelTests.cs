namespace CommonNews.Web.Tests.ViewModels.Tests
{
    using System;
    using System.Collections.Generic;
    using Data.Models;
    using Moq;
    using NUnit.Framework;
    using Web.ViewModels.Comment;
    using Web.ViewModels.Post;

    [TestFixture]
    public class PostViewModelTests
    {
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void PostViewModel_ShouldSet_Id(int id)
        {
            // Arrange
            var postViewModel = new PostViewModel();

            // Act
            postViewModel.Id = id;

            // Assert
            Assert.AreEqual(id, postViewModel.Id);
        }

        [TestCase("str1")]
        [TestCase("str2")]
        [TestCase("str3")]
        public void PostViewModel_ShouldSet_Title(string title)
        {
            // Arrange
            var postViewModel = new PostViewModel();

            // Act
            postViewModel.Title = title;

            // Assert
            Assert.AreEqual(title, postViewModel.Title);
        }

        [TestCase("str1")]
        [TestCase("str2")]
        [TestCase("str3")]
        public void PostViewModel_ShouldSet_Content(string content)
        {
            // Arrange
            var postViewModel = new PostViewModel();

            // Act
            postViewModel.Content = content;

            // Assert
            Assert.AreEqual(content, postViewModel.Content);
        }

        [TestCase("str1")]
        [TestCase("str2")]
        [TestCase("str3")]
        public void PostViewModel_ShouldSet_ImageUrl(string imageUrl)
        {
            // Arrange
            var postViewModel = new PostViewModel();

            // Act
            postViewModel.ImageUrl = imageUrl;

            // Assert
            Assert.AreEqual(imageUrl, postViewModel.ImageUrl);
        }

        [TestCase("str1")]
        [TestCase("str2")]
        [TestCase("str3")]
        public void PostViewModel_ShouldSet_AuthorUsername(string authorUsername)
        {
            // Arrange
            var postViewModel = new PostViewModel();

            // Act
            postViewModel.AuthorUsername = authorUsername;

            // Assert
            Assert.AreEqual(authorUsername, postViewModel.AuthorUsername);
        }

        [TestCase("10/10/2017")]
        [TestCase("10/12/2017")]
        [TestCase("10/11/2017")]
        public void PostViewModel_ShouldSet_PostedOn(DateTime postedOn)
        {
            // Arrange
            var postViewModel = new PostViewModel();

            // Act
            postViewModel.PostedOn = postedOn;

            // Assert
            Assert.AreEqual(postedOn, postViewModel.PostedOn);
        }

        [Test]
        public void PostViewModel_ShouldSet_Comments()
        {
            // Arrange
            var mockList = new Mock<ICollection<CommentViewModel>>();
            var postViewModel = new PostViewModel();

            // Act
            postViewModel.Comments = mockList.Object;

            // Assert
            Assert.AreEqual(mockList.Object, postViewModel.Comments);
        }

        [Test]
        public void PostViewModel_ShouldSet_Category()
        {
            // Arrange
            var mockList = new Mock<PostCategory>();
            var postViewModel = new PostViewModel();

            // Act
            postViewModel.Category = mockList.Object;

            // Assert
            Assert.AreEqual(mockList.Object, postViewModel.Category);
        }
    }
}
