using System.Web.Mvc;
using System.Web.Routing;

namespace ContactDemo.Tests.Web.Infrastructure
{
    public static class ViewHelpers
    {
        public static UrlHelper GetUrlHelper()
        {
            var httpContext = FakeHttpContext.New();
            var requestContext = new RequestContext(httpContext, new RouteData());
            var routes = new RouteCollection();
            if (routes["Default"] == null)
            {
                routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );
            }

            return new UrlHelper(requestContext, routes);
        }
    }
}