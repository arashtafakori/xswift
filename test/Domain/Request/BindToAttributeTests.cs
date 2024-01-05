using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XSwift.Domain;

namespace XSwift.Test.Domain
{
    [TestClass]
    public class BindToAttributeTests
    {
        public class TestClass
        {
            [BindTo(typeof(TargetClass), nameof(TargetClass.TargetProperty))]
            public required string SourceProperty { get; set; }
        }

        public class TargetClass
        {
            public required string TargetProperty { get; set; }
        }

        [TestMethod]
        public void BindToAttribute_Should_HaveCorrectProperties()
        {
            // Arrange
            var property = typeof(TestClass).GetProperty(nameof(TestClass.SourceProperty));

            // Act
            var bindToAttribute = property!.GetCustomAttributes(typeof(BindToAttribute), false)[0] as BindToAttribute;

            // Assert
            bindToAttribute.Should().NotBeNull();
            bindToAttribute!.TargetType.Should().Be(typeof(TargetClass));
            bindToAttribute.TargetPropertyName.Should().Be(nameof(TargetClass.TargetProperty));
        }
    }
}
