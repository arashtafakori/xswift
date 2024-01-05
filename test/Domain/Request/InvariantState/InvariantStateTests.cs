using FluentAssertions;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using XSwift.Domain;

namespace XSwift.Test.Domain
{

    [TestClass]
    public class InvariantStateTests
    {
        private class TestEntity : Entity<TestEntity, Guid>, IAggregateRoot
        {
        }

        [TestMethod]
        public async Task AssestAsync_NoIssues_ShouldNotThrowException()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var invariantState = new InvariantState<TestEntity>();

            // Act
            await invariantState.AssestAsync(mediatorMock.Object);

            // Assert
            invariantState.GetIssues().Should().BeEmpty();
        }
    }
}
