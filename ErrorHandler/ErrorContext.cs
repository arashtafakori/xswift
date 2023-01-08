//using System.Text.Json;
//using MassTransit;
//using Microsoft.AspNetCore.Diagnostics;
//using Microsoft.AspNetCore.Http;

//namespace Artaware.Infrastructure.CoreX
//{
//    public static class ErrorContext
//    {
//        internal static bool IsMultipleError(string jsonString)
//        {
//            if (jsonString.Contains(nameof(ExceptionType.Multipile)))
//                return true;

//            return false;
//        }
//        internal static List<TraceableError> GetErrorResults(
//            string jsonString,
//            object? stackTrace = null)
//        {
//            var errors = JsonSerializer.Deserialize
//                <List<TraceableError>>(jsonString.Substring(nameof(ExceptionType.Multipile).Length));

//            foreach (var error in errors!)
//            {
//                var description = error.Description;
//                error.ErrorType = DetectErrorType(description);
//                error.Description = GetDescription(description);
//                error.EnvironmentState = CoreXOptions.Global.Environment.State;
//                if (stackTrace != null)
//                    error.StackTrace = stackTrace;
//            }

//            return errors!;
//        }
//        internal static ExceptionType DetectErrorType(string description)
//        {
//            if (description.Contains(nameof(ExceptionType.BusinessLike)))
//                return ExceptionType.BusinessLike;
//            else if (description.Contains(nameof(ExceptionType.Validation)))
//                return ExceptionType.Validation;
//            return ExceptionType.Technical;
//        }
//        private static string GetCode(string code)
//        {
//            string exceptionName = nameof(Exception);
//            if (code.Substring(code.Length - exceptionName.Length) == exceptionName)
//                code = code.Substring(0, code.Length - exceptionName.Length);
//            return code;
//        }
//        private static string GetDescription(string description)
//        {
//            if (description.Contains(nameof(ExceptionType.BusinessLike)))
//                return description.Substring(nameof(ExceptionType.BusinessLike).Length);
//            if (description.Contains(nameof(ExceptionType.Validation)))
//                return description.Substring(nameof(ExceptionType.Validation).Length);
//            return description;
//        }
//        public static List<TraceableError> GetErrors(HttpContext context)
//        {
//            var exception = context.Features.Get<IExceptionHandlerPathFeature>().Error;
//            return GetErrors(exception);
//        }
//        public static List<TraceableError> GetErrors(Exception exception)
//        {
//            var errors = new List<TraceableError>();

//            if (exception is MultipleException)
//            {
//                errors = ((MultipleException)exception).GetErrorResults();
//            }
//            else
//            {
//                string code = "";
//                string description = "";
//                object? stackTrace = null;
//                if (exception is RequestFaultException)
//                {
//                    var exp = exception as RequestFaultException;
//                    stackTrace = exp!.Fault.Exceptions[0].StackTrace;
//                    code = GetCode(exp!.Fault.Exceptions[0].ExceptionType.Split('.').Last());

//                    if (IsMultipleError(exp.Fault.Exceptions[0].Message))
//                    {
//                        errors = GetErrorResults(
//                            exp.Fault.Exceptions[0].Message, stackTrace);
//                    }
//                    else
//                    {
//                        description = exp.Fault.Exceptions[0].Message;

//                        errors.Add(new TraceableError(code,
//                            GetDescription(description),
//                            DetectErrorType(description),
//                            CoreXOptions.Global.Environment.State,
//                            stackTrace: stackTrace));
//                    }
//                }
//                else
//                {
//                    var stack = new string[0];
//                    if (!string.IsNullOrWhiteSpace(exception.StackTrace))
//                        stack = exception.StackTrace.Trim().Split("\r\n");
//                    stackTrace = stack;

//                    var a = exception.GetType();
//                    if (exception is ValidationException)
//                    {


//                        code = GetCode(exception.GetType().Name);
//                        description = exception.Message;


//                        errors.Add(new TraceableError(code,
//                            GetDescription(description),
//                            DetectErrorType(description),
//                            CoreXOptions.Global.Environment.State,
//                            stackTrace: stackTrace));
//                    }
//                    else
//                    {
//                        code = GetCode(exception.GetType().Name);
//                        description = exception.Message;


//                        errors.Add(new TraceableError(code,
//                            GetDescription(description),
//                            DetectErrorType(description),
//                            CoreXOptions.Global.Environment.State,
//                            stackTrace: stackTrace));
//                    }
//                }
//            }

//            return errors;
//        }
//    }
//}
