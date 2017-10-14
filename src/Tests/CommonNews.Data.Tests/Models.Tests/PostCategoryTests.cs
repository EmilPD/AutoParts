namespace CommonNews.Data.Tests.Models.Tests
{
    using System.Collections.Generic;
    using Moq;
    using NUnit.Framework;
    using Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;

    [TestFixture]
    public class PostCategoryTests
    {
        [Test]
        public void PostCategoryModel_ShouldSet_Posts()
        {
            // Arrange
            var mockList = new Mock<ICollection<Post>>();
            var postCategoryModel = new PostCategory();

            // Act
            postCategoryModel.Posts = mockList.Object;

            // Assert
            Assert.AreEqual(mockList.Object, postCategoryModel.Posts);
        }

        [TestCase("str1")]
        [TestCase("str2")]
        [TestCase("str3")]
        public void PostCategoryModel_ShouldSet_Name(string name)
        {
            // Arrange
            var postCategoryModel = new PostCategory();

            // Act
            postCategoryModel.Name = name;

            // Assert
            Assert.AreEqual(name, postCategoryModel.Name);
        }
    }
}