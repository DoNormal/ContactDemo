using System;
using System.IO;

using FluentValidation;

using ContactDemo.Globalization;
using ContactDemo.Model;

namespace ContactDemo.Services
{
    /// <summary>
    /// Validates incoming contact requests.
    /// </summary>
    public class PostContactValidator : AbstractValidator<PostContact>
    {
        /// <summary>
        /// Initializes a new instance of the <c>PostContactValidator</c> class.
        /// </summary>
        public PostContactValidator()
        {
            /* Validate name. */
            this.RuleFor(x => x.Name)
                    .NotEmpty()
                    .WithMessage(ContactText.Validate_Name_Empty);

            /* Validate email address. */
            this.RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .WithMessage(ContactText.Validate_EmailAddress_Empty);
            /* FluentValidation has a built-in rule for validating email addresses, but that uses
             * a regex that's far too complicated, and even contains errors. The best validation for email
             * addresses is simply sending an email. Therefore, just check for the basic syntax of an email address:
             * must containt @, some text before and after @, and a dot after @. */
            this.RuleFor(x => x.EmailAddress)
               .Matches(@"^.+@.+\..+$")
               .When(x => !String.IsNullOrWhiteSpace(x.EmailAddress))
               .WithMessage(ContactText.Validate_EmailAddress_Invalid);

            /* Validate uploaded file. */
            this.RuleFor(x => x.FileContents)
                .Must(this.HaveAValidSize)
                .When(x => x.FileContents != null)
                .WithMessage(ContactText.Validate_FileContents_TooBig);

            // TODO Validate presence of file name.
        }

        /// <summary>
        /// Helper predicate for determining if a stream has a valid byte size.
        /// </summary>
        /// <param name="fileContents">The stream to check.</param>
        /// <returns>True if the stream has a valid size; otherwise false.</returns>
        protected bool HaveAValidSize(Stream fileContents)
        {
            long bytes = fileContents.Length;
            /* Stream must not be bigger than 1 MB. */
            return bytes / 1048576 < 1;
        }
    }
}