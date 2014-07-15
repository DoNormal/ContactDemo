using System;
using System.Configuration;
using System.Web.Hosting;

using Ninject.Activation;

namespace ContactDemo.Services.Dependencies
{
    /// <summary>
    /// Provides implementations of <c>IStorageService</c> for loading into the kernel.
    /// </summary>
    public class DiskStorageServiceProvider : Provider<IStorageService>
    {
        /// <summary>
        /// Creates the required storage service.
        /// </summary>
        /// <param name="context">The binding context.</param>
        /// <returns>An instantiated implementation of <c>IStorageService</c>.</returns>
        protected override IStorageService CreateInstance(IContext context)
        {
            string uploadDirectory = ConfigurationManager.AppSettings["ContactDemo:Storage:UploadDirectory"];
            if (String.IsNullOrWhiteSpace(uploadDirectory))
                throw new ConfigurationErrorsException("No upload directory configured.");

            // TODO Check if the path is valid.
            return new DiskStorageService(HostingEnvironment.MapPath(uploadDirectory));
        }
    }
}