namespace CommonNews.Data.Tests.Models.Tests
{
    using System.Collections.Generic;
    using Moq;
    using NUnit.Framework;
    using Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;

    [TestFixture]
    public class CommentTests
    {
        [Test]
        public void CommentModel_ShouldSet_Post()
        {
            // Arrange
            var mockPost = new Mock<Post>();
            var commentModel = new Comment();

            // Act
            commentModel.Post = mockPost.Object;

            // Assert
            Assert.AreEqual(mockPost.Object, commentModel.Post);
        }

        [Test]
        public void CommentModel_ShouldSet_Author()
        {
            // Arrange
            var mockAuthor = new Mock<ApplicationUser>();
            var commentModel = new Comment();

            // Act
            commentModel.Author = mockAuthor.Object;

            // Assert
            Assert.AreEqual(mockAuthor.Object, commentModel.Author);
        }

        [TestCase("str1")]
        [TestCase("str2")]
        [TestCase("str3")]
        public void CommentModel_ShouldSet_Content(string content)
        {
            // Arrange
            var commentModel = new Comment();

            // Act
            commentModel.Content = content;

            // Assert
            Assert.AreEqual(content, commentModel.Content);
        }
    }
}
