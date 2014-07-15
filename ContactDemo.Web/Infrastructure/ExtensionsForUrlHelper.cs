using System.Web.Mvc;

namespace ContactDemo.Web.Infrastructure
{
    /// <summary>
    /// Handy extensions for <c>UrlHelper</c>.
    /// </summary>
    /// <remarks>
    /// Used to prevent having strings with names of action methods and controller all over the place.
    /// </remarks>
    public static class ExtensionsForUrlHelper
    {
        /// <summary>
        /// Generates a url to the home page.
        /// </summary>
        /// <param name="urlHelper">The url helper to extend.</param>
        /// <returns>A string containing the url to the home page.</returns>
        public static string Home(this UrlHelper urlHelper)
        {
            return urlHelper.Action("index", "home");
        }
    }
}