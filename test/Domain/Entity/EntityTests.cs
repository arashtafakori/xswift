using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XSwift.Domain;

namespace XSwift.Test.Domain
{
    [TestClass]
    public class EntityTests
    {
        public class MyEntity : Entity<MyEntity, int>
        {
        }

        [TestMethod]
        public void SetId_Should_Set_Id_Property()
        {
            // Arrange
            var entity = new MyEntity();
            var newId = 42;

            // Act
            entity.SetId(newId);

            // Assert
            entity.Id.Should().Be(newId);
        }

        [TestMethod]
        public void Id_Property_Should_Have_Required_Attribute()
        {
            // Arrange
            var propertyInfo = typeof(MyEntity).GetProperty("Id");

            // Act & Assert
            propertyInfo.Should().BeDecoratedWith<RequiredAttribute>();
        }
    }
}
