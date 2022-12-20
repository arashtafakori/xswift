using System.Text.Json;
using MassTransit;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace CoreX.Structure
{
    public static class ErrorContext
    {
        internal static bool IsMultipleError(string jsonString)
        {
            if (jsonString.Contains(Constants.MULTIPPLE_ERROR))
                return true;

            return false;
        }
        internal static List<Error> GetErrorResults(
            string jsonString,
            object? stackTrace = null)
        {
            var errors = JsonSerializer.Deserialize
                <List<Error>>(jsonString.Substring(Constants.MULTIPPLE_ERROR.Length));

            foreach (var error in errors!)
            {
                var description = error.Description;
                error.ErrorType = DetectErrorType(description);
                error.Description = GetDescription(description);
                error.EnvironmentMode = Env.State;
                if (stackTrace != null)
                    error.StackTrace = stackTrace;
            }

            return errors!;
        }
        internal static ErrorType DetectErrorType(string description)
        {
            if (description.Contains(Constants.BUSINESSLIKE_ERROR))
                return ErrorType.BusinessLike;
            else if (description.Contains(Constants.VALIDATION_ERROR))
                return ErrorType.Validation;
            return ErrorType.Technical;
        }
        private static string GetCode(string code)
        {
            string exceptionName = nameof(Exception);
            if (code.Substring(code.Length - exceptionName.Length) == exceptionName)
                code = code.Substring(0, code.Length - exceptionName.Length);
            return code;
        }
        private static string GetDescription(string description)
        {
            if (description.Contains(Constants.BUSINESSLIKE_ERROR))
                return description.Substring(Constants.BUSINESSLIKE_ERROR.Length);
            if (description.Contains(Constants.VALIDATION_ERROR))
                return description.Substring(Constants.VALIDATION_ERROR.Length);
            return description;
        }
        public static List<Error> GetErrors(HttpContext context)
        {
            var exception = context.Features.Get<IExceptionHandlerPathFeature>().Error;
            return GetErrors(exception);
        }
        public static List<Error> GetErrors(Exception exception)
        {
            var errors = new List<Error>();

            if (exception is MultipleException)
            {
                errors = ((MultipleException)exception).GetErrorResults();
            }
            else
            {
                string code = "";
                string description = "";
                object? stackTrace = null;
                if (exception is RequestFaultException)
                {
                    var exp = exception as RequestFaultException;
                    stackTrace = exp!.Fault.Exceptions[0].StackTrace;
                    code = GetCode(exp!.Fault.Exceptions[0].ExceptionType.Split('.').Last());

                    if (IsMultipleError(exp.Fault.Exceptions[0].Message))
                    {
                        errors = GetErrorResults(
                            exp.Fault.Exceptions[0].Message, stackTrace);
                    }
                    else
                    {
                        description = exp.Fault.Exceptions[0].Message;

                        errors.Add(new Error(code,
                            GetDescription(description),
                            DetectErrorType(description),
                            Env.State,
                            stackTrace: stackTrace));
                    }
                }
                else
                {
                    var stack = new string[0];
                    if (!string.IsNullOrWhiteSpace(exception.StackTrace))
                        stack = exception.StackTrace.Trim().Split("\r\n");
                    stackTrace = stack;
                    code = GetCode(exception.GetType().Name);
                    description = exception.Message;


                    errors.Add(new Error(code,
                        GetDescription(description),
                        DetectErrorType(description),
                        Env.State,
                        stackTrace: stackTrace));
                }
            }

            return errors;
        }
    }
}
