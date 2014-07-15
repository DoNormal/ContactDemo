using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ContactDemo.Web.Infrastructure
{
    /// <summary>
    /// The main HTTP application.
    /// </summary>
    public class MainApplication : HttpApplication
    {
        /// <summary>
        /// Handles the application start event.
        /// </summary>
        protected void Application_Start()
        {
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}