//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using XSwift.Domain;

//namespace XSwift.Test.Base
//{
//    public class ValidationTest : ValidationIssue
//    {
//        public ValidationTest(
//            string entityName = "",
//            string description = "Description of ValidationTest") :
//            base(outerDescription: description)
//        {
//        }
//    }

//    [TestClass]
//    public class ErrorHelperTests
//    {
//        [TestMethod]
//        public void GetDevError_ShouldReturnDevErrorForErrorException_WhenErrorExceptionIsProvided()
//        {
//            // Arrange
//            var expectedEnvironmentState = EnvironmentState.Development;
//            var serviceName = "TestService";
//            var exceptionMessage = "This is an error exception.";

//            var issues = new List<BaseIssue>
//            {
//                new ValidationTest ()
//            };

//            var error = new Error(
//                service: serviceName,
//                errorType: ErrorType.Validation,
//                issues: issues);

//            var errorException = new ErrorException(error);

//            // Act
//            var devError = ErrorHelper.GetDevError(errorException);

//            // Assert
//            devError.Should().NotBeNull();
//            devError!.EnvironmentState.Should().Be(expectedEnvironmentState);
//            devError.Service.Should().Be(serviceName);
//            devError.ErrorType.Should().Be(ErrorType.Validation);
//            devError.Issues.Should().HaveCount(1);
//            devError.StackTrace.Should().NotBeNull();
//        }

//        [TestMethod]
//        public void GetDevError_ShouldReturnTechnicalDevError_WhenNonErrorExceptionIsProvided()
//        {
//            // Arrange
//            var expectedEnvironmentState = EnvironmentState.Development;
//            var serviceName = "TestService";
//            var exceptionMessage = "This is a test exception message.";
//            var genericException = new Exception(exceptionMessage);

//            // Act
//            var devError = ErrorHelper.GetDevError(genericException);

//            // Assert
//            devError.Should().NotBeNull();
//            devError!.EnvironmentState.Should().Be(expectedEnvironmentState);
//            devError.Service.Should().Be(serviceName);
//            devError.ErrorType.Should().Be(ErrorType.Technical);
//            devError.Issues.Should().HaveCount(1);
//            devError.StackTrace.Should().NotBeNull();
//        }
//    }
//}
