using System.Web.Mvc;
using System.Web.Mvc.Html;

using FluentValidation.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ContactDemo.Web.MvcConfig), "Start")]
namespace ContactDemo.Web
{
    public class MvcConfig
    {
        public static void Start()
        {
            /* By default both the WebForms and Razor viewengines are loaded.
             * This affects the lookup performance by the viewhelpers (e.g. Html.DisplayFor).
             * To improve this performance, only load the one view engine. */
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add( new RazorViewEngine() );

            /* MVC uses this resouce to look up translations for model binding errors. 
             * See: ~/App_GlobalResources */
            DefaultModelBinder.ResourceClassKey = "ModelBinding";
            ValidationExtensions.ResourceClassKey = "ModelBinding";

            /* Remove this for FluentValidation */
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
        }        
    }
}