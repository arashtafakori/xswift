using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XSwift.Base;

namespace XSwift.Test.Base
{
    [TestClass]
    public class EnvironmentTests
    {
        [TestMethod]
        public void State_ShouldReturnDevelopment_WhenEnvironmentVariableIsDevelopment()
        {
            // Arrange
            SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
            var environment = new XSwift.Base.Environment();

            // Act
            var state = environment.State;

            // Assert
            state.Should().Be(EnvironmentState.Development);
        }

        [TestMethod]
        public void State_ShouldReturnProduction_WhenEnvironmentVariableIsProduction()
        {
            // Arrange
            SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Production");
            var environment = new XSwift.Base.Environment();

            // Act
            var state = environment.State;

            // Assert
            state.Should().Be(EnvironmentState.Production);
        }

        [TestMethod]
        public void State_ShouldReturnStaging_WhenEnvironmentVariableIsStaging()
        {
            // Arrange
            SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Staging");
            var environment = new XSwift.Base.Environment();

            // Act
            var state = environment.State;

            // Assert
            state.Should().Be(EnvironmentState.Staging);
        }

        [TestMethod]
        public void EnsureStateIsDevelopment_ShouldNotThrowException_WhenStateIsDevelopment()
        {
            // Arrange
            SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
            var environment = new XSwift.Base.Environment();

            // Act / Assert
            environment.EnsureStateIsDevelopment(); // No exception should be thrown
        }

        [TestMethod]
        public void EnsureStateIsDevelopment_ShouldThrowException_WhenStateIsNotDevelopment()
        {
            // Arrange
            SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Production");
            var environment = new XSwift.Base.Environment();

            // Act / Assert
            Action act = () => environment.EnsureStateIsDevelopment();
            act.Should().Throw<Exception>().WithMessage("The state of environment is not the development.");
        }

        [TestMethod]
        public void EnsureStateIsProduction_ShouldNotThrowException_WhenStateIsProduction()
        {
            // Arrange
            SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Production");
            var environment = new XSwift.Base.Environment();

            // Act / Assert
            environment.EnsureStateIsProduction(); // No exception should be thrown
        }

        [TestMethod]
        public void EnsureStateIsProduction_ShouldThrowException_WhenStateIsNotProduction()
        {
            // Arrange
            SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Staging");
            var environment = new XSwift.Base.Environment();

            // Act / Assert
            Action act = () => environment.EnsureStateIsProduction();
            act.Should().Throw<Exception>().WithMessage("The state of environment is not the production.");
        }

        [TestMethod]
        public void EnsureStateIsStaging_ShouldNotThrowException_WhenStateIsStaging()
        {
            // Arrange
            SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Staging");
            var environment = new XSwift.Base.Environment();

            // Act / Assert
            environment.EnsureStateIsStaging(); // No exception should be thrown
        }

        [TestMethod]
        public void EnsureStateIsStaging_ShouldThrowException_WhenStateIsNotStaging()
        {
            // Arrange
            SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
            var environment = new XSwift.Base.Environment();

            // Act / Assert
            Action act = () => environment.EnsureStateIsStaging();
            act.Should().Throw<Exception>().WithMessage("The state of environment is not the staging.");
        }

        private void SetEnvironmentVariable(string name, string value)
        {
            System.Environment.SetEnvironmentVariable(name, value);
        }
    }
}
