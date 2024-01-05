using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XSwift.Domain;

namespace XSwift.Test.Domain
{
    [TestClass]
    public class PaginationSettingTests
    {
        [TestMethod]
        public void PaginationSetting_Should_Have_Default_Values()
        {
            // Arrange
            // Act
            var paginationSetting = new PaginationSetting();

            // Assert
            paginationSetting.DefaultPageNumber.Should().Be(1);
            paginationSetting.DefaultPageSize.Should().Be(20);
        }

        [TestMethod]
        public void PaginationSetting_Should_Set_Custom_Values()
        {
            // Arrange
            int customPageNumber = 3;
            int customPageSize = 30;

            // Act
            var paginationSetting = new PaginationSetting(customPageNumber, customPageSize);

            // Assert
            paginationSetting.DefaultPageNumber.Should().Be(customPageNumber);
            paginationSetting.DefaultPageSize.Should().Be(customPageSize);
        }
    }
}
