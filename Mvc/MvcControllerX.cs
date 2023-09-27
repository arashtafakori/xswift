using XSwift.Base;
using XSwift.Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Web;

namespace XSwift.Mvc
{
    /// <summary>
    /// If the ErrorHandlingMode is NoHandleDomainErrorsGlobally,
    /// It means that just technical errors will be handled globally, 
    /// other error wich related to domain (Logical and validation
    /// and invariant errors) will be returned.
    /// </summary>
    public enum ErrorHandlingMode
    {
        HandleAllErrorsGlobally,
        NoHandleDomainErrorsGlobally,
        NoHandleErrorsGlobally
    }

    public abstract class MvcControllerX : Controller
    {
        [NonAction]
        public async Task<IActionResult> View(Func<Task> action,
            ErrorHandlingMode errorHandlingMode = ErrorHandlingMode.HandleAllErrorsGlobally)
        {
            try
            {
                await action();
                return NoContent();
            }
            catch (Exception ex)
            {
                if (ex is ErrorException
                    && ((ErrorException)ex).Error.Issues.OfType<NoEntityWasFound>().Any())
                    return NotFound();

                if (errorHandlingMode == ErrorHandlingMode.HandleAllErrorsGlobally)
                    throw;

                if (errorHandlingMode == ErrorHandlingMode.NoHandleErrorsGlobally ||
                    (errorHandlingMode == ErrorHandlingMode.NoHandleDomainErrorsGlobally &&
                     (((ErrorException)ex).Error.ErrorType == ErrorType.Logical ||
                     ((ErrorException)ex).Error.ErrorType == ErrorType.Validation ||
                     ((ErrorException)ex).Error.ErrorType == ErrorType.Invariant)))
                {
                    var devError = ErrorHelper.GetDevError(ex);
                    if (OptionsX.Global.Environment.State == EnvironmentState.Production)
                        return StatusCode(500, (Error)devError);
                    return StatusCode(500, devError);
                }

                throw;
            }
        }
        [NonAction]
        public async Task<ActionResult<T>> View<T>(Func<Task<T>> action,
            ErrorHandlingMode errorHandlingMode = ErrorHandlingMode.HandleAllErrorsGlobally)
        {
            try
            {
                return await action();
            }
            catch (Exception ex)
            {
                if (ex is ErrorException
                    && ((ErrorException)ex).Error.Issues.OfType<NoEntityWasFound>().Any())
                    return NotFound();

                if (errorHandlingMode == ErrorHandlingMode.HandleAllErrorsGlobally)
                    throw;

                if (errorHandlingMode == ErrorHandlingMode.NoHandleErrorsGlobally ||
                    (errorHandlingMode == ErrorHandlingMode.NoHandleDomainErrorsGlobally &&
                     (((ErrorException)ex).Error.ErrorType == ErrorType.Logical ||
                     ((ErrorException)ex).Error.ErrorType == ErrorType.Validation ||
                     ((ErrorException)ex).Error.ErrorType == ErrorType.Invariant)))
                {
                    var devError = ErrorHelper.GetDevError(ex);
                    if (OptionsX.Global.Environment.State == EnvironmentState.Production)
                        return StatusCode(500, (Error)devError);
                    return StatusCode(500, devError);
                }

                throw;
            }
        }

        [NonAction]
        public async Task<Error?> CatchDomainErrors(Func<Task> action)
        {
            try
            {
                await action();
                return null;
            }
            catch (Exception ex)
            {
                var devError = ErrorHelper.GetDevError(ex);
                if (OptionsX.Global.Environment.State == EnvironmentState.Production)
                    return (Error)devError;
                return devError;
            }
        }

        [NonAction]
        public TRequest GetRequest<TRequest>()
        {
            var dict = HttpUtility.ParseQueryString(HttpContext.Request.QueryString.ToString());
            string json = JsonConvert.SerializeObject(dict.Cast<string>()
                .ToDictionary(k => k, v => dict[v]));
            return JsonConvert.DeserializeObject<TRequest>(json)!;
        }
    }
}
