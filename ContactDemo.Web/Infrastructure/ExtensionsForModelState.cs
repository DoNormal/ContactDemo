using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;

using FluentValidation.Results;

namespace ContactDemo.Web.Infrastructure
{
    /// <summary>
    /// Handy extension methods for the <c>ModelStateDictionary</c> class.
    /// </summary>
    public static class ExtensionsForModelState
    {
        /// <summary>
        /// Adds the specified validation errors to the model state.
        /// </summary>
        /// <param name="modelState">The model state to change.</param>
        /// <param name="errors">The validation errors.</param>
        /// <param name="prefix">
        /// Prefix that was used to bind date. Use <c>null</c> or an empty string in case no prefix was used.
        /// </param>
        public static void AddModelErrors(this ModelStateDictionary modelState, IEnumerable<ValidationFailure> errors, string prefix)
        {
            foreach (var error in errors)
            {
                string key = String.IsNullOrWhiteSpace(prefix) ? error.PropertyName : prefix + "." + error.PropertyName;
                if (modelState.ContainsKey(key) && modelState[key].Errors.Count > 0)
                    continue;

                modelState.AddModelError(key, error.ErrorMessage);
                /* To work around an issue with MVC: SetModelValue must be called if AddModelError is called. */
                modelState.SetModelValue(key, new ValueProviderResult(error.AttemptedValue ?? "", (error.AttemptedValue ?? "").ToString(), CultureInfo.CurrentCulture));
            }
        }
    }
}