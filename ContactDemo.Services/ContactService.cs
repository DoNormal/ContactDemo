using System;
using System.IO;
using System.Linq;

using FluentValidation;

using ContactDemo.Data;
using ContactDemo.Globalization;
using ContactDemo.Model;

namespace ContactDemo.Services
{
    /// <summary>
    /// Service for interacting with the contact model.
    /// </summary>
    public class ContactService : IContactService
    {
        /// <summary>
        /// Services that sends emails.
        /// </summary>
        protected readonly IEmailService EmailService;

        /// <summary>
        /// Service for storing files.
        /// </summary>
        protected readonly IStorageService StorageService;

        /// <summary>
        /// Access to the data layer.
        /// </summary>
        protected readonly DataContext Data;

        /// <summary>
        /// Validation for incoming contact objects.
        /// </summary>
        protected readonly IValidator<PostContact> PostContactValidator;

        /// <summary>
        /// Initializes a new instance of the <c>ContactService</c> class with the specified dependencies.
        /// </summary>
        /// <param name="emailService">Services that sends emails.</param>
        /// <param name="storageService">Services for storing files.</param>
        /// <param name="data">Access to the data layer.</param>
        /// <param name="postContactValidator">Validation for incoming contact objects.</param>
        public ContactService(
            IEmailService emailService, 
            IStorageService storageService,
            DataContext data, 
            IValidator<PostContact> postContactValidator)
        {
            this.EmailService = emailService;
            this.StorageService = storageService;
            this.Data = data;
            this.PostContactValidator = postContactValidator;
        }

        /// <summary>
        /// Processes an incoming contact request by storing the data, sending
        /// a registration email and storing the upload file.
        /// </summary>
        /// <param name="item">The incoming contact request.</param>
        /// <returns>A new instance of the stored contact.</returns>
        public Contact GetInTouch(PostContact item)
        {
            /* Check if the incoming item is valid before processing. */
            if (item == null)
                throw new ArgumentNullException();
            this.PostContactValidator.ValidateAndThrow(item);

            /* Make sure the contact exist in the data store. */
            var contact = this.Data.Contacts.FirstOrDefault(c => c.EmailAddress == item.EmailAddress);
            if (contact == null)
            {
                contact = this.Create(item); 
            }

            /* The contact exists at this point. Mail him and store his file. */
            this.SendRegistrationEmail(contact.EmailAddress);
            this.StoreFile(item.FileName, item.FileContents);

            return contact;
        }

        /// <summary>
        /// Stores the incoming contact request in the data store.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>A new instance of the stored contact.</returns>
        protected Contact Create(PostContact item)
        {
            var contact = new Contact
            {
                Name = item.Name,
                EmailAddress = item.EmailAddress,
                WhenCreated = DateTimeOffset.UtcNow
            };
            this.Data.Contacts.Add(contact);
            this.Data.SaveChanges();

            return contact;
        }

        /// <summary>
        /// Helper method for sending the registration email.
        /// </summary>
        /// <param name="emailAddress">The email address to send the message to.</param>
        protected void SendRegistrationEmail(string emailAddress)
        {
            string subject = ContactText.Email_Subject;
            string body = ContactText.Email_Body;
            this.EmailService.SendEmail(emailAddress, subject, body);
        }

        /// <summary>
        /// Helper method for storing the file.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <param name="fileContents">The contents of the file.</param>
        protected void StoreFile(string fileName, Stream fileContents)
        {
            /* The file is allowed to be null. */
            if (String.IsNullOrWhiteSpace(fileName) || fileContents == null)
                return;

            // TODO Check for existing file names.
            this.StorageService.Save(fileName, fileContents);
        }
    }
}