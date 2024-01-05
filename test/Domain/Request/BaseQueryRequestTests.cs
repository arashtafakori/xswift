using FluentAssertions;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XSwift.Domain;
using Moq;

namespace XSwift.Test.Domain
{
    [TestClass]
    public class BaseQueryRequestTests
    {
        public class TestQueryRequest : BaseQueryRequest<string> { }

        [TestMethod]
        public void Setup_Should_Set_PaginationSetting()
        {
            // Arrange
            var queryRequest = new TestQueryRequest();
            var paginationSetting = new PaginationSetting(2, 30);

            // Act
            queryRequest.Setup(paginationSetting);

            // Assert
            queryRequest.PaginationSetting.Should().Be(paginationSetting);
            queryRequest.PageNumber.Should().Be(paginationSetting.DefaultPageNumber);
            queryRequest.PageSize.Should().Be(paginationSetting.DefaultPageSize);
        }

        [TestMethod]
        public async Task ResolveAsync_Should_NotThrowException()
        {
            // Arrange
            var queryRequest = new TestQueryRequest();
            var mediatorMock = new Mock<IMediator>();

            // Act & Assert
            Func<Task> act = async () => await queryRequest.ResolveAsync(mediatorMock.Object);
            await act.Should().ThrowAsync<NotImplementedException>();
        }

        [TestMethod]
        public async Task NextAsync_Should_NotThrowException()
        {
            // Arrange
            var queryRequest = new TestQueryRequest();
            var mediatorMock = new Mock<IMediator>();
            var returnedValue = "test";

            // Act & Assert
            Func<Task> act = async () => await queryRequest.NextAsync(mediatorMock.Object, returnedValue);
            await act.Should().ThrowAsync<NotImplementedException>();
        }
    }
}
