namespace CommonNews.Data.Tests.Models.Tests
{
    using System.Collections.Generic;
    using Moq;
    using NUnit.Framework;
    using Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;

    [TestFixture]
    public class PostTests
    {
        [Test]
        public void PostModel_ShouldSet_Comments()
        {
            // Arrange
            var mockList = new Mock<ICollection<Comment>>();
            var postModel = new Post();

            // Act
            postModel.Comments = mockList.Object;

            // Assert
            Assert.AreEqual(mockList.Object, postModel.Comments);
        }

        [Test]
        public void PostModel_ShouldSet_Category()
        {
            // Arrange
            var mockCategory = new Mock<PostCategory>();
            var postModel = new Post();

            // Act
            postModel.Category = mockCategory.Object;

            // Assert
            Assert.AreEqual(mockCategory.Object, postModel.Category);
        }

        [Test]
        public void PostModel_ShouldSet_Author()
        {
            // Arrange
            var mockAuthor = new Mock<ApplicationUser>();
            var postModel = new Post();

            // Act
            postModel.Author = mockAuthor.Object;

            // Assert
            Assert.AreEqual(mockAuthor.Object, postModel.Author);
        }

        [TestCase("str1")]
        [TestCase("str2")]
        [TestCase("str3")]
        public void PostModel_ShouldSet_ImageUrl(string imageUrl)
        {
            // Arrange
            var postModel = new Post();

            // Act
            postModel.ImageUrl = imageUrl;

            // Assert
            Assert.AreEqual(imageUrl, postModel.ImageUrl);
        }

        [TestCase("str1")]
        [TestCase("str2")]
        [TestCase("str3")]
        public void PostModel_ShouldSet_Content(string content)
        {
            // Arrange
            var postModel = new Post();

            // Act
            postModel.Content = content;

            // Assert
            Assert.AreEqual(content, postModel.Content);
        }

        [TestCase("str1")]
        [TestCase("str2")]
        [TestCase("str3")]
        public void PostModel_ShouldSet_Title(string title)
        {
            // Arrange
            var postModel = new Post();

            // Act
            postModel.Title = title;

            // Assert
            Assert.AreEqual(title, postModel.Title);
        }
    }
}
