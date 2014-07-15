using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

using FluentValidation;
using FluentValidation.Results;
using Moq;
using Xunit;

using ContactDemo.Model;
using ContactDemo.Services;
using ContactDemo.Tests.Web.Infrastructure;
using ContactDemo.Web.Controllers;

namespace ContactDemo.Tests.Web
{
    public class HomeControllerFacts
    {
        public class IndexMethod
        {
            [Fact]
            public void ReturnsView()
            {
                /* Arrange */
                var service = new Mock<IContactService>();
                var controller = new HomeController(service.Object);

                /* Act */
                var result = controller.Index() as ViewResult;

                /* Assert */
                Assert.NotNull(result);
                Assert.Equal(result.ViewName, "");
            }   
        }

        
        public class IndexPostMethod
        {
            [Fact]
            public void ReturnsCorrectUrlWhenVvalid()
            {
                /* Arrange */
                var contactService = new Mock<IContactService>();
                contactService.Setup(c => c.GetInTouch(It.IsAny<PostContact>())).Returns(It.IsAny<Contact>());

                var controller = new HomeController(contactService.Object);
                controller.ControllerContext = FakeControllerContext.New();
                controller.Url = ViewHelpers.GetUrlHelper();

                var contact = new PostContact
                {
                    Name = "Art Vandelay",
                    EmailAddress = "art@vandelayindustries.com"
                };

                var stream = new Mock<Stream>();
                stream.Setup(s => s.Length).Returns(972800); // 950 kB
                var file = new Mock<HttpPostedFileBase>();
                file.Setup(f => f.FileName).Returns("architects.pdf");
                file.Setup(f => f.InputStream).Returns(stream.Object);

                /* Act */
                var result = controller.PostIndex(contact, file.Object) as RedirectResult;

                /* Assert */
                Assert.NotNull(result);
                Assert.Equal(result.Url, "/");
                Assert.Equal(controller.ModelState.IsValid, true);
            }

            [Fact]
            public void ReturnsCorrectUrlWhenInvalid()
            {
                /* Arrange */
                var contactService = new Mock<IContactService>();
                var errors = new List<ValidationFailure>() { new ValidationFailure("Name", "") };
                contactService.Setup(c => c.GetInTouch(It.IsAny<PostContact>())).Throws(new ValidationException(errors));

                var controller = new HomeController(contactService.Object);
                controller.ControllerContext = FakeControllerContext.New();
                controller.Url = ViewHelpers.GetUrlHelper();

                var contact = new PostContact
                {
                    Name = "",
                    EmailAddress = "art@vandelayindustries.com"
                };

                var stream = new Mock<Stream>();
                stream.Setup(s => s.Length).Returns(972800); // 950 kB
                var file = new Mock<HttpPostedFileBase>();
                file.Setup(f => f.FileName).Returns("architects.pdf");
                file.Setup(f => f.InputStream).Returns(stream.Object);

                /* Act */
                var result = controller.PostIndex(contact, file.Object) as RedirectResult;

                /* Assert */
                Assert.NotNull(result);
                Assert.Equal(result.Url, "/");
            }
        }
    }
}