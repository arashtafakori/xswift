using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XSwift.Domain;

namespace XSwift.Test.Domain
{
    [TestClass]
    public class InvariantIssueTests
    {

        [TestMethod]
        public void Constructor_WithoutDescriptions_ShouldSetPropertiesWithDefaultDescriptions()
        {
            // Arrange

            // Act
            var invariantIssue = new InvariantIssue("", "");

            // Assert
            invariantIssue.Name.Should().Be(typeof(InvariantIssue).FullName);
            invariantIssue.Description.Should().Be("An invariant error has happened.");
        }
    }
}
