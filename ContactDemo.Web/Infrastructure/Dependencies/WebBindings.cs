using System.Net;
using System.Web.Mvc;

using Ninject.Modules;
using Ninject.Web.Mvc.FilterBindingSyntax;

namespace ContactDemo.Web.Infrastructure.Dependencies
{
    /// <summary>
    /// Defines the web app bindings for loading into the kernel.
    /// </summary>
    public class WebBindings : NinjectModule
    {
        /// <summary>
        /// Loads the web app bindings into the kernel.
        /// </summary>
        public override void Load()
        {
            /* Implementation of the PRG pattern for circumventing double postbacks 
             * See: http://en.wikipedia.org/wiki/Post/Redirect/Get */
            this.BindFilter<ImportModelStateFromTempData>(FilterScope.Action, 0).When(
                    (controllerContext, actionDescriptor) => controllerContext.HttpContext.Request.HttpMethod == WebRequestMethods.Http.Get);
            this.BindFilter<ExportModelStateToTempData>(FilterScope.Action, 0).When(
                (controllerContext, actionDescriptor) => controllerContext.HttpContext.Request.HttpMethod == WebRequestMethods.Http.Post);
        }
    }
}