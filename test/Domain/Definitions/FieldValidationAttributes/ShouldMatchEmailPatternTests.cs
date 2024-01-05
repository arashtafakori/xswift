using FluentAssertions;
using XSwift.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XSwift.Base;

namespace XSwift.Test.Domain
{
    [TestClass]
    public class ShouldMatchEmailPatternTests
    {
        [TestMethod]
        public void IsValid_Should_ReturnTrue_When_ValueIsNull()
        {
            // Arrange
            var emailPatternAttribute = new ShouldMatchEmailPattern();

            // Act
            var isValid = emailPatternAttribute.IsValid(null);

            // Assert
            isValid.Should().BeTrue();
        }

        [TestMethod]
        public void IsValid_Should_ReturnTrue_When_ValueIsAValidEmailAddress()
        {
            // Arrange
            var emailPatternAttribute = new ShouldMatchEmailPattern();

            // Act
            var isValid = emailPatternAttribute.IsValid("test@example.com");

            // Assert
            isValid.Should().BeTrue();
        }

        [TestMethod]
        public void IsValid_Should_ReturnFalse_When_ValueIsNotAValidEmailAddress()
        {
            // Arrange
            var emailPatternAttribute = new ShouldMatchEmailPattern();

            // Act
            var isValid = emailPatternAttribute.IsValid("invalid-email");

            // Assert
            isValid.Should().BeFalse();
        }

        [TestMethod]
        public void Validate_Should_AddIssue_When_ValidationFails()
        {
            // Arrange
            var emailPatternAttribute = new ShouldMatchEmailPattern();
            var issues = new List<IIssue>();

            // Act
            emailPatternAttribute.Validate("invalid-email", issues);

            // Assert
            issues.Should().HaveCount(1);
            issues[0].Should().BeOfType<FieldIsNotAValidEamilAddress>();
        }

        [TestMethod]
        public void CreateRegExForMatchingStandardEmail_Should_NotThrowException()
        {
            // Arrange
            Action act = () => ShouldMatchEmailPattern.CreateRegExForMatchingStandardEmail();

            // Act and Assert
            act.Should().NotThrow();
        }
    }
}
