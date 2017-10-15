namespace CommonNews.Data.Tests
{
    using Common;
    using Data.Models;
    using Moq;
    using NUnit.Framework;
    using System.Data.Entity;

    [TestFixture]
    public class MsSqlDbContextTests
    {
        [Test]
        public void MsSqlDbContext_ShouldSet_Comments()
        {
            // Arrange
            var mockDbSet = new Mock<IDbSet<Comment>>();
            var msSqlDbContext = new MsSqlDbContext();

            // Act
            msSqlDbContext.Comments = mockDbSet.Object;

            // Assert
            Assert.AreEqual(mockDbSet.Object, msSqlDbContext.Comments);
        }

        [Test]
        public void MsSqlDbContext_ShouldSet_Posts()
        {
            // Arrange
            var mockDbSet = new Mock<IDbSet<Post>>();
            var msSqlDbContext = new MsSqlDbContext();

            // Act
            msSqlDbContext.Posts = mockDbSet.Object;

            // Assert
            Assert.AreEqual(mockDbSet.Object, msSqlDbContext.Posts);
        }

        [Test]
        public void MsSqlDbContext_ShouldSet_PostCategories()
        {
            // Arrange
            var mockDbSet = new Mock<IDbSet<PostCategory>>();
            var msSqlDbContext = new MsSqlDbContext();

            // Act
            msSqlDbContext.PostCategories = mockDbSet.Object;

            // Assert
            Assert.AreEqual(mockDbSet.Object, msSqlDbContext.PostCategories);
        }
    }
}
