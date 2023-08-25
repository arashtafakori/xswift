using CoreX.Base;
using CoreX.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CoreX.Web
{
    public abstract class CoreXApiController : ControllerBase
    {
        public async Task<IActionResult> ResloveIfAnEntityNotFound(Func<Task> func)
        {
            try
            {
                await func();
                return NoContent();
            }
            catch (ErrorException ex)
            {
                if (ex.Error.Issues.OfType<EntityWasNotFound>().Any())
                    return NotFound();
                else
                    throw ex;
            }
        }
        public async Task<ActionResult<T>> ResloveIfAnEntityNotFound<T>(Func<Task<T>> func)
        {
            try
            {
                return await func();
            }
            catch (ErrorException ex)
            {
                if (ex.Error.Issues.OfType<EntityWasNotFound>().Any())
                    return NotFound();
                else
                    throw ex;
            }
        }
    }
}
