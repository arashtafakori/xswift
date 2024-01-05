using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XSwift.Base;

namespace XSwift.Test.Base
{
    [TestClass]
    public class DateTimeHelperTests
    {
        [TestMethod]
        public void UtcNow_Should_ReturnCurrentUtcDateTime()
        {
            // Act
            var utcNow = DateTimeHelper.UtcNow;

            // Assert
            utcNow.Should().BeCloseTo(
                DateTime.UtcNow, 
                precision: TimeSpan.FromMilliseconds(999));
        }
    }
}
