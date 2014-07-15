using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

using FluentValidation.Results;

using ContactDemo.Web.Infrastructure;

namespace ContactDemo.Web.Controllers
{
    /// <summary>
    /// A base controller for handy functions that are shared by all controllers.
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// Redirect a successfully processed request to the specified url, with the 
        /// specified confirmation key.
        /// </summary>
        /// <param name="url">The url to redirect to.</param>
        /// <param name="confirmationKey">The key of the confirmation message.</param>
        /// <returns>An action result that redirects to the url.</returns>
        public ActionResult RedirectSuccess(string url, string confirmationKey)
        {
            TempData[confirmationKey] = true;

            return Redirect(url);
        }

        /// <summary>
        /// Redirects a failed request to the specified url, putting the specified
        /// errors in the ModelState.
        /// </summary>
        /// <param name="url">The url to redirect to.</param>
        /// <param name="errors">The validation errors.</param>
        /// <returns>An action result that redirects to the url.</returns>
        public ActionResult RedirectError(string url, IEnumerable<ValidationFailure> errors)
        {
            return this.RedirectError(url, errors, "");
        }

        /// <summary>
        /// Redirects a failed request to the specified url, putting the specified
        /// errors in the ModelState with the specified prefix.
        /// </summary>
        /// <param name="url">The url to redirect to.</param>
        /// <param name="errors">The validation errors.</param>
        /// <param name="modelPrefix">The prefix that was used to bind the model.</param>
        /// <returns>An action result that redirects to the url.</returns>
        public ActionResult RedirectError(string url, IEnumerable<ValidationFailure> errors, string modelPrefix)
        {
            ModelState.AddModelErrors(errors, modelPrefix);
            return Redirect(url);
        }
	}
}