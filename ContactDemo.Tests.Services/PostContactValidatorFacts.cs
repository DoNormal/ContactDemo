using System.IO;

using FluentValidation.TestHelper;
using Moq;
using Xunit;

using ContactDemo.Services;

namespace ContactDemo.Tests.Services
{
    public class PostContactValidatorFacts
    {
        protected readonly PostContactValidator Validator;

        public PostContactValidatorFacts()
        {
            this.Validator = new PostContactValidator();
        }

        [Fact]
        public void ShouldBeInvalidWhenNameIsNull()
        {
            this.Validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
        }

        [Fact]
        public void ShouldBeOkWhenNameIsSpecified()
        {
            this.Validator.ShouldNotHaveValidationErrorFor(x => x.Name, "Art Vandelay");
        }

        [Fact]
        public void ShouldBeInvalidWhenEmailAddressIsNull()
        {
            this.Validator.ShouldHaveValidationErrorFor(x => x.EmailAddress, null as string);
        }

        [Fact]
        public void ShouldBeInvalidWhenEmailAddressIsInvalid()
        {
            this.Validator.ShouldHaveValidationErrorFor(x => x.EmailAddress, "art.vandelayindustries.com");
        }

        [Fact]
        public void ShouldBeOkWhenEmailAddressIsSpecified()
        {
            this.Validator.ShouldNotHaveValidationErrorFor(x => x.EmailAddress, "art@vandelayindustries.com");
        }

        [Fact]
        public void ShouldBeOkWhenFileIsMissing()
        {
            this.Validator.ShouldNotHaveValidationErrorFor(x => x.FileContents, Stream.Null);
        }

        [Fact]
        public void ShouldBeInvalidWhenFileIsTooBig()
        {
            var stream = new Mock<Stream>();
            stream.Setup(s => s.Length).Returns(2000000); // 1.90735 MB

            this.Validator.ShouldHaveValidationErrorFor(x => x.FileContents, stream.Object);
        }

        [Fact]
        public void ShouldBeOkWhenFileIsSmallEnough()
        {
            var stream = new Mock<Stream>();
            stream.Setup(s => s.Length).Returns(972800); // 950 kB

            this.Validator.ShouldNotHaveValidationErrorFor(x => x.FileContents, stream.Object);
        }
    }
}