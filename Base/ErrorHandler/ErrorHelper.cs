using MassTransit;
using System.Reflection;

namespace XSwift.Base
{
    public static class ErrorHelper
    {
        public static DevError GetDevError(Exception exception)
        {
            return ConvertToError(exception);
        }
        private static DevError ConvertToError(Exception exception)
        {
            var stack = Array.Empty<string>();
            if (!string.IsNullOrWhiteSpace(exception.StackTrace))
                stack = exception.StackTrace.Trim().Split("\r\n");
            object? stackTrace = stack;

            if (exception is RequestFaultException)
            {
                var requestFaultException = exception as RequestFaultException;
                if (ExceptionHelper.IsErrorException(
                    requestFaultException!.Message))
                {
                    var error = ExceptionHelper.RetrieceError(
                        requestFaultException.Message);

                    if (error != null)
                        return new DevError(
                            ExceptionHelper.RetrieceError(
                                requestFaultException.Message)!,
                            OptionsX.Global.Environment.State,
                            stackTrace: stackTrace);
                }

                return MakeAnTechnicalError(
                    exception, 
                    serviceName: requestFaultException.Fault!.Host.Assembly!);
            }

            if (exception is ErrorException)
            {
                var errorException = exception as ErrorException;
                return new DevError(
                    errorException!.Error,
                    OptionsX.Global.Environment.State,
                    stackTrace: stackTrace);
            }

            return MakeAnTechnicalError(
                exception,
                serviceName: Assembly.GetEntryAssembly()!.GetName().Name!);
        }

        private static DevError MakeAnTechnicalError(
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
                environmentState: OptionsX.Global.Environment.State,
                stackTrace: stackTrace);
        }
    }
}
