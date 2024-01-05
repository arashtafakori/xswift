using Microsoft.VisualStudio.TestTools.UnitTesting;
using XSwift.Domain;

namespace XSwift.Test.Domain
{
    public class TestEntity : Entity<TestEntity, Guid>, IAggregateRoot
    {
    }
    public class TestQueryRequest : QueryRequest<TestEntity>
    {
    }
    [TestClass]
    public class QueryRequestTests
    {
        [TestMethod]
        public void Setup_Should_Set_Pagination_Settings_If_PaginationSetting_Is_Provided()
        {
            // Arrange
            var queryRequest = new TestQueryRequest();
            var paginationSetting = new PaginationSetting(
                defaultPageNumber: 1, defaultPageSize: 10);

            // Act
            queryRequest.Setup(paginationSetting);

            // Assert
            Assert.AreEqual(1, queryRequest.PageNumber);
            Assert.AreEqual(10, queryRequest.PageSize);
        }
    }
}
