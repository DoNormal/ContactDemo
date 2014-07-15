using System;
using System.Configuration;

using Ninject.Activation;

namespace ContactDemo.Services.Dependencies
{
    /// <summary>
    /// Provides implementations of <c>IEmailService</c> for loading into the kernel.
    /// </summary>
    public class EmailServiceProvider : Provider<IEmailService>
    {
        /// <summary>
        /// Creates the required email service.
        /// </summary>
        /// <param name="context">The binding context.</param>
        /// <returns>An instantiated implementation of <c>IEmailService</c>.</returns>
        protected override IEmailService CreateInstance(IContext context)
        {
            string fromEmailAddress = ConfigurationManager.AppSettings["ContactDemo:Mail:FromAddress"];
            if (String.IsNullOrWhiteSpace(fromEmailAddress))
                throw new ConfigurationErrorsException("No from email address configured.");

            return new EmailService(fromEmailAddress: fromEmailAddress);
        }
    }
}