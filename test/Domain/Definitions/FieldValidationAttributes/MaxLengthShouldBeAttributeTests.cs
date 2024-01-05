using FluentAssertions;
using XSwift.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XSwift.Base;

namespace XSwift.Test.Domain
{
    [TestClass]
    public class MaxLengthShouldBeAttributeTests
    {
        [TestMethod]
        public void IsValid_Should_ReturnTrue_When_ValueIsNull()
        {
            // Arrange
            var maxLengthAttribute = new MaxLengthShouldBeAttribute(10);

            // Act
            var isValid = maxLengthAttribute.IsValid(null);

            // Assert
            isValid.Should().BeTrue();
        }

        [TestMethod]
        public void IsValid_Should_ReturnTrue_When_StringLengthIsWithinLimit()
        {
            // Arrange
            var maxLengthAttribute = new MaxLengthShouldBeAttribute(10);

            // Act
            var isValid = maxLengthAttribute.IsValid("1234567890");

            // Assert
            isValid.Should().BeTrue();
        }

        [TestMethod]
        public void IsValid_Should_ReturnTrue_When_ArrayLengthIsWithinLimit()
        {
            // Arrange
            var maxLengthAttribute = new MaxLengthShouldBeAttribute(3);

            // Act
            var isValid = maxLengthAttribute.IsValid(new int[] { 1, 2, 3 });

            // Assert
            isValid.Should().BeTrue();
        }

        [TestMethod]
        public void IsValid_Should_ReturnFalse_When_StringLengthExceedsLimit()
        {
            // Arrange
            var maxLengthAttribute = new MaxLengthShouldBeAttribute(5);

            // Act
            var isValid = maxLengthAttribute.IsValid("123456");

            // Assert
            isValid.Should().BeFalse();
        }

        [TestMethod]
        public void Validate_Should_AddIssue_When_ValidationFails()
        {
            // Arrange
            var maxLengthAttribute = new MaxLengthShouldBeAttribute(3);
            var issues = new List<IIssue>();

            // Act
            maxLengthAttribute.Validate("12345", issues);

            // Assert
            issues.Should().HaveCount(1);
            issues[0].Should().BeOfType<FieldLengthIsMoreThanMaximumLengthLimit>();
        }

        [TestMethod]
        public void EnsureLengthsIsAllowed_Should_ThrowException_When_LengthIsZero()
        {
            // Arrange
            var maxLengthAttribute = new MaxLengthShouldBeAttribute(0);

            // Act and Assert
            Action act = () => maxLengthAttribute.Invoking(a => a.EnsureLengthsIsAllowed()).Should().Throw<InvalidOperationException>();
        }

        [TestMethod]
        public void EnsureLengthsIsAllowed_Should_ThrowException_When_LengthIsNegative()
        {
            // Arrange
            var maxLengthAttribute = new MaxLengthShouldBeAttribute(-1);

            // Act and Assert
            Action act = () => maxLengthAttribute.Invoking(a => a.EnsureLengthsIsAllowed()).Should().Throw<InvalidOperationException>();
        }

        [TestMethod]
        public void EnsureLengthsIsAllowed_Should_NotThrowException_When_LengthIsPositive()
        {
            // Arrange
            var maxLengthAttribute = new MaxLengthShouldBeAttribute(5);

            // Act and Assert
            maxLengthAttribute.Invoking(a => a.EnsureLengthsIsAllowed()).Should().NotThrow();
        }
    }
}
