using XSwift.Base;
using XSwift.Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Web;

namespace XSwift.Mvc
{

    public abstract class ApiControllerX : Controller
    {
        [NonAction]
        public async Task<IActionResult> View(Func<Task> action)
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

                throw;
            }
        }
        [NonAction]
        public async Task<ActionResult<T>> View<T>(Func<Task<T>> action)
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

                throw;
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
