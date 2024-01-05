using System.Linq.Expressions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XSwift.Domain;

namespace XSwift.Test.Domain
{
    [TestClass]
    public class ConditionPropertyTests
    {
        public class SampleEntity
        {
            public bool SomeProperty { get; set; }
        }

        [TestMethod]
        public void ConditionProperty_WithCondition_ShouldHaveCorrectCondition()
        {
            // Arrange
            Expression<Func<SampleEntity, bool>> expectedCondition = entity => entity.SomeProperty;

            // Act
            var conditionProperty = new ConditionProperty<SampleEntity>
            {
                Condition = expectedCondition,
                Description = "Some description"
            };

            // Assert
            conditionProperty.Condition.Should().BeEquivalentTo(expectedCondition);
        }

        [TestMethod]
        public void ConditionProperty_WithDescription_ShouldHaveCorrectDescription()
        {
            // Arrange
            string expectedDescription = "Some description";

            // Act
            var conditionProperty = new ConditionProperty<SampleEntity>
            {
                Condition = entity => entity.SomeProperty,
                Description = expectedDescription
            };

            // Assert
            conditionProperty.Description.Should().Be(expectedDescription);
        }

        [TestMethod]
        public void ConditionProperty_WithoutCondition_ShouldBeNull()
        {
            // Act
            var conditionProperty = new ConditionProperty<SampleEntity>
            {
                Description = "Some description"
            };

            // Assert
            conditionProperty.Condition.Should().BeNull();
        }
    }
}
