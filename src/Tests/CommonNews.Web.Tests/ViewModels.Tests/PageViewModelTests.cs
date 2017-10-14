namespace CommonNews.Web.Tests.ViewModels.Tests
{
    using System.Collections.Generic;
    using Common;
    using Moq;
    using NUnit.Framework;
    using Web.ViewModels.Pagination;
    using Web.ViewModels.Post;

    [TestFixture]
    public class PageViewModelTests
    {
        [Test]
        public void PageViewModel_ShouldSet_Items()
        {
            // Arrange
            var mockList = new Mock<IEnumerable<PostViewModel>>();
            var pageViewModel = new PageViewModel<PostViewModel>();

            // Act
            pageViewModel.Items = mockList.Object;

            // Assert
            Assert.AreEqual(mockList.Object, pageViewModel.Items);
        }

        [Test]
        public void PageViewModel_ShouldSet_Pagination()
        {
            // Arrange
            var mockPagination = new Mock<Pagination>(2, 2, 2);
            var pageViewModel = new PageViewModel<PostViewModel>();

            // Act
            pageViewModel.Pagination = mockPagination.Object;

            // Assert
            Assert.AreEqual(mockPagination.Object, pageViewModel.Pagination);
        }
    }
}
