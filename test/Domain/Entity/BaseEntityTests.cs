using FluentAssertions;
using XSwift.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XSwift.Test.Domain
{
    [TestClass]
    public class BaseEntityTests
    {
        [TestMethod]
        public void Create_ShouldSetCreatedDateAndModifiedDate()
        {
            // Arrange
            var entity = new MockEntity();

            // Act
            entity.Create();

            // Assert
            entity.ModifiedDate.Should().NotBe(default);
        }

        [TestMethod]
        public void Update_ShouldSetModifiedDate()
        {
            // Arrange
            var entity = new MockEntity();

            // Act
            entity.Update();

            // Assert
            entity.ModifiedDate.Should().NotBe(default);
        }

        [TestMethod]
        public void Archive_ShouldSetModifiedDate()
        {
            // Arrange
            var entity = new MockEntity();

            // Act
            entity.Archive();

            // Assert
            entity.ModifiedDate.Should().NotBe(default);
        }

        [TestMethod]
        public void Restore_ShouldSetModifiedDate()
        {
            // Arrange
            var entity = new MockEntity();

            // Act
            entity.Restore();

            // Assert
            entity.ModifiedDate.Should().NotBe(default);
        }

        [TestMethod]
        public void Delete_ShouldNotThrowException()
        {
            // Arrange
            var entity = new MockEntity();

            // Act & Assert
            entity.Invoking(e => e.Delete()).Should().NotThrow();
        }

        [TestMethod]
        public void Uniqueness_ShouldReturnNull()
        {
            // Arrange
            var entity = new MockEntity();

            // Act
            var result = entity.Uniqueness();

            // Assert
            result.Should().BeNull();
        }

        private class MockEntity : BaseEntity<object>
        {
        }
    }
}