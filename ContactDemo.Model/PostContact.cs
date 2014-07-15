using System.IO;

namespace ContactDemo.Model
{
    /// <summary>
    /// Model for a new incoming contact request.
    /// </summary>
    public class PostContact
    {
        /// <summary>
        /// Gets or sets the name of the contact.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email address of the contact.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the name of the uploaded file.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the contents of the uploaded file.
        /// </summary>
        public Stream FileContents { get; set; }
    }
}