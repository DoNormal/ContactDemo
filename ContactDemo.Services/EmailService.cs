using System.Net.Mail;

namespace ContactDemo.Services
{
    /// <summary>
    /// Helper service for sending emails.
    /// </summary>
    public class EmailService : IEmailService
    {
        /// <summary>
        /// The email address all mails are coming from.
        /// </summary>
        protected readonly string FromEmailAddress;

        /// <summary>
        /// Initializes a new instance of the <c>EmailService</c> class.
        /// </summary>
        /// <param name="fromEmailAddress">The email address all mails are coming from.</param>
        public EmailService(string fromEmailAddress)
        {
            this.FromEmailAddress = fromEmailAddress;
        }

        /// <summary>
        /// Sends the specified mail message to the specified recipient.
        /// </summary>
        /// <param name="recipient">The receiver of the email.</param>
        /// <param name="subject">The subject of the mail.</param>
        /// <param name="body">The contents of the email.</param>
        public void SendEmail(string recipient, string subject, string body)
        {
            var message = new MailMessage();
            message.From = new MailAddress(this.FromEmailAddress);
            message.To.Add(new MailAddress(recipient));
            message.Subject = subject;
            message.Body = body;

            using (var client = new SmtpClient())
            {
                client.Send(message);
            }
        }
    }
}