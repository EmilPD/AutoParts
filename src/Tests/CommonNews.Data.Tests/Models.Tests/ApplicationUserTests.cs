namespace CommonNews.Data.Tests.Models.Tests
{
    using System.Collections.Generic;
    using Moq;
    using NUnit.Framework;
    using Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;

    [TestFixture]
    public class ApplicationUserTests
    {
        [Test]
        public void ConstructorWhenCreatingNewUser_ShouldInheritsIdentityUserClass()
        {
            // Arrange & Act
            var user = new ApplicationUser();

            // Assert
            Assert.IsInstanceOf(typeof(IdentityUser), user);
        }

        [Test]
        public void ApplicationUserModel_ShouldSet_Comments()
        {
            // Arrange
            var mockList = new Mock<ICollection<Comment>>();
            var applicationUserModel = new ApplicationUser();

            // Act
            applicationUserModel.Comments = mockList.Object;

            // Assert
            Assert.AreEqual(mockList.Object, applicationUserModel.Comments);
        }

        [Test]
        public void ApplicationUserModel_ShouldSet_Posts()
        {
            // Arrange
            var mockList = new Mock<ICollection<Post>>();
            var applicationUserModel = new ApplicationUser();

            // Act
            applicationUserModel.Posts = mockList.Object;

            // Assert
            Assert.AreEqual(mockList.Object, applicationUserModel.Posts);
        }

        [Test]
        public void Constructor_WhenInvoked_ShouldSetPropertyCreatedOn()
        {
            // Arrange & Act
            var user = new ApplicationUser();

            // Assert
            Assert.IsAssignableFrom(typeof(DateTime), user.CreatedOn);
        }

        [Test]
        public void Constructor_WhenInvoked_ShouldNotSetPropertyDeletedOn()
        {
            // Arrange & Act
            var user = new ApplicationUser();

            // Assert
            Assert.IsNull(user.DeletedOn);
        }

        [Test]
        public void Constructor_WhenInvoked_ShouldNotSetPropertyModifiedOn()
        {
            // Arrange & Act
            var user = new ApplicationUser();

            // Assert
            Assert.IsNull(user.ModifiedOn);
        }

        [Test]
        public void Constructor_WhenInvoked_ShouldNotSetPropertyIsDeleted()
        {
            // Arrange & Act
            var user = new ApplicationUser();

            // Assert
            Assert.IsFalse(user.IsDeleted);
        }
    }
}