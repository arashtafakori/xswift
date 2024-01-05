using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XSwift.Domain;

namespace XSwift.Test.Domain
{
    [TestClass]
    public class BaseQueryItemRequestByKeyTests
    {
        public class TestQueryItemRequest : BaseQueryItemRequestByKey<int, string>
        {
            public TestQueryItemRequest(int keyValue) : base(keyValue) { }
        }

        [TestMethod]
        public void Constructor_Should_Set_KeyValue()
        {
            // Arrange
            var keyValue = 42;

            // Act
            var queryItemRequest = new TestQueryItemRequest(keyValue);

            // Assert
            queryItemRequest.KeyValue.Should().Be(keyValue);
        }

        [TestMethod]
        public void SetKeyValue_Should_Update_KeyValue()
        {
            // Arrange
            var queryItemRequest = new TestQueryItemRequest(42);
            var newKeyValue = 100;

            // Act
            queryItemRequest.SetKeyValue(newKeyValue);

            // Assert
            queryItemRequest.KeyValue.Should().Be(newKeyValue);
        }

        [TestMethod]
        public void SetKeyValue_Should_Enable_Fluent_Chaining()
        {
            // Arrange
            var queryItemRequest = new TestQueryItemRequest(42);
            var newKeyValue = 100;

            // Act
            var result = queryItemRequest.SetKeyValue(newKeyValue);

            // Assert
            result.Should().BeSameAs(queryItemRequest);
        }
    }
}
