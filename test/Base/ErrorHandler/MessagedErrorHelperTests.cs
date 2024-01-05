using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XSwift.Base;
using XSwift.Domain;

namespace XSwift.Test.Base
{
    public class ValidationA : ValidationIssue
    {
        public ValidationA(
            string entityName = "",
            string description = "Description of Validation A") :
            base(outerDescription: description)
        {
        }
    }
    public class ValidationB : ValidationIssue
    {
        public ValidationB(
            string entityName = "",
            string description = "Description of Validation B") :
            base(outerDescription: description)
        {
        }
    }

    [TestClass]
    public class MessagedErrorHelperTests
    {
        //[TestMethod]
        //public void RetrieveError_ShouldReturnError_WhenValidSerializedErrorProvided()
        //{
        //    var issues = new List<BaseIssue>
        //    {
        //        new ValidationA (),
        //        new ValidationB ()
        //    };

        //    var error = new Error(
        //        service: "TestService",
        //        errorType: ErrorType.Validation,
        //        issues: issues);

        //    var errorMessage = MessagedErrorHelper.ConvertToErrorMessage(error);

        //    // Act
        //    var retrievedError = MessagedErrorHelper.RetrieceError(errorMessage);

        //    // Assert
        //    retrievedError.Should().NotBeNull();
        //    retrievedError!.ErrorType.Should().Be(ErrorType.Validation);
        //    retrievedError.Issues.Should().HaveCount(2);
        //    retrievedError.Issues.Should().Contain(issue => issue.Name == "XSwift.Test.Base.ErrorHandler.ValidationA" && issue.Description == "Description of Validation A");
        //    retrievedError.Issues.Should().Contain(issue => issue.Name == "XSwift.Test.Base.ErrorHandler.ValidationB" && issue.Description == "Description of Validation B");
        //}

        [TestMethod]
        public void RetrieveError_ShouldReturnNull_WhenInvalidSerializedErrorProvided()
        {
            // Arrange
            var invalidErrorMessage = "This is not a valid error message.";

            // Act
            var retrievedError = MessagedErrorHelper.RetrieceError(invalidErrorMessage);

            // Assert
            retrievedError.Should().BeNull();
        }

        [TestMethod]
        public void IsErrorException_ShouldReturnTrue_WhenValidSerializedErrorProvided()
        {
            // Arrange
            var issues = new List<IIssue>
            {
                new ValidationA (),
                new ValidationB ()
            };

            var error = new Error(
                service: "TestService",
                errorType: ErrorType.Validation,
                issues: issues);

            var errorMessage = MessagedErrorHelper.ConvertToErrorMessage(error);

            // Act
            var isErrorException = MessagedErrorHelper.IsErrorException(errorMessage);

            // Assert
            isErrorException.Should().BeTrue();
        }

        [TestMethod]
        public void IsErrorException_ShouldReturnFalse_WhenInvalidSerializedErrorProvided()
        {
            // Arrange
            var invalidErrorMessage = "This is not a valid error message.";

            // Act
            var isErrorException = MessagedErrorHelper.IsErrorException(invalidErrorMessage);

            // Assert
            isErrorException.Should().BeFalse();
        }
    }
}
