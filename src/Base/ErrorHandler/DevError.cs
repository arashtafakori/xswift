using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace XSwift.Base
{
    /// <summary>
    /// Represents a development-specific error, extending the base <see cref="Error"/> class
    /// with additional information such as stack trace and environment state.
    /// </summary>
    public class DevError : Error
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DevError"/> class with an existing <see cref="Error"/> instance.
        /// </summary>
        /// <param name="error">The base error instance to be extended.</param>
        /// <param name="environmentState">The environment state of the applicatin execution.</param>
        /// <param name="stackTrace">The stack trace associated with the error.</param>
        public DevError(
            Error error,
            EnvironmentState environmentState,
            object? stackTrace = null)
            : base(error.Service, error.ErrorType, error.Issues)
        {
            StackTrace = stackTrace;
            EnvironmentState = environmentState;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DevError"/> class with individual parameters.
        /// </summary>
        /// <param name="service">The name of the service where the error occurred.</param>
        /// <param name="errorType">The type of the error.</param>
        /// <param name="issues">A list of issues associated with the error.</param>
        /// <param name="environmentState">The environment state of the applicatin execution.</param>
        /// <param name="stackTrace">The stack trace associated with the error.</param>
        public DevError(
            string service,
            ErrorType errorType,
            List<IIssue> issues,
            EnvironmentState environmentState,
            object? stackTrace = null)
            : base(service, errorType, issues)
        {
            StackTrace = stackTrace;
            EnvironmentState = environmentState;
        }

        /// <inheritdoc/>
        [DataMember(Order = 1)]
        public override string? RequestId => base.RequestId;

        /// <inheritdoc/>
        [DataMember(Order = 2)]
        public override string Service => base.Service;

        /// <inheritdoc/>
        [DataMember(Order = 3)]
        public override string Type => base.Type;

        /// <summary>
        /// Gets the string representation of the environment state of the applicatin execution.
        /// </summary>
        [DataMember(Order = 4)]
        public string State { get { return EnvironmentState.ToString(); } }

        /// <inheritdoc/>
        [DataMember(Order = 5)]
        public override List<IIssue> Issues => base.Issues;

        /// <summary>
        /// Gets or sets the stack trace associated with the error.
        /// </summary>
        [DataMember(Order = 6)]
        public object? StackTrace { get; set; }

        /// <summary>
        /// Gets or sets the environment state of the applicatin execution.
        /// </summary>
        [JsonIgnore]
        public EnvironmentState EnvironmentState { get; set; }
    }
}
