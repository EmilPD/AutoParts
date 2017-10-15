namespace CommonNews.Services.Data.Tests
{
    using System;
    using Common.Contracts;
    using CommonNews.Data.Common.Contracts;
    using CommonNews.Data.Models;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class DataServiceTests
    {
        [Test]
        public void Constructor_ShouldCreateInstance_WhenParameterIEfRepositoryIsPassedCorrectly()
        {
            // Arrange
            var repoMock = new Mock<IEfRepository<Post>>();
            var saveContextMock = new Mock<ISaveContext>();

            // Act
            var postsService = new DataService<Post>(repoMock.Object, saveContextMock.Object);

            // Assert
            Assert.IsInstanceOf<IDataService<Post>>(postsService);
        }

        [Test]
        public void GetAll_Should_InvokeOnlyOnce()
        {
            // Arrange
            var repoMock = new Mock<IEfRepository<Post>>();
            var saveContextMock = new Mock<ISaveContext>();

            var postsService = new DataService<Post>(repoMock.Object, saveContextMock.Object);

            // Act
            postsService.GetAll();

            // Assert
            repoMock.Verify(p => p.All(), Times.Once);
        }

        [Test]
        public void Update_Should_InvokeOnlyOnce()
        {
            // Arrange
            var repoMock = new Mock<IEfRepository<Post>>();
            var saveContextMock = new Mock<ISaveContext>();

            var postsService = new DataService<Post>(repoMock.Object, saveContextMock.Object);
            var post = new Post { Id = 1 };

            // Act
            postsService.Update(post);

            // Assert
            repoMock.Verify(p => p.Update(It.IsAny<Post>()), Times.Once);
        }

        [Test]
        public void Add_Should_InvokeOnlyOnce()
        {
            // Arrange
            var repoMock = new Mock<IEfRepository<Post>>();
            var saveContextMock = new Mock<ISaveContext>();

            var postsService = new DataService<Post>(repoMock.Object, saveContextMock.Object);
            var post = new Post { Id = 1 };

            // Act
            postsService.Add(post);

            // Assert
            repoMock.Verify(p => p.Add(It.IsAny<Post>()), Times.Once);
        }

        [Test]
        public void Delete_Should_ThrowWhenIdIsInvalid()
        {
            // Arrange
            var repoMock = new Mock<IEfRepository<Post>>();
            var saveContextMock = new Mock<ISaveContext>();

            var postsService = new DataService<Post>(repoMock.Object, saveContextMock.Object);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => postsService.Delete(1));
        }

        [Test]
        public void PropertySaveContext_ShouldBeSame_AsInjectedInConstructor()
        {
            // Arrange
            var repoMock = new Mock<IEfRepository<Post>>();
            var saveContextMock = new Mock<ISaveContext>();

            var postsService = new DataService<Post>(repoMock.Object, saveContextMock.Object);

            // Act
            var prop = postsService.Context;

            // Assert
            Assert.AreEqual(prop, saveContextMock.Object);
        }

        [Test]
        public void PropertyIEfRepository_ShouldBeSame_AsInjectedInConstructor()
        {
            // Arrange
            var repoMock = new Mock<IEfRepository<Post>>();
            var saveContextMock = new Mock<ISaveContext>();

            var postsService = new DataService<Post>(repoMock.Object, saveContextMock.Object);

            // Act
            var prop = postsService.Data;

            // Assert
            Assert.AreEqual(prop, repoMock.Object);
        }

        [Test]
        public void Get_Should_InvokeGetAllOnce()
        {
            // Arrange
            var repoMock = new Mock<IEfRepository<Post>>();
            var saveContextMock = new Mock<ISaveContext>();

            var postsService = new DataService<Post>(repoMock.Object, saveContextMock.Object);

            // Act
            postsService.Get(5);

            // Assert
            repoMock.Verify(r => r.All(), Times.Once);
        }

        [Test]
        public void GetById_Should_InvokeGetByIdOnce()
        {
            // Arrange
            var repoMock = new Mock<IEfRepository<Post>>();
            var saveContextMock = new Mock<ISaveContext>();

            var postsService = new DataService<Post>(repoMock.Object, saveContextMock.Object);
            var post = new Post { Id = 1 };

            // Act
            postsService.GetById(post);

            // Assert
            repoMock.Verify(r => r.GetById(It.IsAny<Post>()), Times.Once);
        }

        [Test]
        public void Save_Should_InvokeOnlyOnce()
        {
            // Arrange
            var repoMock = new Mock<IEfRepository<Post>>();
            var saveContextMock = new Mock<ISaveContext>();

            var postsService = new DataService<Post>(repoMock.Object, saveContextMock.Object);
            var post = new Post { Id = 1 };

            // Act
            postsService.Save();

            // Assert
            saveContextMock.Verify(c => c.Commit(), Times.Once);
        }
    }
}
