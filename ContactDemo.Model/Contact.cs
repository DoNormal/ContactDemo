using System;

namespace ContactDemo.Model
{
    /// <summary>
    /// Model for a contact.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Gets or sets the identifier of the contact.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the contact.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email address of the contact.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the date when the contact was created.
        /// </summary>
        public DateTimeOffset WhenCreated { get; set; }
    }
}