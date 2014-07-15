using System.Web;
using System.Web.Mvc;

using FluentValidation;

using ContactDemo.Model;
using ContactDemo.Services;
using ContactDemo.Web.Infrastructure;

namespace ContactDemo.Web.Controllers
{
    /// <summary>
    /// Handles requests for the home page.
    /// </summary>
    public class HomeController : BaseController
    {
        /// <summary>
        /// Service for interacting with the contact model.
        /// </summary>
        protected readonly IContactService ContactService;

        /// <summary>
        /// Initializes a new instance of the <c>HomeController</c> class.
        /// </summary>
        /// <param name="contactService">The services for interacting with the contact model.</param>
        public HomeController(IContactService contactService)
        {
            this.ContactService = contactService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Handles the posted contact form by sending it to the contact service.
        /// </summary>
        /// <param name="item">The posted contact details.</param>
        /// <param name="attachment">The posted file.</param>
        /// <returns>
        /// A redirect to the home page if the request was processed successfull; otherwise, a redirect
        /// to the same page with the errors in the model state.
        /// </returns>
        [ActionName("Index"), HttpPost, ValidateAntiForgeryToken]
        public ActionResult PostIndex(PostContact item, HttpPostedFileBase attachment)
        {
            try
            {
                /* The file upload isn't required: check to prevent for null pointers. */
                if (attachment != null)
                {
                    item.FileName = attachment.FileName;
                    item.FileContents = attachment.InputStream;
                }
                this.ContactService.GetInTouch(item);

                return RedirectSuccess(Url.Home(), "Done");
            }
            catch (ValidationException ex)
            {
                return RedirectError(Url.Home(), ex.Errors);
            }
        }
    }
}