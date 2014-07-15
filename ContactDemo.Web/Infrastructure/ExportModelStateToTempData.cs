using System.Web.Mvc;

namespace ContactDemo.Web.Infrastructure
{
    /// <summary>
    /// Filter that exports the invalid model state to TempData for usage in the next GET request.
    /// </summary>
    /// <remarks>Part of the PRG-pattern. See: http://en.wikipedia.org/wiki/Post/Redirect/Get</remarks>
    public class ExportModelStateToTempData : ModelStateTempDataTransfer, IActionFilter
    {
        /// <summary>
        /// Called when the action is executing. Does nothing in this case.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }

        /// <summary>
        /// Called after the action is executed.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            /* Only export when ModelState is not valid */
            if (filterContext.Controller.ViewData.ModelState.IsValid)
                return;

            /* Export if we are redirecting. */
            if ((filterContext.Result is RedirectResult) || (filterContext.Result is RedirectToRouteResult))
            {
                filterContext.Controller.TempData[Key] = filterContext.Controller.ViewData.ModelState;
            }
        }
    }
}