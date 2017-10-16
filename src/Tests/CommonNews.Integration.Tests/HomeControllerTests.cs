namespace CommonNews.Integration.Tests
{
    using Data.Common;
    using Data.Models;
    using NUnit.Framework;
    using Services.Data;
    using Web.Controllers;
    using System.Reflection;
    using Web.Infrastructure.Mapping;

    [SetUpFixture]
    public class TestsInitializer
    {
        [OneTimeSetUp]
        public void Init()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(Assembly.GetExecutingAssembly());
        }
    }

    [TestFixture]
    public class HomeControllerIntegrationTests
    {
        [Test]
        public void Constructor_ShouldReturnObject()
        {
            // Arrange
            var context = new MsSqlDbContext();
            var saveContext = new SaveContext(context);
            var repo = new EfRepository<Post>(context);
            var postService = new DataService<Post>(repo, saveContext);
            var mapper = AutoMapperConfig.Configuration.CreateMapper();

            // Act
            var controller = new HomeController(postService, mapper);

            // Assert
            Assert.IsInstanceOf<HomeController>(controller);
        }
    }
}
