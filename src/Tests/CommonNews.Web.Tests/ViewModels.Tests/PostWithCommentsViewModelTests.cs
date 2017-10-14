namespace CommonNews.Web.Tests.ViewModels.Tests
{
    using System.Collections.Generic;
    using Moq;
    using NUnit.Framework;
    using Web.ViewModels.Comment;
    using Web.ViewModels.Post;

    [TestFixture]
    public class PostWithCommentsViewModelTests
    {
        [Test]
        public void PostWithCommentsViewModel_ShouldSet_Comments()
        {
            // Arrange
            var mockList = new Mock<ICollection<CommentViewModel>>();
            var postWithCommentsViewModel = new PostWithCommentsViewModel();

            // Act
            postWithCommentsViewModel.Comments = mockList.Object;

            // Assert
            Assert.AreEqual(mockList.Object, postWithCommentsViewModel.Comments);
        }

        [Test]
        public void PostWithCommentsViewModel_ShouldSet_Post()
        {
            // Arrange
            var mockPost = new Mock<PostViewModel>();
            var postWithCommentsViewModel = new PostWithCommentsViewModel();

            // Act
            postWithCommentsViewModel.Post = mockPost.Object;

            // Assert
            Assert.AreEqual(mockPost.Object, postWithCommentsViewModel.Post);
        }
    }
}
