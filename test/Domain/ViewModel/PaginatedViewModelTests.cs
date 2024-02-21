using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XSwift.Domain;

namespace XSwift.Test.Domain
{
    [TestClass]
    public class PaginatedViewModelTests
    {
        [TestMethod]
        public void PaginatedViewModel_ShouldCalculateTotalPagesCorrectly()
        {
            // Arrange
            var items = new List<int> { 1, 2, 3, 4, 5 };
            var numberOfTotalItems = items.Count;
            var pageSize = 2;
            var paginatedViewModel = new PaginatedViewModel<int>(items, numberOfTotalItems, pageSize: pageSize);

            // Act

            // Assert
            paginatedViewModel.TotalPages.Should().Be((int)Math.Ceiling(numberOfTotalItems / (double)pageSize));
        }

        [TestMethod]
        public void PaginatedViewModel_HasPreviousPage_ShouldReturnTrueWhenPageNumberIsGreaterThanOne()
        {
            // Arrange
            var items = new List<int> { 1, 2, 3, 4, 5 };
            var numberOfTotalItems = items.Count;
            var pageNumber = 2;
            var paginatedViewModel = new PaginatedViewModel<int>(items, numberOfTotalItems, pageNumber: pageNumber);

            // Act

            // Assert
            paginatedViewModel.HasPreviousPage.Should().BeTrue();
        }

        [TestMethod]
        public void PaginatedViewModel_HasPreviousPage_ShouldReturnFalseWhenPageNumberIsOne()
        {
            // Arrange
            var items = new List<int> { 1, 2, 3, 4, 5 };
            var numberOfTotalItems = items.Count;
            var pageNumber = 1;
            var paginatedViewModel = new PaginatedViewModel<int>(items, numberOfTotalItems, pageNumber: pageNumber);

            // Act

            // Assert
            paginatedViewModel.HasPreviousPage.Should().BeFalse();
        }

        [TestMethod]
        public void PaginatedViewModel_HasNextPage_ShouldReturnTrueWhenPageNumberIsLessThanTotalPages()
        {
            // Arrange
            var items = new List<int> { 1, 2, 3, 4, 5 };
            var numberOfTotalItems = items.Count;
            var pageNumber = 1;
            var pageSize = 2;
            var paginatedViewModel = new PaginatedViewModel<int>(items, numberOfTotalItems, pageNumber: pageNumber, pageSize: pageSize);

            // Act

            // Assert
            paginatedViewModel.HasNextPage.Should().BeTrue();
        }

        [TestMethod]
        public void PaginatedViewModel_HasNextPage_ShouldReturnFalseWhenPageNumberEqualsTotalPages()
        {
            // Arrange
            var items = new List<int> { 1, 2, 3, 4, 5 };
            var numberOfTotalItems = items.Count;
            var pageNumber = 3;
            var pageSize = 2;
            var paginatedViewModel = new PaginatedViewModel<int>(items, numberOfTotalItems, pageNumber: pageNumber, pageSize: pageSize);

            // Act

            // Assert
            paginatedViewModel.HasNextPage.Should().BeFalse();
        }
    }
}
