namespace ContactDemo.Services
{
    /// <summary>
    /// Defines a contract for services that send email.
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Deliver the specified email to the specified recipient.
        /// </summary>
        /// <param name="recipient">The receiver of the email</param>
        /// <param name="subject">The subject of the email.</param>
        /// <param name="body">The contents of the email.</param>
        void SendEmail(string recipient, string subject, string body);
    }
}