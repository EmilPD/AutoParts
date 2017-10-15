namespace CommonNews.Web.Tests.Helpers
{
    using NUnit.Framework;
    using Web.Helpers;

    [TestFixture]
    public class StringExtensionsTests
    {
        [Test]
        public void Limit_ShouldReturnNewStringContainingDots_WhenInputIsBigger()
        {
            // Arrange
            var str = "dalag text";
            var expected = "dalag...";

            // Act
            var result = StringExtensions.Limit(str, 5);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
