namespace CommonNews.Data.Tests.Repository.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Data.Models;
    using Mock;
    using Moq;
    using NUnit.Framework;
    
    [TestFixture]
    public class EfRepositoryTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenContextIsNull()
        {
            //Arrange
            string expectedExceptionMessage = "argument is null";

            //Act & Assert
            var exc = Assert.Throws<ArgumentNullException>(() => { new EfRepository<Post>(null); });

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void Constructor_ShouldThrowArgumentException_WhenContextDbSetIsNull()
        {
            //Arrange
            var mockedDbContext = new Mock<MsSqlDbContext>();
            
            //Act & Assert
            Assert.Throws<ArgumentException>(() => { new EfRepository<Post>(mockedDbContext.Object); });
        }

        [Test]
        public void AllWithDeleted_ShouldReturn_DbSet()
        {
            //Arrange
            var posts = new List<Post>
            {
                new Post() {Id = 1, Title = "post", Content = "content"},
                new Post() {Id = 2, Title = "post", Content = "content"}
            };

            var mockedDbContext = new Mock<MsSqlDbContext>();
            var mockedPostSet = QueryableDbSetMock.GetQueryableMockDbSet<Post>(posts);

            mockedDbContext.Setup(c => c.Set<Post>()).Returns(mockedPostSet);
            mockedDbContext.Setup(c => c.Posts).Returns(mockedPostSet);

            var repositoryUnderTest = new EfRepository<Post>(mockedDbContext.Object);

            //Act
            var result = repositoryUnderTest.AllWithDeleted();

            //Assert
            Assert.AreEqual(result, mockedPostSet);
        }

        [Test]
        public void All_ShouldReturn_InstanceOfIQueryable()
        {
            //Arrange
            var posts = new List<Post>
            {
                new Post() {Id = 1, Title = "post", Content = "content"},
                new Post() {Id = 2, Title = "post", Content = "content"}
            };

            var mockedDbContext = new Mock<MsSqlDbContext>();
            var mockedPostSet = QueryableDbSetMock.GetQueryableMockDbSet<Post>(posts);

            mockedDbContext.Setup(c => c.Set<Post>()).Returns(mockedPostSet);
            mockedDbContext.Setup(c => c.Posts).Returns(mockedPostSet);

            var repositoryUnderTest = new EfRepository<Post>(mockedDbContext.Object);

            //Act
            var result = repositoryUnderTest.All();

            //Assert
            Assert.IsInstanceOf(typeof(IQueryable<Post>), result);
        }

        [Test]
        public void GetById_ShouldThrowArgumentNullException_WhenPassedEntityIsNull()
        {
            //Arrange
            var posts = new List<Post>
            {
                new Post() {Id = 1, Title = "post", Content = "content"},
                new Post() {Id = 2, Title = "post", Content = "content"}
            };

            var mockedDbContext = new Mock<MsSqlDbContext>();
            var mockedPostSet = QueryableDbSetMock.GetQueryableMockDbSet(posts);

            mockedDbContext.Setup(c => c.Set<Post>()).Returns(mockedPostSet);
            mockedDbContext.Setup(c => c.Posts).Returns(mockedPostSet);
            string expectedExceptionMessage = "null";

            var repositoryUnderTest = new EfRepository<Post>(mockedDbContext.Object);

            //Act & Assert
            var exc = Assert.Throws<ArgumentNullException>(() => repositoryUnderTest.GetById(null));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void GetById_ShouldReturnInstanceOfCorrectType_WhenIdIsValid()
        {
            // Arrange
            var posts = new List<Post>
            {
                new Post() {Id = 1, Title = "post", Content = "content"},
                new Post() {Id = 2, Title = "post", Content = "content"}
            };

            var mockedDbContext = new Mock<MsSqlDbContext>();
            var mockedPostSet = QueryableDbSetMock.GetQueryableMockDbSet(posts);

            mockedDbContext.Setup(c => c.Set<Post>()).Returns(mockedPostSet);
            mockedDbContext.Setup(c => c.Posts).Returns(mockedPostSet);
            mockedDbContext.SetupSet(c => c.Posts = mockedPostSet);

            var repositoryUnderTest = new EfRepository<Post>(mockedDbContext.Object);

            // Act
            var result = repositoryUnderTest.GetById(1);

            // Assert
            Assert.IsInstanceOf(typeof(Post), result);
        }

        [Test]
        public void Add_ShouldThrowArgumentNullException_WhenPassedEntityIsNull()
        {
            // Arrange
            var posts = new List<Post>
            {
                new Post() {Id = 1, Title = "post", Content = "content"},
                new Post() {Id = 2, Title = "post", Content = "content"}
            };

            var mockedDbContext = new Mock<MsSqlDbContext>();
            var mockedPostSet = QueryableDbSetMock.GetQueryableMockDbSet<Post>(posts);

            mockedDbContext.Setup(c => c.Set<Post>()).Returns(mockedPostSet);
            mockedDbContext.Setup(c => c.Posts).Returns(mockedPostSet);
            string expectedExceptionMessage = "entity";

            var repositoryUnderTest = new EfRepository<Post>(mockedDbContext.Object);

            // Act & Assert
            var exc = Assert.Throws<ArgumentNullException>(() => repositoryUnderTest.Add(null));

            // Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }
        
        [Test]
        public void Update_ShouldThrowArgumentNullException_WhenPassedEntityIsNull()
        {
            //Arrange
            var posts = new List<Post>
            {
                new Post() {Id = 1, Title = "post", Content = "content"},
                new Post() {Id = 2, Title = "post", Content = "content"}
            };

            var mockedDbContext = new Mock<MsSqlDbContext>();
            var mockedPostSet = QueryableDbSetMock.GetQueryableMockDbSet<Post>(posts);

            mockedDbContext.Setup(c => c.Set<Post>()).Returns(mockedPostSet);
            mockedDbContext.Setup(c => c.Posts).Returns(mockedPostSet);
            string expectedExceptionMessage = "entity";

            var repositoryUnderTest = new EfRepository<Post>(mockedDbContext.Object);

            //Act & Assert
            var exc = Assert.Throws<ArgumentNullException>(() => repositoryUnderTest.Update(null));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }
        
        [Test]
        public void Delete_ShouldThrowArgumentNullException_WhenPassedEntityIsNull()
        {
            //Arrange
            var posts = new List<Post>
            {
                new Post() {Id = 1, Title = "post", Content = "content"},
                new Post() {Id = 2, Title = "post", Content = "content"}
            };

            var mockedDbContext = new Mock<MsSqlDbContext>();
            var mockedPostSet = QueryableDbSetMock.GetQueryableMockDbSet<Post>(posts);

            mockedDbContext.Setup(c => c.Set<Post>()).Returns(mockedPostSet);
            mockedDbContext.Setup(c => c.Posts).Returns(mockedPostSet);
            string expectedExceptionMessage = "entity";

            var repositoryUnderTest = new EfRepository<Post>(mockedDbContext.Object);

            //Act & Assert
            var exc = Assert.Throws<ArgumentNullException>(() => repositoryUnderTest.Delete(null));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        [Test]
        public void Delete_ShouldSetIsDeleted_ToTrue()
        {
            //Arrange
            var posts = new List<Post>
            {
                new Post() {Id = 1, Title = "post", Content = "content"},
                new Post() {Id = 2, Title = "post", Content = "content"}
            };

            var mockedDbContext = new Mock<MsSqlDbContext>();
            var mockedPostSet = QueryableDbSetMock.GetQueryableMockDbSet(posts);

            mockedDbContext.Setup(c => c.Set<Post>()).Returns(mockedPostSet);
            mockedDbContext.Setup(c => c.Posts).Returns(mockedPostSet);

            var repositoryUnderTest = new EfRepository<Post>(mockedDbContext.Object);

            //Act
            repositoryUnderTest.Delete(posts[0]);

            //Assert
            Assert.AreEqual(posts[0].IsDeleted, true);
        }

        [Test]
        public void Delete_ShouldSet_DeletedOn()
        {
            //Arrange
            var posts = new List<Post>
            {
                new Post() {Id = 1, Title = "post", Content = "content"},
                new Post() {Id = 2, Title = "post", Content = "content"}
            };

            var mockedDbContext = new Mock<MsSqlDbContext>();
            var mockedPostSet = QueryableDbSetMock.GetQueryableMockDbSet(posts);

            mockedDbContext.Setup(c => c.Set<Post>()).Returns(mockedPostSet);
            mockedDbContext.Setup(c => c.Posts).Returns(mockedPostSet);

            var repositoryUnderTest = new EfRepository<Post>(mockedDbContext.Object);

            //Act
            repositoryUnderTest.Delete(posts[0]);

            //Assert
            Assert.IsAssignableFrom(typeof(DateTime), posts[0].DeletedOn);
        }
    }
}
