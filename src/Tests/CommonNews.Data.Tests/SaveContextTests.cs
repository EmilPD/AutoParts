namespace CommonNews.Data.Tests
{
    using Common;
    using Moq;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class SaveContextTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenContextIsNull()
        {
            // Arrange
            MsSqlDbContext msSqlDbContext = null;
            
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new SaveContext(msSqlDbContext));
        }

        [Test]
        public void Commit_ShouldCall_SaveChanges()
        {
            // Arrange
            var mockContext = new Mock<MsSqlDbContext>();
            var saveContext = new SaveContext(mockContext.Object);

            // Act
            saveContext.Commit();

            // Assert
            mockContext.Verify(c => c.SaveChanges(), Times.Once());
        }
    }
}
