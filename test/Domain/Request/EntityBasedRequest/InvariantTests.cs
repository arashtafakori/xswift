using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq.Expressions;
using XSwift.Base;
using XSwift.Domain;

namespace XSwift.Test.Domain
{
    [TestClass]
    public class InvariantTests
    {
        public class TestModel
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        [TestMethod]
        public void Constructor_Should_SetConditionAndIssue()
        {
            // Arrange
            Expression<Func<TestModel, bool>> condition = model => model.Age >= 18;
            IIssue issue = new InvariantIssue("Invalid Age", string.Empty);

            // Act
            var invariant = new Invariant<TestModel>(condition, issue);

            // Assert
            invariant.Condition.Should().Be(condition);
            invariant.Issue.Should().Be(issue);
        }
    }
}
