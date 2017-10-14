namespace CommonNews.Web.Tests.ViewModels.Tests
{
    using System;
    using NUnit.Framework;
    using Web.ViewModels.Comment;

    [TestFixture]
    public class CommentViewModelTests
    {
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void CommentViewModel_ShouldSet_Id(int id)
        {
            // Arrange
            var commentViewModel = new CommentViewModel();

            // Act
            commentViewModel.Id = id;

            // Assert
            Assert.AreEqual(id, commentViewModel.Id);
        }

        [TestCase("str1")]
        [TestCase("str2")]
        [TestCase("str3")]
        public void CommentViewModel_ShouldSet_Content(string content)
        {
            // Arrange
            var commentViewModel = new CommentViewModel();

            // Act
            commentViewModel.Content = content;

            // Assert
            Assert.AreEqual(content, commentViewModel.Content);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void CommentViewModel_ShouldSet_PostId(int postId)
        {
            // Arrange
            var commentViewModel = new CommentViewModel();

            // Act
            commentViewModel.PostId = postId;

            // Assert
            Assert.AreEqual(postId, commentViewModel.PostId);
        }

        [TestCase("str1")]
        [TestCase("str2")]
        [TestCase("str3")]
        public void CommentViewModel_ShouldSet_AuthorUsername(string authorUsername)
        {
            // Arrange
            var commentViewModel = new CommentViewModel();

            // Act
            commentViewModel.AuthorUsername = authorUsername;

            // Assert
            Assert.AreEqual(authorUsername, commentViewModel.AuthorUsername);
        }

        [TestCase("10/10/2017")]
        [TestCase("10/12/2017")]
        [TestCase("10/11/2017")]
        public void CommentViewModel_ShouldSet_CommentedOn(DateTime commentedOn)
        {
            // Arrange
            var commentViewModel = new CommentViewModel();

            // Act
            commentViewModel.CommentedOn = commentedOn;

            // Assert
            Assert.AreEqual(commentedOn, commentViewModel.CommentedOn);
        }
    }
}
