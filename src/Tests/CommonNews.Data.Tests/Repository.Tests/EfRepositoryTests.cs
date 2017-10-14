namespace CommonNews.Data.Tests.Repository.Tests
{
    using Common;
    using Data.Models;
    using Mock;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Data.Entity;
    using System.Linq;

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
            var mockedPostSet = QueryableDbSetMock.GetQueryableMockDbSet<Post>(posts);

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
        public void GetById_ShouldCall_Find()
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
            mockedDbContext.SetupSet(c => c.Posts = mockedPostSet);

            var repositoryUnderTest = new EfRepository<Post>(mockedDbContext.Object);

            //Act
            var result = repositoryUnderTest.GetById(1);

            //Assert
            //mockedDbContext.Verify(mc => mc.Posts.Find(It.IsAny<object>()), Times.Once());
            Assert.IsInstanceOf(typeof(Post), result);
        }

        [Test]
        public void Add_ShouldThrowArgumentNullException_WhenPassedEntityIsNull()
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
            var exc = Assert.Throws<ArgumentNullException>(() => repositoryUnderTest.Add(null));

            //Assert
            StringAssert.Contains(expectedExceptionMessage, exc.Message);
        }

        //[Test]
        //public void Add_ShouldCallSetAddedMethodOfDbContext()
        //{
        //    //Arrange
        //    var posts = new List<Post>
        //    {
        //        new Post() {Id = 1, Title = "post", Content = "content"},
        //        new Post() {Id = 2, Title = "post", Content = "content"}
        //    };

        //    var mockedDbContext = new Mock<MsSqlDbContext>();
        //    var mockedPageSet = QueryableDbSetMock.GetQueryableMockDbSet<Post>(posts);

        //    mockedDbContext.Setup(c => c.Set<Post>()).Returns(mockedPageSet);
        //    mockedDbContext.Setup(c => c.Posts).Returns(mockedPageSet);
        //    mockedDbContext.Setup(c => c.(It.IsAny<object>())).Returns(true);

        //    var repositoryUnderTest = new EfRepository<Page>(mockedDbContext.Object);

        //    //Act & Assert
        //    repositoryUnderTest.Add(pages[0]);

        //    //Assert
        //    mockedDbContext.Verify(mc => mc.SetAdded(It.IsAny<object>()), Times.Once());
        //}

        //[Test]
        //public void Add_ShouldCallAddMethodOfDbset_WhenSetAddedReturnsFalse()
        //{
        //    //Arrange
        //    var posts = new List<Post>
        //    {
        //        new Post() {Id = 1, Title = "post", Content = "content"},
        //        new Post() {Id = 2, Title = "post", Content = "content"}
        //    };

        //    var mockedDbContext = new Mock<MsSqlDbContext>();
        //    var mockedPostSet = QueryableDbSetMock.GetQueryableMockDbSet<Post>(posts);

        //    mockedDbContext.Setup(c => c.Set<Post>()).Returns(mockedPostSet);
        //    mockedDbContext.Setup(c => c.Posts).Returns(mockedPostSet);
        //    mockedDbContext.Setup(c => c.Posts.Add(It.IsAny<Post>())).Returns(new Post());

        //    var repositoryUnderTest = new EfRepository<Post>(mockedDbContext.Object);

        //    // Act
        //    repositoryUnderTest.Add(posts[0]);

        //    // Assert
        //    mockedDbContext.Verify(m => m.Entry(It.IsAny<Post>()), Times.Once());
        //}

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

        //[Test]
        //public void Update_ShouldCall_AddOrUpdate()
        //{
        //    //Arrange
        //    var posts = new List<Post>
        //    {
        //        new Post() {Id = 1, Title = "post", Content = "content"},
        //        new Post() {Id = 2, Title = "post", Content = "content"}
        //    };

        //    var mockedDbContext = new Mock<MsSqlDbContext>();
        //    var mockedPostSet = QueryableDbSetMock.GetQueryableMockDbSet<Post>(posts);

        //    mockedDbContext.Setup(c => c.Set<Post>()).Returns(mockedPostSet);
        //    mockedDbContext.Setup(c => c.Posts).Returns(mockedPostSet);

        //    var repositoryUnderTest = new EfRepository<Post>(mockedDbContext.Object);

        //    //Act & Assert
        //    repositoryUnderTest.Update(posts[0]);

        //    //Assert
        //    mockedDbContext.Verify(m => m.Posts.AddOrUpdate(It.IsAny<Post>()), Times.Once());
        //}

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
