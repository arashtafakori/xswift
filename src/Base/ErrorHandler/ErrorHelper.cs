using System.Reflection;

namespace XSwift.Base
{
    /// <summary>
    /// Helper class providing methods for working with errors and exceptions in the application.
    /// </summary>
    public static class ErrorHelper
    {
        /// <summary>
        /// Gets a development-specific error based on the provided exception.
        /// </summary>
        /// <param name="exception">The exception for which to cast a development-specific error.</param>
        /// <returns>A development-specific error instance.</returns>
        public static DevError GetDevError(Exception exception)
        {
            var stack = Array.Empty<string>();
            if (!string.IsNullOrWhiteSpace(exception.StackTrace))
                stack = exception.StackTrace.Trim().Split("\r\n");
            object? stackTrace = stack;

            if (exception is ErrorException)
            {
                var errorException = exception as ErrorException;
                return new DevError(
                    errorException!.Error,
                    XService.Environment.State,
                    stackTrace: stackTrace);
            }

            return CreateATechnicalError(
                exception,
                serviceName: Assembly.GetEntryAssembly()!.GetName().Name!);
        }

        private static DevError CreateATechnicalError(
            Exception exception, string serviceName)
        {
            var stack = Array.Empty<string>();
            if (!string.IsNullOrWhiteSpace(exception.StackTrace))
                stack = exception.StackTrace.Trim().Split("\r\n");
            object? stackTrace = stack;

            var issues = new List<IIssue>
            {
                new TechnicalIssue
                {
                    Name = exception.GetType().Name,
                    Description = exception.Message
                }
            };
            return new DevError(
                service: serviceName,
                errorType: ErrorType.Technical,
                issues: issues,
                environmentState: XService.Environment.State,
                stackTrace: stackTrace);
        }
    }
}
