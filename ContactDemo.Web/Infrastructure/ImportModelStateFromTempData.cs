using System.Web.Mvc;

namespace ContactDemo.Web.Infrastructure
{
    /// <summary>
    /// Filter that imports the temp data from a previous POST request to the model state.
    /// </summary>
    /// <remarks>Part of the PRG-pattern. See: http://en.wikipedia.org/wiki/Post/Redirect/Get</remarks>
    public class ImportModelStateFromTempData : ModelStateTempDataTransfer, IActionFilter
    {
        /// <summary>
        /// Called when the action is executing. Does nothing in this case.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }

        /// <summary>
        /// Called when the action is executed.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var modelState = filterContext.Controller.TempData[Key] as ModelStateDictionary;
            if (modelState == null)
                return;

            if (filterContext.Result is ViewResult)
            {
                filterContext.Controller.ViewData.ModelState.Merge(modelState);
                return;
            }

            filterContext.Controller.TempData.Remove(Key);
        }
    }
}