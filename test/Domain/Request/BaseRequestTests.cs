using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XSwift.Domain;

namespace XSwift.Test.Domain
{
    [TestClass]
    public class BaseRequestTests
    {
        public class TestBaseRequest : BaseRequest { }

        [TestMethod]
        public void BaseRequest_Initialization_Should_SetValidationState()
        {
            // Arrange
            var request = new TestBaseRequest();

            // Act
            var validationState = request.ValidationState;

            // Assert
            validationState.Should().NotBeNull();
        }
    }
}
