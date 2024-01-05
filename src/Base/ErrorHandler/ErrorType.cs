namespace XSwift.Base
{
    /// <summary>
    /// Represents the type of an error in the application.
    /// </summary>
    public enum ErrorType
    {
        /// <summary>
        /// Represents a technical error, often related to infrastructure or system-level issues.
        /// </summary>
        Technical,

        /// <summary>
        /// Represents a logical error, indicating issues related to business logic or application flow.
        /// </summary>
        Logical,

        /// <summary>
        /// Represents an invariant error, denoting violations of expected conditions or assumptions in a domain model.
        /// </summary>
        Invariant,

        /// <summary>
        /// Represents a validation error, indicating issues related to input or data validation for a request.
        /// </summary>
        Validation
    }
}
